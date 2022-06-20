using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetPatientNamesResponse
    {
        public List<PatientName> PatientNames { get; set; }
    }

    public class PatientName
    {
        public long PatientId { get; set; }
        public string FullName { get; set; }
    }
}
