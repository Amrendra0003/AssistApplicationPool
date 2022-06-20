using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class AssessmentStatusMaster
    {
        [Key]
        public long Id { get; set; }
        public string AssessmentStatus { get; set; }
    }
}
