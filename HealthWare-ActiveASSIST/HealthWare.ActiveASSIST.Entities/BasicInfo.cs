using System;
using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table(Healthware.Core.Constants.Application.BasicInfo)]
    public class BasicInfo : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Assessment Assessment { get; set; }

        public string Suffix { get; set; }
        public string MaidenName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string EmailAddress { get; set; }
        public string SSNNumber { get; set; }
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
        public long BasicContactId { get; set; }
        public long HomeContactId { get; set; }
        public long WorkContactId { get; set; }
        public string ReasonNoSsn { get; set; }
    }
}
