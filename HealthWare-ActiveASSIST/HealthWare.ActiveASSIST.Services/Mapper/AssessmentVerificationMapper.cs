namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IAssessmentVerificationMapper
    {
        Entities.AssessmentVerification MapFrom(long assessmentId);
    }
    public class AssessmentVerificationMapper : IAssessmentVerificationMapper
    {
        public Entities.AssessmentVerification MapFrom(long assessmentId)
        {
            var assessmentVerification = new Entities.AssessmentVerification()
            {
                Assessment = new Entities.Assessment() { Id = assessmentId },
                EmailVerificationToken = null,
                CellNumberOTP = null,
                CellNumberOTPUpdatedTime = null,
                IsEmailConfirmed = false,
                IsCellNumberConfirmed = false
            };
            return assessmentVerification;
        }
    }
}
