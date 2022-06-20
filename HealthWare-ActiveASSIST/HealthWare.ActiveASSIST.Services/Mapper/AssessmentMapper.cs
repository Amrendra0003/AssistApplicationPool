using System;
using System.Collections.Generic;
using System.Linq;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Extensions;
using ContactDetails = Healthware.Core.Entities.ContactDetails;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IAssessmentMapper
    {
        Guarantor MapFrom(Guarantor guarantor, UpdateGuarantorRequest updateGuarantorRequest);
        Assessment MapFrom(long loggedInUserId);
        Assessment MapFrom(Assessment assessment);
        PatientProgramRequest MapFrom(BasicInfo basicInfo,
            List<HouseHoldMember> houseHoldMembers,
            List<HouseHoldMemberIncome> houseHoldMemberIncomes,
            List<HouseHoldMemberResource> houseHoldMemberResources,
            IEnumerable<ContactDetails> contactDetails);
    }

    public class AssessmentMapper : IAssessmentMapper
    {
        public Guarantor MapFrom(Guarantor guarantor, UpdateGuarantorRequest updateGuarantorRequest)
        {
            guarantor.RelationShipWithPatient = updateGuarantorRequest.RelationshipWithPatient;
            guarantor.FirstName = updateGuarantorRequest.FirstName;
            guarantor.MiddleName = updateGuarantorRequest.MiddleName;
            guarantor.LastName = updateGuarantorRequest.LastName;
            guarantor.Suffix = updateGuarantorRequest.Suffix;
            guarantor.EmailAddress = updateGuarantorRequest.EmailAddress;
            guarantor.Cell = updateGuarantorRequest.Cell;
            guarantor.CountyCode = updateGuarantorRequest.CountyCode;
            guarantor.DateOfBirth = updateGuarantorRequest.DateOfBirth.ConvertStringToDate();
            guarantor.SSNNumber = updateGuarantorRequest.SSNNumber;
            guarantor.ReasonNoSsn = updateGuarantorRequest.ReasonNoSsn;
            return guarantor;
        }

        public Assessment MapFrom(long loggedInUserId)
        {
            var assessment = new Assessment()
            {
                CreatedBy = loggedInUserId,
                AssessmentStatusMaster = new AssessmentStatusMaster() { Id = (long)Enums.AssessmentStatus.Incomplete },
                IsActive = true,
                IsEvaluated = false
            };
            return assessment;
        }

        public Assessment MapFrom(Assessment assessment)
        {
            assessment.IsActive = false;
            return assessment;
        }

        public PatientProgramRequest MapFrom(BasicInfo basicInfo,
            List<HouseHoldMember> houseHoldMembers,
            List<HouseHoldMemberIncome> houseHoldMemberIncomes,
            List<HouseHoldMemberResource> houseHoldMemberResources,
            IEnumerable<ContactDetails> contactDetails)
        {
            var patientProgramData = new PatientProgramRequest { RequestBusinessObject = new RequestBusinessObject() };
            var clientInfo = new ClientInfo
            {
                FacilityCode = Constants.FacilityCode
            };
            var patientInfo = new PatientInfo
            {
                SSN = basicInfo.SSNNumber,
                FirstName = basicInfo.FirstName,
                MiddleName = basicInfo.MiddleName,
                LastName = basicInfo.LastName,
                Suffix = basicInfo.Suffix,
                Gender = basicInfo.Gender,
                DOB = basicInfo.DateOfBirth.ToShortDateString(),
                MaritalStatus = basicInfo.MaritalStatus,
                Phones = new List<Phone>(),
                Addresses = new List<Address>(),
                Email = basicInfo.EmailAddress,
                NumberOfHouseholdMembers = houseHoldMembers.Count.ToString(),
                HouseholdIncome = houseHoldMemberIncomes.Sum(a => a.CalculatedMonthlyIncome).ToString(),
            };

            foreach (var contactDetail in contactDetails)
            {
                if (!string.IsNullOrWhiteSpace(contactDetail.Cell))
                {
                    var phone = new Phone()
                    {
                        PhoneType = contactDetail.ContactTypeDetails.ContactType,
                        PhoneNumber = contactDetail.Cell
                    };
                    patientInfo.Phones.Add(phone);
                }

                var address = new Address()
                {
                    AddressType = contactDetail.ContactTypeDetails.ContactType,
                    Address1 = contactDetail.StreetAddress,
                    Phone = contactDetail.Cell,
                    City = contactDetail.City,
                    State = contactDetail.State,
                    ZipCode = contactDetail.Zip,
                    County = contactDetail.County
                };
                patientInfo.Addresses.Add(address);
            }

            var households = new List<Household>();

            var counter = 1;

            foreach (var houseHoldMember in houseHoldMembers)
            {
                var household = new Household
                {
                    Number = counter.ToString(),
                    RelationshipToPatient = houseHoldMember.Relationship,
                    FirstName = houseHoldMember.FirstName,
                    MiddleName = houseHoldMember.MiddleName,
                    LastName = houseHoldMember.LastName,
                    Suffix = houseHoldMember.Suffix,
                    DOB = houseHoldMember.DateOfBirth.ToString(),
                    Gender = houseHoldMember.Gender,
                    MaritalStatus = houseHoldMember.MaritalStatus,
                    SSN = houseHoldMember.SSNNumber,
                    UnderCareOfPatient = houseHoldMember.IsDependent.Value ? Constants.True : Constants.False,
                    HasPriorCoverage = houseHoldMember.IsInsuranceAvailable.Value ? Constants.True : Constants.False,
                    Resources = new List<Resource>(),
                    Incomes = new List<Income>()
                };

                var houseHoldResourceDetails =
                    houseHoldMemberResources.FindAll(a => a.HouseHoldMember.Id == houseHoldMember.Id);

                foreach (var houseHoldMemberResourceInfo in houseHoldResourceDetails.Select(houseHoldMemberResource => new Resource
                {
                    ResourceType = houseHoldMemberResource.ResourceType,
                    ResourceStatus = houseHoldMemberResource.CurrentStatus,
                    ResourceVerificationStatus = houseHoldMemberResource.Verification,
                    CurrentMarketValue = houseHoldMemberResource.CurrentMarketValue.ToString(),
                    OwnershipPercentage = houseHoldMemberResource.Ownership,
                    CalculatedResourceValue = houseHoldMemberResource.CalculatedValue.ToString(),
                    RealPropertyLocation = houseHoldMemberResource.PropertyLocation
                }))
                {
                    household.Resources.Add(houseHoldMemberResourceInfo);
                }

                var houseHoldIncomeDetails =
                    houseHoldMemberIncomes.FindAll(b => b.HouseHoldMember.Id == houseHoldMember.Id);

                foreach (var houseHoldIncome in houseHoldIncomeDetails)
                {
                    var houseHoldMemberIncomeInfo = new Income
                    {
                        IncomeType = houseHoldIncome.IncomeType,
                        IncomeStatus = houseHoldIncome.CurrentStatus,
                        IncomeVerificationStatus = houseHoldIncome.Verification,
                        IncomeAmount = houseHoldIncome.CalculatedMonthlyIncome.ToString(),
                        GrossPay = houseHoldIncome.GrossPay.ToString(),
                        CalculatedMonthlyIncome = houseHoldIncome.CalculatedMonthlyIncome.ToString(),
                        ContactName = houseHoldIncome.ContactName,
                        Addresses = new List<Address>()
                    };

                    houseHoldMemberIncomeInfo.Addresses.Add(new Address
                    {
                        State = houseHoldIncome.ContactDetails.State,
                        City = houseHoldIncome.ContactDetails.City,
                        ZipCode = houseHoldIncome.ContactDetails.Zip,
                        County = houseHoldIncome.ContactDetails.County,
                        Phone = houseHoldIncome.ContactDetails.Cell,
                        AddressType = houseHoldIncome.ContactDetails.ContactTypeDetails.ContactType,
                        Address1 = houseHoldIncome.ContactDetails.StreetAddress
                    });

                    household.Incomes.Add(houseHoldMemberIncomeInfo);
                }

                households.Add(household);
                counter++;
            }

            patientInfo.Household = households;

            patientProgramData.RequestBusinessObject.PatientInfo = patientInfo;
            patientProgramData.RequestBusinessObject.ExternalId = new Guid().ToString();
            patientProgramData.RequestBusinessObject.ClientInfo = clientInfo;
            return patientProgramData;
        }
    }
}