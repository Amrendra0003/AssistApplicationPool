using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class UpdateContactDetails
    {
        [Required]
        public long ContactDetailsId { get; set; }

        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string StreetAddress { get; set; }
        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Name { get; set; }
        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Suite { get; set; }
        public string Town { get; set; }

        [RegularExpression(@"^.{3,}$", ErrorMessage = Constants.MinimumThreeCharactersRequired)]
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string City { get; set; }

        [RegularExpression(@"^.{2,}$", ErrorMessage = Constants.MinimumTwoCharactersRequired)]
        public string State { get; set; }

        [RegularExpression(@"^.{5,}$", ErrorMessage = Constants.MinFiveCharactersRequired)]
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string ZipCode { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string County { get; set; }
        [RegularExpression(@"^.{10,}$", ErrorMessage = Constants.MinTenCharactersRequired)]
        [StringLength(25, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string CellNumber { get; set; }

        public string CountyCode { get; set; }
        public string Fax { get; set; }
        [Required]
        public long AssessmentId { get; set; }
        public bool AreYouGuarantor { get; set; }
        public string StateCode { get; set; }
    }
}
