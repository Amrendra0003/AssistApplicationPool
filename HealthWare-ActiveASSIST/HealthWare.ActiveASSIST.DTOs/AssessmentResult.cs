namespace HealthWare.ActiveASSIST.DTOs
{
    public class AssessmentResult
    {
        public int ScreenId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int ParentId { get; set; }
        public string QuestionKeyName { get; set; }
        public string ControlType { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public string ScreenQuestionMappingId { get; set; }
        public string OptionId { get; set; }
        public string KeyName { get; set; }
        public string DisplayFormat { get; set; }
        public string ControlId { get; set; }
        public int Order { get; set; }
    }
}
