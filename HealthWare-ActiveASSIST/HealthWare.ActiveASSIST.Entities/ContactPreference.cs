using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("ContactPreference")]
    public class ContactPreference : BaseEntity
    {
        public long AssessmentId { get; set; }
        public long ContactPhoneId { get; set; }
        public long ContactAddressId { get; set; }
        public long ContactEmailId { get; set; }
        public long OtherContactId { get; set; }
        public string TimeOfCalling { get; set; }
        public string ModeOfCommunication { get; set; }
    }
}
