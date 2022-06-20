using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class PatientProgramResponse
    {
        public string ExternalID { get; set; }
        public ClientInfo ClientInfo { get; set; }
        public List<Program> Programs { get; set; }
        public List<Program> AllPrograms { get; set; }
        public bool Override { get; set; }
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public string Message { get; set; }
    }

    public class Program
    {
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public string BenefitsDescriptionUrl { get; set; }
        public string State { get; set; }
        public List<Form> Forms { get; set; }
        public List<Document> Documents { get; set; }
    }

    public class Form
    {
        public string FormName { get; set; }
        public string FormLocation { get; set; }
        public bool EsignFlag { get; set; }
    }

    public class Document
    {
        public string DocumentName { get; set; }
        public string DocumentLocation { get; set; }
    }
}