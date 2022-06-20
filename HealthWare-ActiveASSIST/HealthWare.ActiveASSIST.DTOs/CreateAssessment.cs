using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class CreateAssessment
    {
        public long BasicInfoId { get; set; }
        public long LoggedInUserId { get; set; }
        public string SSN { get; set; }
        public string ReasonNoSsn { get; set; }
        public string UserTime { get; set; }
        public bool IsDynamic { get; set; }
        public bool IsInsuranceAvailable { get; set; }
        public List<QuestionAndAnswer> QuestionAndAnswers { get; set; }
        public string QuestionAndAnswersJson { get; set; }
        public long QuickAssessmentResultId { get; set; }
        public AssessmentContactDetails AssessmentContactDetails { get; set; }
        public GuarantorInfo GuarantorInfo { get; set; }
    }
    public class QuestionAndAnswer
    {
        public long ScreenQuestionMappingId { get; set; }
        public long QuestionId { get; set; }
        public string OptionId { get; set; }
        public string Value { get; set; }
    }
    public class AssessmentContactDetails
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string StateCode { get; set; }
        public string CountyCode { get; set; }
    }
    public class GuarantorInfo
    {
        public string RelationshipWithPatient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
        public bool IsGuarantor { get; set; }
    }
}
