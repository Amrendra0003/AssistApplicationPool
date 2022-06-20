namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface ITabStatusMapper
    {
        Entities.TabCompletionStatus MapFrom(long assessmentId);
    }
    public class TabStatusMapper: ITabStatusMapper
    {
        public Entities.TabCompletionStatus MapFrom(long assessmentId)
        {
            var tabCompletionStatus = new Entities.TabCompletionStatus
            {
                Assessment = new Entities.Assessment
                {
                    Id = assessmentId
                },
                IsQuickAssessmentComplete = true,
                IsPersonalBasicInfoComplete = true,
                IsPersonalHomeComplete = false,
                IsPersonalWorkComplete = false,
                IsGuarantorBasicInfoComplete = false,
                IsGuarantorHomeComplete = false,
                IsGuarantorWorkComplete = false,
                IsContactPreferenceComplete = false,
                IsHouseholdComplete = false,
                IsApplicationFormsComplete = false,
                IsProgramsComplete = false,
                IsEmailVerificationComplete = false,
                IsCellVerificationComplete = false,
                IsIdVerificationComplete = false,
                IsAddressVerificationComplete = false,
                IsIncomeVerificationComplete = false,
                IsOtherVerificationComplete = false,

            };
            return tabCompletionStatus;
        }
    }
}
