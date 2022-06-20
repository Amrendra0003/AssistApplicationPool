using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("PatientProgramMapping")]
    public class PatientProgramMapping: BaseEntity
    {
        public Assessment Assessment { get; set; }
        public Program Program { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public bool IsEvaluated { get; set; }
    }
}
