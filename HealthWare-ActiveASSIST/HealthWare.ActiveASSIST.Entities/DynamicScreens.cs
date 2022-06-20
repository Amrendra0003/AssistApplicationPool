using System.Collections.Generic;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class DynamicScreens : BaseEntity
    {
        public string LeftHeader { get; set; }
        public string LeftContent { get; set; }
        public long? NextScreenId { get; set; }
        public long? PreviousScreenId { get; set; }
        public List<QuickAssessmentQuestions> Controls { get; set; }
    }
}