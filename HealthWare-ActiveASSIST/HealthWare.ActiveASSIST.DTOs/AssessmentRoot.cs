using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class AssessmentRoot
    {
        public List<Screen> screen { get; set; }
    }
    public class Screen
    {
        [JsonProperty("@ScreenId")]
        public string ScreenId { get; set; }

        [JsonProperty("@ScreenName")]
        public string ScreenName { get; set; }
        public string LeftPanelContent { get; set; }
        public string LeftDescription { get; set; }
        public List<Question> Questions { get; set; }
    }
    public class Questions
    {
        public Question Question { get; set; }
    }
    public class Question
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UIType { get; set; }
        public string DisplayFormat { get; set; }
        public string KeyName { get; set; }
        public string CssStyle { get; set; }
        public string ScreenQuestionMappingId { get; set; }
        public bool IsRequired { get; set; }
        public List<Option> Options { get; set; }
        public SubQuestion SubQuestion { get; set; }
    }
    public class Option
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
    }
    public class SubQuestion
    {
        public List<Question> Question { get; set; }
    }
}
