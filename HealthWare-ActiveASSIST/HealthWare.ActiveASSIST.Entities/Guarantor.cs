using System;
using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Guarantor")]
    public class Guarantor: BaseEntity
    {
        public Assessment Assessment { get; set; }
        public string RelationShipWithPatient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public string Cell { get; set; }
        public string CountyCode { get; set; }
        public string SSNNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long BasicContactId { get; set; }
        public long HomeContactId { get; set; }
        public long WorkContactId { get; set; }
        public string ReasonNoSsn { get; set; }
    }
}
