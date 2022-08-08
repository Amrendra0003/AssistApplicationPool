using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities.Master;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Services.Mapper;
using Healthware.Core.Configurations;
using Healthware.Core.Repository;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.Utility;
using Newtonsoft.Json;
using RestSharp;
using Programs = HealthWare.ActiveASSIST.DTOs.Programs;


namespace HealthWare.ActiveASSIST.Services
{
    public interface IDashboardService
    {
        Task<Result<DashboardResponse>> GetDashboardDetails(int userId, string partialName, long tenantId);
        Task<Result<AdvocateDashboardSummary>> GetAssessmentSummary(BasePatientAssessment basePatientAssessment);
        Result<long> GetEstimatedCostForVisit(int patientId);

        Task<Result<List<IOrderedEnumerable<AdvocateDashboardResponse>>>>
            GetAdvocateDashboardDetailsList(int userId, string filterByDays, string orderBy, string partialName,
                string localDateTime, long tenantId);
    }

    public class DashboardService : IDashboardService
    {
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly IDashboardMapper _dashboardMapper;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        private readonly IDocumentService _documentService;
        private readonly IAnswerRepository _answerRepository;
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly IHouseHoldIncomeRepository _houseHoldIncomeRepository;
        private readonly IHouseHoldResourceRepository _houseHoldResourceRepository;
        private readonly IGuarantorRepository _guarantorRepository;
        private readonly IContactPreferenceRepository _contactPreferenceRepository;
        private readonly IUserRepository _userRepository;

        public DashboardService(IBasicInfoRepository basicInfoRepository, IDashboardMapper dashboardMapper, IAssessmentRepository assessmentRepository, IContactDetailsRepository<PatientDbContext> contactDetailsRepository, IDocumentService documentService, IAnswerRepository answerRepository, IHouseHoldMemberRepository houseHoldMemberRepository, IHouseHoldIncomeRepository houseHoldIncomeRepository, IHouseHoldResourceRepository houseHoldResourceRepository, IGuarantorRepository guarantorRepository, IContactPreferenceRepository contactPreferenceRepository, IUserRepository userRepository)
        {
            _basicInfoRepository = basicInfoRepository;
            _dashboardMapper = dashboardMapper;
            _assessmentRepository = assessmentRepository;
            _contactDetailsRepository = contactDetailsRepository;
            _documentService = documentService;
            _answerRepository = answerRepository;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _houseHoldIncomeRepository = houseHoldIncomeRepository;
            _houseHoldResourceRepository = houseHoldResourceRepository;
            _guarantorRepository = guarantorRepository;
            _contactPreferenceRepository = contactPreferenceRepository;
            _userRepository = userRepository;
        }
        public async Task<Result<DashboardResponse>> GetDashboardDetails(int userId, string partialName, long tenantId)
        {
            if (partialName.isNullOrEmpty()) partialName = string.Empty;

            if (ContainsInvalidCharacters(partialName))
                return new Result<DashboardResponse>();

            //if (PropertyValues.isMockEnabled())
            //    return LoadMockAssessment();

            var assessmentList = _assessmentRepository.GetAssessmentListForPatientDashboard(userId, partialName, tenantId);
            foreach (var assessment in assessmentList)
            {
                assessment.ProfileImageData = await _documentService.LoadProfileImage(assessment.AssessmentId);
            }
            var dashboardDetailResponse = assessmentList.Select(assessment => _dashboardMapper.MapFrom(assessment)).ToList();
            var partialAssessmentEntity = await _answerRepository.GetPartialAssessmentByUserId(userId);
            var existingIncompletePatients = await _basicInfoRepository.GetAllBasicInfo(x =>
                x.Assessment.CreatedBy == userId &&
                x.Assessment.AssessmentStatusMaster.AssessmentStatus == Constants.AssessmentIncomplete && x.Assessment.IsActive == true);

            var dashboardResponse = new DashboardResponse()
            {
                DashboardDetailResponse = dashboardDetailResponse,
                CanCreateNewAssessment = partialAssessmentEntity.IsNull() && existingIncompletePatients.Count() == 0 ? true : false,
            };

            if (partialAssessmentEntity.IsNull())
            {
                return new Result<DashboardResponse> { Data = dashboardResponse };
            }

            var values = JsonConvert.DeserializeObject<List<JsonObject>>(partialAssessmentEntity.QuestionAnswerJson);

            var firstName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.FirstName))?[Constants.FirstName];
            var lastName = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.LastName))?[Constants.LastName];
            var gender = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Gender))?[Constants.Gender];
            var dateOfBirth =
                ((string)values.FirstOrDefault(x => x.ContainsKey(Constants.DateOfBirth))?[Constants.DateOfBirth] ??
                 string.Empty).ConvertStringToDate();
            var age = (DateTime.Today.Year - dateOfBirth.Year).ToString();
            var contactCell = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.CellNumberProperty))?[Constants.CellNumberProperty];
            var contactCountyCode = "1";
            var contactEmail = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Email))?[Constants.Email];
            var partialAssessmentSubmittedByUser = await _userRepository.GetUserById(userId);
            var homeContactDetail = await _contactDetailsRepository.GetContactDetailsById(partialAssessmentSubmittedByUser.ContactDetails.Id);

            var partialAssessment = new PartialAssessment()
            {
                FullName = firstName + " " + lastName,
                Gender = gender,
                Age = age,
                SubmittedBy = new SubmittedBy()
                {
                    Name = partialAssessmentSubmittedByUser.ContactDetails?.Name,
                    SubmittedOn = partialAssessmentEntity.CreatedDate.ToString("MM/dd/yyyy hh:mm:ss tt"),
                    CreatedDate = partialAssessmentEntity.CreatedDate,
                    HospitalName = null,
                    City = homeContactDetail.City

                },
                ContactDetails = new ContactDetails()
                {
                    CellNumber = contactCell.IsNotNullOrEmpty() ? $"({contactCell.Substring(0, 3)}) {contactCell.Substring(3, 3)}-{contactCell.Substring(6)}" : null,
                    CountryCode = contactCountyCode,
                    EmailAddress = contactEmail,
                },
                PartialAssessmentId = partialAssessmentEntity.Id

            };

            dashboardResponse.PartialAssessment = partialAssessment;
            return new Result<DashboardResponse> { Data = dashboardResponse };

        }


        public async Task<Result<List<IOrderedEnumerable<AdvocateDashboardResponse>>>>
           GetAdvocateDashboardDetailsList(int userId, string filterByDays, string orderBy, string searchText, string localDateTime, long tenantId)
        {
            if (searchText.isNullOrEmpty()) searchText = string.Empty;

            var isDescending = !orderBy.Equals(Constants.OldestFirst);

            if (ContainsInvalidCharacters(searchText))
                return new Result<List<IOrderedEnumerable<AdvocateDashboardResponse>>>();

            var dashboardAssessmentList = _assessmentRepository.GetAssessmentListForDashboard(userId, searchText, tenantId);
            var dashboardAssessments1 = dashboardAssessmentList.ToList();
            List<DashboardAssessment> dashboardAssessmentsForAdvocate = new List<DashboardAssessment>();
            List<DashboardAssessment> dashboardAssessmentsForOthers = new List<DashboardAssessment>();
            var userIDs = _assessmentRepository.GetUserIds(userId);
            userIDs.Result.RemoveAll(x => x.UserId == userId);
            if (userIDs.Result.Count != 0)
            {
                dashboardAssessments1.RemoveAll(x => x.CreatedBy != userId);
                dashboardAssessmentsForAdvocate.AddRange(dashboardAssessments1);
                foreach (var item in userIDs.Result)
                {
                    var dashboardAssessments3 = dashboardAssessmentList.ToList();
                    dashboardAssessments3.RemoveAll(x => x.CreatedBy != item.UserId);
                    dashboardAssessmentsForOthers.AddRange(dashboardAssessments3);
                }
            }
            else
            {
                dashboardAssessments1.RemoveAll(x => x.CreatedBy != userId);
                dashboardAssessmentsForAdvocate.AddRange(dashboardAssessments1);
            }
            dashboardAssessmentList = dashboardAssessmentsForAdvocate;
            foreach (var assessment in dashboardAssessmentsForAdvocate)
            {
                assessment.PatientProfileImage = await _documentService.LoadProfileImage(assessment.AssessmentId);
            }
            var filterDate = Clock.Now();

            if (!string.IsNullOrEmpty(localDateTime))
            {
                var localDateTimeOffset = DateTimeOffset.Parse(localDateTime, CultureInfo.InvariantCulture);
                filterDate = localDateTimeOffset.DateTime;
                //Get timezone difference
                var diffTimeZone = localDateTimeOffset.DateTime - DateTime.UtcNow;
                //Convert the local time string to date time
                for (var index = 0; index < dashboardAssessmentsForAdvocate.Count; index++)
                {
                    dashboardAssessmentsForAdvocate[index].CreatedDate =
                        dashboardAssessmentsForAdvocate[index].CreatedDate.Add(diffTimeZone);
                }
            }

            switch (filterByDays)
            {
                case Constants.Today:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date == filterDate.Date).ToList();
                    break;

                case Constants.Yesterday:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date == filterDate.Date.AddDays(-1)).ToList();
                    break;

                case Constants.LastThreeDays:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date >= filterDate.Date.AddDays(-2)).ToList();
                    break;

                case Constants.MonthFilter:
                    //filterDate will be point to the start date of the current month.
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where
                        (x => x.CreatedDate.Year == filterDate.Year && x.CreatedDate.Month == filterDate.Month).ToList();
                    break;

                default:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date >= filterDate.Date.AddDays(-6)).ToList();
                    break;
            }
            var result = new List<AdvocateDashboardResponse>();
            dashboardAssessmentList = isDescending ? dashboardAssessmentList.OrderByDescending(x => x.CreatedDate) : dashboardAssessmentList.OrderBy(x => x.CreatedDate);
            var dateEnumerable = dashboardAssessmentList.GroupBy(x => x.CreatedDate.Date);
            foreach (var date in dateEnumerable)
            {
                var advocateDashboardResponse = new AdvocateDashboardResponse()
                {
                    AssessmentCreatedDate = date.Key,
                    CreateDate = date.Key.ToLongDateString(),
                    DashboardAssessments = date.ToList()
                };
                result.Add(advocateDashboardResponse);
            }
            var resForAdvocate = isDescending ? result.OrderByDescending(x => x.AssessmentCreatedDate) : result.OrderBy(x => x.AssessmentCreatedDate) ;

            dashboardAssessmentsForAdvocate = dashboardAssessmentsForOthers;
            dashboardAssessmentList = dashboardAssessmentsForAdvocate;
            foreach (var assessment in dashboardAssessmentsForAdvocate)
            {
                assessment.PatientProfileImage = await _documentService.LoadProfileImage(assessment.AssessmentId);
            }

            if (!string.IsNullOrEmpty(localDateTime))
            {
                var localDateTimeOffset = DateTimeOffset.Parse(localDateTime, CultureInfo.InvariantCulture);
                filterDate = localDateTimeOffset.DateTime;
                //Get timezone difference
                var diffTimeZone = localDateTimeOffset.DateTime - DateTime.UtcNow;
                //Convert the local time string to date time
                for (var index = 0; index < dashboardAssessmentsForAdvocate.Count; index++)
                {
                    dashboardAssessmentsForAdvocate[index].CreatedDate =
                        dashboardAssessmentsForAdvocate[index].CreatedDate.Add(diffTimeZone);
                }
            }

            switch (filterByDays)
            {
                case Constants.Today:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date == filterDate.Date).ToList();
                    break;

                case Constants.Yesterday:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date == filterDate.Date.AddDays(-1)).ToList();
                    break;

                case Constants.LastThreeDays:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date >= filterDate.Date.AddDays(-2)).ToList();
                    break;

                case Constants.MonthFilter:
                    //filterDate will be point to the start date of the current month.
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where
                        (x => x.CreatedDate.Year == filterDate.Year && x.CreatedDate.Month == filterDate.Month).ToList();
                    break;

                default:
                    dashboardAssessmentList = dashboardAssessmentsForAdvocate.Where(x => x.CreatedDate.Date >= filterDate.Date.AddDays(-6)).ToList();
                    break;
            }
            result = new List<AdvocateDashboardResponse>();
            dashboardAssessmentList = isDescending ? dashboardAssessmentList.OrderByDescending(x => x.CreatedDate) : dashboardAssessmentList.OrderBy(x => x.CreatedDate);
            dateEnumerable = dashboardAssessmentList.GroupBy(x => x.CreatedDate.Date);
            foreach (var date in dateEnumerable)
            {
                var advocateDashboardResponse = new AdvocateDashboardResponse()
                {
                    AssessmentCreatedDate = date.Key,
                    CreateDate = date.Key.ToLongDateString(),
                    DashboardAssessments = date.ToList()
                };
                result.Add(advocateDashboardResponse);
            }
            var resForOthers = isDescending ? result.OrderByDescending(x => x.AssessmentCreatedDate)  : result.OrderBy(x => x.AssessmentCreatedDate) ;
            List<IOrderedEnumerable<AdvocateDashboardResponse>> results = new List<IOrderedEnumerable<AdvocateDashboardResponse>>();
            results.Add(resForAdvocate);
            results.Add(resForOthers);
            return new Result<List<IOrderedEnumerable<AdvocateDashboardResponse>>> { Data = results };


        }

        public async Task<Result<AdvocateDashboardSummary>> GetAssessmentSummary(BasePatientAssessment basePatientAssessment)
        {
            var getCreatedByRole = await _assessmentRepository.GetUserRoleOfTheAssessment(basePatientAssessment.AssessmentId);
            var dashboardSummary = new AdvocateDashboardSummary();
            if (getCreatedByRole == "Advocate")
            {
                var summaryResult = await _answerRepository.GetAssessmentSummary(basePatientAssessment.AssessmentId);

                foreach (var result in summaryResult)
                {
                    switch (result.KeyName)
                    {
                        case Constants.ZipCode:
                            dashboardSummary.ZipCode = result.Value;
                            break;
                        case Constants.City:
                            dashboardSummary.City = result.Value;
                            break;
                        case Constants.State:
                            dashboardSummary.StateCode = result.Value;
                            break;
                        case Constants.CitizenshipStatus:
                            dashboardSummary.CitizenshipStatus = result.Value.IsNotNull() ? result.Value : result.AnswerOptionValue;
                            break;
                        case Constants.Insurance:
                            dashboardSummary.Insurance = result.Value;
                            break;
                        case Constants.NoOfHousehold:
                            dashboardSummary.NumberOfMembers = result.Value;
                            break;
                        case Constants.MinorChildren:
                            dashboardSummary.NumberOfMinors = result.Value;
                            break;
                        case Constants.IsHouseholdEmployed:
                            dashboardSummary.IsHouseHoldEmployed = result.Value.IsNotNull() && bool.Parse(result.Value);
                            break;
                        case Constants.ProgramServices:
                            dashboardSummary.ReceivingAny = result.Value;
                            break;
                        case Constants.HouseholdIncomeAnswer:
                            dashboardSummary.HouseHoldIncomeMonthly = result.Value;
                            break;
                        case Constants.IncomePayPeriod:
                            if (result.Value.Equals(Constants.Yearly))
                                dashboardSummary.HouseHoldIncomeMonthly = Math.Round((Convert.ToDouble(dashboardSummary.HouseHoldIncomeMonthly) / 12), 2).ToString();
                            if (result.AnswerOptionValue.Equals(Constants.Bimonthly))
                                dashboardSummary.HouseHoldIncomeMonthly = Math.Round((Convert.ToDouble(dashboardSummary.HouseHoldIncomeMonthly) / 2), 2).ToString();
                            if (result.Value.Equals(Constants.Biweekly))
                                dashboardSummary.HouseHoldIncomeMonthly = Math.Round((Convert.ToDouble(dashboardSummary.HouseHoldIncomeMonthly) * 2), 2).ToString();
                            if (result.Value.Equals(Constants.Weekly))
                                dashboardSummary.HouseHoldIncomeMonthly = Math.Round((Convert.ToDouble(dashboardSummary.HouseHoldIncomeMonthly) * 4), 2).ToString();
                            break;
                        case Constants.HouseholdResources:
                            dashboardSummary.HouseHoldResources = Math.Round(Convert.ToDouble(result.Value), 2).ToString();
                            break;
                        case Constants.ServiceProgram:
                            dashboardSummary.GeneralQuestions = result.Value;
                            break;

                        case Constants.HealthCondition:
                            dashboardSummary.HealthConditions = result.Value;
                            break;
                        case Constants.BeenInjured:
                            dashboardSummary.BeenInjured = result.Value;
                            break;
                    }
                }
            }
            else if(getCreatedByRole == "Patient")
            {
                var quickAssessment = await _answerRepository.GetQuestionAnswerJson(basePatientAssessment.AssessmentId);
                var values = JsonConvert.DeserializeObject<List<JsonObject>>(quickAssessment.QuestionAnswerJson);
                dashboardSummary.ZipCode = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.ZipCode))?[Constants.ZipCode];
                dashboardSummary.City = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.City))?[Constants.City];
                dashboardSummary.StateCode = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.StateCode))?[Constants.StateCode];
                dashboardSummary.CitizenshipStatus = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Citizenship))?[Constants.Citizenship];
                dashboardSummary.Insurance = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.Insurance))?[Constants.Insurance];
                dashboardSummary.NumberOfMembers = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.TotalHouseholdMembers))?[Constants.TotalHouseholdMembers];
                dashboardSummary.NumberOfMinors = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.TotalHouseholdMembers))?[Constants.TotalHouseholdMembers];
                //dashboardSummary.IsHouseHoldEmployed = bool.Parse((string)values.FirstOrDefault(x => x.ContainsKey(Constants.IsHouseholdEmployed))?[Constants.IsHouseholdEmployed]);
                //dashboardSummary.ReceivingAny = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.ProgramServices))?[Constants.ProgramServices];
                dashboardSummary.HouseHoldIncomeMonthly = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.HouseholdIncomeAnswer))?[Constants.HouseholdIncomeAnswer];
                //dashboardSummary.HouseHoldResources = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.ProgramServices))?[Constants.ProgramServices];
                //dashboardSummary.GeneralQuestions = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.ServiceProgram))?[Constants.ServiceProgram];
                //dashboardSummary.HealthConditions = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.HealthCondition))?[Constants.HealthCondition];
                //dashboardSummary.BeenInjured = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.BeenInjured))?[Constants.BeenInjured];
            }

            var householdMembers =
                await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(basePatientAssessment.AssessmentId);
            if (householdMembers.Count() > 0)
            {
                dashboardSummary.UpdatedNumberOfMembers = householdMembers.Count().ToString();
                dashboardSummary.UpdatedNumberOfMinors = Constants.ZeroAsString;
                var totalHouseHoldIncome = 0m;
                var totalHouseHoldResource = 0m;
                foreach (var houseHoldMember in householdMembers)
                {
                    var memberAge = (Convert.ToInt32(DateTime.Today.Year - houseHoldMember.DateOfBirth?.Year)).ToString();
                    if (Int32.Parse(memberAge) < 18)
                    {
                        dashboardSummary.UpdatedNumberOfMinors = (Int32.Parse(dashboardSummary.UpdatedNumberOfMinors) + 1).ToString();
                    }
                    var householdIncome = await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberId(houseHoldMember.Id);
                    totalHouseHoldIncome += Convert.ToDecimal(householdIncome.Select(p => p.CalculatedMonthlyIncome).Sum());

                    var householdResource =
                        await _houseHoldResourceRepository.GetHouseHoldResourceByHouseHoldMemberId(houseHoldMember.Id);
                    totalHouseHoldResource += Convert.ToDecimal(householdResource.Select(p => p.CalculatedValue).Sum());
                }

                dashboardSummary.UpdatedMonthlyIncome = totalHouseHoldIncome.ToString();
                dashboardSummary.UpdatedNumberOfResource = totalHouseHoldResource.ToString();
            }

            var basicInfo = await _basicInfoRepository.GetBasicInfoById(basePatientAssessment.PatientId);
            var guarantor = await _guarantorRepository.GetGuarantorByAssessmentId(basePatientAssessment.AssessmentId);
            var contactPreference =
                await _contactPreferenceRepository.GetContactPreferenceByAssessmentId(
                    basePatientAssessment.AssessmentId);
            var contactSummary = new ContactSummary();
            if (basicInfo.IsNotNull())
            {
                contactSummary.PersonalEmail = basicInfo.EmailAddress;
                contactSummary.PersonalCell = basicInfo.CellNumber;
                contactSummary.PersonalCountyCode = basicInfo.CountyCode;
            }

            if (guarantor.IsNotNull())
            {
                contactSummary.GuarantorEmail = guarantor.EmailAddress;
                contactSummary.GuarantorCell = guarantor.Cell;
                contactSummary.GuarantorCountyCode = guarantor.CountyCode;
            }

            if (contactPreference.IsNotNull())
            {
                var contactPhoneDetails = await _contactDetailsRepository.GetContactDetailsById(contactPreference.ContactPhoneId == 0
                    ? contactPreference.OtherContactId
                    : contactPreference.ContactPhoneId);
                if (contactPreference.ContactPhoneId != -1)
                {
                    if (contactPhoneDetails.Cell.IsNotNullOrEmpty() && contactPhoneDetails.IsNotNull())
                    {
                        contactSummary.PreferredCell = contactPhoneDetails.Cell;
                        contactSummary.PreferredCountyCode = contactPhoneDetails.CountyCode.IsNullOrEmpty() ? Constants.OneAsString : contactPhoneDetails.CountyCode;
                    }
                    else
                    {
                        contactSummary.PreferredCell = null;
                        contactSummary.PreferredCountyCode = null;
                    }
                }

                if (contactPreference.ContactEmailId != -1)
                {
                    var contactEmailDetails =
                    await _contactDetailsRepository.GetContactDetailsById(contactPreference.ContactEmailId);
                    if (contactEmailDetails.IsNotNull())
                    {
                        contactSummary.PreferredEmail = contactEmailDetails.Email;
                    }
                    else
                    {
                        contactSummary.PreferredEmail = null;
                    }
                }

            }
            dashboardSummary.ContactSummary = contactSummary;

            return new Result<AdvocateDashboardSummary> { Data = dashboardSummary };
        }

        private static Result<IEnumerable<DashboardDetailResponse>> LoadMockAssessment()
        {
            var dashboardDetailsList = new List<DashboardDetailResponse>();
            var dashboardDetails = new DashboardDetailResponse
            {
                Gender = Genders.Male.Value,
                Age = 35,
                AssessmentId = 00439490,
                SubmittedBy = new SubmittedBy()
                {
                    Name = Constants.Self,
                    SubmittedOn = DateTime.UtcNow.ToString(),
                    HospitalName = Constants.MemorialHospital,
                    City = Constants.DallasCity
                },
                ContactDetails = new ContactDetails()
                {
                    CellNumber = Constants.CellNumber,
                    EmailAddress = Constants.EmailAddress,
                    State = Constants.TxState,
                    City = Constants.DallasCity
                },
                Programs = new Programs()
                {
                    ProgramName = new List<string>()
                    {
                        Constants.VeteranAdministration,
                        Constants.MemorialHospitalFinancialAssistance
                    }
                }
            };
            var dashboardDetails2 = new DashboardDetailResponse
            {
                Gender = Genders.Female.Value,
                Age = 65,
                AssessmentId = 00439490,
                SubmittedBy = new SubmittedBy()
                {
                    Name = Constants.Name,
                    SubmittedOn = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
                    HospitalName = Constants.MemorialHospital,
                    City = Constants.DallasCity
                },
                ContactDetails = new ContactDetails()
                {
                    CellNumber = Constants.CellNumber,
                    EmailAddress = Constants.EmailAddress,
                    State = Constants.TxState,
                    City = Constants.DallasCity
                },
                Programs = new Programs()
                {
                    ProgramName = new List<string>()
                    {
                        Constants.SeniorCitizensAssistance,
                        Constants.MemorialHospitalFinancialAssistance
                    }
                }
            };
            dashboardDetailsList.Add(dashboardDetails);
            dashboardDetailsList.Add(dashboardDetails2);
            var sortedMockDashboardDetails = dashboardDetailsList.OrderBy(a => a.SubmittedBy.CreatedDate);
            return new Result<IEnumerable<DashboardDetailResponse>> { Data = sortedMockDashboardDetails };
        }

        public Result<long> GetEstimatedCostForVisit(int patientId)
        {
            return PropertyValues.isMockEnabled() ? new Result<long>(230) : new Result<long>(0);
        }

        private bool ContainsInvalidCharacters(string word)
        {
            return word.Contains(Constants.Percentage);
        }
    }
}