using System.ComponentModel.DataAnnotations;
namespace HealthWare.ActiveASSIST.DTOs
{
    public class PatientBasicInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string MaidenName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string EmailAddress { get; set; }
        public string CellNumber { get; set; }
        public string CountyCode { get; set; }
        public string SSNNumber { get; set; }
        public string SSNNumberUnMasked { get; set; }
        public string ReasonNoSsn { get; set; }
        public string EmailVerificationToken { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool CellNumberConfirmed { get; set; }
        public bool AreYouGuarantor { get; set; }
        [RegularExpression(@"^(?=.*[A - Za - z])(?=.*\d)(?=.*[@$!% *#?&])[A-Za-z\d@$!%*#?&]$", ErrorMessage = Constants.PasswordPattern)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = Constants.PasswordLength)]
        public string Password { get; set; }
    }
}
