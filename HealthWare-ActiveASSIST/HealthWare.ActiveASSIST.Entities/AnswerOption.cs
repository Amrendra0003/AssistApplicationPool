using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class AnswerOption
    {
        [Key]
        public long Id { get; set; }
        public string Content { get; set; }
        public long QuestionId { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }   
        public int Order { get; set; }   
    }
}
