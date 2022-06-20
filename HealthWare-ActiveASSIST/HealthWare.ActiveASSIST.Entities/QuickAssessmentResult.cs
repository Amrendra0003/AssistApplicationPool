using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class QuickAssessmentResult : BaseEntity
    {
        public Assessment Assessment { get; set; }
        public string QuestionAnswerJson { get; set; }
    }
}
