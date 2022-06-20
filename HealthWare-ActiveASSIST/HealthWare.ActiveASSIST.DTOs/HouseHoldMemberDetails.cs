using FoolProof.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class HouseHoldMemberDetails
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        [Required]
        public long AssessmentId { get; set; }
        [Required]
        [RegularExpression(@"^.{2,}$", ErrorMessage = Constants.MinimumTwoCharactersRequired)]
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string MiddleName { get; set; }
        [Required]
        [RegularExpression(@"^.{1,}$", ErrorMessage = Constants.MinimumOneCharacterRequired)]
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Suffix { get; set; }
        [Required]
        public string Relationship { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string SSNNumber { get; set; }
        public string SSNNumberMasked { get; set; }
        public string ReasonNoSsn { get; set; }
        public bool? IsDependent { get; set; }
        public bool? IsMedicAidAvailable { get; set; }
        public bool? IsInsuranceAvailable { get; set; }

        [RequiredIf("IsInsuranceAvailable", true)]
        public string PayerName { get; set; }
        //[RequiredIf("IsInsuranceAvailable", true)]
        public string GroupName { get; set; }
        [RequiredIf("IsInsuranceAvailable", true)]
        public string GroupNumber { get; set; }
        [RequiredIf("IsInsuranceAvailable", true)]
        public string PolicyNumber { get; set; }
        public string PriorCoverageEffectiveFrom { get; set; }
        public string PriorCoverageTerminationDate { get; set; }
        [RequiredIf("IsMedicAidAvailable", true)]
        public string State { get; set; }
        [RequiredIf("IsMedicAidAvailable", true)]
        public string MedicAidId { get; set; }
        public string MedicAidEffectiveFrom { get; set; }
        public string MedicAidTerminationDate { get; set; }
        [Required]
        public List<int> DeletedIncomeIds { get; set; }
        [Required]
        public List<int> DeletedResourceIds { get; set; }
        public List<HouseHoldIncomeDetails> HouseHoldIncomeDtos { get; set; }
        public List<HouseHoldResourceDetails> HouseHoldResourceDtos { get; set; }
    }

    public class HouseHoldIncomeDetails
    {
        [Required]
        public long IncomeId { get; set; }
        [Required]
        public long ContactDetailsId { get; set; }
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = Constants.MinimumThreeCharactersRequired)]
        public string IncomeType { get; set; }
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = Constants.MinimumThreeCharactersRequired)]
        public string CurrentStatus { get; set; }
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = Constants.MinimumThreeCharactersRequired)]
        public string Verification { get; set; }
        [Required]
        [RegularExpression(@"^.{1,}$", ErrorMessage = Constants.MinimumOneCharacterRequired)]
        public string GrossPay { get; set; }
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = Constants.MinimumThreeCharactersRequired)]
        public string GrossPayPeriod { get; set; }
        [RegularExpression(@"^.{1,}$", ErrorMessage = Constants.MinimumOneCharacterRequired)]
        public string CalculatedMonthlyIncome { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CellNumber { get; set; }
        public string Fax { get; set; }
        public string CountyCode { get; set; }
    }

    public class HouseHoldResourceDetails
    {
        [Required]
        public long ResourceId { get; set; }
        [Required]
        [RegularExpression(@"^.{2,}$", ErrorMessage = Constants.MinimumTwoCharactersRequired)]
        public string ResourceType { get; set; }
        [Required]
        [RegularExpression(@"^.{2,}$", ErrorMessage = Constants.MinimumTwoCharactersRequired)]
        public string CurrentStatus { get; set; }
        [Required]
        [RegularExpression(@"^.{2,}$", ErrorMessage = Constants.MinimumTwoCharactersRequired)]
        public string Verification { get; set; }
        [Required]
        [RegularExpression(@"^.{1,}$", ErrorMessage = Constants.MinimumOneCharacterRequired)]
        public string CurrentMarketValue { get; set; }
        [Required]
        [RegularExpression(@"^.{1,}$", ErrorMessage = Constants.MinimumOneCharacterRequired)]
        public string Ownership { get; set; }
        [Required]
        public string CalculatedValue { get; set; }
        public string PropertyLocation { get; set; }
    }
}