using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.Repository;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IHouseHoldService
    {
        Task<Result<MessageDto>> CreateHouseHoldMember(HouseHoldMemberDetails houseHoldMemberDto);
        Task<Result<object>> GetHouseHoldMembersList(long assessmentId);
        Task<Result<HouseHoldMemberDetails>> GetHouseHoldMemberById(long houseHoldMemberId);
        Task<Result<MessageDto>> DeleteHouseHoldMember(long householdMemberId);
        Task<Result<IncomeResourceDetail>> GetIncomeResourcesAmount(long assessmentId);
    }

    public class HouseHoldService : IHouseHoldService
    {
        private readonly IHouseHoldMapper _houseHoldMapper;
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly IContactDetailsMapper _contactDetailsMapper;
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        private readonly IHouseHoldIncomeRepository _houseHoldIncomeRepository;
        private readonly IHouseHoldResourceRepository _houseHoldResourceRepository;
        private readonly IHouseholdMemberDocumentMappingRepository _householdMemberDocumentMappingRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IAssessmentService _assessmentService;
        private readonly IAnswerRepository _answerRepository;

        public HouseHoldService(IHouseHoldMapper houseHoldMapper,
            IHouseHoldMemberRepository houseHoldMemberRepository,
            IContactDetailsMapper contactDetailsMapper, IContactDetailsRepository<PatientDbContext> contactDetailsRepository,
            IHouseHoldIncomeRepository houseHoldIncomeRepository,
            IHouseHoldResourceRepository houseHoldResourceRepository, IHouseholdMemberDocumentMappingRepository householdMemberDocumentMappingRepository, IDocumentRepository documentRepository, IAssessmentService assessmentService, IAnswerRepository answerRepository)
        {
            _houseHoldMapper = houseHoldMapper;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _contactDetailsMapper = contactDetailsMapper;
            _contactDetailsRepository = contactDetailsRepository;
            _houseHoldIncomeRepository = houseHoldIncomeRepository;
            _houseHoldResourceRepository = houseHoldResourceRepository;
            _householdMemberDocumentMappingRepository = householdMemberDocumentMappingRepository;
            _documentRepository = documentRepository;
            _assessmentService = assessmentService;
            _answerRepository = answerRepository;
        }

        public async Task<Result<MessageDto>> CreateHouseHoldMember(HouseHoldMemberDetails houseHoldMemberDto)
        {
            long houseHoldMemberId = houseHoldMemberDto.Id;

            if (houseHoldMemberDto.Id == 0)
            {
                //Mapper - HouseHoldMember
                //Save HouseHoldMember and get Id
                var houseHoldMember = _houseHoldMapper.MapFrom(houseHoldMemberDto);
                houseHoldMemberId = _houseHoldMemberRepository.CreateHouseHoldMember(houseHoldMember).GetAwaiter()
                    .GetResult();
                if (houseHoldMemberId == 0) return new Result<MessageDto>().AddError(Constants.CouldNotCreateHouseHoldMember);
            }
            else if (houseHoldMemberDto.Id > 0)
            {
                var houseHoldMember = _houseHoldMemberRepository
                    .GetHouseHoldMemberById(houseHoldMemberDto.Id)
                    .GetAwaiter()
                    .GetResult();

                if (houseHoldMember.IsNull()) return new Result<MessageDto>().AddError(Constants.HouseholdMemberNotFound);

                var updatedHouseHoldMember = _houseHoldMapper.MapFrom(houseHoldMember, houseHoldMemberDto);
                var isHouseHoldMemberUpdated = await _houseHoldMemberRepository
                    .UpdateHouseHoldMember(updatedHouseHoldMember);
                if (!isHouseHoldMemberUpdated)
                    return new Result<MessageDto>().AddError(Constants.CouldNotUpdateHouseholdMember);
            }

            //Save income details only when DTO size > 0
            //If IncomeId == 0 then insert else update
            if (houseHoldMemberDto.HouseHoldIncomeDtos.Count > 0)
            {
                //Loop each HouseHoldIncome detail and save
                //Mapper - Address
                //Save Address and get Id.
                //Mapper - HouseHoldIncome
                foreach (var incomeDto in houseHoldMemberDto.HouseHoldIncomeDtos)
                {
                    if (incomeDto.IncomeId == 0 && incomeDto.ContactDetailsId == 0)
                    {
                        var contactDetailsDto = _contactDetailsMapper.MapFrom(incomeDto,
                            houseHoldMemberDto.AssessmentId);

                        var contactDetails = _contactDetailsMapper.MapFrom(contactDetailsDto);
                        var contactDetailsId = await _contactDetailsRepository.CreateContactDetail(contactDetails);
                        if (contactDetailsId == 0) return new Result<MessageDto>().AddError(Constants.CouldNotInsertHouseholdIncomeContactDetails);

                        var houseHoldIncome = _houseHoldMapper.MapFrom(incomeDto, houseHoldMemberId,
                            houseHoldMemberDto.AssessmentId, contactDetailsId);
                        var houseHoldIncomeId = _houseHoldIncomeRepository.CreateHouseHoldIncome(houseHoldIncome).GetAwaiter()
                            .GetResult();
                        if (houseHoldIncomeId == 0) return new Result<MessageDto>().AddError(Constants.CouldNotInsertHouseholdIncome);
                    }
                    else if (incomeDto.IncomeId > 0 && incomeDto.ContactDetailsId > 0)
                    {
                        //Update Income
                        var houseHoldIncome =
                            await _houseHoldIncomeRepository.GetHouseHoldIncomeById(incomeDto.IncomeId);
                        var updatedHouseHoldIncome = _houseHoldMapper.MapFrom(houseHoldIncome, incomeDto);
                        var isHouseHoldIncomeUpdated =
                            await _houseHoldIncomeRepository.UpdateHouseHoldIncome(updatedHouseHoldIncome);
                        if (!isHouseHoldIncomeUpdated) return new Result<MessageDto>().AddError(Constants.CouldNotUpdateHouseholdIncome);

                        //Update Address
                        var contactDetails = await _contactDetailsRepository.GetContactDetailsById(incomeDto.ContactDetailsId);
                        var updatedContactDetails = _contactDetailsMapper.MapFrom(contactDetails, incomeDto);
                        var isContactDetailsUpdated = await _contactDetailsRepository.UpdateContactDetails(updatedContactDetails);
                        if (!isContactDetailsUpdated) return new Result<MessageDto>().AddError(Constants.CouldNotUpdateHouseholdIncomeContactDetails);
                    }
                }
            }

            //Save resource details only when DTO size > 0
            //If ResourceId == 0 then insert else update
            if (houseHoldMemberDto.HouseHoldResourceDtos.Count > 0)
            {
                //Loop each HouseHoldResource details and save
                //Mapper - HouseHoldResource
                //Save HouseHoldResource.
                foreach (var resourceDto in houseHoldMemberDto.HouseHoldResourceDtos)
                {
                    if (resourceDto.ResourceId == 0)
                    {
                        var houseHoldResource = _houseHoldMapper.MapFrom(resourceDto, houseHoldMemberId,
                            houseHoldMemberDto.AssessmentId);
                        var houseHoldResourceId = await _houseHoldResourceRepository.CreateHouseHoldResource(houseHoldResource);
                        if (houseHoldResourceId == 0) return new Result<MessageDto>().AddError(Constants.CouldNotInsertHouseHoldResources);
                    }
                    else if (resourceDto.ResourceId > 0)
                    {
                        var houseHoldResource =
                            await _houseHoldResourceRepository.GetHouseHoldResourceById(resourceDto.ResourceId);
                        var updatedHouseHoldResource = _houseHoldMapper.MapFrom(houseHoldResource, resourceDto);
                        var isResourceUpdated =
                            await _houseHoldResourceRepository.UpdateHouseHoldResource(updatedHouseHoldResource);
                        if (!isResourceUpdated) return new Result<MessageDto>().AddError(Constants.CouldNotUpdateHouseholdResources);
                    }
                }
            }

            if (houseHoldMemberDto.DeletedIncomeIds.Count > 0)
            {
                foreach (var incomeId in houseHoldMemberDto.DeletedIncomeIds)
                {
                    if (Convert.ToInt64(incomeId) > 0)
                    {
                        var houseHoldIncome = await _houseHoldIncomeRepository.GetHouseHoldIncomeById(Convert.ToInt64(incomeId));
                        if (houseHoldIncome.IsNull()) return new Result<MessageDto>().AddError(Constants.InvalidHouseHoldIncomeId);
                        var contactDetails = await _contactDetailsRepository.GetContactDetailsById(houseHoldIncome.ContactDetails.Id);

                        //First delete HouseholdIncome
                        //Then delete Address
                        var isHouseHoldIncomeDeleted = await _houseHoldIncomeRepository.DeleteHouseHoldIncome(houseHoldIncome);
                        _ = await _contactDetailsRepository.DeleteContactDetails(contactDetails);

                        if (!isHouseHoldIncomeDeleted) new Result<MessageDto>().AddError(Constants.CouldNotDeleteHouseholdIncome);
                    }
                }
            }

            if (houseHoldMemberDto.DeletedResourceIds.Count > 0)
            {
                foreach (var resourceId in houseHoldMemberDto.DeletedResourceIds)
                {
                    if (Convert.ToInt64(resourceId) > 0)
                    {
                        var houseHoldResource = await _houseHoldResourceRepository.GetHouseHoldResourceById(Convert.ToInt64(resourceId));
                        if (houseHoldResource.IsNull()) return new Result<MessageDto>().AddError(Constants.InvalidHouseHoldResourceId);
                        var isHouseHoldResourceDeleted = await _houseHoldResourceRepository.DeleteHouseHoldResource(houseHoldResource);
                        if (!isHouseHoldResourceDeleted) new Result<MessageDto>().AddError(Constants.CouldNotDeleteHouseHoldResource);
                    }
                }
            }

            //Update tab status
            await _assessmentService.UpdateTabStatus(houseHoldMemberDto.AssessmentId, Constants.Household, true);

            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Constants.HouseholdMemberCreated) };
        }

        public async Task<Result<object>> GetHouseHoldMembersList(long assessmentId)
        {
            var memberList = new List<HouseHoldMemberList.MemberList>();

            var houseHoldMemberList = await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(assessmentId);
            var houseHoldMemberListDto = new HouseHoldMemberList();
            foreach (var houseHoldMember in houseHoldMemberList)
            {
                var member = new HouseHoldMemberList.MemberList();
                var houseHoldIncomeList =
                    await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberId(houseHoldMember.Id);
                var houseHoldResourceList =
                    await _houseHoldResourceRepository.GetHouseHoldResourceByHouseHoldMemberId(houseHoldMember.Id);
                member.HouseHoldMemberId = houseHoldMember.Id;
                member.Name = houseHoldMember.FirstName + StringExtensions.Space +
                              houseHoldMember.LastName;
                member.Relation = houseHoldMember.Relationship;
                member.CanDeleteHousehold = houseHoldMember.CanDeleteHousehold;

                var years = CalculateHouseholdMemberAge(houseHoldMember, member);

                int CalculateHouseholdMemberAge(HouseHoldMember houseHoldMember1, HouseHoldMemberList.MemberList member1)
                {
                    DateTime now = DateTime.Now;
                    int year = new DateTime(DateTime.Now.Subtract(houseHoldMember1.DateOfBirth.Value).Ticks).Year - 1;
                    DateTime pastYearDate = houseHoldMember1.DateOfBirth.Value.AddYears(year);
                    int months = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        if (pastYearDate.AddMonths(i) == now)
                        {
                            months = i;
                            break;
                        }
                        else if (pastYearDate.AddMonths(i) >= now)
                        {
                            months = i - 1;
                            break;
                        }
                    }

                    int days = now.Subtract(pastYearDate.AddMonths(months)).Days;
                    int hours = now.Subtract(pastYearDate).Hours;
                    int seconds = now.Subtract(pastYearDate).Seconds;

                    if (year != 0)
                    {
                        member1.Age = year + Constants.Years;
                    }
                    else if (year == 0)
                    {
                        member1.Age = months + Constants.Months;
                        houseHoldMemberListDto.Minors += 1;
                    }

                    var memberAge = String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)", year, months,
                        days, hours, seconds);
                    return year;
                }

                if (years < 18)
                {
                    houseHoldMemberListDto.Minors += 1;
                }

                member.DateOfBirth =
                    houseHoldMember.DateOfBirth?.ToString(Constants.MonthDayYear, CultureInfo.InvariantCulture);
                if (!houseHoldIncomeList.Any())
                {
                    member.MonthlyIncome = null;
                    member.MonthlyIncomeString = null;
                    member.Source = null;
                }
                else
                {
                    member.MonthlyIncome = (decimal)houseHoldIncomeList.Where(a=>a.CurrentStatus.Equals("Current") || a.CurrentStatus.Equals("Not Current, but in month of patient care")).Select(t => t.CalculatedMonthlyIncome).Sum();
                    member.MonthlyIncomeString = houseHoldIncomeList.Where(a=>a.CurrentStatus.Equals("Current") || a.CurrentStatus.Equals("Not Current, but in month of patient care")).Select(t => t.CalculatedMonthlyIncome).Sum().ToString();
                }

                if (houseHoldIncomeList.Count() == 1)
                {
                    member.Source = houseHoldIncomeList.FirstOrDefault().IncomeType;
                }
                else if (houseHoldIncomeList.Count() > 1)
                {
                    member.Source = Constants.MultipleIncome;
                }

                if (houseHoldResourceList.Count() == 0)
                {
                    member.Resource = null;
                    member.ResourceString = null;
                    member.Type = null;
                }
                else
                {
                    member.Resource = (decimal)houseHoldResourceList.Select(t => t.CalculatedValue).Sum();
                    member.ResourceString = houseHoldResourceList.Select(t => t.CalculatedValue).Sum().ToString();
                }

                if (houseHoldResourceList.Count() == 1)
                {
                    member.Type = houseHoldResourceList.FirstOrDefault().ResourceType;
                }
                else if (houseHoldResourceList.Count() > 1)
                {
                    member.Type = Constants.MultipleResources;
                }

                if (houseHoldMember.FirstName.IsNull() || houseHoldMember.LastName.IsNull() ||
                    houseHoldMember.Relationship.IsNull() || houseHoldMember.Gender.IsNull() ||
                    houseHoldMember.DateOfBirth == null ||
                    (houseHoldMember.SSNNumber.IsNull() && houseHoldMember.ReasonNoSsn.IsNull()) ||
                    houseHoldMember.IsMedicAidAvailable == null || houseHoldMember.IsMedicAidAvailable == null ||
                    houseHoldMember.IsDependent == null)
                {
                    member.IsRequiredDetailsCompleted = false;
                }

                memberList.Add(member);
            }

            var questionAnswerJson = await _answerRepository.GetQuestionAnswerJson(assessmentId);
            if (questionAnswerJson.IsNotNull())
            {
                var values = JsonConvert.DeserializeObject<List<Dictionary<Object, Object>>>(questionAnswerJson.QuestionAnswerJson);
                houseHoldMemberListDto.TotalHouseholdCount = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.TotalHouseholdMembers))?[Constants.TotalHouseholdMembers];
            }
            else
            {
                var summaryResult = await _answerRepository.GetAssessmentSummary(assessmentId);
                var assessmentSummary = summaryResult.FirstOrDefault(x => x.KeyName == "noOfHousehold");
                houseHoldMemberListDto.TotalHouseholdCount = assessmentSummary.Value;
            }
            
            houseHoldMemberListDto.MemberLists = memberList;
            houseHoldMemberListDto.TotalMembers = memberList.Count;
            houseHoldMemberListDto.TotalMonthlyIncome = memberList.Select(t => t.MonthlyIncome).Sum().ToString();
            houseHoldMemberListDto.TotalResource = memberList.Select(t => t.Resource).Sum().ToString();

            return new Result<object>()
            { Data = houseHoldMemberListDto };
        }

        public async Task<Result<HouseHoldMemberDetails>> GetHouseHoldMemberById(long houseHoldMemberId)
        {
            var houseHoldMember = await _houseHoldMemberRepository.GetHouseHoldMemberById(houseHoldMemberId);
            var houseHoldIncomes =
                await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberId(houseHoldMember.Id);
            var houseHoldResources =
                await _houseHoldResourceRepository.GetHouseHoldResourceByHouseHoldMemberId(houseHoldMemberId);

            var houseHoldMemberDto =
                await _houseHoldMapper.MapFrom(houseHoldMember, houseHoldIncomes, houseHoldResources);
            return new Result<HouseHoldMemberDetails>() { Data = houseHoldMemberDto };
        }
        public async Task<Result<MessageDto>> DeleteHouseHoldMember(long householdMemberId)
        {
            var householdMember = await _houseHoldMemberRepository.GetHouseHoldMemberById(householdMemberId);
            if (householdMember.IsNull()) return new Result<MessageDto>().AddError(Error.HouseholdMemberNotFound);

            //Delete the uploaded documents for Household member if any.
            var householdDocuments = await _householdMemberDocumentMappingRepository.GetDocumentMapping(householdMember.Id);

            if (householdDocuments.Count() > 0)
            {
                foreach (var householdDocument in householdDocuments)
                {
                    _ =
                        await _householdMemberDocumentMappingRepository.DeleteDocumentMapping(householdDocument.Document.Id, householdMemberId);
                }

                foreach (var householdDocument in householdDocuments)
                {
                    _ = await _documentRepository.DeleteDocument(householdDocument.Document.Id);
                }
            }
            //Delete Contact Address for the Household income if any.
            //Delete Household Income if any.
            var householdIncomes =
                await _houseHoldIncomeRepository.GetHouseHoldIncomeByHouseHoldMemberId(householdMemberId);
            if (householdIncomes.Count() > 0)
            {
                foreach (var householdIncome in householdIncomes)
                {
                    var contactContactDetails = await _contactDetailsRepository.GetContactDetailsById(householdIncome.ContactDetails.Id);

                    var isHouseholdIncomeDeleted = await _houseHoldIncomeRepository.DeleteHouseHoldIncome(householdIncome);
                    if (!isHouseholdIncomeDeleted) return new Result<MessageDto>().AddError(Error.DeleteHouseholdIncomeFailed);
                    if (contactContactDetails.IsNotNull())
                    {
                        var isContactDetailsDeleted = await _contactDetailsRepository.DeleteContactDetails(contactContactDetails);
                        if (!isContactDetailsDeleted) return new Result<MessageDto>().AddError(Error.DeleteContactDetailsFailed);
                    }
                }
            }

            //Delete Household Resource if any.
            var householdResources =
                await _houseHoldResourceRepository.GetHouseHoldResourceByHouseHoldMemberId(householdMemberId);
            if (householdResources.Any())
            {
                foreach (var householdResource in householdResources)
                {
                    var isHouseholdDeleted =
                        await _houseHoldResourceRepository.DeleteHouseHoldResource(householdResource);
                    if (!isHouseholdDeleted) return new Result<MessageDto>().AddError(Error.DeleteHouseholdResourceFailed);
                }
            }

            //Delete Household Member.

            var isHouseHoldDeleted = await _houseHoldMemberRepository.DeleteHouseHoldMember(householdMember);
            if (!isHouseHoldDeleted) return new Result<MessageDto>().AddError(Error.DeleteHouseholdMemberFailed);

            //Update tab status
            var householdMembers =
                await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(householdMember.Assessment.Id);
            if (householdMembers.Count() == 0)
            {
                await _assessmentService.UpdateTabStatus(householdMember.Assessment.Id, Constants.Household, false);
            }


            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.DeletedHouseholdMemberSuccess) };
        }

        public async Task<Result<IncomeResourceDetail>> GetIncomeResourcesAmount(long assessmentId)
        {
            var totalHouseholdCount = "";
            var incomeResourceDetail = new IncomeResourceDetail();
            var questionAnswerJson = await _answerRepository.GetQuestionAnswerJson(assessmentId);
            //if(questionAnswerJson.IsNull()) return new Result<IncomeResourceDetail>().AddError(Constants.InvalidRequest);
            if (questionAnswerJson.IsNotNull())
            {
                var values = JsonConvert.DeserializeObject<List<Dictionary<Object, Object>>>(questionAnswerJson.QuestionAnswerJson);
                totalHouseholdCount = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.TotalHouseholdMembers))?[Constants.TotalHouseholdMembers];

                if (!totalHouseholdCount.Equals("1")) return new Result<IncomeResourceDetail>().AddError(Constants.InvalidRequest);
                incomeResourceDetail.IncomeAmount = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.EstimatedHouseholdIncome))?[Constants.EstimatedHouseholdIncome];
                incomeResourceDetail.GrossPay = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.GrossPay))?[Constants.GrossPay];
                incomeResourceDetail.ResourceAmount = (string)values.FirstOrDefault(x => x.ContainsKey(Constants.EstimatedHouseholdResource))?[Constants.EstimatedHouseholdResource];
            }
            else
            {
                var summaryResult = await _answerRepository.GetAssessmentSummary(assessmentId);
                totalHouseholdCount = summaryResult.FirstOrDefault(x => x.KeyName == "noOfHousehold").Value;
                
                if (!totalHouseholdCount.Equals("1")) return new Result<IncomeResourceDetail>().AddError(Constants.InvalidRequest);
                incomeResourceDetail.IncomeAmount = summaryResult.FirstOrDefault(x => x.KeyName == "householdIncome").Value;
                incomeResourceDetail.GrossPay = summaryResult.FirstOrDefault(x => x.KeyName == "incomePayPeriod").Value;
                incomeResourceDetail.ResourceAmount = summaryResult.FirstOrDefault(x => x.KeyName == "householdResources").Value;
            }

            return new Result<IncomeResourceDetail>()
                { Data = incomeResourceDetail };
        }
    }
}