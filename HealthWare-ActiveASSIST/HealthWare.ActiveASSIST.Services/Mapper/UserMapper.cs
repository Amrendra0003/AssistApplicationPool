using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities.UserManagement;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Security;
using ContactDetails = Healthware.Core.Entities.ContactDetails;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IUserMapper
    {
        User MapFrom(User user, UpdateProfileDetail updateProfileDetail);
        User MapFrom(User user, PatientBasicInfo patientBasicProfileInfo);
        ContactDetails MapFrom(ContactDetails contactDetails, UpdateProfileDetail updateProfileDetail);
        User MapFromUser(User user, UpdateUserDetails updateUserDetails);
    }
    public class UserMapper : IUserMapper
    {
        public User MapFrom(User user, UpdateProfileDetail updateProfileDetail)
        {
            user.FirstName = updateProfileDetail.FirstName;
            user.LastName = updateProfileDetail.LastName;
            user.MiddleName = updateProfileDetail.MiddleName;
            user.DateOfBirth = updateProfileDetail.DateOfBirth.ConvertStringToDate();
            user.Gender = updateProfileDetail.Gender;
            user.EmailAddress = updateProfileDetail.Email;
            user.Cell = updateProfileDetail.Cell;
            user.CountyCode = updateProfileDetail.CountyCode;
            if (user.ContactDetails.IsNull())
            {
                user.ContactDetails = new ContactDetails()
                {
                    Email = updateProfileDetail.Email,
                    Cell = updateProfileDetail.MailingAddressCell,
                    CountyCode = updateProfileDetail.MailingAddressCountyCode,
                    StreetAddress = updateProfileDetail.StreetAddress,
                    Suite = updateProfileDetail.Suite,
                    City = updateProfileDetail.City,
                    State = updateProfileDetail.State,
                    Zip = updateProfileDetail.ZipCode,
                    County = updateProfileDetail.County,
                    ContactTypeDetails = new ContactTypeMaster()
                    {
                        Id = 9,
                        EntityType = Repositories.Constants.UserProfile,
                        ContactType = Repositories.Constants.Home
                    }
                };
                user.ContactDetails.Name = $"{updateProfileDetail.FirstName} {updateProfileDetail.LastName} {updateProfileDetail.LastName}";
                if (updateProfileDetail.MiddleName.IsNull())
                    user.ContactDetails.Name = $"{updateProfileDetail.FirstName} {updateProfileDetail.LastName}";

            }
            return user;
        }

        public User MapFrom(User user, PatientBasicInfo patientBasicProfileInfo)
        {

            user.FirstName = patientBasicProfileInfo.FirstName;
            user.LastName = patientBasicProfileInfo.LastName;
            user.DateOfBirth = patientBasicProfileInfo.DateOfBirth.ConvertStringToDate();
            user.Gender = patientBasicProfileInfo.Gender;
            user.MaritalStatus = patientBasicProfileInfo.MaritalStatus;
            user.EmailAddress = patientBasicProfileInfo.EmailAddress;
            user.CountyCode = patientBasicProfileInfo.CountyCode;
            user.ContactDetails = new ContactDetails()
            {
                CountyCode = patientBasicProfileInfo.CountyCode,
                Email = patientBasicProfileInfo.EmailAddress,
                Cell = patientBasicProfileInfo.CellNumber,
                ContactTypeDetails = new ContactTypeMaster()
                {
                    Id = 9,
                    EntityType = Repositories.Constants.UserProfile,
                    ContactType = Repositories.Constants.Home
                }
            };
            user.ContactDetails.Name = $"{patientBasicProfileInfo.FirstName} {patientBasicProfileInfo.LastName} {patientBasicProfileInfo.LastName}";
            if (patientBasicProfileInfo.MiddleName.IsNull())
                user.ContactDetails.Name = $"{patientBasicProfileInfo.FirstName} {patientBasicProfileInfo.LastName}";
            user.Cell = patientBasicProfileInfo.CellNumber;
            user.Password = patientBasicProfileInfo.Password;
            user.IsActive = true;

            return user;
        }

        public ContactDetails MapFrom(ContactDetails contactDetails, UpdateProfileDetail updateProfileDetail)
        {
            contactDetails.Name = $"{updateProfileDetail.FirstName} {updateProfileDetail.LastName} {updateProfileDetail.LastName}";
            if (updateProfileDetail.MiddleName.IsNull())
                contactDetails.Name = $"{updateProfileDetail.FirstName} {updateProfileDetail.LastName}";
            contactDetails.Email = updateProfileDetail.Email;
            contactDetails.Cell = updateProfileDetail.MailingAddressCell;
            contactDetails.CountyCode = updateProfileDetail.MailingAddressCountyCode;
            contactDetails.StreetAddress = updateProfileDetail.StreetAddress;
            contactDetails.Suite = updateProfileDetail.Suite;
            contactDetails.City = updateProfileDetail.City;
            contactDetails.State = updateProfileDetail.State;
            contactDetails.Zip = updateProfileDetail.ZipCode;
            contactDetails.County = updateProfileDetail.County;
            contactDetails.ContactTypeDetails = new ContactTypeMaster()
            {
                Id = 9,
                EntityType = Repositories.Constants.UserProfile,
                ContactType = Repositories.Constants.Home
            };
            return contactDetails;
        }

        public User MapFromUser(User user, UpdateUserDetails updateUserDetails)
        {
            user.FirstName = updateUserDetails.FirstName;
            user.MiddleName = updateUserDetails.MiddleName;
            user.LastName = updateUserDetails.LastName;
            user.DateOfBirth = updateUserDetails.DateOfBirth.ConvertStringToDate();
            user.Gender = updateUserDetails.Gender;
            user.MaritalStatus = updateUserDetails.MaritalStatus;
            user.Cell = updateUserDetails.CellNumber;
            user.CountyCode = updateUserDetails.CountyCode;
            user.EmailAddress = updateUserDetails.EmailAddress;
            user.Password = PasswordEncryptionDecryption.HashPassword(updateUserDetails.Password);
            user.IsActive = true;
            user.ContactDetails.Email = updateUserDetails.EmailAddress;

            return user;
        }
    }
}
