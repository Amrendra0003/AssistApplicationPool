using System;

namespace Healthware.Core.Entities
{
    public class MainUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Cell { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string OtpNumber { get; set; }
        public bool CanChangePassword { get; set; }
        public bool IsTokenConsumed { get; set; }
        public bool IsAuthenticated { get; set; }
        public string CountyCode { get; set; }
        public DateTime? LoginOTPUpdatedTime { get; set; }
        public bool? IsTwoFactorEnabled { get; set; }
        public string MaritalStatus { get; set; }
        public string SSNNumber { get; set; }
        public ContactDetails? ContactDetails { get; set; }
        public ContactDetails? SecondaryEmailContactDetails { get; set; }
    }
}
