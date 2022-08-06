using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.Repository;
using Healthware.Core.Security;
using Healthware.Core.Utility;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using HealthWare.ActiveASSIST.Web.Common.HttpClient;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Option = HealthWare.ActiveASSIST.DTOs.Option;
using Question = HealthWare.ActiveASSIST.DTOs.Question;
using Screen = HealthWare.ActiveASSIST.DTOs.Screen;
using StringExtensions = Healthware.Core.Extensions.StringExtensions;


namespace HealthWare.ActiveASSIST.Services
{
    public interface IQuickAssessmentService
    {
        Result<AssessmentRoot> QuickAssessment();
        Task<Result<AssessmentEvaluationResponse>> CreateNewAssessment(CreateAssessment createAssessmentDto);
        Task<Result<AssessmentEvaluationResponse>> CreateNewAdvocateAssessment(CreateAssessment createAssessmentDto);
        Result<AssessmentRoot> QuickAssessment(string assessmentId);
        Task<Result<CityStateResponse>> GetStateAndCounty(string zipcode);
        Task<Result<QuickAssessmentSelfResponse>> GetSelfDetails(long userId);
        Task<Result<QuickAssessmentSelfResponse>> GetBasicInfoSelfDetails(long patientId);
        Task<Result<ValidatePolicyNumberResponse>> ValidatePolicyNumber(string policyNumber);
        Task<Result<bool>> IsUserNameExists(string emailAddress);
        Task<Result<string>> GetUserNameInfo(string emailAddress);
        Task<Result<QuickAssessmentQuestionsDto>> GetDynamicScreens(long tenantId);
        Task<Result<GetPatientNamesResponse>> GetAdvocatePatients(GetPatientNamesRequest getPatientNamesRequest);
        Task<Result<string>> GetPartialAssessment(int partialSaveId);
        Task<Result<PartialSaveResponse>> SavePartialAssessment(string questionAnswerJson);
        Task<Result<MessageDto>> UpdatePartialAssessment(PartialSaveResponse partialSaveResponse);
        Task<Result<MessageDto>> DeletePartialAssessment(long quickAssessmentResultId);
    }
    public class QuickAssessmentService : IQuickAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentMapper _assessmentMapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerMapper _answerMapper;
        private readonly IPatientProgramMappingRepository _patientProgramMappingRepository;
        private readonly IPatientProgramMappingMapper _patientProgramMappingMapper;
        private readonly IProgramRepository _programRepository;
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        private readonly IContactDetailsMapper _contactDetailsMapper;
        private readonly IAssessmentVerificationRepository _assessmentVerificationRepository;
        private readonly IAssessmentVerificationMapper _assessmentVerificationMapper;
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpClientService _httpClientService;
        private readonly IBasicInfoMapper _basicInfoMapper;
        private readonly IUserHasRolesRepository _userHasRolesRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IGuarantorRepository _guarantorRepository;
        private readonly IGuarantorMapper _guarantorMapper;
        private readonly ITabStatusRepository _tabStatusRepository;
        private readonly ITabStatusMapper _tabStatusMapper;
        private readonly IDynamicScreensMapper _dynamicScreensMapper;
        private readonly IHouseHoldMapper _houseHoldMapper;
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly IVerificationDocumentRepository _verificationDocumentRepository;
        private readonly ICurrentHttpContext _currentHttpContext;
        private readonly IProgramMapper _programMapper;
        private readonly IProgramDocumentMapper _programDocumentMapper;
        private readonly IProgramDocumentRepository _programDocumentRepository;

        public QuickAssessmentService(IAssessmentRepository assessmentRepository, IAnswerRepository answerRepository,
            IAnswerMapper answerMapper, IAssessmentMapper assessmentMapper, IPatientProgramMappingMapper patientProgramMappingMapper,
            IPatientProgramMappingRepository patientProgramMappingRepository, IProgramRepository programRepository, IContactDetailsRepository<PatientDbContext> contactDetailsRepository,
            IContactDetailsMapper addressMapper, IAssessmentVerificationRepository assessmentVerificationRepository,
            IAssessmentVerificationMapper assessmentVerificationMapper, IBasicInfoRepository basicInfoRepository, IUserRepository userRepository,
            IHttpClientService httpClientService, IBasicInfoMapper basicInfoMapper, IUserHasRolesRepository userHasRolesRepository,
            IRoleRepository roleRepository, IGuarantorRepository guarantorRepository, IGuarantorMapper guarantorMapper, ITabStatusRepository tabStatusRepository, ITabStatusMapper tabStatusMapper
            , IDynamicScreensMapper dynamicScreensMapper, IHouseHoldMapper houseHoldMapper, IHouseHoldMemberRepository houseHoldMemberRepository,
            IVerificationDocumentRepository verificationDocumentRepository, ICurrentHttpContext currentHttpContext, IProgramMapper programMapper, IProgramDocumentMapper programDocumentMapper, IProgramDocumentRepository programDocumentRepository)
        {
            _assessmentRepository = assessmentRepository;
            _answerRepository = answerRepository;
            _answerMapper = answerMapper;
            _assessmentMapper = assessmentMapper;
            _patientProgramMappingMapper = patientProgramMappingMapper;
            _patientProgramMappingRepository = patientProgramMappingRepository;
            _programRepository = programRepository;
            _contactDetailsRepository = contactDetailsRepository;
            _contactDetailsMapper = addressMapper;
            _assessmentVerificationRepository = assessmentVerificationRepository;
            _assessmentVerificationMapper = assessmentVerificationMapper;
            _basicInfoRepository = basicInfoRepository;
            _userRepository = userRepository;
            _httpClientService = httpClientService;
            _basicInfoMapper = basicInfoMapper;
            _userHasRolesRepository = userHasRolesRepository;
            _roleRepository = roleRepository;
            _guarantorRepository = guarantorRepository;
            _guarantorMapper = guarantorMapper;
            _tabStatusRepository = tabStatusRepository;
            _tabStatusMapper = tabStatusMapper;
            _dynamicScreensMapper = dynamicScreensMapper;
            _houseHoldMapper = houseHoldMapper;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _verificationDocumentRepository = verificationDocumentRepository;
            _currentHttpContext = currentHttpContext;
            _programMapper = programMapper;
            _programDocumentMapper = programDocumentMapper;
            _programDocumentRepository = programDocumentRepository;
        }

        public Result<AssessmentRoot> QuickAssessment()
        {
            var roleName = _currentHttpContext.GetCurrentUserRole();
            var assessmentList = _userRepository.GetAssessmentList();
            var assessmentResults = assessmentList.ToList();
            var screens = assessmentResults.Select(a => a.ScreenId).Distinct().ToList();
            var assessmentRoot = new AssessmentRoot();
            var screenList = new List<Screen>();
            foreach (var screenId in screens)
            {
                var screen = new Screen
                {
                    ScreenId = screenId.ToString(),
                    ScreenName = assessmentResults.Where(c => c.ScreenId == screenId).Select(a => a.Name)
                        .FirstOrDefault(),
                    LeftPanelContent = assessmentResults.Where(c => c.ScreenId == screenId).Select(a => a.Content)
                        .FirstOrDefault(),
                    LeftDescription = assessmentResults.Where(c => c.ScreenId == screenId).Select(a => a.Description)
                        .FirstOrDefault()
                };
                var questions = assessmentResults.Where(a => a.ScreenId == screenId).Select(a => a.QuestionId).Distinct().ToList();
                questions.Sort();

                var sQuestionIdList = new List<int>();
                var questionList = new List<Question>();
                foreach (var questionId in questions)
                {
                    if (!sQuestionIdList.Contains((int)questionId))
                    {
                        var question = new Question
                        {
                            Id = questionId.ToString(),
                            Name = assessmentResults.Where(c => c.QuestionId == questionId).Select(a => a.QuestionName)
                                .FirstOrDefault(),
                            UIType = assessmentResults.Where(c => c.QuestionId == questionId).Select(a => a.ControlType)
                                .FirstOrDefault(),
                            DisplayFormat = assessmentResults.Where(c => c.QuestionId == questionId)
                                .Select(a => a.DisplayFormat)
                                .FirstOrDefault(),
                            KeyName = assessmentResults.Where(c => c.QuestionId == questionId)
                                .Select(a => a.QuestionKeyName)
                                .FirstOrDefault(),
                            ScreenQuestionMappingId = assessmentResults.Where(c => c.QuestionId == questionId)
                                .Select(a => a.ScreenQuestionMappingId)
                                .FirstOrDefault(),
                            IsRequired = assessmentResults.Where(c => c.QuestionId == questionId).Select(a => a.IsRequired)
                                .FirstOrDefault()
                        };

                        var optionIdList = assessmentResults.Where(c => c.QuestionId == questionId).Select(a => a.OptionId).ToList();

                        if (optionIdList[0] != null)
                        {
                            var optionList = optionIdList.Select(optionId => new Option
                            {
                                Id = optionId.ToString(),
                                Name = assessmentResults.Where(c => c.QuestionId == questionId && c.OptionId == optionId)
                                        .Select(a => a.KeyName)
                                        .FirstOrDefault(),
                                Value = assessmentResults.Where(c => c.QuestionId == questionId && c.OptionId == optionId)
                                        .Select(a => a.Value)
                                        .FirstOrDefault(),
                                Order = (int)assessmentResults.Where(c => c.QuestionId == questionId && c.OptionId == optionId)
                                        .Select(a => a.Order)
                                        .FirstOrDefault()
                            })
                                .ToList();
                            question.Options = optionList;
                        }
                        else
                        {
                            question.Options = null;
                        }

                        var subQuestionIdList = assessmentResults.Where(c => c.ParentId == questionId).Select(a => a.QuestionId).Distinct().ToList();
                        var subQuestionList = new List<Question>();
                        if (subQuestionList.Count == 0) question.SubQuestion = null;
                        foreach (var subQuestionId in subQuestionIdList)
                        {
                            if (subQuestionId == 0) continue;
                            var subQuestion = SubQuestion((int)subQuestionId, assessmentResults);
                            subQuestionList.Add(subQuestion);
                            sQuestionIdList.Add((int)subQuestionId);
                        }
                        var sQuestion = new SubQuestion
                        {
                            Question = subQuestionList
                        };
                        question.SubQuestion = sQuestion;

                        questionList.Add(question);
                    }
                }

                Question SubQuestion(int questionId, IEnumerable<AssessmentResult> assessmentList)
                {
                    var enumerable = assessmentList.ToList();
                    var question = new Question
                    {
                        Id = questionId.ToString(),
                        Name = enumerable.Where(c => c.QuestionId == questionId).Select(a => a.QuestionName)
                            .FirstOrDefault(),
                        UIType = enumerable.Where(c => c.QuestionId == questionId).Select(a => a.ControlType)
                            .FirstOrDefault(),
                        DisplayFormat = enumerable.Where(c => c.QuestionId == questionId)
                            .Select(a => a.DisplayFormat)
                            .FirstOrDefault(),
                        KeyName = enumerable.Where(c => c.QuestionId == questionId)
                            .Select(a => a.QuestionKeyName)
                            .FirstOrDefault(),
                        ScreenQuestionMappingId = enumerable.Where(c => c.QuestionId == questionId)
                            .Select(a => a.ScreenQuestionMappingId)
                            .FirstOrDefault()
                    };

                    var optionIdList = enumerable.Where(c => c.QuestionId == questionId).Select(a => a.OptionId).ToList();

                    if (optionIdList[0] != null)
                    {
                        var optionList = optionIdList.Select(optionId => new Option
                        {
                            Id = optionId.ToString(),
                            Name = enumerable.Where(c => c.QuestionId == questionId && c.OptionId == optionId)
                                    .Select(a => a.KeyName)
                                    .FirstOrDefault(),
                            Value = enumerable.Where(c => c.QuestionId == questionId && c.OptionId == optionId)
                                    .Select(a => a.Value)
                                    .FirstOrDefault()
                        })
                            .ToList();
                        question.Options = optionList;
                    }
                    else
                    {
                        question.Options = null;
                    }

                    var subQuestionIdList = enumerable.Where(c => c.ParentId == questionId).Select(a => a.QuestionId).Distinct().ToList();

                    foreach (var subQuestionId in subQuestionIdList)
                    {
                        if (subQuestionId != 0)
                        {
                            var subQuestion = SubQuestion((int)subQuestionId, enumerable);
                            var subQuestionList = new List<Question> { subQuestion };
                            sQuestionIdList.Add((int)subQuestionId);

                            var sQuestion = new SubQuestion { Question = subQuestionList };

                            question.SubQuestion = sQuestion;
                        }
                    }
                    return question;
                }
                screen.Questions = questionList;
                screenList.Add(screen);
            }

            assessmentRoot.screen = screenList;
            return new Result<AssessmentRoot>()
            { Data = assessmentRoot };
        }


        public async Task<Result<AssessmentEvaluationResponse>> CreateNewAssessment(CreateAssessment createAssessmentDto)
        {
            var values = JsonConvert.DeserializeObject<List<JsonObject>>(createAssessmentDto.QuestionAndAnswersJson);
            var patientType = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Patient))?[Constants.Patient];
            //if (Convert.ToInt64(createAssessmentDto.SSN) % 2 != 0) return new Result<AssessmentEvaluationResponse>().AddError(Error.EvaluationFailed);
            if (createAssessmentDto.SSN != null)
            {
                var existingIncompletePatients = await _basicInfoRepository.GetAllBasicInfo(x =>
                    x.SSNNumber == createAssessmentDto.SSN &&
                    x.Assessment.CreatedBy == createAssessmentDto.LoggedInUserId &&
                    x.Assessment.AssessmentStatusMaster.AssessmentStatus == Constants.AssessmentIncomplete && x.Assessment.IsActive == true && x.Assessment.ExternalPatientId == createAssessmentDto.BasicInfoId);
                if (existingIncompletePatients.Any())
                    return new Result<AssessmentEvaluationResponse>().AddError(
                        createAssessmentDto.BasicInfoId == Constants.ZeroAsNumber &&
                        patientType == Constants.Myself
                            ? Error.OpenAssessmentAlreadyExistsSelf
                            : Error.OpenAssessmentAlreadyExists);
            }
            

            var assessmentEvaluationResponse = new AssessmentEvaluationResponse();
            var cellNumber = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.CellNumberProperty))?[Constants.CellNumberProperty];
            var email = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Email))?[Constants.Email];
            var firstName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.FirstName))?[Constants.FirstName];
            var middleName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.MiddleName))?[Constants.MiddleName];
            var lastName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.LastName))?[Constants.LastName];
            var dateOfBirth =
                ((string)values.FirstOrDefault(x => x.ContainsKey(Constants.DateOfBirth))?[Constants.DateOfBirth] ??
                 string.Empty).ConvertStringToDate();
            var gender = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Gender))?[Constants.Gender];
            var maritalStatus = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.MaritalStatus))?[Constants.MaritalStatus];
            var loggedInUser = await _userRepository.GetUserById(createAssessmentDto.LoggedInUserId);
            var loggedInUserHasRole = await _userHasRolesRepository.GetUserRoleByUserId(loggedInUser.Id);
            var loggedInRole = await _roleRepository.FindByIdAsync(loggedInUserHasRole.Role.Id.ToString(), cancellationToken: CancellationToken.None);
            var isInsuranceAvailable = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Insurance))?[Constants.Insurance];

            //var payerName = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(16));
            var payerName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.PayerName))?[Constants.PayerName];
            var groupName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Groupname))?[Constants.Groupname];
            var groupNumber = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.GroupNo))?[Constants.GroupNo];
            var policyNumber = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.PolicyNo))?[Constants.PolicyNo];
            var effectiveFrom = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.EffectiveFrom))?[Constants.EffectiveFrom];
            var termination = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Termination))?[Constants.Termination];

            //Create a new assessment.
            var assessment = _assessmentMapper.MapFrom(createAssessmentDto.LoggedInUserId);
            if (loggedInRole.RoleName.Equals(Entities.Master.Roles.Advocate.RoleName))
            {
                if (assessment != null) assessment.ExternalPatientId = createAssessmentDto.BasicInfoId;
            }

            var assessmentId = await _assessmentRepository.CreateAssessment(assessment);
            _ = await _verificationDocumentRepository.CreateVerificationDocument(new Entities.VerificationDocument()
            { Assessment = new Assessment() { Id = assessmentId } });

            if (loggedInRole.RoleName.Equals(Entities.Master.Roles.Advocate.RoleName))
            {
                var newBasicInfo = _basicInfoMapper.CreateMapFrom(createAssessmentDto, firstName,middleName, lastName,
                    dateOfBirth, gender, maritalStatus, email, cellNumber);
                newBasicInfo.Assessment = new Assessment { Id = assessmentId };
                var newBasicInfoId = await _basicInfoRepository.CreateBasicInfo(newBasicInfo);
                createAssessmentDto.BasicInfoId = newBasicInfoId;

                assessmentEvaluationResponse.Gender = newBasicInfo.Gender;
                assessmentEvaluationResponse.Age = (DateTime.Today.Year - newBasicInfo.DateOfBirth.Year).ToString();
                assessmentEvaluationResponse.FullName = newBasicInfo.FirstName + StringExtensions.Space + newBasicInfo.LastName;
                assessmentEvaluationResponse.BasicInfoId = newBasicInfoId;
                assessmentEvaluationResponse.AssessmentStatus = Constants.AssessmentIncomplete;

                //Create Self household member
                var houseHoldMember = _houseHoldMapper.MapFrom(newBasicInfo, !isInsuranceAvailable.Equals("No"));
                if (isInsuranceAvailable.Equals("Yes"))
                {
                    houseHoldMember.PayerName = payerName;
                    houseHoldMember.GroupName = groupName;
                    houseHoldMember.GroupNumber = groupNumber;
                    houseHoldMember.PolicyNumber = policyNumber;
                    houseHoldMember.PriorCoverageEffectiveFrom = effectiveFrom.ConvertStringToDate();
                    houseHoldMember.PriorCoverageTerminationDate = termination.IsNotNull() ? termination.ConvertStringToDate() : (DateTime?)null;
                }
                var householdMemberId = await _houseHoldMemberRepository.CreateHouseHoldMember(houseHoldMember);
            }

            var quickAssessmentResultEntity = await _answerRepository.GetPartialAssessmentById(createAssessmentDto.QuickAssessmentResultId);
            quickAssessmentResultEntity.Assessment = new Assessment() {Id = assessmentId};
            quickAssessmentResultEntity.QuestionAnswerJson = createAssessmentDto.QuestionAndAnswersJson;
            var isQuickAssessmentResultUpdated = await _answerRepository.UpdateQuickAssessmentResult(quickAssessmentResultEntity);


            switch (patientType)
            {
                case Constants.RelationshipCase:
                    //Create BasicInfo
                    var newBasicInfo1 = _basicInfoMapper.CreateMapFrom(createAssessmentDto, firstName, middleName,lastName,
                         dateOfBirth, gender, maritalStatus, email, cellNumber);
                    newBasicInfo1.Assessment = new Assessment { Id = assessmentId };
                    var newBasicInfoId1 = await _basicInfoRepository.CreateBasicInfo(newBasicInfo1);
                    createAssessmentDto.BasicInfoId = newBasicInfoId1;

                    assessmentEvaluationResponse.Gender = newBasicInfo1.Gender;
                    assessmentEvaluationResponse.Age = (DateTime.Today.Year - newBasicInfo1.DateOfBirth.Year).ToString();
                    assessmentEvaluationResponse.FullName = newBasicInfo1.FirstName + StringExtensions.Space + newBasicInfo1.LastName;
                    assessmentEvaluationResponse.BasicInfoId = newBasicInfoId1;
                    assessmentEvaluationResponse.AssessmentStatus = Constants.AssessmentIncomplete;

                    //Create Self household member
                    var houseHoldMember = _houseHoldMapper.MapFrom(newBasicInfo1, !isInsuranceAvailable.Equals("No"));
                    if (isInsuranceAvailable.Equals("Yes"))
                    {
                        houseHoldMember.PayerName = payerName;
                        houseHoldMember.GroupName = groupName;
                        houseHoldMember.GroupNumber = groupNumber;
                        houseHoldMember.PolicyNumber = policyNumber;
                        houseHoldMember.PriorCoverageEffectiveFrom = effectiveFrom.ConvertStringToDate();
                        houseHoldMember.PriorCoverageTerminationDate = termination.IsNotNullOrEmpty() ? termination.ConvertStringToDate() : (DateTime?)null;
                    }
                    var householdMemberId = await _houseHoldMemberRepository.CreateHouseHoldMember(houseHoldMember);

                    //Create account owner as a household member
                    var accountOwnerMember = _houseHoldMapper.MapFrom(loggedInUser);
                    accountOwnerMember.Assessment = new Assessment {Id = assessmentId};
                    var accountOwnerMemberId = await _houseHoldMemberRepository.CreateHouseHoldMember(accountOwnerMember);
                    break;
                case Constants.Myself:
                    //Create BasicInfo
                    var newBasicInfo2 = _basicInfoMapper.CreateMapFrom(createAssessmentDto, firstName,middleName, lastName,
                        dateOfBirth, gender, maritalStatus, email, cellNumber);
                    newBasicInfo2.Assessment = new Assessment { Id = assessmentId };
                    var newBasicInfoId2 = await _basicInfoRepository.CreateBasicInfo(newBasicInfo2);
                    createAssessmentDto.BasicInfoId = newBasicInfoId2;

                    assessmentEvaluationResponse.Gender = newBasicInfo2.Gender;
                    assessmentEvaluationResponse.Age = (DateTime.Today.Year - newBasicInfo2.DateOfBirth.Year).ToString();
                    assessmentEvaluationResponse.FullName = newBasicInfo2.FirstName + StringExtensions.Space + newBasicInfo2.LastName;
                    assessmentEvaluationResponse.BasicInfoId = newBasicInfoId2;
                    assessmentEvaluationResponse.AssessmentStatus = Constants.AssessmentIncomplete;

                    //Create Self household member
                    var houseHoldMember1 = _houseHoldMapper.MapFrom(newBasicInfo2, !isInsuranceAvailable.Equals("No"));
                    if (isInsuranceAvailable.Equals("Yes"))
                    {
                        houseHoldMember1.PayerName = payerName;
                        houseHoldMember1.GroupName = groupName;
                        houseHoldMember1.GroupNumber = groupNumber;
                        houseHoldMember1.PolicyNumber = policyNumber;
                        houseHoldMember1.PriorCoverageEffectiveFrom = effectiveFrom.ConvertStringToDate();
                        houseHoldMember1.PriorCoverageTerminationDate = termination.IsNotNullOrEmpty() ? termination.ConvertStringToDate() : (DateTime?)null;
                    }
                    var householdMemberId1 = await _houseHoldMemberRepository.CreateHouseHoldMember(houseHoldMember1);
                    break;
            }

            //Create PatientProgramMapping
            var programsResponse = _httpClientService.GetProgramsResponse(false);
            var programs = await _programRepository.GetAllPrograms();
            foreach (var program in programsResponse.Programs)
            {
                long programId = 0;

                //Check whether program from API response is present in Program table. 
                var isProgramPresent = programs.Any(prg => prg.Name == program.ProgramName);

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
                }

                //Create PatientProgramMapping 
                var programEntity = await _programRepository.GetProgramByName(program.ProgramName);

                var patientProgramMapping = _patientProgramMappingMapper.MapFrom(assessmentId, programEntity.Id, false);
                var patientProgramMappingId = await _patientProgramMappingRepository.CreateProgramMapping(patientProgramMapping);
            }

            var patientDetails = await _basicInfoRepository.GetBasicInfoById(assessmentEvaluationResponse.BasicInfoId);

            //Create Address
            var contactDetailsDto = new ContactDetailsInfo()
            {
                AssessmentId = assessmentId,
                ContactTypeId = (long)Enums.ContactType.SelfHome,
                ZipCode = createAssessmentDto.AssessmentContactDetails.ZipCode,
                City = createAssessmentDto.AssessmentContactDetails.City,
                State = createAssessmentDto.AssessmentContactDetails.State,
                County = createAssessmentDto.AssessmentContactDetails.County,
                StateCode = createAssessmentDto.AssessmentContactDetails.StateCode
            };
            var contactDetails = _contactDetailsMapper.MapFrom(contactDetailsDto);
            if (patientDetails != null)
                patientDetails.HomeContactId = await _contactDetailsRepository.CreateContactDetail(contactDetails);

            //Todo:Use a one to one field mapping rather than using hardcoded question Id
            //Create Address For Basic Info
            var basicContactDetailsDto = new ContactDetailsInfo()
            {
                AssessmentId = assessmentId,
                ContactTypeId = (long)Enums.ContactType.SelfBasic,
                ZipCode = createAssessmentDto.AssessmentContactDetails.ZipCode,
                City = createAssessmentDto.AssessmentContactDetails.City,
                State = createAssessmentDto.AssessmentContactDetails.State,
                County = createAssessmentDto.AssessmentContactDetails.County,
                CountyCode = createAssessmentDto.AssessmentContactDetails.CountyCode,
                CellNumber = cellNumber,
                Email = email
            };
            var basicContactDetail = _contactDetailsMapper.MapFrom(basicContactDetailsDto);
            basicContactDetail.Name = firstName + StringExtensions.Space + lastName;
            if (patientDetails != null)
            {
                patientDetails.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetail);
                await _basicInfoRepository.UpdateBasicInfo(patientDetails);
            }
            //Create Assessment Verification
            var assessmentVerification = _assessmentVerificationMapper.MapFrom(assessmentId);
            var assessmentVerificationId = await _assessmentVerificationRepository.CreateVerification(assessmentVerification);

            //Create TabCompletion status
            var tabCompletionStatus = _tabStatusMapper.MapFrom(assessmentId);
            var tabStatusId = await _tabStatusRepository.CreateTabStatus(tabCompletionStatus);

            //If Patient is Guarantor
            if (loggedInRole.RoleName.Equals(Constants.AdvocateRole))
            {
                var isGuarantorBasicInfoComplete = false;
                var isGuarantorHomeComplete = false;
                if (createAssessmentDto.GuarantorInfo.IsGuarantor)
                {
                    var basicInfo = await _basicInfoRepository.GetBasicInfoById(createAssessmentDto.BasicInfoId);
                    var guarantor = _guarantorMapper.MapFrom(basicInfo, assessmentId);
                    //Create Basic Address For Guarantor
                    var basicContactInfo = new ContactDetailsInfo()
                    {
                        AssessmentId = guarantor.Assessment.Id,
                        ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                        CellNumber = guarantor.Cell,
                        CountyCode = guarantor.CountyCode,
                        Email = guarantor.EmailAddress
                    };
                    var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactInfo);
                    basicContactDetails.Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName;
                    guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);

                    //Create Address for Guarantor
                    var guarantorHomeContactDetails = _contactDetailsMapper.MapFrom(contactDetails);
                    guarantorHomeContactDetails.ContactTypeDetails = new ContactTypeMaster() { Id = (long)Enums.ContactType.GuarantorHome };
                    guarantor.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetails);
                    await _guarantorRepository.CreateGuarantor(guarantor);
                    isGuarantorBasicInfoComplete = true;
                    isGuarantorHomeComplete = false;
                }
                else
                {
                    var guarantor = _guarantorMapper.MapFrom(createAssessmentDto.GuarantorInfo,
                        assessmentId);
                    //Create Basic Address For Guarantor
                    var basicContactInfo = new ContactDetailsInfo()
                    {
                        AssessmentId = guarantor.Assessment.Id,
                        ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                        CellNumber = guarantor.Cell,
                        CountyCode = guarantor.CountyCode,
                        Email = guarantor.EmailAddress
                    };
                    var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactInfo);
                    basicContactDetails.Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName;
                    guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);
                    await _guarantorRepository.CreateGuarantor(guarantor);
                    isGuarantorBasicInfoComplete = true;
                }
                //Update tab status
                var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);
                tabStatus.IsGuarantorBasicInfoComplete = isGuarantorBasicInfoComplete;
                tabStatus.IsGuarantorHomeComplete = isGuarantorHomeComplete;
                var isTabStatusUpdated = await _tabStatusRepository.Update(tabStatus);
            }


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

            assessmentEvaluationResponse.AssessmentId = assessmentId;
            assessmentEvaluationResponse.SubmittedOn = Clock.Now().ToString(CultureInfo.InvariantCulture);
            assessmentEvaluationResponse.ProgramNames = programsResponse.Programs.Select(a => a.ProgramName).ToList();
            assessmentEvaluationResponse.Override = programsResponse.Override;
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
        public async Task<Result<PartialSaveResponse>> SavePartialAssessment(string questionAnswerJson)
        {
            var partialQuickAssessmentResult = new QuickAssessmentResult
            {
                QuestionAnswerJson = questionAnswerJson
            };
            var questionAnswerJsonId  = await _answerRepository.AddQuestionAnswerJson(partialQuickAssessmentResult);
            var partialSaveResponse = new PartialSaveResponse()
            {
                QuickAssessmentResultId = questionAnswerJsonId,
                QuestionAnswerJson = questionAnswerJson
            };
            return new Result<PartialSaveResponse>() { Data = partialSaveResponse };

        }

        public async Task<Result<MessageDto>> UpdatePartialAssessment(PartialSaveResponse partialSaveResponse)
        {
            var quickAssessmentResult = await _answerRepository.GetPartialAssessmentById(partialSaveResponse.QuickAssessmentResultId);
            if(quickAssessmentResult.IsNull()) return new Result<MessageDto>().AddError(Error.EvaluationFailed);

            quickAssessmentResult.QuestionAnswerJson = partialSaveResponse.QuestionAnswerJson;
            var isQuickAssessmentResultUpdated = await _answerRepository.UpdateQuickAssessmentResult(quickAssessmentResult);

            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.QuickAssessmentResultUpdatedSuccessfully) };
        }

        public async Task<Result<MessageDto>> DeletePartialAssessment(long quickAssessmentResultId)
        {
            var quickAssessmentResult = await _answerRepository.GetPartialAssessmentById(quickAssessmentResultId);
            if(quickAssessmentResult.IsNull()) return new Result<MessageDto>().AddError(Error.EvaluationFailed);

           var isPartialAssessmentDeleted = await _answerRepository.DeleteQuickAssessmentResult(quickAssessmentResult);
           if(isPartialAssessmentDeleted) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Constants.QuickAssessmentResultDeletedSuccessfully) };
           return new Result<MessageDto>().AddError(Error.EvaluationFailed);
        }

        public async Task<Result<string>> GetPartialAssessment(int partialSaveId)
        {
            var partialAssessmentJson = await _answerRepository.GetPartialAssessmentById(partialSaveId);
            return new Result<string>() { Data = partialAssessmentJson.QuestionAnswerJson };

        }


        public async Task<Result<AssessmentEvaluationResponse>> CreateNewAdvocateAssessment(CreateAssessment createAssessmentDto)
        {
            var payerName = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(16));
            var groupName = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(17));
            var groupNumber = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(18));
            var policyNumber = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(19));
            var effectiveFrom = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(20));
            var termination = createAssessmentDto.QuestionAndAnswers.FirstOrDefault(item => item.QuestionId.Equals(21));

            //if (Convert.ToInt64(createAssessmentDto.SSN) % 2 != 0) return new Result<AssessmentEvaluationResponse>().AddError(Error.EvaluationFailed);
            var existingIncompletePatients = await _basicInfoRepository.GetAllBasicInfo(x =>
                x.SSNNumber == createAssessmentDto.SSN &&
                x.Assessment.CreatedBy == createAssessmentDto.LoggedInUserId &&
                x.Assessment.AssessmentStatusMaster.AssessmentStatus == Constants.AssessmentIncomplete && x.Assessment.IsActive == true && x.Assessment.ExternalPatientId == createAssessmentDto.BasicInfoId);
            if (existingIncompletePatients.Any())
                return new Result<AssessmentEvaluationResponse>().AddError(createAssessmentDto.BasicInfoId == Constants.ZeroAsNumber && createAssessmentDto.QuestionAndAnswers.First(x => x.QuestionId == 1).Value == Constants.Myself ? Error.OpenAssessmentAlreadyExistsSelf : Error.OpenAssessmentAlreadyExists);

            var assessmentEvaluationResponse = new AssessmentEvaluationResponse();

            var loggedInUser = await _userRepository.GetUserById(createAssessmentDto.LoggedInUserId);
            var loggedInUserHasRole = await _userHasRolesRepository.GetUserRoleByUserId(loggedInUser.Id);
            var loggedInRole = await _roleRepository.FindByIdAsync(loggedInUserHasRole.Role.Id.ToString(), cancellationToken: CancellationToken.None);

            //Create a new assessment.
            var assessment = _assessmentMapper.MapFrom(createAssessmentDto.LoggedInUserId);
            if (loggedInRole.RoleName.Equals(Entities.Master.Roles.Advocate.RoleName))
            {
                if (assessment != null) assessment.ExternalPatientId = createAssessmentDto.BasicInfoId;
            }

            var assessmentId = await _assessmentRepository.CreateAssessment(assessment);
            _ = await _verificationDocumentRepository.CreateVerificationDocument(new Entities.VerificationDocument()
            { Assessment = new Assessment() { Id = assessmentId } });

            //Create BasicInfo
            var newBasicInfo = _basicInfoMapper.CreateMapFrom(createAssessmentDto);
            newBasicInfo.Assessment = new Assessment { Id = assessmentId };
            var newBasicInfoId = await _basicInfoRepository.CreateBasicInfo(newBasicInfo);
            createAssessmentDto.BasicInfoId = newBasicInfoId;

                assessmentEvaluationResponse.Gender = newBasicInfo.Gender;
                assessmentEvaluationResponse.Age = (DateTime.Today.Year - newBasicInfo.DateOfBirth.Year).ToString();
                assessmentEvaluationResponse.FullName = newBasicInfo.FirstName + StringExtensions.Space + newBasicInfo.LastName;
                assessmentEvaluationResponse.BasicInfoId = newBasicInfoId;
                assessmentEvaluationResponse.AssessmentStatus = Constants.AssessmentIncomplete;

                //Create Self household member
                var houseHoldMember = _houseHoldMapper.MapFrom(newBasicInfo, createAssessmentDto.IsInsuranceAvailable);
            if (createAssessmentDto.IsInsuranceAvailable)
            {
                houseHoldMember.PayerName = payerName?.Value;
                houseHoldMember.GroupName = groupName?.Value;
                houseHoldMember.GroupNumber = groupNumber?.Value;
                houseHoldMember.PolicyNumber = policyNumber?.Value;
                houseHoldMember.PriorCoverageEffectiveFrom = effectiveFrom?.Value.ConvertStringToDate();
                houseHoldMember.PriorCoverageTerminationDate = termination.Value.IsNotNull() ? termination.Value.ConvertStringToDate() : (DateTime?) null;
            }
            var householdMemberId = await _houseHoldMemberRepository.CreateHouseHoldMember(houseHoldMember);
                
            //Save the answers in Answer table.
            foreach (var questionAnswer in createAssessmentDto.QuestionAndAnswers)
            {
                var answer = _answerMapper.MapFrom(questionAnswer.ScreenQuestionMappingId,
                    questionAnswer.OptionId, assessmentId, questionAnswer.Value, questionAnswer.QuestionId);
                var answerId = await _answerRepository.CreateAnswer(answer);
            }

            //Create PatientProgramMapping
            var programsResponse = _httpClientService.GetProgramsResponse(false);
            var programs = await _programRepository.GetAllPrograms();

            foreach (var program in programsResponse.Programs)
            {
                long programId = 0;

                //Check whether program from API response is present in Program table. 
                var isProgramPresent = programs.Any(prg => prg.Name == program.ProgramName);

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
                }

                //Create PatientProgramMapping 
                var programEntity = await _programRepository.GetProgramByName(program.ProgramName);

                var patientProgramMapping = _patientProgramMappingMapper.MapFrom(assessmentId, programEntity.Id, false);
                var patientProgramMappingId = await _patientProgramMappingRepository.CreateProgramMapping(patientProgramMapping);
            }

            var patientDetails = await _basicInfoRepository.GetBasicInfoById(assessmentEvaluationResponse.BasicInfoId);

            //Create Address
            var contactDetailsDto = new ContactDetailsInfo()
            {
                AssessmentId = assessmentId,
                ContactTypeId = (long)Enums.ContactType.SelfHome,
                ZipCode = createAssessmentDto.AssessmentContactDetails.ZipCode,
                City = createAssessmentDto.AssessmentContactDetails.City,
                State = createAssessmentDto.AssessmentContactDetails.State,
                County = createAssessmentDto.AssessmentContactDetails.County,
                StateCode = createAssessmentDto.AssessmentContactDetails.StateCode
            };
            var contactDetails = _contactDetailsMapper.MapFrom(contactDetailsDto);
            if (patientDetails != null)
                patientDetails.HomeContactId = await _contactDetailsRepository.CreateContactDetail(contactDetails);

            //Todo:Use a one to one field mapping rather than using hardcoded question Id
            //Create Address For Basic Info
            var basicContactDetailsDto = new ContactDetailsInfo()
            {
                AssessmentId = assessmentId,
                ContactTypeId = (long)Enums.ContactType.SelfBasic,
                ZipCode = createAssessmentDto.AssessmentContactDetails.ZipCode,
                City = createAssessmentDto.AssessmentContactDetails.City,
                State = createAssessmentDto.AssessmentContactDetails.State,
                County = createAssessmentDto.AssessmentContactDetails.County,
                CellNumber = createAssessmentDto.QuestionAndAnswers.First(x => x.QuestionId == 13).Value,
                Email = createAssessmentDto.QuestionAndAnswers.First(x => x.QuestionId == 12).Value
            };
            var basicContactDetail = _contactDetailsMapper.MapFrom(basicContactDetailsDto);
            basicContactDetail.Name = createAssessmentDto.QuestionAndAnswers.First(x => x.QuestionId == 7).Value + StringExtensions.Space + createAssessmentDto.QuestionAndAnswers.First(x => x.QuestionId == 8).Value;
            if (patientDetails != null)
            {
                patientDetails.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetail);
                await _basicInfoRepository.UpdateBasicInfo(patientDetails);
            }

            //Create Assessment Verification
            var assessmentPatient = await _basicInfoRepository.GetBasicInfoById(createAssessmentDto.BasicInfoId);
            var assessmentVerification = _assessmentVerificationMapper.MapFrom(assessmentId);
            var assessmentVerificationId = await _assessmentVerificationRepository.CreateVerification(assessmentVerification);

            //Create TabCompletion status
            var tabCompletionStatus = _tabStatusMapper.MapFrom(assessmentId);
            var tabStatusId = await _tabStatusRepository.CreateTabStatus(tabCompletionStatus);

            //If Patient is Guarantor
            if (loggedInRole.RoleName.Equals(Constants.AdvocateRole))
            {
                bool isGuarantorBasicInfoComplete = false;
                bool isGuarantorHomeComplete = false;
                if (createAssessmentDto.GuarantorInfo.IsGuarantor)
                {
                    var patient = await _basicInfoRepository.GetBasicInfoById(createAssessmentDto.BasicInfoId);
                    var guarantor = _guarantorMapper.MapFrom(patient, assessmentId);
                    //Create Basic Address For Guarantor
                    var basicContactInfo = new ContactDetailsInfo()
                    {
                        AssessmentId = guarantor.Assessment.Id,
                        ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                        CellNumber = guarantor.Cell,
                        CountyCode = guarantor.CountyCode,
                        Email = guarantor.EmailAddress
                    };
                    var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactInfo);
                    basicContactDetails.Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName;
                    guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);

                    //Create Address for Guarantor
                    var guarantorHomeContactDetails = _contactDetailsMapper.MapFrom(contactDetails);
                    guarantorHomeContactDetails.ContactTypeDetails = new ContactTypeMaster() { Id = (long)Enums.ContactType.GuarantorHome };
                    guarantor.HomeContactId = await _contactDetailsRepository.CreateContactDetail(guarantorHomeContactDetails);
                    await _guarantorRepository.CreateGuarantor(guarantor);
                    isGuarantorBasicInfoComplete = true;
                    isGuarantorHomeComplete = false;
                }
                else
                {
                    var guarantor = _guarantorMapper.MapFrom(createAssessmentDto.GuarantorInfo,
                        assessmentId);
                    //Create Basic Address For Guarantor
                    var basicContactInfo = new ContactDetailsInfo()
                    {
                        AssessmentId = guarantor.Assessment.Id,
                        ContactTypeId = (long)Enums.ContactType.GuarantorBasic,
                        CellNumber = guarantor.Cell,
                        CountyCode = guarantor.CountyCode,
                        Email = guarantor.EmailAddress
                    };
                    var basicContactDetails = _contactDetailsMapper.MapFrom(basicContactInfo);
                    basicContactDetails.Name = guarantor.FirstName + StringExtensions.Space + guarantor.LastName;
                    guarantor.BasicContactId = await _contactDetailsRepository.CreateContactDetail(basicContactDetails);
                    await _guarantorRepository.CreateGuarantor(guarantor);
                    isGuarantorBasicInfoComplete = true;
                }
                //Update tab status
                var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);
                tabStatus.IsGuarantorBasicInfoComplete = isGuarantorBasicInfoComplete;
                tabStatus.IsGuarantorHomeComplete = isGuarantorHomeComplete;
                var isTabStatusUpdated = await _tabStatusRepository.Update(tabStatus);
            }

            HashSet<string> sentIDs = new HashSet<string>(programsResponse.Programs.Select(s => s.ProgramName));
            var results = programsResponse.AllPrograms.Where(m => !sentIDs.Contains(m.ProgramName)).ToList();

            var updatedPrograms = await _programRepository.GetAllPrograms();
            var programIdList = new Dictionary<long,string>();
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
                    programIdList.Add(programId,program.ProgramName);
                }
                else
                {
                    var program1 = await _programRepository.GetProgramByName(program.ProgramName);
                    programIdList.Add(program1.Id, program1.Name);
                }
            }

            assessmentEvaluationResponse.AssessmentId = assessmentId;
            assessmentEvaluationResponse.SubmittedOn = Clock.Now().ToString(CultureInfo.InvariantCulture);
            assessmentEvaluationResponse.ProgramNames = programsResponse.Programs.Select(a => a.ProgramName).ToList();
            assessmentEvaluationResponse.Override = programsResponse.Override;
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

        public Result<AssessmentRoot> QuickAssessment(string assessmentId)
        {
            var assessmentRoot = new AssessmentRoot();
            return new Result<AssessmentRoot>()
            { Data = assessmentRoot };
        }

        public async Task<Result<CityStateResponse>> GetStateAndCounty(string zipcode)
        {
            var cityStateRoot = await _httpClientService.GetCityState(zipcode);
            if (cityStateRoot.IsNotNull())
            {
                var cityState = new CityStateResponse()
                {
                    City = cityStateRoot.Places[0].PlaceName,
                    State = cityStateRoot.Places[0].State,
                    County = cityStateRoot.Country,
                    StateCode = cityStateRoot.Places[0].StateAbbreviation,
                };
                return new Result<CityStateResponse>()
                { Data = cityState };
            }

            return new Result<CityStateResponse>()
            { Data = null };
        }

        public async Task<Result<QuickAssessmentSelfResponse>> GetSelfDetails(long userId)
        {
            var selfDetails = await _httpClientService.GetSelfDetails(userId);
            return new Result<QuickAssessmentSelfResponse>()
            { Data = selfDetails };
        }

        public async Task<Result<QuickAssessmentSelfResponse>> GetBasicInfoSelfDetails(long patientId)
        {
            var patient = await _userRepository.GetUserById(patientId);
            if(patient.ContactDetails == null)
            {
                var quickAssessmentSelfResponse1 = new QuickAssessmentSelfResponse()
                {
                    Citizenship = "U.S. Citizen",
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth?.ToString("MM/dd/yyyy"),
                    Gender = patient.Gender,
                    MaritalStatus = patient.MaritalStatus,
                    Email = patient.EmailAddress,
                    Cell = patient.Cell,
                    CountyCode = patient.CountyCode
                };
                return new Result<QuickAssessmentSelfResponse>() { Data = quickAssessmentSelfResponse1 };
            }
            var homeContactDetails = await _contactDetailsRepository.GetContactDetailsById(patient.ContactDetails.Id);
            var quickAssessmentSelfResponse = new QuickAssessmentSelfResponse()
            {
                Citizenship = "U.S. Citizen",
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth?.ToString("MM/dd/yyyy"),
                Gender = patient.Gender,
                MaritalStatus = patient.MaritalStatus,
                Email = patient.EmailAddress,
                Cell = patient.Cell,
                ZipCode = homeContactDetails.Zip,
                City = homeContactDetails.City,
                State = homeContactDetails.State,
                StateCode = homeContactDetails.StateCode,
                CountyCode = patient.CountyCode
            };
            return new Result<QuickAssessmentSelfResponse>() { Data = quickAssessmentSelfResponse };
        }

        public async Task<Result<ValidatePolicyNumberResponse>> ValidatePolicyNumber(string policyNumber)
        {
            var response = new ValidatePolicyNumberResponse();
            switch (policyNumber)
            {
                case Constants.SampleCell:
                    response.CanProceed = false;
                    response.Message = Constants.InsuranceResponse;
                    return new Result<ValidatePolicyNumberResponse>()
                    { Data = response };
                default:
                    var isValid = _httpClientService.ValidatePolicyNumber(policyNumber);
                    if (isValid)
                    {
                        response.CanProceed = true;
                        response.Message = Constants.ValidPolicyNumber;
                        return new Result<ValidatePolicyNumberResponse>()
                        { Data = response };
                    }
                    response.CanProceed = false;
                    response.Message = Constants.InvalidPolicyNumber;
                    return new Result<ValidatePolicyNumberResponse>()
                    { Data = response };
            }
        }

        public async Task<Result<bool>> IsUserNameExists(string emailAddress)
        {
            var user = await _userRepository.GetUserByEmailAddress(emailAddress);
            if (user.IsNotNull()) return new Result<bool> { Data = true };
            return new Result<bool> { Data = false };
        }

        public async Task<Result<string>> GetUserNameInfo(string emailAddress)
        {
            var user = await _userRepository.GetUserByEmailAddress(emailAddress);

            if (user.IsNull())
                return new Result<string> { Data = false.ToString() };

            var userRoleInfo = await _userHasRolesRepository.GetUserRoleByUserId(user.Id);

            var userRole = Entities.Master.Roles.FindBy(userRoleInfo.Role.Id);

            return new Result<string> { Data = userRole.RoleName };

        }

        public async Task<Result<QuickAssessmentQuestionsDto>> GetDynamicScreens(long tenantId)
        {
            DynamicScreenList screens = new DynamicScreenList();
            var dynamicScreens = await _assessmentRepository.GetDynamicScreens(tenantId);
            screens.Screens = dynamicScreens.Item1.ToList();
            var dynamicScreensDto = _dynamicScreensMapper.MapFrom(screens);
            foreach (var item in dynamicScreensDto.Screens)
            {
                foreach (var itemControl in item.Controls)
                {
                    if (dynamicScreens.Item2.Contains(itemControl.QuestionId))
                    {
                        if (itemControl.SubQuestion == null)
                        {
                            itemControl.SubQuestion = new List<QuickAssessmentQuestionsDto.Control>();
                        }
                        itemControl.SubQuestion.AddRange(item.Controls.FindAll(x => x.ParentQuestionId.ToString() == itemControl.QuestionId));
                    }
                }
            }

            foreach (var screen in dynamicScreensDto.Screens)
            {
                screen.Controls.RemoveAll(x => dynamicScreens.Item2.Contains(x.ParentQuestionId.ToString()));
            }

            var dynamicScreenUser = await _userRepository.GetUserById(Constants.AdminUserId);
            dynamicScreensDto.IsDynamic = dynamicScreenUser.IsActive;
            return new Result<QuickAssessmentQuestionsDto> { Data = dynamicScreensDto };
        }

        public async Task<Result<GetPatientNamesResponse>> GetAdvocatePatients(GetPatientNamesRequest getPatientNamesRequest)
        {
            var advocatePatient = await _userRepository.GetUserForAdvocateAssessment();
            var inputDate = DateTime.ParseExact(getPatientNamesRequest.DateOfBirth, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var patientNames = advocatePatient.Where(p => (String.Concat(p.FirstName, StringExtensions.Space, p.LastName)).Contains(getPatientNamesRequest.Name, StringComparison.OrdinalIgnoreCase) && p.DateOfBirth.Equals(inputDate) ).Select(patient => new PatientName()
            {
                PatientId = Convert.ToInt64(patient.Id),
                FullName = String.Concat(patient.FirstName, StringExtensions.Space, patient.LastName)
            });
            var patientNamesList = new List<PatientName>();
            foreach (var patient in patientNames)
            {
                var patientName = new PatientName
                {
                    PatientId = patient.PatientId,
                    FullName = patient.FullName
                };
                patientNamesList.Add(patientName);
            }
            var response = new GetPatientNamesResponse { PatientNames = patientNamesList };
            return new Result<GetPatientNamesResponse> { Data = response };
        }
    }
}
