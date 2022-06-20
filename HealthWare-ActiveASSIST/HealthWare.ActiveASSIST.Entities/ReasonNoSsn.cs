using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class ReasonNoSsn
    {
        [Key]
        public long Id { get; set; }
        public string CodeData { get; set; }
        public string CodeType { get; set; }
        public string CodeDescription { get; set; }
    }
}
