using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public string QuestionName { get; set; }
        public string Type { get; set; }
        public Control Control { get; set; }
        public string Description { get; set; }
        public long? ParentId { get; set; }
        public string UiType { get; set; }
        public string DisplayFormat { get; set; }
        public string CssStyle { get; set; }
        public bool IsRequired { get; set; }
        public string? RoleName { get; set; }
    }
}
