using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Assessment")]
    public class Assessment : BaseEntity
    {
        public AssessmentStatusMaster AssessmentStatusMaster { get; set; }
        public bool IsActive { get; set; }
        public long ExternalPatientId { get; set; }
        public bool IsEvaluated { get; set; }
    }
}
