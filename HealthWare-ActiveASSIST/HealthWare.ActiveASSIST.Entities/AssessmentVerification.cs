using System;
using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("AssessmentVerification")]
    public class AssessmentVerification: BaseEntity
    {
        public Assessment Assessment { get; set; }
        public string EmailVerificationToken { get; set; }
        public string CellNumberOTP { get; set; }
        public DateTime? CellNumberOTPUpdatedTime { get; set; }
        public bool IsCellNumberConfirmed { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
