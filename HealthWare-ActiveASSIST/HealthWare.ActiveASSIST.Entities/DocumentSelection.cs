using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class VerificationDocument
    {
        [Key]
        public long Id { get; set; }
        public Assessment Assessment { get; set; }
        public long? IdVerification { get; set; }
        public long? AddressVerification { get; set; }
        public long? OtherVerification { get; set; }
    }
}
