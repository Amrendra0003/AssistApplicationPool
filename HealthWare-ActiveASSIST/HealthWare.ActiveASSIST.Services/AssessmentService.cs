using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.Master;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using HealthWare.ActiveASSIST.Web.Common.HttpClient;
using Healthware.Core.Configurations;
using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Enumerators;
using Healthware.Core.Extensions;
using Healthware.Core.Repository;
using Healthware.Core.Security;
using Newtonsoft.Json;
using RestSharp;
using ContactDetails = Healthware.Core.Entities.ContactDetails;
using CreateContactPreference = HealthWare.ActiveASSIST.DTOs.CreateContactPreference;
using Document = HealthWare.ActiveASSIST.DTOs.HealthWareServices.Document;
using Program = HealthWare.ActiveASSIST.Entities.Program;
using StringExtensions = Healthware.Core.Extensions.StringExtensions;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IAssessmentService
    {
        Task<Result<PatientBasicInfo>> GetBasicInfoById(BasePatientAssessment basePatientAssessment);
        Task<Result<MessageDto>> UpdatePersonalDetail(PatientPersonalDetail patientPersonalDetail);
        Task<Result<ContactDetails>> GetContactDetails(GetContactDetails contactDetailsDto);
        Task<Result<MessageDto>> InsertContactDetails(ContactDetailsInfo contactDetailsDto);
        Task<Result<MessageDto>> UpdateContactDetails(UpdateContactDetails updateContactDetailsRequest);
        Task<Result<GetGuarantorResponse>> GetGuarantor(long assessmentId);
        Task<Result<long>> CreateGuarantor(CreateGuarantorRequest createGuarantorRequest);
        Task<Result<MessageDto>> UpdateGuarantor(UpdateGuarantorRequest updateGuarantorRequest);
        Task<Result<MessageDto>> UpdateReviewProgramStatus(List<UpdateReviewProgramRequest> updateReviewProgramRequest);
        Task<Result<ReviewProgramResponse>> GetActiveReviewPrograms(BasePatientAssessment patientAssessment);
        Task<Result<ReviewProgramResponse>> GetAllReviewPrograms(BasePatientAssessment patientAssessment);
        Task<Result<ReviewProgramResponse>> GetNotEvaluatedActiveReviewPrograms(BasePatientAssessment patientAssessment);
        Task<Result<EFormResponse>> GetEFormData(BasePatientAssessment patientAssessment);
        Task<Result<PreferedCell>> GetPreferredCell(BasePatientAssessment patientAssessment);
        Task<Result<PreferredAddressDropdown>> GetPreferredContactDetails(BasePatientAssessment patientAssessment);
        Task<Result<MessageDto>> DeleteContactDetails(DeleteContactDetailsRequest deleteContactDetailsRequest);
        Task<Result<PreferedEmail>> GetPreferredEmail(BasePatientAssessment patientAssessment);
        Task<Result<MessageDto>> CreateContactPreference(CreateContactPreference createContactPreferenceRequest);
        Task<Result<GetContactPreferenceDto>> GetContactPreference(BasePatientAssessment patientAssessment);
        Task<Result<MessageDto>> UpdateContactPreference(UpdateContactPreference updateContactPreferenceRequest);
        Task<Result<MessageDto>> UpdateAssessmentStatus(UpdateAssessmentStatus assessmentStatus);
        Task<Result<MessageDto>> DeleteAssessment(long assessmentId);
        Task<Result<MessageDto>> CreatePatientProgramMapping(ProgramMappingRequest patientProgramMapping);
        Task<Result<MessageDto>> CreateProgramMapping(ProgramMappingRequest patientProgramMapping);
        Task<Result<MessageDto>> AddReviewNotes(ReviewNotesRequest reviewNotesRequest);
        Task<Result<List<ReviewNotesResponse>>> GetReviewNotes(BasePatientAssessment basePatientAssessment);
        Task<Result<Dictionary<string, string>>> GetPrograms(GetProgramsRequest getProgramsRequest);
        Task<Result<PatientProgramResponse>> GetPatientProgram(int assessmentId);
        Task<Result<TabStatusResponse>> GetTabCompletionStatus(TabStatusRequest tabStatusRequest);
        Task UpdateTabStatus(long assessmentId, string tabName, bool isValid);
        Task<Result<AssessmentEvaluationResponse>> EvaluateAssessment(BasePatientAssessment basePatientAssessment);
        Task<Result<ReviewProgramResponse>> GetEvaluatedPrograms(BasePatientAssessment patientAssessment);
    }

    public class AssessmentService : IAssessmentService
    {
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        private readonly IGuarantorRepository _guarantorRepository;
        private readonly IAssessmentMapper _assessmentMapper;
        private readonly IContactDetailsMapper _contactDetailsMapper;
        private readonly IGuarantorMapper _guarantorMapper;
        private readonly IUserRepository _userRepository;
        private readonly IBasicInfoRepository _basicInfoRepository;

        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentVerificationRepository _assessmentVerificationRepository;
        private readonly IContactPreferenceRepository _contactPreferenceRepository;
        private readonly IContactPreferenceMapper _contactPreferenceMapper;
        private readonly IPatientProgramMappingRepository _patientProgramMappingRepository;
        private readonly IPatientProgramMappingMapper _patientProgramMappingMapper;
        private readonly IProgramRepository _programRepository;
        private readonly IHouseHoldMapper _houseHoldMapper;
        private readonly IDocumentProgramMappingRepository _documentProgramMappingRepository;

        private readonly IReviewNotesMapper _reviewNotesMapper;
        private readonly IReviewNotesRepository _reviewNotesRepository;
        private readonly IHttpClientService _httpClientService;
        private readonly IDocumentRepository _documentRepository;
        private readonly IHealthWareSharedService _healthWareSharedService;
        private readonly ITabStatusRepository _tabStatusRepository;
        private readonly IHouseHoldIncomeRepository _houseHoldIncomeRepository;
        private readonly IHouseHoldResourceRepository _houseHoldResourceRepository;
        private readonly IBasicInfoMapper _basicInfoMapper;
        private readonly ICurrentHttpContext _currentHttpContext;
        private readonly IAnswerRepository _answerRepository;
        private readonly IProgramMapper _programMapper;
        private readonly IProgramDocumentMapper _programDocumentMapper;
        private readonly IProgramDocumentRepository _programDocumentRepository;


        public AssessmentService(IAssessmentMapper assessmentMapper, IContactDetailsMapper contactDetailsMapper,
            IContactDetailsRepository<PatientDbContext> contactDetailsRepository,
            IGuarantorRepository guarantorRepository, IGuarantorMapper guarantorMapper, IUserRepository userRepository,
            IBasicInfoRepository basicInfoRepository,
            IHouseHoldMemberRepository houseHoldMemberRepository, IAssessmentRepository assessmentRepository,
            IAssessmentVerificationRepository assessmentVerificationRepository,
            IContactPreferenceRepository contactPreferenceRepository,
            IContactPreferenceMapper contactPreferenceMapper,
            IPatientProgramMappingRepository patientProgramMappingRepository,
            IPatientProgramMappingMapper patientProgramMappingMapper,
            IProgramRepository programRepository, IHouseHoldMapper houseHoldMapper,
            IReviewNotesMapper reviewNotesMapper, IReviewNotesRepository reviewNotesRepository,
            IHttpClientService httpClientService, IDocumentRepository documentRepository,
        IHealthWareSharedService healthWareSharedService, ITabStatusRepository tabStatusRepository,
            IHouseHoldIncomeRepository houseHoldIncomeRepository, IHouseHoldResourceRepository houseHoldResourceRepository, IBasicInfoMapper basicInfoMapper, ICurrentHttpContext currentHttpContext, IAnswerRepository answerRepository, IProgramMapper programMapper, IProgramDocumentMapper programDocumentMapper, IProgramDocumentRepository programDocumentRepository, IDocumentProgramMappingRepository documentProgramMappingRepository)
        {
            _assessmentMapper = assessmentMapper;
            _contactDetailsMapper = contactDetailsMapper;
            _contactDetailsRepository = contactDetailsRepository;
            _guarantorRepository = guarantorRepository;
            _guarantorMapper = guarantorMapper;
            _userRepository = userRepository;
            _basicInfoRepository = basicInfoRepository;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _assessmentRepository = assessmentRepository;
            _assessmentVerificationRepository = assessmentVerificationRepository;
            _contactPreferenceRepository = contactPreferenceRepository;
            _contactPreferenceMapper = contactPreferenceMapper;
            _patientProgramMappingRepository = patientProgramMappingRepository;
            _programRepository = programRepository;
            _patientProgramMappingMapper = patientProgramMappingMapper;
            _houseHoldMapper = houseHoldMapper;
            _reviewNotesMapper = reviewNotesMapper;
            _reviewNotesRepository = reviewNotesRepository;
            _httpClientService = httpClientService;
            _documentRepository = documentRepository;
            _healthWareSharedService = healthWareSharedService;
            _tabStatusRepository = tabStatusRepository;
            _houseHoldIncomeRepository = houseHoldIncomeRepository;
            _houseHoldResourceRepository = houseHoldResourceRepository;
            _basicInfoMapper = basicInfoMapper;
            _currentHttpContext = currentHttpContext;
            _answerRepository = answerRepository;
            _programMapper = programMapper;
            _programDocumentMapper = programDocumentMapper;
            _programDocumentRepository = programDocumentRepository;
            _documentProgramMappingRepository = documentProgramMappingRepository;
        }

        public async Task<Result<PatientBasicInfo>> GetBasicInfoById(BasePatientAssessment basePatientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(basePatientAssessment.PatientId);
            if (basicInfo.IsNull()) return new Result<PatientBasicInfo>().AddError(Error.PatientNotFound);

            var isPatientSelfGuarantor = await _guarantorRepository.IsPatientSelfGuarantor(basePatientAssessment.AssessmentId, Application.SelfRelation);
            var patientBasicInfo = _basicInfoMapper.MapFrom(basicInfo, isPatientSelfGuarantor);
            return new Result<PatientBasicInfo>()
            { Data = patientBasicInfo };
        }
        public async Task<Result<MessageDto>> UpdatePersonalDetail(PatientPersonalDetail patientPersonalDetail)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(patientPersonalDetail.Id);
            if (basicInfo.IsNull()) return new Result<MessageDto>().AddError(Error.PatientNotFound);

            //Update Assessment Verification to update status of Cell verification
            if (!basicInfo.CountyCode.Equals(patientPersonalDetail.CountyCode) ||
                !basicInfo.CellNumber.Equals(patientPersonalDetail.Cell) || !basicInfo.EmailAddress.Equals(patientPersonalDetail.EmailAddress))
            {
                var assessmentVerification =
                    await _assessmentVerificationRepository.GetVerification(patientPersonalDetail.AssessmentId);
                _ =
                    await _assessmentVerificationRepository.UpdateVerificationByCellNumberConfirmed(assessmentVerification, false);
                //Update Patient Basic Address Info
                var basicContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.BasicContactId);
                basicContactDetails.Name = patientPersonalDetail.FirstName + StringExtensions.Space + patientPersonalDetail.LastName;
                basicContactDetails.Cell = patientPersonalDetail.Cell;
                basicContactDetails.CountyCode = patientPersonalDetail.CountyCode;
                basicContactDetails.Email = patientPersonalDetail.EmailAddress;
                await _contactDetailsRepository.UpdateContactDetails(basicContactDetails);
            }
            var updatedPatient = _basicInfoMapper.MapFrom(basicInfo, patientPersonalDetail);
            var isBasicInfoUpdated = await _basicInfoRepository.UpdateBasicInfo(updatedPatient);
            if (!isBasicInfoUpdated) return new Result<MessageDto>().AddError(Application.UpdatePatientFailed);

            //Update Household member when there is record created under self relationship
            var householdMember = await _houseHoldMemberRepository.GetSelfHouseHoldMember(basicInfo.Assessment.Id);
            if (householdMember.IsNotNull())
            {
                var updatedHouseholdMember = _houseHoldMapper.MapFrom(householdMember, updatedPatient);
                var isSelfHouseholdMemberUpdated =
                    await _houseHoldMemberRepository.UpdateHouseHoldMember(updatedHouseholdMember);
                if (!isSelfHouseholdMemberUpdated) return new Result<MessageDto>().AddError(Error.UpdateHouseholdMemberFailed);
            }

            bool isGuarantorHomeComplete = false;
            bool isGuarantorWorkComplete = false;
            var tabStatus = await _tabStatusRepository.GetTabStatus(patientPersonalDetail.AssessmentId);
            bool isContactPreferenceComplete = tabStatus.IsContactPreferenceComplete.Value;
            //Update Guarantor when AreYouGuarantor is true
            if (patientPersonalDetail.IsGuarantor)
            {
                //When AreYouGuarantor is true, check whether already Guarantor exists, if exists replace those records with Personal data.
                //If Guarantor doesn't exists just create a new record with Personal data.
                var isGuarantorExists =
                    await _guarantorRepository.GetGuarantorByAssessmentId(patientPersonalDetail.AssessmentId);
                bool guarantorBasicInfoComplete;
                if (isGuarantorExists.IsNotNull())
                {
                    var guarantorSSN = isGuarantorExists.SSNNumber;
                    var guarantorRelation = isGuarantorExists.RelationShipWithPatient;
                    var guarantorFirstName = isGuarantorExists.FirstName;
                    var guarantorMiddleName = isGuarantorExists.MiddleName;
                    var guarantorLastName = isGuarantorExists.LastName;
                    var guarantorDateOfBirth = isGuarantorExists.DateOfBirth;

                    var updatedGuarantor = _guarantorMapper.MapFrom(isGuarantorExists, basicInfo);
                    var isGuarantorUpdated = await _guarantorRepository.UpdateGuarantor(updatedGuarantor);
                    guarantorBasicInfoComplete = true;
                    var basicGuarantorInfo = await _contactDetailsRepository.GetContactDetailsById(isGuarantorExists.BasicContactId);
                    basicGuarantorInfo.Name = patientPersonalDetail.FirstName + StringExtensions.Space + patientPersonalDetail.LastName;
                    basicGuarantorInfo.Cell = patientPersonalDetail.Cell;
                    basicGuarantorInfo.CountyCode = patientPersonalDetail.CountyCode;
                    basicGuarantorInfo.Email = basicInfo.EmailAddress;
                    await _contactDetailsRepository.UpdateContactDetails(basicGuarantorInfo);
                    if (!isGuarantorUpdated) return new Result<MessageDto>().AddError(Constants.CouldNotUpdateGuarantor);


                    //Check whether the guarantor data is mapped in contact preference
                    var contactPreference =
                        await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(patientPersonalDetail
                            .AssessmentId);

                    if (contactPreference.IsNotNull())
                    {
                        //Check whether Guarantor is Preferred Cell
                        var isPreferredCellGuarantorBasic = await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactPhoneId, CoreEnums.ContactType.GuarantorBasic);
                        if (isPreferredCellGuarantorBasic)
                        {
                            contactPreference.ContactPhoneId = -1;
                            isContactPreferenceComplete = false;
                        }

                        var isPreferredCellGuarantorHome = await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactPhoneId, CoreEnums.ContactType.GuarantorHome);
                        if (isPreferredCellGuarantorHome)
                        {
                            contactPreference.ContactPhoneId = -1;
                            isContactPreferenceComplete = false;
                        }

                        var isPreferredCellGuarantorWork =
                            await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactPhoneId, CoreEnums.ContactType.GuarantorWork);
                        if (isPreferredCellGuarantorWork)
                        {
                            contactPreference.ContactPhoneId = -1;
                            isContactPreferenceComplete = false;
                        }

                        //Check whether Guarantor is Preferred Email
                        var isPreferredEmailIsGuarantor = await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactEmailId, CoreEnums.ContactType.GuarantorBasic);
                        if (isPreferredEmailIsGuarantor)
                        {
                            contactPreference.ContactEmailId = -1;
                            isContactPreferenceComplete = false;
                        }

                        //Check whether Guarantor is Preferred Email
                        var isPreferredContactDetailsGuarantorHome = await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactAddressId, CoreEnums.ContactType.GuarantorHome);
                        if (isPreferredContactDetailsGuarantorHome)
                        {
                            contactPreference.ContactAddressId = -1;
                            isContactPreferenceComplete = false;
                        }

                        var isPreferredContactDetailsGuarantorWork =
                            await _contactDetailsRepository.IsPreferredCellIsGuarantor(contactPreference.ContactAddressId, CoreEnums.ContactType.GuarantorWork);
                        if (isPreferredContactDetailsGuarantorWork)
                        {
                            contactPreference.ContactAddressId = -1;
                            isContactPreferenceComplete = false;
                        }
                        _ = await _contactPreferenceRepository.UpdateContactPreference(contactPreference);
                    }

                    var guarantorHomeContactDetailsExists = await _contactDetailsRepository.GetContactDetailsById(isGuarantorExists.HomeContactId);
                    if (guarantorHomeContactDetailsExists.IsNotNull())
                    {
                        var patientHomeContactDetails1 = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                        var updatedGuarantorHomeContactDetails =
                             _contactDetailsMapper.MapFrom(guarantorHomeContactDetailsExists, patientHomeContactDetails1);
                        _ = await _contactDetailsRepository.UpdateContactDetails(updatedGuarantorHomeContactDetails);

                        if (updatedGuarantorHomeContactDetails.StreetAddress.IsNotNullOrEmpty() && updatedGuarantorHomeContactDetails.Zip.IsNotNullOrEmpty())
                        {
                            isGuarantorHomeComplete = true;
                        }
                    }
                    else
                    {
                        var patientHomeContactDetailsNew = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                        if (patientHomeContactDetailsNew.IsNotNull())
                        {
                            var guarantorHomeContactDetailsNew = _contactDetailsMapper.MapFrom(patientHomeContactDetailsNew);
                            guarantorHomeContactDetailsNew.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorHome };
                            isGuarantorExists.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetailsNew);

                            if (guarantorHomeContactDetailsNew.StreetAddress.IsNotNullOrEmpty() && guarantorHomeContactDetailsNew.Zip.IsNotNullOrEmpty())
                            {
                                isGuarantorHomeComplete = true;
                            }
                        }
                    }

                    var guarantorWorkContactDetailsExists = await _contactDetailsRepository.GetContactDetailsById(isGuarantorExists.WorkContactId);
                    if (guarantorWorkContactDetailsExists.IsNotNull())
                    {
                        var patientWorkContactDetails1 = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                        //If Personal work address is null and try to update the Guarantor Work Address with null
                        if (!patientWorkContactDetails1.IsNotNull())
                        {
                            updatedGuarantor.WorkContactId = Constants.ZeroAsNumber;
                            await _guarantorRepository.UpdateGuarantor(updatedGuarantor);
                            _ =
                                await _contactDetailsRepository.DeleteContactDetails(guarantorWorkContactDetailsExists);
                            isGuarantorWorkComplete = false;
                        }
                        else
                        {
                            var updatedGuarantorWorkContactDetails =
                                 _contactDetailsMapper.MapFrom(guarantorWorkContactDetailsExists, patientWorkContactDetails1);
                            _ = await _contactDetailsRepository.UpdateContactDetails(updatedGuarantorWorkContactDetails);
                            isGuarantorWorkComplete = true;
                        }
                    }
                    else
                    {
                        var patientWorkContactDetailsNew = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                        if (patientWorkContactDetailsNew.IsNotNull())
                        {
                            var guarantorWorkContactDetails = _contactDetailsMapper.MapFrom(patientWorkContactDetailsNew);
                            guarantorWorkContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorWork };
                            isGuarantorExists.WorkContactId = await _contactDetailsRepository.CreateContactDetail(guarantorWorkContactDetails);
                            isGuarantorWorkComplete = true;
                        }
                    }

                    await _guarantorRepository.UpdateGuarantor(isGuarantorExists);
                    //Remove guarantor record from Household if exists, because now self record created in Guarantor.
                    var guarantorHousehold = await _houseHoldMemberRepository.GetHouseholdBySSN(patientPersonalDetail.AssessmentId, guarantorSSN, guarantorRelation, guarantorFirstName, guarantorMiddleName, guarantorLastName, guarantorDateOfBirth.Value);
                    if (guarantorHousehold.IsNotNull())
                    {
                        _ = _houseHoldMemberRepository.DeleteHouseHoldMember(guarantorHousehold);
                        tabStatus.IsHouseholdComplete = true;
                        //Update tab status
                        _ = await _tabStatusRepository.Update(tabStatus);
                    }

                    await UpdateTabStatusForGuarantor(patientPersonalDetail.AssessmentId, guarantorBasicInfoComplete, isGuarantorHomeComplete, isGuarantorWorkComplete, isContactPreferenceComplete);
                    return new Result<MessageDto>()
                    { Data = new MessageDto().AddMessage(Constants.BasicInfoUpdatedSuccessfully) };
                }
                else
                {
                    //If Guarantor doesn't exists then create a new Guarantor record with Personal data.
                    //Create new Home Address with Personal Home Address
                    //Create new Work Address with Personal Work Address
                    var guarantor = _guarantorMapper.MapFrom(basicInfo, patientPersonalDetail.AssessmentId);
                    //Create Basic Address For Guarantor
                    var basicContactDetailsDto = new ContactDetailsInfo()
                    {
                        AssessmentId = patientPersonalDetail.AssessmentId,
                        ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                        CellNumber = patientPersonalDetail.Cell,
                        CountyCode = patientPersonalDetail.CountyCode,
                        Email = basicInfo.EmailAddress
                    };
                    var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactDetailsDto);
                    basicContactDetails.Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName;
                    guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);

                    var patientHomeContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                    var guarantorHomeContactDetails = _contactDetailsMapper.MapFrom(patientHomeContactDetails);
                    guarantorHomeContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorHome };
                    guarantor.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetails);

                    if (guarantorHomeContactDetails.StreetAddress.IsNotNullOrEmpty() && guarantorHomeContactDetails.Zip.IsNotNullOrEmpty())
                    {
                        isGuarantorHomeComplete = true;
                    }

                    var patientWorkContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                    if (patientWorkContactDetails.IsNotNull())
                    {
                        var guarantorWorkContactDetails = _contactDetailsMapper.MapFrom(patientWorkContactDetails);
                        guarantorWorkContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorWork };
                        guarantor.WorkContactId = await _contactDetailsRepository.CreateContactDetail(guarantorWorkContactDetails);
                        isGuarantorWorkComplete = true;
                    }
                    guarantor.WorkContactId = await _guarantorRepository.CreateGuarantor(guarantor);
                    guarantorBasicInfoComplete = true;

                    //Update Household tab status
             
                    await UpdateTabStatusForGuarantor(patientPersonalDetail.AssessmentId, guarantorBasicInfoComplete, isGuarantorHomeComplete, isGuarantorWorkComplete);
                    return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.BasicInfoUpdatedSuccessfully) };
                }
            }
            else
            {
                //If IsGuarantor is false and if already a Guarantor exists with Self data - Delete the Guarantor and their respective Home and Work address.
                var guarantor =
                    await _guarantorRepository.GetGuarantorByAssessmentId(patientPersonalDetail.AssessmentId);
                if (guarantor.IsNotNull() && guarantor.RelationShipWithPatient.Equals(Constants.Self))
                {
                    //Delete Guarantor Basic Address
                    var guarantorBasicInfo = await _contactDetailsRepository.GetContactDetailsById(guarantor.BasicContactId);
                    if (guarantorBasicInfo.IsNotNull()) await _contactDetailsRepository.DeleteContactDetails(guarantorBasicInfo);

                    var guarantorHomeContactDetails =
                        await _contactDetailsRepository.GetContactDetailsById(guarantor.HomeContactId);
                    if (guarantorHomeContactDetails.IsNotNull()) await _contactDetailsRepository.DeleteContactDetails(guarantorHomeContactDetails);

                    var guarantorWorkContactDetails = await _contactDetailsRepository.GetContactDetailsById(guarantor.WorkContactId);
                    if (guarantorWorkContactDetails.IsNotNull()) await _contactDetailsRepository.DeleteContactDetails(guarantorWorkContactDetails);

                    _ = await _guarantorRepository.DeleteGuarantor(guarantor);

                    //Update tab status
                    tabStatus.IsHouseholdComplete = false;
                    _ = await _tabStatusRepository.Update(tabStatus);
                    await UpdateTabStatusForGuarantor(guarantor.Assessment.Id, false, false, false);
                    return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.BasicInfoUpdatedSuccessfully) };
                }
            }

            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.BasicInfoUpdatedSuccessfully) };
        }
        private async Task UpdateTabStatusForGuarantor(long assessmentId, bool isGuarantorBasicInfoComplete,
            bool isGuarantorHomeComplete, bool isGuarantorWorkComplete)
        {
            var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);

            tabStatus.IsGuarantorBasicInfoComplete = isGuarantorBasicInfoComplete;
            tabStatus.IsGuarantorHomeComplete = isGuarantorHomeComplete;
            tabStatus.IsGuarantorWorkComplete = isGuarantorWorkComplete;

            _ = await _tabStatusRepository.Update(tabStatus);
        }
        private async Task UpdateTabStatusForGuarantor(long assessmentId, bool isGuarantorInfoComplete, bool isGuarantorHomeComplete, bool isGuarantorWorkComplete, bool isContactPreferenceComplete)
        {
            var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);

            tabStatus.IsContactPreferenceComplete = isContactPreferenceComplete;
            tabStatus.IsGuarantorBasicInfoComplete = isGuarantorInfoComplete;
            tabStatus.IsGuarantorHomeComplete = isGuarantorHomeComplete;
            tabStatus.IsGuarantorWorkComplete = isGuarantorWorkComplete;

            _ = await _tabStatusRepository.Update(tabStatus);
        }

        public async Task<Result<ContactDetails>> GetContactDetails(GetContactDetails contactDetailsDto)
        {
            ContactDetails contactDetails = null;
            long contactDetailId = Constants.ZeroAsNumber;
            switch (contactDetailsDto.ContactTypeId)
            {
                case (long)Enums.ContactType.SelfBasic:
                case (long)Enums.ContactType.SelfHome:
                case (long)Enums.ContactType.SelfWork:
                    {
                        var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(contactDetailsDto.AssessmentId);
                        contactDetailId = contactDetailsDto.ContactTypeId switch
                        {
                            (long)Enums.ContactType.SelfBasic => basicInfo.BasicContactId,
                            (long)Enums.ContactType.SelfHome => basicInfo.HomeContactId,
                            (long)Enums.ContactType.SelfWork => basicInfo.WorkContactId,
                            _ => contactDetailId
                        };

                        break;
                    }
                case (long)Enums.ContactType.GuarantorBasic:
                case (long)Enums.ContactType.GuarantorHome:
                case (long)Enums.ContactType.GuarantorWork:
                    {
                        var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(contactDetailsDto.AssessmentId);
                        contactDetailId = contactDetailsDto.ContactTypeId switch
                        {
                            (long)Enums.ContactType.GuarantorBasic => guarantor.BasicContactId,
                            (long)Enums.ContactType.GuarantorHome => guarantor.HomeContactId,
                            (long)Enums.ContactType.GuarantorWork => guarantor.WorkContactId,
                            _ => contactDetailId
                        };

                        break;
                    }
            }
            if (contactDetailId != Constants.ZeroAsNumber)
            {
                contactDetails = await _contactDetailsRepository.GetContactDetailsById(contactDetailId);
            }
            return contactDetails.IsNull() ? new Result<ContactDetails>() { Data = null } : new Result<ContactDetails>() { Data = contactDetails };
        }

        public async Task<Result<MessageDto>> InsertContactDetails(ContactDetailsInfo contactDetailsDto)
        {
            //Check whether the patient with Entity type has address already.
            long contactDetailId = Constants.ZeroAsNumber;
            switch (contactDetailsDto.ContactTypeId)
            {
                case (long)Enums.ContactType.SelfBasic:
                case (long)Enums.ContactType.SelfHome:
                case (long)Enums.ContactType.SelfWork:
                    {
                        var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(contactDetailsDto.AssessmentId);
                        contactDetailId = contactDetailsDto.ContactTypeId switch
                        {
                            (long)Enums.ContactType.SelfBasic => basicInfo.BasicContactId,
                            (long)Enums.ContactType.SelfHome => basicInfo.HomeContactId,
                            (long)Enums.ContactType.SelfWork => basicInfo.WorkContactId,
                            _ => contactDetailId
                        };

                        break;
                    }
                case (long)Enums.ContactType.GuarantorBasic:
                case (long)Enums.ContactType.GuarantorHome:
                case (long)Enums.ContactType.GuarantorWork:
                    {
                        var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(contactDetailsDto.AssessmentId);
                        contactDetailId = contactDetailsDto.ContactTypeId switch
                        {
                            (long)Enums.ContactType.GuarantorBasic => guarantor.BasicContactId,
                            (long)Enums.ContactType.GuarantorHome => guarantor.HomeContactId,
                            (long)Enums.ContactType.GuarantorWork => guarantor.WorkContactId,
                            _ => contactDetailId
                        };

                        break;
                    }
            }
            var isContactDetailsExists = await _contactDetailsRepository.GetContactDetailsById(contactDetailId);
            if (isContactDetailsExists.IsNotNull()) return new Result<MessageDto>().AddError(Error.ContactDetailsExists);

            //Get the EntityMaster for Work Address type.

            var contactDetails = _contactDetailsMapper.MapFrom(contactDetailsDto);
            var contactDetailsId = await _contactDetailsRepository.CreateContactDetail(contactDetails);
            if (contactDetailsId == 0) return new Result<MessageDto>().AddError(Error.CreateContactDetailsFailed);

            switch (contactDetailsDto.ContactTypeId)
            {
                case (long)Enums.ContactType.SelfWork:
                    {
                        var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(contactDetailsDto.AssessmentId);
                        if (basicInfo != null)
                        {
                            basicInfo.WorkContactId = contactDetailsId;
                            await _basicInfoRepository.UpdateBasicInfo(basicInfo);
                            await UpdateTabStatus(contactDetailsDto.AssessmentId, Constants.PersonalWork, true);
                        }

                        break;
                    }
                case (long)Enums.ContactType.GuarantorHome:
                    {
                        var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(contactDetailsDto.AssessmentId);
                        if (guarantor != null)
                        {
                            guarantor.HomeContactId = contactDetailsId;
                            await _guarantorRepository.UpdateGuarantor(guarantor);
                            await UpdateTabStatus(contactDetailsDto.AssessmentId, Constants.GuarantorHomeTab, true);
                        }

                        break;
                    }
                case (long)Enums.ContactType.GuarantorWork:
                    {
                        var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(contactDetailsDto.AssessmentId);
                        if (guarantor != null)
                        {
                            guarantor.WorkContactId = contactDetailsId;
                            await _guarantorRepository.UpdateGuarantor(guarantor);
                            await UpdateTabStatus(contactDetailsDto.AssessmentId, Constants.GuarantorWorkTab, true);
                        }

                        break;
                    }
            }

            //Create work address for Guarantor when Patient itself a Guarantor.
            if (contactDetailsDto.AreYouGuarantor)
            {
                var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(contactDetailsDto.AssessmentId);
                if (guarantor.IsNull()) return new Result<MessageDto>().AddError(Error.GuarantorNotFound);
                if (guarantor.RelationShipWithPatient == Constants.Self)
                {
                    var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(contactDetailsDto.AssessmentId);
                    var patientHomeContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);

                    var guarantorContactDetails = _contactDetailsMapper.MapFrom(patientHomeContactDetails);
                    guarantorContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorWork };
                    guarantor.WorkContactId = await _contactDetailsRepository.CreateContactDetail(guarantorContactDetails);
                    await _guarantorRepository.UpdateGuarantor(guarantor);
                    await UpdateTabStatus(contactDetailsDto.AssessmentId, Constants.GuarantorWorkTab, true);
                }
            }

            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.CreateContactDetailsSuccess) };
        }

        public async Task<Result<MessageDto>> UpdateContactDetails(UpdateContactDetails updateContactDetailsRequest)
        {
            //Check whether Address exists for give AddressId.
            var contactDetails = await _contactDetailsRepository.GetContactDetailsById(updateContactDetailsRequest.ContactDetailsId);
            if (contactDetails.IsNull()) return new Result<MessageDto>().AddError(Error.ContactDetailsNotFound);

            var updatedContactDetails = _contactDetailsMapper.MapFrom(contactDetails, updateContactDetailsRequest);
            var isContactDetailsUpdated = await _contactDetailsRepository.UpdateContactDetails(updatedContactDetails);
            if (!isContactDetailsUpdated) return new Result<MessageDto>().AddError(Error.UpdateContactDetailsFailed);

            //Update Guarantor address when Patient itself a Guarantor.
            if (updateContactDetailsRequest.AreYouGuarantor)
            {
                var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(updateContactDetailsRequest.AssessmentId);
                if (guarantor.IsNull()) return new Result<MessageDto>().AddError(Error.GuarantorNotFound);
                if (guarantor.RelationShipWithPatient == Constants.Self)
                {
                    var guarantorContactDetails = await _contactDetailsRepository.GetContactDetailsById(contactDetails.ContactTypeDetails.Id == (long)Enums.ContactType.SelfHome ? guarantor.HomeContactId : guarantor.WorkContactId);
                    var updatedGuarantorContactDetails =
                        _contactDetailsMapper.MapFrom(guarantorContactDetails, updatedContactDetails);
                    var isGuarantorContactDetailsUpdated = await _contactDetailsRepository.UpdateContactDetails(updatedGuarantorContactDetails);
                    if (!isGuarantorContactDetailsUpdated) return new Result<MessageDto>().AddError(Error.UpdateContactDetailsFailed);

                    switch (updatedGuarantorContactDetails.ContactTypeDetails.Id)
                    {
                        case (long)Enums.ContactType.GuarantorHome:
                            await UpdateTabStatus(updateContactDetailsRequest.AssessmentId, Constants.GuarantorHomeTab, true);
                            break;
                        case (long)Enums.ContactType.GuarantorWork:
                            await UpdateTabStatus(updateContactDetailsRequest.AssessmentId, Constants.GuarantorWorkTab, true);
                            break;
                    }
                }
            }

            //Update tab status
            await UpdateTabStatusWithContact(updateContactDetailsRequest.AssessmentId, updatedContactDetails.ContactTypeDetails.Id);
            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.UpdateContactDetailsSuccess) };
        }

        private async Task UpdateTabStatusWithContact(long assessmentId, long contactTypeId)
        {
            switch (contactTypeId)
            {
                case (long)Enums.ContactType.SelfHome:
                    await UpdateTabStatus(assessmentId, Constants.PersonalHome, true);
                    break;
                case (long)Enums.ContactType.SelfWork:
                    await UpdateTabStatus(assessmentId, Constants.PersonalWork, true);
                    break;
                case (long)Enums.ContactType.GuarantorHome:
                    await UpdateTabStatus(assessmentId, Constants.GuarantorHomeTab, true);
                    break;
                case (long)Enums.ContactType.GuarantorWork:
                    await UpdateTabStatus(assessmentId, Constants.GuarantorWorkTab, true);
                    break;
            }
        }
        public async Task<Result<GetGuarantorResponse>> GetGuarantor(long assessmentId)
        {
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(assessmentId);
            if (guarantor.IsNull()) return new Result<GetGuarantorResponse>() { Data = null };

            var getGuarantorResponse = _guarantorMapper.MapFrom(guarantor);

            switch (getGuarantorResponse.RelationShipWithPatient)
            {
                case Constants.Self:
                    {
                        var last = "";
                        if (getGuarantorResponse.SSNNumber.IsNotNullOrEmpty())
                        {
                            last = getGuarantorResponse.SSNNumber.Substring(getGuarantorResponse.SSNNumber.Length - 4, 4);
                        }

                        getGuarantorResponse.SSNNumber = getGuarantorResponse.SSNNumber.IsNotNullOrEmpty() ? string.Format(Constants.SsnMask, last) : null;
                        break;
                    }
            }

            return new Result<GetGuarantorResponse>()
            { Data = getGuarantorResponse };
        }
        public async Task<Result<long>> CreateGuarantor(CreateGuarantorRequest createGuarantorRequest)
        {
            var isGuarantorExist = await _guarantorRepository.GetGuarantorByAssessmentId(createGuarantorRequest.AssessmentId);
            if (isGuarantorExist.IsNotNull()) return new Result<long>().AddError(Application.GuarantorExists);

            var guarantor = _guarantorMapper.MapFrom(createGuarantorRequest);
            //Create Basic Address For Guarantor
            var basicContactInfo = new ContactDetailsInfo()
            {
                AssessmentId = createGuarantorRequest.AssessmentId,
                ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName,
                CellNumber = createGuarantorRequest.Cell,
                CountyCode = createGuarantorRequest.CountyCode,
                Email = createGuarantorRequest.EmailAddress
            };
            var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactInfo);
            guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);


            bool guarantorBasicInfoComplete = true;
            bool isGuarantorHomeComplete = false;
            bool isGuarantorWorkComplete = false;

            var tabStatus = await _tabStatusRepository.GetTabStatus(createGuarantorRequest.AssessmentId);
            if (createGuarantorRequest.RelationshipWithPatient.Equals("Self"))
            {
                var basicInfo =
                    await _basicInfoRepository.GetBasicInfoByAssessment(createGuarantorRequest.AssessmentId);

                var patientHomeContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                var guarantorHomeContactDetails = _contactDetailsMapper.MapFrom(patientHomeContactDetails);
                guarantorHomeContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorHome };
                guarantor.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetails);

                if (guarantorHomeContactDetails.StreetAddress.IsNotNullOrEmpty() && guarantorHomeContactDetails.Zip.IsNotNullOrEmpty())
                {
                    isGuarantorHomeComplete = true;
                }
                var patientWorkContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                if (patientWorkContactDetails.IsNotNull())
                {
                    var guarantorWorkContactDetails = _contactDetailsMapper.MapFrom(patientWorkContactDetails);
                    guarantorWorkContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorWork };
                    guarantor.WorkContactId = await _contactDetailsRepository.CreateContactDetail(guarantorWorkContactDetails);
                    isGuarantorWorkComplete = true;
                }
                //If the assessment is created for Myself then make Household tab green.
                var quickAssessmentResult = await _answerRepository.GetQuestionAnswerJson(createGuarantorRequest.AssessmentId);
                var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessmentResult.QuestionAnswerJson);
                var patientType = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
                if (patientType == "Myself")
                {
                    tabStatus.IsHouseholdComplete = false;
                    _ = await _tabStatusRepository.Update(tabStatus);
                }
            }

            var guarantorId = await _guarantorRepository.CreateGuarantor(guarantor);
            if (!createGuarantorRequest.RelationshipWithPatient.Equals("Self"))
            {
                //Create the household record for this guarantor
                var guarantorHouseHold = _houseHoldMapper.MapFrom(guarantor);
                guarantorHouseHold.Assessment = new Assessment { Id = createGuarantorRequest.AssessmentId };
                var guarantorHouseHoldId = await _houseHoldMemberRepository.CreateHouseHoldMember(guarantorHouseHold);

                //Update tab status
                tabStatus.IsHouseholdComplete = false;
                _ = await _tabStatusRepository.Update(tabStatus);
            }

            //Update TabCompletionStatus
            await UpdateTabStatusForGuarantor(createGuarantorRequest.AssessmentId, guarantorBasicInfoComplete, isGuarantorHomeComplete, isGuarantorWorkComplete);

            return guarantorId == 0 ? new Result<long>().AddError(Application.InsertGuarantorFailed) : new Result<long>() { Data = guarantorId };
        }
        public async Task<Result<MessageDto>> UpdateGuarantor(UpdateGuarantorRequest updateGuarantorRequest)
        {
            var guarantor = await _guarantorRepository.GetGuarantorById(updateGuarantorRequest.GuarantorId);
            if (guarantor.IsNull()) return new Result<MessageDto>().AddError(Error.GuarantorNotFound);
            var guarantorSSN = guarantor.SSNNumber;
            var guarantorRelation = guarantor.RelationShipWithPatient;
            var guarantorFirstName = guarantor.FirstName;
            var guarantorMiddleName = guarantor.MiddleName;
            var guarantorLastName = guarantor.LastName;
            var guarantorDateOfBirth = guarantor.DateOfBirth;

            if (guarantor.Cell != updateGuarantorRequest.Cell || guarantor.CountyCode != updateGuarantorRequest.CountyCode || guarantor.EmailAddress != updateGuarantorRequest.EmailAddress)
            {
                //Update Guarantor Basic Address
                var guarantorBasicInfo = await _contactDetailsRepository.GetContactDetailsById(guarantor.BasicContactId);
                guarantorBasicInfo.Name = updateGuarantorRequest.FirstName + StringExtensions.Space + updateGuarantorRequest.LastName;
                guarantorBasicInfo.Cell = updateGuarantorRequest.Cell;
                guarantorBasicInfo.CountyCode = updateGuarantorRequest.CountyCode;
                guarantorBasicInfo.Email = updateGuarantorRequest.EmailAddress;
                _ = await _contactDetailsRepository.UpdateContactDetails(guarantorBasicInfo);
            }

            var basicInfo = await _basicInfoRepository.GetBasicInfoById(updateGuarantorRequest.BasicInfoId);
            bool isHouseholdComplete = true;
            if (updateGuarantorRequest.RelationshipWithPatient.Equals("Self"))
            {
                bool isGuarantorHomeComplete = false;
                bool isGuarantorWorkComplete = false;
                var guarantorHomeContactDetailsExists = await _contactDetailsRepository.GetContactDetailsById(guarantor.HomeContactId);
                if (guarantorHomeContactDetailsExists.IsNotNull())
                {
                    var patientHomeContactDetails1 = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                    var updatedGuarantorHomeContactDetails =
                         _contactDetailsMapper.MapFrom(guarantorHomeContactDetailsExists, patientHomeContactDetails1);
                    _ = await _contactDetailsRepository.UpdateContactDetails(updatedGuarantorHomeContactDetails);

                    if (updatedGuarantorHomeContactDetails.StreetAddress.IsNotNullOrEmpty() && updatedGuarantorHomeContactDetails.Zip.IsNotNullOrEmpty())
                    {
                        isGuarantorHomeComplete = true;
                    }
                }
                else
                {
                    var patientHomeContactDetailsNew = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
                    if (patientHomeContactDetailsNew.IsNotNull())
                    {
                        var guarantorHomeContactDetailsNew = _contactDetailsMapper.MapFrom(patientHomeContactDetailsNew);
                        guarantorHomeContactDetailsNew.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorHome };
                        guarantor.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetailsNew);

                        if (guarantorHomeContactDetailsNew.StreetAddress.IsNotNullOrEmpty() && guarantorHomeContactDetailsNew.Zip.IsNotNullOrEmpty())
                        {
                            isGuarantorHomeComplete = true;
                        }
                    }
                }
                var guarantorWorkContactDetailsExists = await _contactDetailsRepository.GetContactDetailsById(guarantor.WorkContactId);
                if (guarantorWorkContactDetailsExists.IsNotNull())
                {
                    var patientWorkContactDetails1 = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                    //If Personal work address is null and try to update the Guarantor Work Address with null
                    if (!patientWorkContactDetails1.IsNotNull())
                    {
                        guarantor.WorkContactId = Constants.ZeroAsNumber;
                        //await _guarantorRepository.UpdateGuarantor(updatedGuarantor);
                        _ =
                            await _contactDetailsRepository.DeleteContactDetails(guarantorWorkContactDetailsExists);
                        isGuarantorWorkComplete = false;
                    }
                    else
                    {
                        var updatedGuarantorWorkContactDetails =
                             _contactDetailsMapper.MapFrom(guarantorWorkContactDetailsExists, patientWorkContactDetails1);
                        _ = await _contactDetailsRepository.UpdateContactDetails(updatedGuarantorWorkContactDetails);
                        isGuarantorWorkComplete = true;
                    }
                }
                else
                {
                    var patientWorkContactDetailsNew = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);
                    if (patientWorkContactDetailsNew.IsNotNull())
                    {
                        var guarantorWorkContactDetails = _contactDetailsMapper.MapFrom(patientWorkContactDetailsNew);
                        guarantorWorkContactDetails.ContactTypeDetails = new ContactTypeMaster { Id = (long)Enums.ContactType.GuarantorWork };
                        guarantor.WorkContactId = await _contactDetailsRepository.CreateContactDetail(guarantorWorkContactDetails);
                        isGuarantorWorkComplete = true;
                    }
                }
                //Delete the guarantor record in household because Self record is updated in Guarantor.
                var guarantorHousehold = await _houseHoldMemberRepository.GetHouseholdBySSN(updateGuarantorRequest.AssessmentId, guarantorSSN, guarantorRelation, guarantorFirstName, guarantorMiddleName, guarantorLastName, guarantorDateOfBirth.Value);
                if (guarantorHousehold.IsNotNull())
                {
                    _ = _houseHoldMemberRepository.DeleteHouseHoldMember(guarantorHousehold);
                    isHouseholdComplete = false;
                }

                //If the assessment is created for Myself then make Household tab green.
                var quickAssessmentResult = await _answerRepository.GetQuestionAnswerJson(updateGuarantorRequest.AssessmentId);
                var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessmentResult.QuestionAnswerJson);
                var patientType = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
                if (patientType == "Myself")
                {
                    isHouseholdComplete = false;
                }

                await UpdateTabStatusForGuarantor(updateGuarantorRequest.AssessmentId, true, isGuarantorHomeComplete,
                    isGuarantorWorkComplete);
            }



            var updatedGuarantor = _assessmentMapper.MapFrom(guarantor, updateGuarantorRequest);
            var isGuarantorUpdated = await _guarantorRepository.UpdateGuarantor(updatedGuarantor);

            if (!isGuarantorUpdated) return new Result<MessageDto>().AddError(Error.UpdateGuarantorFailed);

            //Update guarantor record in household
            if (!updateGuarantorRequest.RelationshipWithPatient.Equals("Self"))
            {
                var guarantorHousehold = await _houseHoldMemberRepository.GetHouseholdBySSN(updateGuarantorRequest.AssessmentId, guarantorSSN, guarantorRelation, guarantorFirstName, guarantorMiddleName, guarantorLastName, guarantorDateOfBirth.Value);
                //if (guarantorHousehold.IsNull())
                //{
                //    var guarantorHouseholdEntity = _houseHoldMapper.MapFromCreate(updatedGuarantor);
                //    var guarantorHouseholdEntityId = _houseHoldMemberRepository.CreateHouseHoldMember(guarantorHouseholdEntity);
                //}
                var updatedHouseHold = await _houseHoldMapper.MapFromUpdate(guarantorHousehold, updatedGuarantor);
                var isGuarantorHouseholdUpdated = await _houseHoldMemberRepository.UpdateHouseHoldMember(updatedHouseHold);
                isHouseholdComplete = false;
            }
            //Update tab status
            var tabStatus = await _tabStatusRepository.GetTabStatus(updateGuarantorRequest.AssessmentId);
            tabStatus.IsHouseholdComplete = isHouseholdComplete;
            _ = await _tabStatusRepository.Update(tabStatus);
            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.UpdateGuarantorSuccess) };
        }

        public async Task<Result<MessageDto>> UpdateReviewProgramStatus(List<UpdateReviewProgramRequest> updateReviewProgramRequest)
        {
            long assessmentId = 0;
            bool fromQuickAssessmentTab = false;
            foreach (var program in updateReviewProgramRequest)
            {
                fromQuickAssessmentTab = program.IsEvaluated;
                assessmentId = program.AssessmentId;
                var patientProgramList = await _patientProgramMappingRepository.GetAllReviewProgramsOfAssessment(program.AssessmentId);
                var patientProgram = patientProgramList.FirstOrDefault(x => x.Program.Id == program.ProgramId && x.IsEvaluated.Equals(program.IsEvaluated));
                if (patientProgram == null) continue;
                patientProgram.IsActive = program.IsActive;
                var isReviewProgramUpdated =
                    await _patientProgramMappingRepository.UpdateReviewProgramStatus(patientProgram);
            }
            //Update tab status
            if (fromQuickAssessmentTab)
            {
                //var programDocumentCount = _patientProgramMappingRepository.GetProgramDocumentCount(assessmentId);
                //var eSignedDocumentCount = _documentRepository.GetESignedDocumentCountForActivePrograms(assessmentId);

                var isProgramDocumentSigned = new List<bool>();
                var patientProgramMappings = await _patientProgramMappingRepository.GetPatientProgramMappingOfActiveAndEvaluatedPrograms(assessmentId);
                foreach (var patientProgramMapping in patientProgramMappings)
                {
                    var programDocuments = await _programDocumentRepository.GetProgramDocumentDetailsByProgramId(patientProgramMapping.Program.Id);
                    foreach (var programDocument in programDocuments)
                    {
                        var documentProgramMappingId = await _documentProgramMappingRepository.GetProgramDocumentMappingIdByProgramDocumentAndAssessmentId(assessmentId, programDocument.Id);
                        if (documentProgramMappingId != 0)
                        {
                            isProgramDocumentSigned.Add(true);
                            break;
                        }
                    }
                }

                await UpdateTabStatus(assessmentId, Constants.ApplicationForms, (patientProgramMappings.Count().Equals(isProgramDocumentSigned.Count) && patientProgramMappings.Any()));
            }

            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Constants.ReviewProgramsUpdatedMessage) };
        }

        public async Task<Result<ReviewProgramResponse>> GetActiveReviewPrograms(BasePatientAssessment patientAssessment)
        {
            var patientProgramMappings = await _patientProgramMappingRepository.GetActiveReviewPrograms(patientAssessment.AssessmentId);

            var reviewPrograms = new List<ReviewProgramsResponseDto>();
            foreach (var patientProgramMapping in patientProgramMappings)
            {
                var program = await _programRepository.GetProgramDetailsById(patientProgramMapping.Program.Id);
                var reviewProgram = new ReviewProgramsResponseDto()
                {
                    ProgramId = program.Id,
                    ProgramName = program.Name,
                    Benefits = program.Details,
                    Status = patientProgramMapping.Status
                };
                reviewPrograms.Add(reviewProgram);
            }

            var reviewProgramResponse = new ReviewProgramResponse
            {
                ReviewPrograms = reviewPrograms
            };
            return new Result<ReviewProgramResponse>()
            { Data = reviewProgramResponse };
        }

        public async Task<Result<ReviewProgramResponse>> GetAllReviewPrograms(BasePatientAssessment patientAssessment)
        {
            var patientProgramMappings =
                await _patientProgramMappingRepository.GetNotEvaluatedPrograms
                    (patientAssessment.AssessmentId);

            var reviewPrograms = new List<ReviewProgramsResponseDto>();
            foreach (var patientProgramMapping in patientProgramMappings)
            {
                var program = await _programRepository.GetProgramDetailsById(patientProgramMapping.Program.Id);
                var reviewProgram = new ReviewProgramsResponseDto()
                {
                    ProgramId = program.Id,
                    ProgramName = program.Name,
                    Benefits = program.Details,
                    Status = patientProgramMapping.Status,
                    IsActive = patientProgramMapping.IsActive
                };
                reviewPrograms.Add(reviewProgram);
            }

            var reviewProgramResponse = new ReviewProgramResponse
            {
                ReviewPrograms = reviewPrograms
            };
            return new Result<ReviewProgramResponse>()
            { Data = reviewProgramResponse };
        }
        public async Task<Result<ReviewProgramResponse>> GetNotEvaluatedActiveReviewPrograms(BasePatientAssessment patientAssessment)
        {
            var patientProgramMappings =
                await _patientProgramMappingRepository.GetNotEvaluatedActiveReviewPrograms
                    (patientAssessment.AssessmentId);

            var reviewPrograms = new List<ReviewProgramsResponseDto>();
            foreach (var patientProgramMapping in patientProgramMappings)
            {
                var program = await _programRepository.GetProgramDetailsById(patientProgramMapping.Program.Id);
                var reviewProgram = new ReviewProgramsResponseDto()
                {
                    ProgramId = program.Id,
                    ProgramName = program.Name,
                    Benefits = program.Details,
                    Status = patientProgramMapping.Status,
                    IsActive = patientProgramMapping.IsActive
                };
                reviewPrograms.Add(reviewProgram);
            }

            var reviewProgramResponse = new ReviewProgramResponse
            {
                ReviewPrograms = reviewPrograms
            };
            return new Result<ReviewProgramResponse>()
            { Data = reviewProgramResponse };
        }

        public async Task<Result<EFormResponse>> GetEFormData(BasePatientAssessment patientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(patientAssessment.PatientId);
            if (basicInfo.IsNull()) return new Result<EFormResponse>().AddError(Error.PatientNotFound);

            var homeContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.HomeContactId);
            var workContactDetails = await _contactDetailsRepository.GetContactDetailsById(basicInfo.WorkContactId);

            var homeCell = homeContactDetails.IsNotNull() ? homeContactDetails.Cell : string.Empty;
            var workCell = workContactDetails.IsNotNull() ? workContactDetails.Cell : string.Empty;
            var mainApplicantDetail = new MainApplicantDetail()
            {
                Title = basicInfo.Suffix,
                SSN = basicInfo.SSNNumber,
                Surname = basicInfo.LastName,
                Forename = basicInfo.FirstName,
                MiddleName = basicInfo.MiddleName,
                Address = homeContactDetails.Suite + StringExtensions.Space + homeContactDetails.StreetAddress + StringExtensions.Comma + homeContactDetails.City + StringExtensions.Comma + homeContactDetails.State,
                ZipCode = homeContactDetails.Zip,
                Gender = basicInfo.Gender,
                MaritalStatus = basicInfo.MaritalStatus,
                DateOfBirth = basicInfo.DateOfBirth.ToString(Constants.MonthDayYear, CultureInfo.InvariantCulture),
                EmailAddress = basicInfo.EmailAddress,
                City = homeContactDetails.City,
                State = homeContactDetails.State,
                County = homeContactDetails.County,
                HomeCellNumber = homeContactDetails.IsNotNull() ? Constants.AdditionSymbol + homeContactDetails.CountyCode + homeCell : string.Empty,
                WorkCellNumber = workContactDetails.IsNotNull() ? Constants.AdditionSymbol + workContactDetails.CountyCode + workCell : string.Empty,
                CellNumber = basicInfo.CountyCode + basicInfo.CellNumber
            };

            var houseHoldMembers =
                await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(patientAssessment
                    .AssessmentId);
            var otherApplicantList = new List<OtherApplicant>();
            foreach (var houseHoldMember in houseHoldMembers)
            {
                var otherApplicant = new OtherApplicant()
                {
                    Title = houseHoldMember.Suffix,
                    Surname = houseHoldMember.LastName,
                    Forename = houseHoldMember.FirstName,
                    Gender = houseHoldMember.Gender,
                    DateOfBirth = houseHoldMember.DateOfBirth.Value.ToString(Constants.MonthDayYear, CultureInfo.InvariantCulture)
                };
                otherApplicantList.Add(otherApplicant);
            }
            var eformResponseDto = new EFormResponse
            {
                MainApplicantDetails = mainApplicantDetail,
                OtherApplicants = otherApplicantList
            };
            return new Result<EFormResponse>()
            { Data = eformResponseDto };
        }

        public async Task<Result<PreferedCell>> GetPreferredCell(BasePatientAssessment patientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(patientAssessment.PatientId);
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(patientAssessment.AssessmentId);
            var houseHoldMember = await _houseHoldMemberRepository.GetRelativeHouseHoldMember(patientAssessment.AssessmentId);
            var assessmentCreator = await _userRepository.GetUserById(basicInfo.Assessment.CreatedBy ?? 0);
            var holdMemberList = new List<long>();
            foreach (var holdMember in houseHoldMember)
            {
                holdMemberList.Add(holdMember.Id);
            }
            var houseHoldIncome = await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberIds(holdMemberList
                .Where(x => !x.Equals(0)).ToList());
            var holdMemberIncomeWorkList = new List<long>();
            foreach (var houseHoldMemberIncome in houseHoldIncome)
            {
                holdMemberIncomeWorkList.Add(houseHoldMemberIncome.ContactDetails.Id);
            }
            var patientName = $"{basicInfo.FirstName} {basicInfo.LastName}";
            var contactIdList = new List<long>();
            contactIdList.AddRange(new List<long>() { basicInfo.BasicContactId, basicInfo.HomeContactId, basicInfo.WorkContactId });
            var guarantorName = string.Empty;
            var guarantorRelationshipWithPatient = string.Empty;
            if (guarantor.IsNotNull())
            {
                guarantorName = $"{guarantor.FirstName} {guarantor.LastName}";
                guarantorRelationshipWithPatient = guarantor.RelationShipWithPatient;
                contactIdList.AddRange(new List<long>() { guarantor.BasicContactId, guarantor.HomeContactId, guarantor.WorkContactId });
            }
            contactIdList.AddRange(holdMemberIncomeWorkList);
            if (_currentHttpContext.GetCurrentUserRole() == Roles.Patient.RoleName)
            {
                var dynamicUser = await _userRepository.GetUserById(Constants.AdminUserId);
                if (dynamicUser.IsActive)
                {
                    var quickAssessment = await _answerRepository.GetQuestionAnswerJson(patientAssessment.AssessmentId);
                    var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessment.QuestionAnswerJson);
                    var patientType =
                        (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
                    if (patientType.IsNotNull() && patientType.Contains(Constants.RelationshipCase))
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                }
                else
                {
                    var quickAssessment = await _answerRepository.IsMyselfAssessment(patientAssessment.AssessmentId);
                    if (!quickAssessment)
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                }

            }
            var contactIdNonZeroList = contactIdList.Where(x => !x.Equals(0));
            var preferredPhoneDropDown = new PreferedCell();
            var preferredPhoneDropdownValueList = new List<PreferedCellValue>();

            var contactDetailsList = new List<ContactDetails>();
            foreach (long contactId in contactIdNonZeroList)
            {
                contactDetailsList.Add(await _contactDetailsRepository.GetContactDetailsById(contactId));
            }

            var phoneDropDownList = contactDetailsList.OrderByDescending(x => x.ContactTypeDetails.EntityType).ThenBy(y => y.ContactTypeDetails.ContactType);

            foreach (var cell in phoneDropDownList)
            {
                if (cell.Cell.IsNull() || cell.Cell == string.Empty) continue;
                PreferedCellValue dropdownValue = new PreferedCellValue();
                switch (cell.ContactTypeDetails.Id)
                {
                    case (long)Enums.ContactType.SelfHome:
                        dropdownValue.DisplayTitle = $"{patientName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorHome when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.SelfWork:
                        dropdownValue.DisplayTitle = $"{patientName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorWork when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.SelfBasic:
                        dropdownValue.DisplayTitle = $"{patientName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorBasic when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.HouseHoldIncome:
                        var houseHoldIncomeDetails = await _houseHoldIncomeRepository.GetHouseHoldIncomeByContactId(cell.Id);
                        dropdownValue.DisplayTitle = $"{houseHoldIncomeDetails.HouseHoldMember.FirstName} {houseHoldIncomeDetails.HouseHoldMember.LastName} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.UserProfile:
                        dropdownValue.DisplayTitle = $"{cell.Name} ({cell.ContactTypeDetails.EntityType}) - {cell.ContactTypeDetails.ContactType} - +{cell.CountyCode} {String.Format(Constants.PhoneNumberFormat, Convert.ToInt64(cell.Cell))}";
                        dropdownValue.ContactPhoneId = cell.Id;
                        dropdownValue.PreferredPhoneUniqueId = string.Join(StringExtensions.Underscore, cell.ContactTypeDetails.EntityType, cell.ContactTypeDetails.ContactType);
                        break;
                }
                if (dropdownValue.DisplayTitle.IsNotNull())
                {
                    preferredPhoneDropdownValueList.Add(dropdownValue);
                }

            }
            var preferredPhoneDropdownValueOther = new PreferedCellValue()
            {
                DisplayTitle = Constants.Other,
                ContactPhoneId = 0,
                PreferredPhoneUniqueId = Constants.Other
            };
            preferredPhoneDropdownValueList.Add(preferredPhoneDropdownValueOther);
            preferredPhoneDropDown.PreferredCellDropdownValueList = preferredPhoneDropdownValueList;
            return new Result<PreferedCell>()
            { Data = preferredPhoneDropDown };
        }

        public async Task<Result<PreferredAddressDropdown>> GetPreferredContactDetails(BasePatientAssessment patientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(patientAssessment.PatientId);
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(patientAssessment.AssessmentId);

            var houseHoldMember = await _houseHoldMemberRepository.GetRelativeHouseHoldMember(patientAssessment.AssessmentId);
            var assessmentCreator = await _userRepository.GetUserById(basicInfo.Assessment.CreatedBy ?? 0);
            var holdMemberList = new List<long>();
            foreach (var holdMember in houseHoldMember)
            {
                holdMemberList.Add(holdMember.Id);
            }
            var houseHoldIncome = await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberIds(holdMemberList
                .Where(x => !x.Equals(0)).ToList());
            var holdMemberIncomeWorkList = new List<long>();
            foreach (var houseHoldMemberIncome in houseHoldIncome)
            {
                holdMemberIncomeWorkList.Add(houseHoldMemberIncome.ContactDetails.Id);
            }

            var contactIdList = new List<long>();
            contactIdList.AddRange(new List<long>() { basicInfo.HomeContactId, basicInfo.WorkContactId });
            var patientName = $"{basicInfo.FirstName} {basicInfo.LastName}";
            var guarantorName = string.Empty;
            var guarantorRelationshipWithPatient = string.Empty;
            if (guarantor.IsNotNull())
            {
                guarantorName = $"{guarantor.FirstName} {guarantor.LastName}";
                guarantorRelationshipWithPatient = guarantor.RelationShipWithPatient;
                contactIdList.AddRange(new List<long>() { guarantor.HomeContactId, guarantor.WorkContactId });
            }

            contactIdList.AddRange(holdMemberIncomeWorkList);
            if (_currentHttpContext.GetCurrentUserRole() == Roles.Patient.RoleName)
            {
                var dynamicUser = await _userRepository.GetUserById(Constants.AdminUserId);
                if (dynamicUser.IsActive)
                {
                    var quickAssessment = await _answerRepository.GetQuestionAnswerJson(patientAssessment.AssessmentId);
                    var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessment.QuestionAnswerJson);
                    var patientType =
                        (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
                    if (patientType.IsNotNull() && patientType.Contains(Constants.RelationshipCase))
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                }
                else
                {
                    var quickAssessment = await _answerRepository.IsMyselfAssessment(patientAssessment.AssessmentId);
                    if (!quickAssessment)
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                }
            }

            var contactIdNonZeroList = contactIdList.Where(x => !x.Equals(0));
            var preferredContactDetailsDropDown = new PreferredAddressDropdown();
            var preferredContactDetailsDropdownValueList = new List<PreferredAddressDropdownValue>();

            var contactDetailsList = new List<ContactDetails>();
            foreach (long contactId in contactIdNonZeroList)
            {
                contactDetailsList.Add(await _contactDetailsRepository.GetContactDetailsById(contactId));
            }

            var contactDetailsDropDownList = contactDetailsList.OrderByDescending(x => x.ContactTypeDetails.EntityType).ThenBy(y => y.ContactTypeDetails.ContactType);

            foreach (var contactDetails in contactDetailsDropDownList)
            {
                PreferredAddressDropdownValue dropdownValue = new PreferredAddressDropdownValue();
                var contactDetailsArray = new[] { contactDetails.Suite, contactDetails.StreetAddress, contactDetails.City, contactDetails.State };
                string fullContactDetails = string.Join(StringExtensions.Comma, contactDetailsArray.Where(s => !string.IsNullOrEmpty(s)));
                if (string.IsNullOrEmpty(fullContactDetails)) continue;
                switch (contactDetails.ContactTypeDetails.Id)
                {
                    case (long)Enums.ContactType.SelfHome:
                        dropdownValue.DisplayTitle = $"{patientName} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorHome when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.SelfWork:
                        dropdownValue.DisplayTitle = $"{patientName} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorWork when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.HouseHoldIncome:
                        var houseHoldIncomeDetails = await _houseHoldIncomeRepository.GetHouseHoldIncomeByContactId(contactDetails.Id);
                        dropdownValue.DisplayTitle = $"{houseHoldIncomeDetails.HouseHoldMember.FirstName} {houseHoldIncomeDetails.HouseHoldMember.LastName} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.UserProfile:
                        dropdownValue.DisplayTitle = $"{contactDetails.Name} ({contactDetails.ContactTypeDetails.EntityType}) - {contactDetails.ContactTypeDetails.ContactType} - {fullContactDetails}";
                        dropdownValue.ContactAddressId = contactDetails.Id;
                        dropdownValue.PreferedAddressUniqueId = string.Join(StringExtensions.Underscore, contactDetails.ContactTypeDetails.EntityType, contactDetails.ContactTypeDetails.ContactType);
                        break;
                }
                if (dropdownValue.DisplayTitle.IsNotNull())
                {
                    preferredContactDetailsDropdownValueList.Add(dropdownValue);
                }
            }
            var preferredContactDetailsDropdownValueOther = new PreferredAddressDropdownValue()
            {
                DisplayTitle = Constants.Other,
                ContactAddressId = 0,
                PreferedAddressUniqueId = Constants.Other
            };
            preferredContactDetailsDropdownValueList.Add(preferredContactDetailsDropdownValueOther);
            preferredContactDetailsDropDown.PreferredAddressDropdownValueList = preferredContactDetailsDropdownValueList;
            return new Result<PreferredAddressDropdown>() { Data = preferredContactDetailsDropDown };
        }

        public async Task<Result<MessageDto>> DeleteContactDetails(DeleteContactDetailsRequest deleteContactDetailsRequest)
        {
            var contactDetails = await _contactDetailsRepository.GetContactDetailsById(deleteContactDetailsRequest.ContactDetailsId);
            if (contactDetails.IsNotNull())
            {
                _ = await _contactDetailsRepository.DeleteContactDetails(contactDetails);

                switch (contactDetails.ContactTypeDetails.Id)
                {
                    case (long)Enums.ContactType.SelfWork:
                        {
                            var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(deleteContactDetailsRequest.AssessmentId);
                            if (basicInfo != null)
                            {
                                basicInfo.WorkContactId = 0;
                                await _basicInfoRepository.UpdateBasicInfo(basicInfo);
                                await UpdateTabStatus(deleteContactDetailsRequest.AssessmentId, Constants.PersonalWork, false);
                            }
                            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(deleteContactDetailsRequest.AssessmentId);
                            if (guarantor != null && guarantor.RelationShipWithPatient.Equals(Constants.Self))
                            {
                                guarantor.WorkContactId = 0;
                                await _guarantorRepository.UpdateGuarantor(guarantor);
                                await UpdateTabStatus(deleteContactDetailsRequest.AssessmentId, Constants.GuarantorWorkTab, false);
                            }
                            break;
                        }
                    case (long)Enums.ContactType.GuarantorWork:
                        {
                            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(deleteContactDetailsRequest.AssessmentId);
                            if (guarantor != null)
                            {
                                guarantor.WorkContactId = 0;
                                await _guarantorRepository.UpdateGuarantor(guarantor);
                                await UpdateTabStatus(deleteContactDetailsRequest.AssessmentId, Constants.GuarantorWorkTab, false);
                            }
                            break;
                        }
                }

                return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.DeleteContactDetailsSuccess) };
            }
            return new Result<MessageDto>().AddError(Error.DeleteContactDetailsFailed);
        }
        public async Task<Result<PreferedEmail>> GetPreferredEmail(BasePatientAssessment patientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(patientAssessment.PatientId);
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(patientAssessment.AssessmentId);
            var assessmentCreator = await _userRepository.GetUserById(basicInfo.Assessment.CreatedBy ?? 0);
            var contactIdList = new List<long>();
            contactIdList.AddRange(new List<long>() { basicInfo.BasicContactId });
            var patientName = $"{basicInfo.FirstName} {basicInfo.LastName}";
            var guarantorName = string.Empty;
            var guarantorRelationshipWithPatient = string.Empty;
            if (guarantor.IsNotNull())
            {
                guarantorName = $"{guarantor.FirstName} {guarantor.LastName}";
                guarantorRelationshipWithPatient = guarantor.RelationShipWithPatient;
                contactIdList.AddRange(new List<long>() { guarantor.BasicContactId });
            }
            if (_currentHttpContext.GetCurrentUserRole() == Roles.Patient.RoleName)
            {
                var dynamicUser = await _userRepository.GetUserById(Constants.AdminUserId);
                if (dynamicUser.IsActive)
                {
                    var quickAssessment = await _answerRepository.GetQuestionAnswerJson(patientAssessment.AssessmentId);
                    var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessment.QuestionAnswerJson);
                    var patientType =
                        (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
                    if (patientType.IsNotNull() && patientType.Contains(Constants.RelationshipCase))
                    {
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                        if (assessmentCreator?.EmailAddress !=
                            assessmentCreator?.SecondaryEmailContactDetails.Email)
                        {
                            contactIdList.Add(assessmentCreator?.SecondaryEmailContactDetails.Id ?? 0);
                        }
                    }
                    else
                    {
                        if(assessmentCreator.SecondaryEmailContactDetails != null)
                            contactIdList.Add(assessmentCreator?.SecondaryEmailContactDetails.Id ?? 0);
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                    }

                }
                else
                {
                    var quickAssessment = await _answerRepository.IsMyselfAssessment(patientAssessment.AssessmentId);
                    if (!quickAssessment)
                        contactIdList.Add(assessmentCreator?.ContactDetails?.Id ?? 0);
                }

            }
            var contactIdNonZeroList = contactIdList.Where(x => !x.Equals(0));
            var preferredEmailDropDown = new PreferedEmail();
            var preferredEmailDropdownValueList = new List<PreferredEmailValue>();

            var contactDetailsList = new List<ContactDetails>();
            foreach (long contactId in contactIdNonZeroList)
            {
                contactDetailsList.Add(await _contactDetailsRepository.GetContactDetailsById(contactId));
            }

            var emailDropDownList = contactDetailsList.OrderByDescending(x => x.ContactTypeDetails.EntityType).ThenBy(y => y.ContactTypeDetails.ContactType);
            foreach (var email in emailDropDownList)
            {
                PreferredEmailValue dropdownValue = new PreferredEmailValue();
                switch (email.ContactTypeDetails.Id)
                {
                    case (long)Enums.ContactType.SelfBasic:
                        dropdownValue.DisplayTitle = $"{patientName} ({email.ContactTypeDetails.EntityType}) - {email.ContactTypeDetails.ContactType} - {email.Email}";
                        dropdownValue.ContactEmailId = email.Id;
                        dropdownValue.PreferredEmailUniqueId = string.Join(StringExtensions.Underscore, email.ContactTypeDetails.EntityType, email.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.GuarantorBasic when guarantor.IsNotNull() && guarantorRelationshipWithPatient != Constants.Self:
                        dropdownValue.DisplayTitle = $"{guarantorName} ({email.ContactTypeDetails.EntityType}) - {email.ContactTypeDetails.ContactType} - {email.Email}";
                        dropdownValue.ContactEmailId = email.Id;
                        dropdownValue.PreferredEmailUniqueId = string.Join(StringExtensions.Underscore, email.ContactTypeDetails.EntityType, email.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.UserProfile:
                        dropdownValue.DisplayTitle = $"{email.Name} ({email.ContactTypeDetails.EntityType}) - {email.ContactTypeDetails.ContactType} - {email.Email}";
                        dropdownValue.ContactEmailId = email.Id;
                        dropdownValue.PreferredEmailUniqueId = string.Join(StringExtensions.Underscore, email.ContactTypeDetails.EntityType, email.ContactTypeDetails.ContactType);
                        break;
                    case (long)Enums.ContactType.SecondaryEmail:
                        dropdownValue.DisplayTitle = $"{email.Name} ({email.ContactTypeDetails.EntityType}) - {email.ContactTypeDetails.ContactType} - {email.Email}";
                        dropdownValue.ContactEmailId = email.Id;
                        dropdownValue.PreferredEmailUniqueId = string.Join(StringExtensions.Underscore, email.ContactTypeDetails.EntityType, email.ContactTypeDetails.ContactType);
                        break;
                }
                if (dropdownValue.DisplayTitle.IsNotNull())
                {
                    preferredEmailDropdownValueList.Add(dropdownValue);
                }
            }

            preferredEmailDropDown.PreferredEmailDropdownValueList = preferredEmailDropdownValueList;
            return new Result<PreferedEmail>()
            { Data = preferredEmailDropDown };
        }

        public async Task<Result<MessageDto>> CreateContactPreference(CreateContactPreference createContactPreferenceRequest)
        {
            var contactPreferenceDetail = await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(createContactPreferenceRequest.AssessmentId);
            if (!contactPreferenceDetail.IsNull()) return new Result<MessageDto>().AddError(Error.ContactPreferenceAlreadyExists);


            ContactDetails contactDetails = new ContactDetails()
            {
                ContactTypeDetails = new ContactTypeMaster() { Id = (long)Enums.ContactType.Other },
                Name = createContactPreferenceRequest.Name,
                StreetAddress = createContactPreferenceRequest.StreetAddress,
                Suite = createContactPreferenceRequest.Suite,
                City = createContactPreferenceRequest.City,
                State = createContactPreferenceRequest.State,
                Zip = createContactPreferenceRequest.ZipCode,
                County = createContactPreferenceRequest.County,
                CountyCode = createContactPreferenceRequest.CountyCode,
                Cell = createContactPreferenceRequest.CellNumber,
                PhoneType = createContactPreferenceRequest.PreferredCellType,
                Email = createContactPreferenceRequest.Email
            };

            if (createContactPreferenceRequest.UniqueContactDetailsId == Enums.ContactType.Other.ToString())
            {
                createContactPreferenceRequest.ContactAddressId = Constants.ZeroAsNumber;
            }
            if (createContactPreferenceRequest.UniquePhoneId == Enums.ContactType.Other.ToString())
            {
                createContactPreferenceRequest.ContactPhoneId = Constants.ZeroAsNumber;
            }
            if (createContactPreferenceRequest.UniqueEmailId == Enums.ContactType.Other.ToString())
            {
                createContactPreferenceRequest.ContactEmailId = Constants.ZeroAsNumber;
            }

            var contactPreference = _contactPreferenceMapper.MapFrom(createContactPreferenceRequest);
            contactPreference.OtherContactId = await _contactDetailsRepository.CreateContactDetail(contactDetails);
            var contactPreferenceId = await _contactPreferenceRepository.CreateContactPreference(contactPreference);
            if (contactPreferenceId == 0) return new Result<MessageDto>().AddError(Error.CreateContactPreferenceFailed);

            //Update Tab Status
            await UpdateTabStatus(createContactPreferenceRequest.AssessmentId, Constants.ContactPreference, true);

            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.CreateContactPreferenceSuccess) };
        }

        public async Task<Result<GetContactPreferenceDto>> GetContactPreference(BasePatientAssessment patientAssessment)
        {
            var contactPreference = await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(patientAssessment.AssessmentId);
            if (contactPreference.IsNull())
            {
                return new Result<GetContactPreferenceDto> { Data = null };
            }

            var otherContactDetails = new ContactDetails();
            if (contactPreference.ContactAddressId == Constants.ZeroAsNumber || contactPreference.ContactPhoneId == Constants.ZeroAsNumber)
            {
                otherContactDetails = await _contactDetailsRepository.GetContactDetailsById(contactPreference.OtherContactId);
            }
            contactPreference.ContactAddressId = contactPreference.ContactAddressId == 0 ? otherContactDetails.Id : contactPreference.ContactAddressId;
            contactPreference.ContactPhoneId = contactPreference.ContactPhoneId == 0 ? otherContactDetails.Id : contactPreference.ContactPhoneId;
            contactPreference.ContactEmailId = contactPreference.ContactEmailId == 0 ? otherContactDetails.Id : contactPreference.ContactEmailId;

            ContactDetails phone = null;
            ContactDetails contactDetails = null;
            string preferedCellUniqueId;
            string uniquePhoneId;
            string uniqueEmailId;
            string preferedEmailUniqueId;
            var preferedAddressUniqueId = string.Empty;
            var uniqueAddressId = string.Empty;
            if (contactPreference.ContactPhoneId == -1)
            {
                preferedCellUniqueId = null;
                uniquePhoneId = null;
            }
            else
            {
                phone = await _contactDetailsRepository.GetContactDetailsById(contactPreference.ContactPhoneId);
                //This null check is when work address is deleted in guarantor or personal, the reference is not removed in contact preference.
                if (phone.IsNotNull())
                {
                    preferedCellUniqueId = contactPreference.ContactPhoneId.ToString();
                    uniquePhoneId = $"{phone.ContactTypeDetails.EntityType}_{phone.ContactTypeDetails.ContactType}";
                    //If contact detail cell is null or empty then update ContactPhoneId as -1 in ContactPreference table.
                    if (phone.Cell.isNullOrEmpty())
                    {
                        var cp = await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(patientAssessment
                            .AssessmentId);
                        cp.ContactPhoneId = -1;
                        _ = await _contactPreferenceRepository.UpdateContactPreference(cp);
                        //Update tab status as false
                        await UpdateTabStatus(contactPreference.AssessmentId, Constants.ContactPreference, false);
                    }
                }
                else
                {
                    preferedCellUniqueId = null;
                    uniquePhoneId = null;
                }

            }
            if (contactPreference.ContactEmailId == -1)
            {
                uniqueEmailId = null;
                preferedEmailUniqueId = null;
            }
            else
            {
                var email = await _contactDetailsRepository.GetContactDetailsById(contactPreference.ContactEmailId);
                preferedEmailUniqueId = contactPreference.ContactEmailId.ToString();
                uniqueEmailId = $"{email.ContactTypeDetails.EntityType}_{email.ContactTypeDetails.ContactType}";
            }
            if (contactPreference.ContactAddressId == -1)
            {
                preferedAddressUniqueId = null;
                uniqueAddressId = null;
            }
            else
            {
                contactDetails = await _contactDetailsRepository.GetContactDetailsById(contactPreference.ContactAddressId);
                //This null check is when work address is deleted in guarantor or personal, the reference is not removed in contact preference.
                if (contactDetails.IsNull())
                {
                    var cp = await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(patientAssessment
                        .AssessmentId);
                    cp.ContactAddressId = -1;
                    _ = await _contactPreferenceRepository.UpdateContactPreference(cp);
                    //Update tab status as false
                    await UpdateTabStatus(contactPreference.AssessmentId, Constants.ContactPreference, false);
                }
                else
                {
                    preferedAddressUniqueId = contactPreference.ContactAddressId.ToString();
                    uniqueAddressId = $"{contactDetails.ContactTypeDetails.EntityType}_{contactDetails.ContactTypeDetails.ContactType}";
                }
            }


            var contactPreferenceDetails = new GetContactPreferenceDto
            {
                ContactPreferenceId = contactPreference.Id.ToString(),
                ModeOfCommunication = contactPreference.ModeOfCommunication,
                PreferedCellUniqueId = preferedCellUniqueId,
                PreferedAddressUniqueId = preferedAddressUniqueId,
                PreferedEmailUniqueId = preferedEmailUniqueId,
                TimeOfCalling = contactPreference.TimeOfCalling,
                UniqueAddressId = uniqueAddressId,
                UniquePhoneId = uniquePhoneId,
                UniqueEmailId = uniqueEmailId,
            };
            if (contactDetails.IsNotNull() && contactDetails.ContactTypeDetails.EntityType == Enums.ContactType.Other.ToString())
            {
                contactPreferenceDetails.Name = otherContactDetails.Name;
                contactPreferenceDetails.StreetAddress = otherContactDetails.StreetAddress;
                contactPreferenceDetails.Suite = otherContactDetails.Suite;
                contactPreferenceDetails.City = otherContactDetails.City;
                contactPreferenceDetails.State = otherContactDetails.State;
                contactPreferenceDetails.County = otherContactDetails.County;
                contactPreferenceDetails.Zipcode = otherContactDetails.Zip;
                contactPreferenceDetails.EmailAddress = otherContactDetails.Email;
                contactPreferenceDetails.PreferedAddressUniqueId = Constants.Zero;
                contactPreferenceDetails.UniqueAddressId = Constants.Other;
            }
            if (phone.IsNotNull() && phone.ContactTypeDetails.EntityType == Enums.ContactType.Other.ToString())
            {
                contactPreferenceDetails.PreferedCellType = otherContactDetails.PhoneType;
                contactPreferenceDetails.CountyCode = otherContactDetails.CountyCode;
                contactPreferenceDetails.CellNumber = otherContactDetails.Cell;
                contactPreferenceDetails.PreferedCellUniqueId = Constants.Zero;
                contactPreferenceDetails.UniquePhoneId = Constants.Other;
            }
            return new Result<GetContactPreferenceDto> { Data = contactPreferenceDetails };
        }

        public async Task<Result<MessageDto>> UpdateContactPreference(UpdateContactPreference updateContactPreferenceRequest)
        {
            var contactPreference = await _contactPreferenceRepository.GetContactPreferenceById(updateContactPreferenceRequest.ContactPreferenceId);
            var updatedContactPreference = _contactPreferenceMapper.MapFrom(contactPreference, updateContactPreferenceRequest);
            await _contactPreferenceRepository.UpdateContactPreference(updatedContactPreference);

            ContactDetails otherContactDetails;
            otherContactDetails = await _contactDetailsRepository.GetContactDetailsById(contactPreference.OtherContactId);

            if (updateContactPreferenceRequest.UniqueAddressId == Enums.ContactType.Other.ToString())
            {
                otherContactDetails.Name = updateContactPreferenceRequest.Name;
                otherContactDetails.StreetAddress = updateContactPreferenceRequest.StreetAddress;
                otherContactDetails.Suite = updateContactPreferenceRequest.Suite;
                otherContactDetails.City = updateContactPreferenceRequest.City;
                otherContactDetails.State = updateContactPreferenceRequest.State;
                otherContactDetails.Zip = updateContactPreferenceRequest.ZipCode;
                otherContactDetails.County = updateContactPreferenceRequest.County;
            }
            if (updateContactPreferenceRequest.UniquePhoneId == Enums.ContactType.Other.ToString())
            {
                otherContactDetails.CountyCode = updateContactPreferenceRequest.CountyCode;
                otherContactDetails.Cell = updateContactPreferenceRequest.CellNumber;
                otherContactDetails.PhoneType = updateContactPreferenceRequest.PreferredCellType;
            }
            if (updateContactPreferenceRequest.UniqueEmailId == Enums.ContactType.Other.ToString())
            {
                otherContactDetails.Email = updateContactPreferenceRequest.Email;
            }
            var isContactPreferenceUpdated = await _contactDetailsRepository.UpdateContactDetails(otherContactDetails);

            if (isContactPreferenceUpdated)
            {
                //Update tab status
                await UpdateTabStatus(updateContactPreferenceRequest.AssessmentId, Constants.ContactPreference, true);
                return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.ContactPreferenceUpdated) };
            }
            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.CouldNotUpdateContactPreference) };
        }

        public async Task<Result<MessageDto>> UpdateAssessmentStatus(UpdateAssessmentStatus assessmentStatus)
        {
            var assessment = await _assessmentRepository.GetAssessmentById(assessmentStatus.AssessmentId);
            if (assessment.IsNull()) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentNotFound) };

            var isAssessmentUpdated = await _assessmentRepository.UpdateAssessmentStatus(assessment, assessmentStatus.Status);
            if (isAssessmentUpdated) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.AssessmentStatusUpdated) };
            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentUpdateFailed) };
        }

        public async Task<Result<MessageDto>> DeleteAssessment(long assessmentId)
        {
            var assessment = await _assessmentRepository.GetAssessmentById(assessmentId);
            if (assessment.IsNull()) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentNotFound) };

            var inactiveAssessment = _assessmentMapper.MapFrom(assessment);
            var isAssessmentDeleted = await _assessmentRepository.Delete(inactiveAssessment);

            if (isAssessmentDeleted) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.AssessmentDeleteSuccess) };
            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentDeleteFailed) };
        }

        public async Task<Result<MessageDto>> CreatePatientProgramMapping(ProgramMappingRequest programMappingRequest)
        {
            var assessment = await _assessmentRepository.GetAssessmentById(programMappingRequest.AssessmentId);
            if (assessment.IsNull()) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentNotFound) };

            foreach (var programId in programMappingRequest.ProgramIdList)
            {
                var patientProgramDetails = _patientProgramMappingMapper.MapFrom(programMappingRequest.AssessmentId, programId.Id, programMappingRequest.IsEvaluated);
                //Default setting the program to apply
                patientProgramDetails.IsActive = true;

                var isPatientProgramMapped = await _patientProgramMappingRepository.CreateProgramMapping(patientProgramDetails);
                if (isPatientProgramMapped == 0) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.ProgramAlreadyExits) };
            }

            _ = await UpdateReviewProgramStatus(programMappingRequest.UpdateReviewProgramRequest);
            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.Success) };
        }
        public async Task<Result<MessageDto>> CreateProgramMapping(ProgramMappingRequest programMappingRequest)
        {
            var assessment = await _assessmentRepository.GetAssessmentById(programMappingRequest.AssessmentId);
            if (assessment.IsNull()) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.AssessmentNotFound) };

            foreach (var programName in programMappingRequest.ProgramNameList)
            {
                var program = await _programRepository.GetProgramByName(programName);
                var patientProgramDetails = _patientProgramMappingMapper.MapFrom(programMappingRequest.AssessmentId, program.Id, programMappingRequest.IsEvaluated);
                //Default setting the program to apply
                patientProgramDetails.IsActive = true;

                var isPatientProgramMapped = await _patientProgramMappingRepository.CreateProgramMapping(patientProgramDetails);
                if (isPatientProgramMapped == 0) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Error.ProgramAlreadyExits) };
            }

            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.Success) };
        }

        public async Task<Result<MessageDto>> AddReviewNotes(ReviewNotesRequest reviewNotesRequest)
        {
            foreach (var reviewNote in reviewNotesRequest.ReviewNotes)
            {
                if (!reviewNote.isNullOrEmpty())
                {
                    var reviewNotes = _reviewNotesMapper.MapFrom(reviewNote, reviewNotesRequest.AssessmentId, reviewNotesRequest.UserId);
                    var reviewNoteId = await _reviewNotesRepository.AddReviewNotes(reviewNotes);
                    if (reviewNoteId == 0) return new Result<MessageDto>().AddError(Error.CreateReviewNotesFailed);
                }
            }

            foreach (var programId in reviewNotesRequest.ProgramIdList)
            {
                _ = await _patientProgramMappingRepository?.UpdateReviewProgramStatus(programId.Id, reviewNotesRequest.AssessmentId, Constants.ApplicationSubmittedStatus);
            }

            _ = await UpdateReviewProgramStatus(reviewNotesRequest.UpdateReviewProgramRequest);

            //Update tab status
            var isProgramSubmitted = await _patientProgramMappingRepository.IsProgramSubmitted(reviewNotesRequest.AssessmentId);
            await UpdateTabStatus(reviewNotesRequest.AssessmentId, Constants.Programs, isProgramSubmitted);

            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.AddReviewNotesSuccess) };
        }

        public async Task<Result<List<ReviewNotesResponse>>> GetReviewNotes(BasePatientAssessment basePatientAssessment)
        {
            var reviewNotesList = new List<ReviewNotesResponse>();
            var reviewNotes = await _reviewNotesRepository.GetReviewNotes(basePatientAssessment.AssessmentId);
            reviewNotes.ToList().ForEach(x => reviewNotesList.Add(new ReviewNotesResponse() { ReviewNote = x.Notes, CreatedDate = x.CreatedDate.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) }));
            return new Result<List<ReviewNotesResponse>>() { Data = reviewNotesList };
        }

        public async Task<Result<Dictionary<string, string>>> GetPrograms(GetProgramsRequest getProgramsRequest)
        {
            var programList = new Dictionary<string, string>();
            var activeProgramList = new List<Program>();
            var programs = await _httpClientService.GetPrograms();

            foreach (var id in getProgramsRequest.ProgramIdList)
            {
                var prg = programs.Where(a => a.Id == id.Id).FirstOrDefault();
                if (prg.IsNotNull())
                {
                    activeProgramList.Add(prg);
                }
            }

            programs = programs.Remove(activeProgramList);
            var programsDictionary = programs.ToDictionary(x => x.Id.ToString(), y => y.Name);
            return new Result<Dictionary<string, string>>() { Data = programsDictionary };
        }

        public async Task<Result<PatientProgramResponse>> GetPatientProgram(int assessmentId)
        {
            if (PropertyValues.IsServiceMockEnabled())
                return MockPatientPrograms();

            var patientProgramRequest = await GetPatientProgramRequestForAssessmentId(assessmentId);

            var patientProgramResponse = await _healthWareSharedService.GetPatientProgram(patientProgramRequest);

            return new Result<PatientProgramResponse> { Data = patientProgramResponse };
        }

        private async Task<PatientProgramRequest> GetPatientProgramRequestForAssessmentId(int assessmentId)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(assessmentId);

            var contactIds = new List<long> { basicInfo.BasicContactId, basicInfo.WorkContactId, basicInfo.HomeContactId };

            var contactDetails = await _contactDetailsRepository.GetContactDetailsByIds(contactIds);

            var houseHoldMembers = await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(assessmentId);

            var houseHoldMemberIds = houseHoldMembers.Select(a => a.Id).ToList();
            var houseHoldMemberIncome =
                await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberIds(houseHoldMemberIds);

            var houseHoldMemberResource =
                await _houseHoldResourceRepository.GetHouseHoldResourceByHouseHoldMemberIds(houseHoldMemberIds);

            var patientAssessmentDetails = _assessmentMapper.MapFrom(basicInfo, houseHoldMembers.ToList(),
                houseHoldMemberIncome.ToList(), houseHoldMemberResource.ToList(), contactDetails);

            return patientAssessmentDetails;
        }

        private static Result<PatientProgramResponse> MockPatientPrograms()
        {
            var program1 = new DTOs.HealthWareServices.Program
            {
                ProgramName = Constants.MvaProgram,
                State = Constants.TexasState,
                Forms = new List<Form>
                {
                    new Form
                    {
                        FormName = Constants.MvaApplication,
                        FormLocation = Constants.MvaFormLocation
                    }
                }
            };

            var program2 = new DTOs.HealthWareServices.Program
            {
                ProgramName = Constants.WcProgram,
                Forms = new List<Form>
                {
                    new Form
                    {
                        FormName =Constants.WcApplication,
                        FormLocation = Constants.WcFormLocation
                    }
                },
                Documents = new List<Document>
                {
                    new Document
                    {
                        DocumentName =Constants.PhotoId
                    }
                }
            };

            var patientProgramDetails = new PatientProgramResponse
            {
                ClientInfo = new ClientInfo
                {
                    Name = string.Empty,
                    State = string.Empty,
                    FacilityCode = Constants.FacilityCode
                },
                Programs = new List<DTOs.HealthWareServices.Program>
                {
                    program1,
                    program2
                },
                HasError = false,
                HasWarning = false,
                Message = null
            };

            return new Result<PatientProgramResponse>
            {
                Data = patientProgramDetails
            };
        }

        public async Task<Result<TabStatusResponse>> GetTabCompletionStatus(TabStatusRequest tabStatusRequest)
        {
            var tabStatus = await _tabStatusRepository.GetTabStatus(tabStatusRequest.AssessmentId);
            var isHouseholdEvaluated = await _patientProgramMappingRepository.IsProgramMappingHasEvaluatedRecord(tabStatusRequest.AssessmentId);

            var tabStatusResponse = new TabStatusResponse();
            var houseHoldMembers = await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(tabStatusRequest.AssessmentId);
            if (!tabStatusRequest.IsTabOut)
            {
                tabStatusResponse.IsQuickAssessmentComplete = tabStatus.IsQuickAssessmentComplete;
                tabStatusResponse.IsPersonalInfoComplete = tabStatus.IsPersonalBasicInfoComplete.Value.Equals(true)
                                                           && tabStatus.IsPersonalHomeComplete.Value.Equals(true)
                                                            ? true : (bool?)null;
                tabStatusResponse.IsPersonalBasicInfoComplete = tabStatus.IsPersonalBasicInfoComplete;
                tabStatusResponse.IsPersonalHomeComplete = tabStatus.IsPersonalHomeComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsPersonalWorkComplete = tabStatus.IsPersonalWorkComplete is true ? true : (bool?)null;

                tabStatusResponse.IsGuarantorInfoComplete = tabStatus.IsGuarantorBasicInfoComplete.Value.Equals(true)
                                                            && tabStatus.IsGuarantorHomeComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsGuarantorBasicInfoComplete = tabStatus.IsGuarantorBasicInfoComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsGuarantorHomeComplete = tabStatus.IsGuarantorHomeComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsGuarantorWorkComplete = tabStatus.IsGuarantorWorkComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsContactPreferenceComplete = tabStatus.IsContactPreferenceComplete is true ? true : (bool?)null;
                tabStatusResponse.IsHouseholdComplete = tabStatus.IsHouseholdComplete.Value.Equals(true) ? true : (bool?)null;
                foreach (var houseHoldMember in houseHoldMembers)
                {
                    if (houseHoldMember.FirstName.IsNull() || houseHoldMember.LastName.IsNull() ||
                        houseHoldMember.Relationship.IsNull() || houseHoldMember.Gender.IsNull() ||
                        houseHoldMember.DateOfBirth == null ||
                        (houseHoldMember.SSNNumber.IsNull() && houseHoldMember.ReasonNoSsn.IsNull()) ||
                        houseHoldMember.IsMedicAidAvailable == null || houseHoldMember.IsMedicAidAvailable == null ||
                        houseHoldMember.IsDependent == null)
                    {
                        tabStatusResponse.IsHouseholdComplete = false;
                        break;
                    }
                }

                tabStatusResponse.IsHouseholdEvaluated = isHouseholdEvaluated;
                if (tabStatus.IsQuickAssessmentComplete.Value.Equals(false) ||
                    tabStatusResponse.IsPersonalInfoComplete.Equals(null) ||
                    tabStatusResponse.IsGuarantorInfoComplete.Equals(null) ||
                    tabStatus.IsContactPreferenceComplete.Value.Equals(false) ||
                    tabStatus.IsHouseholdComplete.Value.Equals(false))
                {
                    tabStatusResponse.CanEvaluate = false;
                }
                else
                {
                    tabStatusResponse.CanEvaluate = true;
                }
                if (isHouseholdEvaluated)
                {
                    tabStatusResponse.IsApplicationFormEnabled = true;
                }
                else
                {
                    tabStatusResponse.IsApplicationFormEnabled = false;
                }
                tabStatusResponse.IsApplicationFormsComplete = tabStatus.IsApplicationFormsComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsProgramsComplete = tabStatus.IsProgramsComplete is true ? true : (bool?)null;
                tabStatusResponse.IsVerificationComplete = tabStatus.IsEmailVerificationComplete.Value.Equals(true)
                                                           && tabStatus.IsIncomeVerificationComplete.Value.Equals(true) ? true : (bool?)null;
                tabStatusResponse.IsEmailVerificationComplete = tabStatus.IsEmailVerificationComplete is true ? true : (bool?)null;
                tabStatusResponse.IsCellVerificationComplete = tabStatus.IsCellVerificationComplete is true ? true : (bool?)null;
                tabStatusResponse.IsIdVerificationComplete = tabStatus.IsIdVerificationComplete is true ? true : (bool?)null; ;
                tabStatusResponse.IsAddressVerificationComplete = tabStatus.IsAddressVerificationComplete is true ? true : (bool?)null;
                tabStatusResponse.IsIncomeVerificationComplete = tabStatus.IsIncomeVerificationComplete is true ? true : (bool?)null; ;
                tabStatusResponse.IsOtherVerificationComplete = tabStatus.IsOtherVerificationComplete is true ? true : (bool?)null; ;
            }
            else
            {
                tabStatusResponse.IsQuickAssessmentComplete = tabStatus.IsQuickAssessmentComplete;
                tabStatusResponse.IsPersonalInfoComplete = tabStatus.IsPersonalWorkComplete != null && tabStatus.IsPersonalBasicInfoComplete != null && tabStatus.IsPersonalHomeComplete != null && (tabStatus.IsPersonalBasicInfoComplete.Value.Equals(true)
                    && tabStatus.IsPersonalHomeComplete.Value.Equals(true)
                    && tabStatus.IsPersonalWorkComplete.Value.Equals(true));
                tabStatusResponse.IsPersonalBasicInfoComplete = tabStatus.IsPersonalBasicInfoComplete;
                tabStatusResponse.IsPersonalHomeComplete = tabStatus.IsPersonalHomeComplete != null && tabStatus.IsPersonalHomeComplete.Value ? tabStatus.IsPersonalHomeComplete : false;
                tabStatusResponse.IsPersonalWorkComplete = tabStatus.IsPersonalWorkComplete != null && tabStatus.IsPersonalWorkComplete.Value ? tabStatus.IsPersonalWorkComplete : false;

                tabStatusResponse.IsGuarantorInfoComplete = tabStatus.IsGuarantorWorkComplete != null &&
                                                            tabStatus.IsGuarantorHomeComplete != null &&
                                                            tabStatus.IsGuarantorBasicInfoComplete != null &&
                                                            (tabStatus.IsGuarantorBasicInfoComplete.Value.Equals(true)
                                                             && tabStatus.IsGuarantorHomeComplete.Value.Equals(true)
                                                             && tabStatus.IsGuarantorWorkComplete.Value.Equals(true));
                tabStatusResponse.IsGuarantorBasicInfoComplete = tabStatus.IsGuarantorBasicInfoComplete;
                tabStatusResponse.IsGuarantorHomeComplete = tabStatus.IsGuarantorHomeComplete != null && tabStatus.IsGuarantorHomeComplete.Value ? tabStatus.IsGuarantorHomeComplete : false;
                tabStatusResponse.IsGuarantorWorkComplete = tabStatus.IsGuarantorWorkComplete != null && tabStatus.IsGuarantorWorkComplete.Value ? tabStatus.IsGuarantorWorkComplete : false;
                //Replace true with dynamic data
                tabStatusResponse.IsContactPreferenceComplete = true;
                tabStatusResponse.IsHouseholdComplete = tabStatus.IsHouseholdComplete;
                tabStatusResponse.IsHouseholdComplete = tabStatus.IsHouseholdComplete is true ? true : (bool?)null;
                foreach (var houseHoldMember in houseHoldMembers)
                {
                    if (houseHoldMember.FirstName.IsNull() || houseHoldMember.LastName.IsNull() ||
                        houseHoldMember.Relationship.IsNull() || houseHoldMember.Gender.IsNull() ||
                        houseHoldMember.DateOfBirth == null ||
                        (houseHoldMember.SSNNumber.IsNull() && houseHoldMember.ReasonNoSsn.IsNull()) ||
                        houseHoldMember.IsMedicAidAvailable == null || houseHoldMember.IsMedicAidAvailable == null ||
                        houseHoldMember.IsDependent == null)
                    {
                        tabStatusResponse.IsHouseholdComplete = false;
                        break;
                    }
                }
                if (tabStatusResponse.IsPersonalInfoComplete == null ||
                    tabStatusResponse.IsGuarantorInfoComplete == null)
                {
                    tabStatusResponse.IsHouseholdEvaluated = false;
                }
                else if (tabStatus.IsHouseholdComplete.Value.Equals(true) && tabStatus.IsContactPreferenceComplete != null && tabStatus.IsQuickAssessmentComplete is true && tabStatusResponse.IsPersonalInfoComplete.Value.Equals(true)
                         && tabStatusResponse.IsGuarantorInfoComplete.Value.Equals(true) && tabStatus.IsContactPreferenceComplete.Value.Equals(true) && tabStatus.IsHouseholdComplete.Value.Equals(true))
                {
                    tabStatusResponse.IsHouseholdEvaluated = true;
                }
                tabStatusResponse.IsApplicationFormsComplete = tabStatus.IsApplicationFormsComplete;
                tabStatusResponse.IsVerificationComplete = tabStatus.IsIncomeVerificationComplete is { } && tabStatus.IsEmailVerificationComplete is true && tabStatus.IsIncomeVerificationComplete.Value.Equals(true);
                tabStatusResponse.IsEmailVerificationComplete = tabStatus.IsEmailVerificationComplete;
                tabStatusResponse.IsCellVerificationComplete = tabStatus.IsCellVerificationComplete;
                tabStatusResponse.IsIdVerificationComplete = tabStatus.IsIdVerificationComplete;
                tabStatusResponse.IsAddressVerificationComplete = tabStatus.IsAddressVerificationComplete;
                tabStatusResponse.IsIncomeVerificationComplete = tabStatus.IsIncomeVerificationComplete;
                tabStatusResponse.IsOtherVerificationComplete = tabStatus.IsOtherVerificationComplete;
            }
            return new Result<TabStatusResponse>() { Data = tabStatusResponse };
        }

        public async Task UpdateTabStatus(long assessmentId, string tabName, bool isValid)
        {
            var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);
            switch (tabName)
            {
                case Constants.PersonalHome:
                    tabStatus.IsPersonalHomeComplete = isValid;
                    break;
                case Constants.PersonalWork:
                    tabStatus.IsPersonalWorkComplete = isValid;
                    break;
                case Constants.GuarantorInfo:
                    tabStatus.IsGuarantorBasicInfoComplete = isValid;
                    break;
                case Constants.GuarantorHomeTab:
                    tabStatus.IsGuarantorHomeComplete = isValid;
                    break;
                case Constants.GuarantorWorkTab:
                    tabStatus.IsGuarantorWorkComplete = isValid;
                    break;
                case Constants.ContactPreference:
                    tabStatus.IsContactPreferenceComplete = isValid;
                    break;
                case Constants.Household:
                    var houseHoldMembers = await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(assessmentId);
                    foreach (var houseHoldMember in houseHoldMembers)
                    {
                        if (houseHoldMember.FirstName.IsNull() || houseHoldMember.LastName.IsNull() ||
                            houseHoldMember.Relationship.IsNull() || houseHoldMember.Gender.IsNull() ||
                            houseHoldMember.DateOfBirth == null ||
                            (houseHoldMember.SSNNumber.IsNull() && houseHoldMember.ReasonNoSsn.IsNull()) ||
                            houseHoldMember.IsMedicAidAvailable == null || houseHoldMember.IsMedicAidAvailable == null ||
                            houseHoldMember.IsDependent == null)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    tabStatus.IsHouseholdComplete = isValid;
                    break;
                case Constants.ApplicationForms:
                    tabStatus.IsApplicationFormsComplete = isValid;
                    break;
                case Constants.Programs:
                    tabStatus.IsProgramsComplete = isValid;
                    break;
                case Constants.EmailVerification:
                    tabStatus.IsEmailVerificationComplete = isValid;
                    break;
                case Constants.CellVerification:
                    tabStatus.IsCellVerificationComplete = isValid;
                    break;
            }
            _ = await _tabStatusRepository.Update(tabStatus);
        }
        public async Task<Result<AssessmentEvaluationResponse>> EvaluateAssessment(BasePatientAssessment basePatientAssessment)
        {
            //If assessment is created for relative then validate no of household members.
            var quickAssessmentResult = await _answerRepository.GetQuestionAnswerJson(basePatientAssessment.AssessmentId);
            string patientType = string.Empty;
            if(quickAssessmentResult == null && Convert.ToString(basePatientAssessment.AssessmentId) != null)
            {
                patientType = "OtherApplicant1";
            }
            else
            {
                var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessmentResult.QuestionAnswerJson);
                patientType = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
            }
            var isGuarantorMemberPresent = true;
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(basePatientAssessment.AssessmentId);
            if (patientType == "Myself")
            {
                var isSelfMemberPresent = await _houseHoldMemberRepository.GetSelfHouseHoldMember(basePatientAssessment.AssessmentId);
                if (isSelfMemberPresent.IsNull()) return new Result<AssessmentEvaluationResponse>().AddError(Constants.SelfHouseholdNotFound);

                if (guarantor.RelationShipWithPatient != "Self")
                {
                    isGuarantorMemberPresent = await _houseHoldMemberRepository.IsGuarantorMemberPresent(guarantor.SSNNumber, guarantor.RelationShipWithPatient);
                }
                if (!isGuarantorMemberPresent) return new Result<AssessmentEvaluationResponse>().AddError(Constants.GuarantorHouseholdNotFound);
            }
            else
            {
                var user = _currentHttpContext.GetCurrentUser();
                var isSelfMemberPresent = await _houseHoldMemberRepository.GetSelfHouseHoldMember(basePatientAssessment.AssessmentId);
                if (isSelfMemberPresent.IsNull()) return new Result<AssessmentEvaluationResponse>().AddError(Constants.SelfHouseholdNotFound);

                var isAccountOwnerPresent = await _houseHoldMemberRepository.IsAccountOwnerAMember(basePatientAssessment.AssessmentId, user.Identity.Name);
                if (!isAccountOwnerPresent && patientType != "OtherApplicant1") return new Result<AssessmentEvaluationResponse>().AddError(Constants.AccountOwnerHouseholdNotFound);


                if (guarantor.RelationShipWithPatient != "Self")
                {
                    isGuarantorMemberPresent = await _houseHoldMemberRepository.IsGuarantorMemberPresent(guarantor.SSNNumber, guarantor.RelationShipWithPatient);
                }
                if (!isGuarantorMemberPresent) return new Result<AssessmentEvaluationResponse>().AddError(Constants.GuarantorHouseholdNotFound);

            }
            //Delete Program mapping if exists
            var programMappings =
                await _patientProgramMappingRepository.GetEvaluatedPrograms(basePatientAssessment.AssessmentId);
            foreach (var mapping in programMappings)
            {
                var isProgramDeleted = await _patientProgramMappingRepository.DeleteProgramMapping(mapping);

            }
            //Delete Document and Document program mapping records.
            var document = await _documentRepository.GetDocumentByAssessmentIdTypeId(basePatientAssessment.AssessmentId, 12, 0);
            if (document.IsNotNull())
            {
                //Delete DocumentProgramMapping
                var documentProgramMappings =
                    await _documentProgramMappingRepository.GetProgramDocumentMappingByDocumentId(document.Id);
                foreach (var documentProgramMapping in documentProgramMappings)
                {
                    await _documentProgramMappingRepository.DeleteDocumentProgramMapping(documentProgramMapping);
                }

                await _documentRepository.DeleteDocument(document);
                UpdateTabStatus(basePatientAssessment.AssessmentId, Constants.ApplicationForms, false);
            }
            var programsResponse = _httpClientService.GetProgramsResponse(true);
            var programs = await _programRepository.GetAllPrograms();
            foreach (var program in programsResponse.Programs)
            {
                var isProgramPresent = programs.Any(prg => prg.Name == program.ProgramName);
                if (!isProgramPresent)
                {
                    var programMapper = _programMapper.MapFrom(program.ProgramName, program.ProgramDescription,
                        program.BenefitsDescriptionUrl);
                    var programId = await _programRepository.CreateProgram(programMapper);
                    foreach (var form in program.Forms)
                    {
                        var programDocumentMapper = _programDocumentMapper.MapFrom(programId, form.FormName,
                            form.FormLocation, form.EsignFlag);
                        var programDocumentId = await _programDocumentRepository.CreateProgramDocument(programDocumentMapper);
                    }
                }

                var programEntity = await _programRepository.GetProgramByName(program.ProgramName);
                var isPatientProgramExists = await _patientProgramMappingRepository.GetEvaluatedGetMapping(basePatientAssessment.AssessmentId,
                        programEntity.Id);
                if (isPatientProgramExists.IsNotNull())
                {
                    isPatientProgramExists.IsActive = true;
                    isPatientProgramExists.IsEvaluated = true;
                    await _patientProgramMappingRepository.UpdatePatientProgram(isPatientProgramExists);
                }
                else
                {
                    var patientProgramMapping = _patientProgramMappingMapper.MapFrom(basePatientAssessment.AssessmentId, programEntity.Id, true);
                    var patientProgramMappingId = await _patientProgramMappingRepository.CreateProgramMapping(patientProgramMapping);
                }
            }

            var assessment = await _assessmentRepository.GetAssessmentById(basePatientAssessment.AssessmentId);
            var isAssessmentUpdated = await _assessmentRepository.UpdateAssessmentIsEvaluated(assessment);

            HashSet<string> sentIDs = new HashSet<string>(programsResponse.Programs.Select(s => s.ProgramName));
            var results = programsResponse.AllPrograms.Where(m => !sentIDs.Contains(m.ProgramName)).ToList();

            var updatedPrograms = await _programRepository.GetAllPrograms();
            var programIdList = new Dictionary<long, string>();
            foreach (var program in results)
            {
                long programId = 0;

                //Check whether program from API response is present in Program table. 
                var isProgramPresent = updatedPrograms.Any(prg => prg.Name == program.ProgramName);

                //If the program from API response is not present in Program table then create a record Program and Program Document table.
                if (!isProgramPresent)
                {
                    var programMapper = _programMapper.MapFrom(program.ProgramName, program.ProgramDescription,
                        program.BenefitsDescriptionUrl);
                    programId = await _programRepository.CreateProgram(programMapper);
                    foreach (var form in program.Forms)
                    {
                        var programDocumentMapper = _programDocumentMapper.MapFrom(programId, form.FormName,
                            form.FormLocation, form.EsignFlag);
                        var programDocumentId = await _programDocumentRepository.CreateProgramDocument(programDocumentMapper);
                    }
                    programIdList.Add(programId, program.ProgramName);
                }
                else
                {
                    var program1 = await _programRepository.GetProgramByName(program.ProgramName);
                    programIdList.Add(program1.Id, program1.Name);
                }
            }
            var assessmentEvaluationResponse = new AssessmentEvaluationResponse();
            assessmentEvaluationResponse.ProgramNames = programsResponse.Programs.Select(a => a.ProgramName).ToList();
            assessmentEvaluationResponse.Override = programsResponse.Override;
            assessmentEvaluationResponse.ProgramsOpted = programsResponse.Programs.Select(a => a.ProgramName).ToList();
            if (programsResponse.Override)
            {
                assessmentEvaluationResponse.AllPrograms = results.Select(a => a.ProgramName).ToList();
                //assessmentEvaluationResponse.AllPrograms = programIdList;
            }
            else
            {
                assessmentEvaluationResponse.AllPrograms = null;
            }
            return new Result<AssessmentEvaluationResponse>()
            { Data = assessmentEvaluationResponse };
        }
        public async Task<Result<ReviewProgramResponse>> GetEvaluatedPrograms(BasePatientAssessment patientAssessment)
        {
            var patientProgramMappings = await _patientProgramMappingRepository.GetEvaluatedPrograms
                (patientAssessment.AssessmentId);

            var reviewPrograms = new List<ReviewProgramsResponseDto>();
            foreach (var patientProgramMapping in patientProgramMappings)
            {
                var reviewProgram = new ReviewProgramsResponseDto()
                {
                    ProgramId = patientProgramMapping.Program.Id,
                    ProgramName = patientProgramMapping.Program.Name,
                    Benefits = patientProgramMapping.Program.Details,
                    Status = patientProgramMapping.Status,
                    BenefitsUrl = patientProgramMapping.Program.BenefitsDescriptionUrl,
                    IsActive = patientProgramMapping.IsActive
                };
                reviewPrograms.Add(reviewProgram);
            }

            var reviewProgramResponse = new ReviewProgramResponse
            {
                ReviewPrograms = reviewPrograms
            };
            return new Result<ReviewProgramResponse>()
            { Data = reviewProgramResponse };
        }
    }
}
