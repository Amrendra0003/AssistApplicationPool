using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class DocumentProgramMapping
    {
        [Key]
        public long Id { get; set; }
        public Document Document { get; set; }
        public ProgramDocument ProgramDocument { get; set; }
    }
}
