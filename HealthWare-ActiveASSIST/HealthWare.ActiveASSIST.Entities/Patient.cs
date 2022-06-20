using System;
using Healthware.Core.Entities;
using HealthWare.ActiveASSIST.DTOs;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CountyCode { get; set; }
        public string Cell { get; set; }
        public DateTime? DateOfService { get; set; }
        public string TenantId { get; set; }

        public static implicit operator Patient(PatientEntity v)
        {
            return new Patient()
            {
                FirstName = v.FirstName,
                LastName = v.LastName,
                CountyCode = v.CountyCode,
                Cell = v.Cell,
                EmailAddress = v.EmailAddress,
            };
        }
    }
}
