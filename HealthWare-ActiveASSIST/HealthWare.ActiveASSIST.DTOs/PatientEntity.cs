using System;
using System.Collections.Generic;
using System.Text;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class PatientEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CountyCode { get; set; }
        public string Cell { get; set; }
        public string DateOfService { get; set; }
        public string TenantId { get; set; }
    }
}
