using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class ScreenQuestionMapping
    {
        [Key]
        public long Id { get; set; }
        public long ScreenId { get; set; }
        public long QuestionId { get; set; }
        public string KeyName { get; set; }
    }
}
