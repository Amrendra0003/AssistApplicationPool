using Healthware.Core.Configurations;
using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Repository;
using Healthware.Core.Security;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities.UserManagement;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using HealthWare.ActiveASSIST.Web.Common.HttpClient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;
using ContactDetails = Healthware.Core.Entities.ContactDetails;
using Patient = HealthWare.ActiveASSIST.Entities.Patient;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IUserManagementService
    {
        Task<Result<PersonalDetail>> GetProfileDetails(long userId);
        Task<Result<MessageDto>> UpdateProfileDetails(UpdateProfileDetail updateProfileDetail);
        Task<Result<MessageDto>> CreateUserProfile(PatientBasicInfo patientBasicProfileInfo);
        Task<Result<AddressVerificationResponse>> VerifyAddressDetails(AddressVerificationRequest addressDetails);
        Task<Result<List<string>>> GetPermissionsForUser(long roleId);
        Task<long> CreateUser(User user);
        Task<bool> CheckIfUserExists(string emailAddress);
        Task<bool> CheckIfPatientExists(string emailAddress);
        Task<Result<LandingScreenResponse>> ValidateUserAccount(string token);
        Task<long> CreatePatient(HealthWare.ActiveASSIST.Entities.Patient patient);
        List<Entities.Patient> ValidateCsv(List<PatientEntity> patients);
    }
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserManagementMapper _userManagementMapper;
        private readonly IUserMapper _userMapper;
        private readonly IUserHasRolesRepository _rolesRepository;
        private readonly IRolesPermissionsRepository _rolesPermissionRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IHealthWareSharedService _healthWareSharedService;
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        private readonly ITenantDataRepository _tenantDataRepository;
        private readonly IPatientRepository _patientRepository;
        private HttpContext _httpContext;
        
        public UserManagementService(IUserRepository userRepository, IUserManagementMapper userManagementMapper,
            IContactDetailsRepository<PatientDbContext> addressRepository, IUserMapper userMapper, IUserHasRolesRepository rolesRepository,
            IAssessmentRepository assessmentRepository, IHealthWareSharedService healthWareSharedService, IContactDetailsRepository<PatientDbContext> contactDetailsRepository,
            IRolesPermissionsRepository rolesPermissionRepository, IHttpContextAccessor contextAccessor, ITenantDataRepository tenantDataRepository, IPatientRepository patientRepository)
        {
            _userRepository = userRepository;
            _userManagementMapper = userManagementMapper;
            _userMapper = userMapper;
            _rolesRepository = rolesRepository;
            _assessmentRepository = assessmentRepository;
            _healthWareSharedService = healthWareSharedService;
            _contactDetailsRepository = contactDetailsRepository;
            _rolesPermissionRepository = rolesPermissionRepository;
            _tenantDataRepository = tenantDataRepository;
            _patientRepository = patientRepository;
            _httpContext = contextAccessor.HttpContext;
        }

        public async Task<Result<MessageDto>> CreateUserProfile(PatientBasicInfo patientBasicProfileInfo)
        {
            var userInfo = await _userRepository.GetUserByEmailAddress(patientBasicProfileInfo.EmailAddress);

            if (userInfo.IsNotNull())
                return new Result<MessageDto>().AddError(Error.UserExists);

            patientBasicProfileInfo.Password =
                PasswordEncryptionDecryption.HashPassword(patientBasicProfileInfo.Password);
            var userDetail = _userMapper.MapFrom(new User(), patientBasicProfileInfo);

            var userId = await _userRepository.CreateUser(userDetail);

            if (userId > 0)
            {
                var userRoleId = await _rolesRepository.CreateUserRole(new UserHasRoles { User = new User { Id = userId }, Role = new Role { Id = Entities.Master.Roles.Patient.Id } });

                if (userRoleId > 0)
                    return new Result<MessageDto>
                    { Data = new MessageDto().AddMessage(Application.UserCreationSuccess) };
            }
            else
                return new Result<MessageDto>().AddError(Error.UserCreationFailed);

            return new Result<MessageDto>
            { Data = new MessageDto().AddMessage(Application.UserCreationSuccess) };
        }


        public async Task<Result<PersonalDetail>> GetProfileDetails(long userId)
        {
            var user = await _userRepository.GetUserById(userId);
            var dynamicUser = await _userRepository.GetUserById(Constants.AdminUserId);
            var assessments =
                _assessmentRepository.GetAssessmentsByUserId(userId, string.Empty);

            var personalDetail = _userManagementMapper.MapFrom(user);
            personalDetail.IsDynamic = dynamicUser.IsActive ? Constants.True : Constants.False.ToCamelCase();
            if (assessments.IsNotNull())
            {
                personalDetail.AssessmentCount = assessments.Count().ToString();
            }
            return new Result<PersonalDetail> { Data = personalDetail };
        }

        public async Task<Result<MessageDto>> UpdateProfileDetails(UpdateProfileDetail updateProfileDetail)
        {
            var user = await _userRepository.GetUserById(updateProfileDetail.UserId);
            if (user.IsNull())
            {
                return new Result<MessageDto>().AddError(Error.UserNotFound);
            }
            
            if (user.ContactDetails.IsNotNull() && !user.ContactDetails.Id.Equals(0))
            {
                var contactDetails = await _contactDetailsRepository.GetContactDetailsById(user.ContactDetails.Id);
                var updatedContactDetails = _userMapper.MapFrom(contactDetails, updateProfileDetail);
                var isContactDetailsUpdated = await _contactDetailsRepository.UpdateContactDetails(updatedContactDetails);
                if (!isContactDetailsUpdated) return new Result<MessageDto>().AddError(Error.UpdateContactDetailsFailed);
                user.ContactDetails = updatedContactDetails;
            }
            var updatedUser = _userMapper.MapFrom(user, updateProfileDetail);
            var isUserUpdated = await _userRepository.Update(updatedUser);

            var dynamicUser = await _userRepository.GetUserById(Constants.AdminUserId);
            dynamicUser.IsActive = updateProfileDetail.IsDynamic.Equals(Constants.True) ? true : false;
            _ = await _userRepository.Update(dynamicUser);

            if (!isUserUpdated) return new Result<MessageDto>().AddError(Error.UpdateUserFailed);
            return new Result<MessageDto> { Data = new MessageDto().AddMessage(Constants.BasicInfoUpdatedSuccessfully) };
        }
        public async Task<Result<AddressVerificationResponse>> VerifyAddressDetails(AddressVerificationRequest addressDetails)
        {
            //if (PropertyValues.IsServiceMockEnabled())
            //    return VerifiedMockAddress();

            var verifiedAddress = await _healthWareSharedService.VerifyAddress(addressDetails);

            return new Result<AddressVerificationResponse> { Data = verifiedAddress };
        }

        public async Task<Result<List<string>>> GetPermissionsForUser(long roleId)
        {
            var userPermissions = await _rolesPermissionRepository.GetRolesPermissionByRoleId(roleId);
            var permissionsForUser = userPermissions.Select(s => s.Permission.Name).Distinct();

            return new Result<List<string>> { Data = permissionsForUser.ToList() };
        }

        public async Task<long> CreateUser(User user)
        {
            user.ContactDetails = new ContactDetails()
            {
                Email = user.EmailAddress,
                Cell = user.Cell,
                CountyCode = user.CountyCode,
                Name = $"{user.FirstName} {user.LastName}",
                ContactTypeDetails = new ContactTypeMaster()
                {
                    Id = 9
                }
            };
            user.SecondaryEmailContactDetails = new ContactDetails()
            {
                Email = user.EmailAddress,
                Name = $"{user.FirstName} {user.LastName}",
                ContactTypeDetails = new ContactTypeMaster()
                {
                    Id = 10
                }
            };
            return await _userRepository.CreateUser(user);
        }

        public async Task<bool> CheckIfUserExists(string emailAddress)
        {
            
            return await _userRepository.IsUserExistsForPrimaryAndSecondaryEmail(emailAddress);
        }

        public async Task<bool> CheckIfPatientExists(string emailAddress)
        {
            var isPatientExists = await _userRepository.IsPatientExists(emailAddress);
            return isPatientExists;
        }

        public async Task<Result<LandingScreenResponse>> ValidateUserAccount(string token)
        {
            _httpContext.Request.Headers.TryGetValue("tenant", out var userTenantId);
            if(userTenantId.IsNullOrEmpty()) return new Result<LandingScreenResponse>().AddError(DTOs.Constants.InValidRequest);

            var tenantDetails = await _tenantDataRepository.GetTenantDetails(Convert.ToInt64(userTenantId));
            var publicKey = tenantDetails.PublicKey;
            var userKey = tenantDetails.UserKey;
            byte[] iv = Encoding.UTF8.GetBytes(userKey);

            var decodedToken = token.Replace('*', '+');
            byte[] buffer = Convert.FromBase64String(decodedToken);

            var landingOption = "";
            var email = "";
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(publicKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            var plainText = streamReader.ReadToEnd();
                            string[] strArray = plainText.Split('|');
                            var userId = strArray[0];
                            var password = strArray[1];
                            var userType = strArray[2];
                            var facilityCode = strArray[3];
                            var expiration = strArray[4];
                            var expirationDateTime = DateTime.ParseExact(expiration, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

                            if(DateTime.UtcNow > expirationDateTime) return new Result<LandingScreenResponse>().AddError(DTOs.Constants.LinkExpired);
                            var user = await _userRepository.GetUserByEmailAddress(userId);
                            if (user.IsNull() && userType.Equals("P") && facilityCode.IsNotNullOrEmpty())
                            {
                                landingOption = "P1";
                                var tenantDetail = await _tenantDataRepository.GetTenantByCode(facilityCode);
                                if (tenantDetail.IsNotNull())
                                {
                                    email = tenantDetail.EmailAddress;
                                }
                                return new Result<LandingScreenResponse> { Data = new LandingScreenResponse { LandingId = landingOption, Email = email } };
                            }
                            if (userId.IsNotNullOrEmpty() && userType.Equals("P") && user.IsActive && facilityCode.IsNotNullOrEmpty()) landingOption = "P3";
                            if (userId.IsNotNullOrEmpty() && userType.Equals("P") && !user.IsActive &&
                                facilityCode.IsNotNullOrEmpty())
                            {
                                landingOption = "P2";
                                email = userId;
                            }
                        }
                    }
                }
            }
            return new Result<LandingScreenResponse> { Data = new LandingScreenResponse{LandingId = landingOption, Email = email} };
        }

        public async Task<long> CreatePatient(HealthWare.ActiveASSIST.Entities.Patient patient)
        {
            var patientId = await _patientRepository.CreatePatient(patient);
            return patientId;
        }

        public List<Patient> ValidateCsv(List<PatientEntity> patients)
        {
            var patient = new List<Patient>();
            foreach (var item in patients)
            {
               bool isFirstNameValid = Regex.IsMatch(item.FirstName, @"^[a-zA-Z ]*$");
               bool isLastNameValid = Regex.IsMatch(item.LastName, @"^[a-zA-Z ]*$");
               bool isCountyCodeValid = Regex.IsMatch(item.CountyCode, @"^\d{1,2}$");
               bool isCellValid = Regex.IsMatch(item.Cell, @"^[0-9]{10}$");
               bool isEmailAddressValid = Regex.IsMatch(item.EmailAddress, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");
               bool isDateOfServiceValid = Regex.IsMatch(item.DateOfService, @"^[0-9]{14}$");
               if (isFirstNameValid && isLastNameValid && isCountyCodeValid && isCellValid && isEmailAddressValid && isDateOfServiceValid)
               {
                   var newPatient1 = new Patient();
                   newPatient1 = item;
                    if (isDateOfServiceValid)
                   {
                       try
                       {
                           var expirationDateTime = DateTime.ParseExact(item.DateOfService, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                           newPatient1.DateOfService = expirationDateTime;
                       }
                       catch (FormatException e)
                       {
                           Console.WriteLine(e);
                           newPatient1.DateOfService = null;
                       }
                   }
                   else
                   {
                       newPatient1.DateOfService = null;
                   }
                  
                   patient.Add(newPatient1);
               }
            }

            return patient;
        }

        private static Result<AddressVerificationResponse> VerifiedMockAddress()
        {
            var addressData = new AddressVerificationResponse();

            var cassResult = new CASSResult
            {
                ObjectId = 1,
                RequestNumber = 1,
                Address1 = Constants.AddressLine1,
                Address2 = string.Empty,
                City = Constants.MockCity,
                County = Constants.MockCounty,
                State = Constants.MockState,
                Zip = Constants.MockZip,
                ZipPlus4 = Constants.MockZipPlus4,
                VerificationDPVFootNotes = Constants.VerificationDpvFootNotes,
                VerificationStatusCode = Constants.VerificationStatusCode,
                Status = new Status { Type = 0 },
                HasError = false,
                HasWarning = false,
                Message = null
            };
            addressData.CassResult = cassResult;
            return new Result<AddressVerificationResponse>
            {
                Data = addressData
            };
        }
    }
}
