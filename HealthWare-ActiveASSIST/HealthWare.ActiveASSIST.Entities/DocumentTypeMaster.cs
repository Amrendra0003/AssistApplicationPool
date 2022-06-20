using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class DocumentTypeMaster
    {
        [Key]
        public long Id { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
