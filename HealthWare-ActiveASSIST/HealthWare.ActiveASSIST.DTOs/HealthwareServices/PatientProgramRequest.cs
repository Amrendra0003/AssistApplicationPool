using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class PatientProgramRequest
    {
        public RequestBusinessObject RequestBusinessObject { get; set; }
    }

    public class RequestBusinessObject
    {
        public string ExternalId { get; set; }
        public ClientInfo ClientInfo { get; set; }
        public PatientInfo PatientInfo { get; set; }
    }

    public class ClientInfo
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string FacilityCode { get; set; }
    }

    public class PatientInfo
    {
        public string PAN { get; set; }
        public string MRN { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string MaritalStatus { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Address> Addresses { get; set; }
        public string Email { get; set; }
        public string NumberOfHouseholdMembers { get; set; }
        public string HouseholdIncome { get; set; }
        public List<Household> Household { get; set; }
    }

    public class Phone
    {
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Address
    {
        public string AddressType { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string Phone { get; set; }
    }

    public class Household
    {
        public string Number { get; set; }
        public string RelationshipToPatient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string SSN { get; set; }
        public string UnderCareOfPatient { get; set; }
        public string HasPriorCoverage { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Resource> Resources { get; set; }
    }

    public class Income
    {
        public string IncomeType { get; set; }
        public string IncomeStatus { get; set; }
        public string IncomeVerificationStatus { get; set; }
        public string IncomeAmount { get; set; }
        public string GrossPay { get; set; }
        public string CalculatedMonthlyIncome { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public List<Address> Addresses { get; set; }
    }

    public class Resource
    {
        public string ResourceType { get; set; }
        public string ResourceStatus { get; set; }
        public string ResourceVerificationStatus { get; set; }
        public string CurrentMarketValue { get; set; }
        public string OwnershipPercentage { get; set; }
        public string CalculatedResourceValue { get; set; }
        public string RealPropertyLocation { get; set; }
    }
}