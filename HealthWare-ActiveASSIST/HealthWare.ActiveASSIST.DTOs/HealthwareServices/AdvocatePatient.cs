using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class AdvocatePatient
    {
        public List<Patient> Patients { get; set; }
    }
    public class Patient
    {
        public string AdvocateId { get; set; }
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Citizen { get; set; }
        public string Email { get; set; }
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
        public string StateCode { get; set; }
    }
}
