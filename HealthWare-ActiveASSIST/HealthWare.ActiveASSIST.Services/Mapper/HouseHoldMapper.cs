using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Repository;
using ContactDetails = Healthware.Core.Entities.ContactDetails;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IHouseHoldMapper
    {
        HouseHoldMember MapFrom(HouseHoldMemberDetails houseHoldMemberDto);
        HouseHoldMemberIncome MapFrom(HouseHoldIncomeDetails income, long houseHoldMemberId,
            long assessmentId, long contactDetailsId);
        HouseHoldMemberResource MapFrom(HouseHoldResourceDetails houseHoldResourceDto,
            long houseHoldMemberId, long assessmentId);
        Task<HouseHoldMemberDetails> MapFrom(HouseHoldMember houseHoldMember, IEnumerable<HouseHoldMemberIncome> houseHoldIncomes, IEnumerable<HouseHoldMemberResource> houseHoldResources);
        HouseHoldMemberIncome MapFrom(HouseHoldMemberIncome houseHoldIncome, HouseHoldIncomeDetails incomeDto);
        HouseHoldMemberResource MapFrom(HouseHoldMemberResource houseHoldResource, HouseHoldResourceDetails resourceDto);
        HouseHoldMember MapFrom(HouseHoldMember houseHoldMember, HouseHoldMemberDetails houseHoldMemberDto);
        HouseHoldMember MapFrom(HouseHoldMember householdMember, BasicInfo updatedBasicInfo);
        HouseHoldMember MapFrom(BasicInfo basicInfo, bool isInsuranceAvailable);
        HouseHoldMember MapFrom(User loggedInUser);
        HouseHoldMember MapFrom(Guarantor guarantor);
        Task<HouseHoldMember> MapFromUpdate(HouseHoldMember houseHoldMember, Guarantor updatedGuarantor);
        HouseHoldMember MapFromCreate(Guarantor guarantor);
    }
    public class HouseHoldMapper : IHouseHoldMapper
    {
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        public HouseHoldMapper(IContactDetailsRepository<PatientDbContext> contactDetailsRepository)
        {
            _contactDetailsRepository = contactDetailsRepository;
        }
        public HouseHoldMember MapFrom(HouseHoldMemberDetails houseHoldMemberDto)
        {
            var houseHoldMember = new HouseHoldMember()
            {
                Assessment = new Assessment { Id = houseHoldMemberDto.AssessmentId },
                FirstName = houseHoldMemberDto.FirstName,
                MiddleName = houseHoldMemberDto.MiddleName,
                LastName = houseHoldMemberDto.LastName,
                Suffix = houseHoldMemberDto.Suffix,
                Relationship = houseHoldMemberDto.Relationship,
                DateOfBirth = houseHoldMemberDto.DateOfBirth.ConvertStringToDate(),
                Gender = houseHoldMemberDto.Gender,
                MaritalStatus = houseHoldMemberDto.MaritalStatus,
                SSNNumber = houseHoldMemberDto.SSNNumber,
                ReasonNoSsn = houseHoldMemberDto.ReasonNoSsn,
                IsDependent = houseHoldMemberDto.IsDependent,
                IsMedicAidAvailable = houseHoldMemberDto.IsMedicAidAvailable,
                IsInsuranceAvailable = houseHoldMemberDto.IsInsuranceAvailable,
                PayerName = houseHoldMemberDto.PayerName,
                GroupName = houseHoldMemberDto.GroupName,
                GroupNumber = houseHoldMemberDto.GroupNumber,
                PolicyNumber = houseHoldMemberDto.PolicyNumber,
                PriorCoverageEffectiveFrom = !houseHoldMemberDto.PriorCoverageEffectiveFrom.IsNullOrWhiteSpace() ? houseHoldMemberDto.PriorCoverageEffectiveFrom.ConvertStringToDate() : (DateTime?)null,
                PriorCoverageTerminationDate = !houseHoldMemberDto.PriorCoverageTerminationDate.IsNullOrWhiteSpace() ? houseHoldMemberDto.PriorCoverageTerminationDate.ConvertStringToDate() : (DateTime?)null,
                State = houseHoldMemberDto.State,
                MedicAidId = houseHoldMemberDto.MedicAidId,
                MedicAidEffectiveFrom = !houseHoldMemberDto.MedicAidEffectiveFrom.IsNullOrWhiteSpace() ? houseHoldMemberDto.MedicAidEffectiveFrom.ConvertStringToDate() : (DateTime?)null,
                MedicAidTerminationDate = !houseHoldMemberDto.MedicAidTerminationDate.IsNullOrWhiteSpace() ? houseHoldMemberDto.MedicAidTerminationDate.ConvertStringToDate() : (DateTime?)null,
                CanDeleteHousehold = true
            };
            return houseHoldMember;
        }

        public HouseHoldMemberIncome MapFrom(HouseHoldIncomeDetails income, long houseHoldMemberId,
            long assessmentId, long contactDetailsId)
        {
            var houseHoldIncome = new HouseHoldMemberIncome()
            {
                HouseHoldMember = new HouseHoldMember { Id = houseHoldMemberId },
                IncomeType = income.IncomeType,
                CurrentStatus = income.CurrentStatus,
                Verification = income.Verification,
                GrossPay = Convert.ToDecimal(income.GrossPay),
                GrossPayPeriod = income.GrossPayPeriod,
                CalculatedMonthlyIncome = Convert.ToDecimal(income.CalculatedMonthlyIncome),
                ContactName = income.ContactName,
                ContactDetails = new ContactDetails { Id = contactDetailsId }
            };
            return houseHoldIncome;
        }

        public HouseHoldMemberResource MapFrom(HouseHoldResourceDetails houseHoldResourceDto,
            long houseHoldMemberId, long assessmentId)
        {
            var houseHoldResource = new HouseHoldMemberResource()
            {
                HouseHoldMember = new HouseHoldMember { Id = houseHoldMemberId },
                ResourceType = houseHoldResourceDto.ResourceType,
                CurrentStatus = houseHoldResourceDto.CurrentStatus,
                Verification = houseHoldResourceDto.Verification,
                CurrentMarketValue = Convert.ToDecimal(houseHoldResourceDto.CurrentMarketValue),
                Ownership = houseHoldResourceDto.Ownership,
                CalculatedValue = Convert.ToDecimal(houseHoldResourceDto.CalculatedValue),
                PropertyLocation = houseHoldResourceDto.PropertyLocation
            };
            return houseHoldResource;
        }

        // Mapper for GetHouseHoldMemberById API
        public async Task<HouseHoldMemberDetails> MapFrom(HouseHoldMember houseHoldMember, IEnumerable<HouseHoldMemberIncome> houseHoldIncomes, IEnumerable<HouseHoldMemberResource> houseHoldResources)
        {
            var ssnMasked = "";
            if (houseHoldMember.SSNNumber.IsNotNullOrEmpty())
            {
                var asterisk = new String('*', houseHoldMember.SSNNumber.Length - 4);
                var last = houseHoldMember.SSNNumber.Substring(houseHoldMember.SSNNumber.Length - 4, 4);
                ssnMasked = String.Concat(asterisk, last);
            }
            
            var houseHoldMemberDto = new HouseHoldMemberDetails()
            {
                AssessmentId = houseHoldMember.Assessment.Id,
                Id = houseHoldMember.Id,
                FirstName = houseHoldMember.FirstName,
                MiddleName = houseHoldMember.MiddleName,
                LastName = houseHoldMember.LastName,
                Suffix = houseHoldMember.Suffix,
                Relationship = houseHoldMember.Relationship,
                DateOfBirth = houseHoldMember.DateOfBirth.Value.ToInvariantDateString(),
                Gender = houseHoldMember.Gender,
                MaritalStatus = houseHoldMember.MaritalStatus,
                SSNNumber = houseHoldMember.SSNNumber,
                SSNNumberMasked = ssnMasked,
                ReasonNoSsn = houseHoldMember.ReasonNoSsn,
                IsDependent = (houseHoldMember.IsDependent == null) ? (bool?)null : houseHoldMember.IsDependent.Value,
                IsMedicAidAvailable = (houseHoldMember.IsMedicAidAvailable == null) ? (bool?)null : houseHoldMember.IsMedicAidAvailable.Value,

                IsInsuranceAvailable = (houseHoldMember.IsInsuranceAvailable == null) ? (bool?)null : houseHoldMember.IsInsuranceAvailable.Value,
                PayerName = houseHoldMember.PayerName,
                GroupName = houseHoldMember.GroupName,
                GroupNumber = houseHoldMember.GroupNumber,
                PolicyNumber = houseHoldMember.PolicyNumber,
                PriorCoverageEffectiveFrom = houseHoldMember.PriorCoverageEffectiveFrom == null ? string.Empty : houseHoldMember.PriorCoverageEffectiveFrom.Value.ToInvariantDateString(),
                PriorCoverageTerminationDate = houseHoldMember.PriorCoverageTerminationDate == null ? string.Empty : houseHoldMember.PriorCoverageTerminationDate.Value.ToInvariantDateString(),
                State = houseHoldMember.State,
                MedicAidId = houseHoldMember.MedicAidId,
                MedicAidEffectiveFrom = houseHoldMember.MedicAidEffectiveFrom == null ? string.Empty : houseHoldMember.MedicAidEffectiveFrom.Value.ToInvariantDateString(),
                MedicAidTerminationDate = houseHoldMember.MedicAidTerminationDate == null ? string.Empty : houseHoldMember.MedicAidTerminationDate.Value.ToInvariantDateString(),
            };

            var houseHoldIncomeDtos = new List<HouseHoldIncomeDetails>();
            var houseHoldResourceDtos = new List<HouseHoldResourceDetails>();

            foreach (var income in houseHoldIncomes)
            {
                var contactDetails = await _contactDetailsRepository.GetContactDetailsById(income.ContactDetails.Id);
                var houseHoldIncomeDto = new HouseHoldIncomeDetails()
                {
                    IncomeId = income.Id,
                    ContactDetailsId = contactDetails.Id,
                    IncomeType = income.IncomeType,
                    CurrentStatus = income.CurrentStatus,
                    Verification = income.Verification,
                    GrossPay = income.GrossPay.ToString(),
                    GrossPayPeriod = income.GrossPayPeriod,
                    CalculatedMonthlyIncome = Convert.ToString(income.CalculatedMonthlyIncome),
                    CompanyName = contactDetails.Name,
                    ContactName = income.ContactName,
                    StreetAddress = contactDetails.StreetAddress,
                    City = contactDetails.City,
                    State = contactDetails.State,
                    ZipCode = contactDetails.Zip,
                    CellNumber = contactDetails.Cell,
                    Fax = contactDetails.Fax,
                    CountyCode = contactDetails.CountyCode
                };
                houseHoldIncomeDtos.Add(houseHoldIncomeDto);
            }

            foreach (var resource in houseHoldResources)
            {
                var houseHoldResourceDto = new HouseHoldResourceDetails()
                {
                    ResourceId = resource.Id,
                    ResourceType = resource.ResourceType,
                    CurrentStatus = resource.CurrentStatus,
                    Verification = resource.Verification,
                    CurrentMarketValue = resource.CurrentMarketValue.ToString(),
                    Ownership = resource.Ownership,
                    CalculatedValue = Convert.ToString(resource.CalculatedValue),
                    PropertyLocation = resource.PropertyLocation
                };
                houseHoldResourceDtos.Add(houseHoldResourceDto);
            }

            houseHoldMemberDto.HouseHoldIncomeDtos = houseHoldIncomeDtos;
            houseHoldMemberDto.HouseHoldResourceDtos = houseHoldResourceDtos;
            return houseHoldMemberDto;
        }

        //Update HouseHoldIncome
        public HouseHoldMemberIncome MapFrom(HouseHoldMemberIncome houseHoldIncome, HouseHoldIncomeDetails incomeDto)
        {
            houseHoldIncome.IncomeType = incomeDto.IncomeType;
            houseHoldIncome.CurrentStatus = incomeDto.CurrentStatus;
            houseHoldIncome.Verification = incomeDto.Verification;
            houseHoldIncome.GrossPay = Convert.ToDecimal(incomeDto.GrossPay);
            houseHoldIncome.GrossPayPeriod = incomeDto.GrossPayPeriod;
            houseHoldIncome.CalculatedMonthlyIncome = Convert.ToDecimal(incomeDto.CalculatedMonthlyIncome);
            houseHoldIncome.ContactName = incomeDto.ContactName;
            return houseHoldIncome;
        }

        //Update HouseHoldResource
        public HouseHoldMemberResource MapFrom(HouseHoldMemberResource houseHoldResource, HouseHoldResourceDetails resourceDto)
        {
            houseHoldResource.ResourceType = resourceDto.ResourceType;
            houseHoldResource.CurrentStatus = resourceDto.CurrentStatus;
            houseHoldResource.Verification = resourceDto.Verification;
            houseHoldResource.CurrentMarketValue = Convert.ToDecimal(resourceDto.CurrentMarketValue);
            houseHoldResource.Ownership = resourceDto.Ownership;
            houseHoldResource.CalculatedValue = Convert.ToDecimal(resourceDto.CalculatedValue);
            houseHoldResource.PropertyLocation = resourceDto.PropertyLocation;
            return houseHoldResource;
        }

        public HouseHoldMember MapFrom(HouseHoldMember houseHoldMember, HouseHoldMemberDetails houseHoldMemberDto)
        {
            houseHoldMember.FirstName = houseHoldMemberDto.FirstName;
            houseHoldMember.MiddleName = houseHoldMemberDto.MiddleName;
            houseHoldMember.LastName = houseHoldMemberDto.LastName;
            houseHoldMember.Suffix = houseHoldMemberDto.Suffix;
            houseHoldMember.Relationship = houseHoldMemberDto.Relationship;
            houseHoldMember.DateOfBirth = houseHoldMemberDto.DateOfBirth.ConvertStringToDate();
            houseHoldMember.Gender = houseHoldMemberDto.Gender;
            houseHoldMember.MaritalStatus = houseHoldMemberDto.MaritalStatus;
            houseHoldMember.SSNNumber = houseHoldMemberDto.SSNNumber;
            houseHoldMember.ReasonNoSsn = houseHoldMemberDto.ReasonNoSsn;
            houseHoldMember.IsDependent = houseHoldMemberDto.IsDependent;
            houseHoldMember.IsMedicAidAvailable = houseHoldMemberDto.IsMedicAidAvailable;
            houseHoldMember.IsInsuranceAvailable = houseHoldMemberDto.IsInsuranceAvailable;
            houseHoldMember.PayerName = houseHoldMemberDto.PayerName;
            houseHoldMember.GroupName = houseHoldMemberDto.GroupName;
            houseHoldMember.GroupNumber = houseHoldMemberDto.GroupNumber;
            houseHoldMember.PolicyNumber = houseHoldMemberDto.PolicyNumber;
            houseHoldMember.PriorCoverageEffectiveFrom = !houseHoldMemberDto.PriorCoverageEffectiveFrom.IsNullOrWhiteSpace() ? houseHoldMemberDto.PriorCoverageEffectiveFrom.ConvertStringToDate() : (DateTime?)null;
            houseHoldMember.PriorCoverageTerminationDate = !houseHoldMemberDto.PriorCoverageTerminationDate.IsNullOrWhiteSpace() ? houseHoldMemberDto.PriorCoverageTerminationDate.ConvertStringToDate() : (DateTime?)null;
            houseHoldMember.State = houseHoldMemberDto.State;
            houseHoldMember.MedicAidId = houseHoldMemberDto.MedicAidId;
            houseHoldMember.MedicAidEffectiveFrom = !houseHoldMemberDto.MedicAidEffectiveFrom.IsNullOrWhiteSpace() ? houseHoldMemberDto.MedicAidEffectiveFrom.ConvertStringToDate() : (DateTime?)null;
            houseHoldMember.MedicAidTerminationDate = !houseHoldMemberDto.MedicAidTerminationDate.IsNullOrWhiteSpace() ? houseHoldMemberDto.MedicAidTerminationDate.ConvertStringToDate() : (DateTime?)null;
            return houseHoldMember;
        }

        public HouseHoldMember MapFrom(HouseHoldMember householdMember, BasicInfo updatedBasicInfo)
        {
            householdMember.FirstName = updatedBasicInfo.FirstName;
            householdMember.MiddleName = updatedBasicInfo.MiddleName;
            householdMember.LastName = updatedBasicInfo.LastName;
            householdMember.Suffix = updatedBasicInfo.Suffix;
            householdMember.DateOfBirth = updatedBasicInfo.DateOfBirth;
            householdMember.MaritalStatus = updatedBasicInfo.MaritalStatus;
            householdMember.Gender = updatedBasicInfo.Gender;
            householdMember.SSNNumber = updatedBasicInfo.SSNNumber;
            householdMember.ReasonNoSsn = updatedBasicInfo.ReasonNoSsn;

            return householdMember;
        }

        public HouseHoldMember MapFrom(BasicInfo basicInfo, bool isInsuranceAvailable)
        {
            var householdMember = new HouseHoldMember
            {
                Assessment = new Assessment { Id = basicInfo.Assessment.Id },
                FirstName = basicInfo.FirstName,
                MiddleName = basicInfo.MiddleName,
                LastName = basicInfo.LastName,
                Suffix = basicInfo.Suffix,
                Relationship = "Self",
                DateOfBirth = basicInfo.DateOfBirth,
                Gender = basicInfo.Gender,
                MaritalStatus = basicInfo.MaritalStatus,
                SSNNumber = basicInfo.SSNNumber,
                ReasonNoSsn = basicInfo.ReasonNoSsn,
                IsMedicAidAvailable = null,
                IsInsuranceAvailable = isInsuranceAvailable,
                IsDependent = null,
                CanDeleteHousehold = false
            };
            return householdMember;
        }

        public HouseHoldMember MapFrom(User loggedInUser)
        {
            var houseHoldMember = new HouseHoldMember
            {
                
                Assessment = null,
                FirstName = loggedInUser.FirstName,
                MiddleName = loggedInUser.MiddleName,
                LastName = loggedInUser.LastName,
                Suffix = null,
                Relationship = null,
                DateOfBirth = loggedInUser.DateOfBirth,
                Gender = loggedInUser.Gender,
                MaritalStatus = null,
                SSNNumber = null,
                IsMedicAidAvailable = null,
                IsInsuranceAvailable = null,
                IsDependent = null,
                PayerName = null,
                GroupName = null,
                GroupNumber = null,
                PolicyNumber = null,
                PriorCoverageEffectiveFrom = null,
                PriorCoverageTerminationDate = null,
                State = null,
                MedicAidId = null,
                MedicAidEffectiveFrom = null,
                MedicAidTerminationDate = null,
                ReasonNoSsn = null,
                CanDeleteHousehold = false
            };
            return houseHoldMember;
        }

        public HouseHoldMember MapFrom(Guarantor guarantor)
        {
            var houseHoldMember = new HouseHoldMember
            {
                FirstName = guarantor.FirstName,
                MiddleName = guarantor.MiddleName,
                LastName = guarantor.LastName,
                Suffix = guarantor.Suffix,
                Relationship = guarantor.RelationShipWithPatient,
                DateOfBirth = guarantor.DateOfBirth,
                Gender = null,
                MaritalStatus = null,
                SSNNumber = guarantor.SSNNumber,
                IsMedicAidAvailable = null,
                IsInsuranceAvailable = null,
                IsDependent = null,
                PayerName = null,
                GroupName = null,
                GroupNumber = null,
                PolicyNumber = null,
                PriorCoverageEffectiveFrom = null,
                PriorCoverageTerminationDate = null,
                State = null,
                MedicAidId = null,
                MedicAidEffectiveFrom = null,
                MedicAidTerminationDate = null,
                ReasonNoSsn = guarantor.ReasonNoSsn,
                CanDeleteHousehold = false
            };
            return houseHoldMember;
        }

        public async Task<HouseHoldMember> MapFromUpdate(HouseHoldMember houseHoldMember, Guarantor updatedGuarantor)
        {
            houseHoldMember.FirstName = updatedGuarantor.FirstName;
            houseHoldMember.MiddleName = updatedGuarantor.MiddleName;
            houseHoldMember.LastName = updatedGuarantor.LastName;
            houseHoldMember.Relationship = updatedGuarantor.RelationShipWithPatient;
            houseHoldMember.Suffix = updatedGuarantor.Suffix;
            houseHoldMember.DateOfBirth = updatedGuarantor.DateOfBirth;
            houseHoldMember.SSNNumber = updatedGuarantor.SSNNumber;
            houseHoldMember.ReasonNoSsn = updatedGuarantor.ReasonNoSsn;

            return houseHoldMember;
        }

        public HouseHoldMember MapFromCreate(Guarantor guarantor)
        {
            var houseHoldMember = new HouseHoldMember
            {
                FirstName = guarantor.FirstName,
                MiddleName = guarantor.MiddleName,
                LastName = guarantor.LastName,
                Suffix = guarantor.Suffix,
                Relationship = guarantor.RelationShipWithPatient,
                DateOfBirth = guarantor.DateOfBirth,
                Gender = null,
                MaritalStatus = null,
                SSNNumber = guarantor.SSNNumber
            };
            return houseHoldMember;
        }
    }
}
