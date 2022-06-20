using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Base;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IAnswerRepository
    {
        Task<long> CreateAnswer(Answer answer);
        Task<bool> IsMyselfAssessment(long assessmentId);
        Task<IEnumerable<AssessmentSummaryResult>> GetAssessmentSummary(long assessmentId);
        Task<long> AddQuestionAnswerJson(QuickAssessmentResult quickAssessmentResult);
        Task<QuickAssessmentResult> GetQuestionAnswerJson(long assessmentId);
        Task<QuickAssessmentResult> GetPartialAssessmentById(long partialSaveId);

        Task<bool> UpdateQuickAssessmentResult(QuickAssessmentResult quickAssessmentResult);
        Task<QuickAssessmentResult> GetPartialAssessmentByUserId(int userId);
        Task<bool> DeleteQuickAssessmentResult(QuickAssessmentResult quickAssessmentResult);
    }
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public AnswerRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateAnswer(Answer answer)
        {
            await _unitOfWork.AddAsync(answer);
            await _unitOfWork.CommitAsync();
            return answer.Id;
        }

        public async Task<bool> IsMyselfAssessment(long assessmentId)
        {
            var answer = await _unitOfWork.GetEntityAsync<Answer>(x => x.AssessmentId == assessmentId && x.QuestionId == 1 && x.AnswerOptionId == 1 && x.Value == Constants.Myself);
            return answer.IsNotNull();
        }

        public async Task<IEnumerable<AssessmentSummaryResult>> GetAssessmentSummary(long assessmentId)
        {
            var assessmentSummaryResult = await _unitOfWork.ExecuteQuery<AssessmentSummaryResult>(string.Format(Constants.GetAssessmentSummaryQuery, assessmentId));
            return assessmentSummaryResult;
        }

        public async Task<long> AddQuestionAnswerJson(QuickAssessmentResult quickAssessmentResult)
        {
            if (quickAssessmentResult.Assessment != null)
                _unitOfWork.Attach(quickAssessmentResult.Assessment);
            await _unitOfWork.AddAsync(quickAssessmentResult);
            _ = await _unitOfWork.CommitAsync();
            return quickAssessmentResult.Id;
        }

        public async Task<QuickAssessmentResult> GetQuestionAnswerJson(long assessmentId)
        {
            return await _unitOfWork.GetEntityAsync<QuickAssessmentResult>(x => x.Assessment.Id == assessmentId);
        }

        public async Task<QuickAssessmentResult> GetPartialAssessmentById(long partialSaveId)
        {
            return await _unitOfWork.GetEntityAsync<QuickAssessmentResult>(x => x.Id == partialSaveId && x.Assessment == null);
        }

        public async Task<bool> UpdateQuickAssessmentResult(QuickAssessmentResult quickAssessmentResult)
        {
            _unitOfWork.Update(quickAssessmentResult);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<QuickAssessmentResult> GetPartialAssessmentByUserId(int userId)
        {
            return await _unitOfWork.GetEntityAsync<QuickAssessmentResult>(a => a.CreatedBy == userId && a.Assessment == null);
        }

        public async Task<bool> DeleteQuickAssessmentResult(QuickAssessmentResult quickAssessmentResult)
        {
            _unitOfWork.Remove(quickAssessmentResult);
            return await _unitOfWork.CommitAsync();
        }
    }
}
