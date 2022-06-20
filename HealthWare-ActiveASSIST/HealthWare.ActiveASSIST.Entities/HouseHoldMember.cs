using System;
using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("HouseHoldMember")]
    public class HouseHoldMember : BaseEntity
    {
        public Assessment Assessment { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Relationship { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string SSNNumber { get; set; }
        public bool? IsMedicAidAvailable { get; set; }
        public bool? IsInsuranceAvailable { get; set; }
        public bool? IsDependent { get; set; }
        public string PayerName { get; set; }
        public string GroupName { get; set; }
        public string GroupNumber { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime? PriorCoverageEffectiveFrom { get; set; }
        public DateTime? PriorCoverageTerminationDate { get; set; }
        public string State { get; set; }
        public string MedicAidId { get; set; }
        public DateTime? MedicAidEffectiveFrom { get; set; }
        public DateTime? MedicAidTerminationDate { get; set; }
        public string ReasonNoSsn { get; set; }
        public bool CanDeleteHousehold { get; set; }
    }
}
