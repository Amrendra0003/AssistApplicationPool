using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class TabCompletionStatus
    {
        [Key]
        public long Id { get; set; }
        public Assessment Assessment { get; set; }
        public bool? IsQuickAssessmentComplete { get; set; }
        public bool? IsPersonalBasicInfoComplete { get; set; }
        public bool? IsPersonalHomeComplete { get; set; }
        public bool? IsPersonalWorkComplete { get; set; }
        public bool? IsGuarantorBasicInfoComplete { get; set; }
        public bool? IsGuarantorHomeComplete { get; set; }
        public bool? IsGuarantorWorkComplete { get; set; }
        public bool? IsContactPreferenceComplete { get; set; }
        public bool? IsHouseholdComplete { get; set; }
        public bool? IsApplicationFormsComplete { get; set; }
        public bool? IsProgramsComplete { get; set; }
        public bool? IsEmailVerificationComplete { get; set; }
        public bool? IsCellVerificationComplete { get; set; }
        public bool? IsIdVerificationComplete { get; set; }
        public bool? IsAddressVerificationComplete { get; set; }
        public bool? IsIncomeVerificationComplete { get; set; }
        public bool? IsOtherVerificationComplete { get; set; }
    }
}
