using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class EFormResponse
    {
        public MainApplicantDetail MainApplicantDetails { get; set; }
        public List<OtherApplicant> OtherApplicants { get; set; }
    }

    public class MainApplicantDetail
    {
        public string Title { get; set; }
        public string SSN { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string WorkCellNumber { get; set; }
        public string HomeCellNumber { get; set; }
        public string CellNumber { get; set; }
    }

    public class OtherApplicant
    {
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
    }
}
