using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("ProgramDocument")]
    public class ProgramDocument: BaseEntity
    {
        public Program Program { get; set; }
        public string DocumentName { get; set; }
        public string FormLocation { get; set; }
        public string DocumentDescription { get; set; }
        public bool ESignFlag { get; set; }
    }
}
