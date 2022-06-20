using System;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IAnswerMapper
    {
        Entities.Answer MapFrom(long screenQuestionMappingId, string answerOptionId, long assessmentId, string value, long questionId);
    }
    public class AnswerMapper : IAnswerMapper
    {
        public Entities.Answer MapFrom(long screenQuestionMappingId, string answerOptionId, long assessmentId, string value, long questionId)
        {
            var answer = new Entities.Answer()
            {
                ScreenQuestionMappingId = screenQuestionMappingId,
                AssessmentId = assessmentId,
                QuestionId = questionId,
                AnswerOptionId = string.IsNullOrEmpty(answerOptionId) ? (long?)null : Convert.ToInt64(answerOptionId),
                Value = value.IsNotNull() ? value : null,
            };
            return answer;
        }
    }
}
