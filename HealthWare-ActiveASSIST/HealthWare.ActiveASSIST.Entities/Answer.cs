using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Answer")]
    public class Answer
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public Nullable<Int64> AnswerOptionId { get; set; }
        public long ScreenQuestionMappingId { get; set; }
        public long AssessmentId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
