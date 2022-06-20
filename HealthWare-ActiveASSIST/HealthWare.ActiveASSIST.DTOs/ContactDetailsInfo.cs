using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class ContactDetailsInfo
    {
        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public long ContactTypeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(1, long.MaxValue, ErrorMessage = Constants.PleaseProvideValidId)]
        public long AssessmentId { get; set; }
        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string StreetAddress { get; set; }
        [StringLength(250, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Suite { get; set; }
        public string Town { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string City { get; set; }
        public string State { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string ZipCode { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string County { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string CellNumber { get; set; }
        public string CountyCode { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool AreYouGuarantor { get; set; }
        public string StateCode { get; set; }
    }
}