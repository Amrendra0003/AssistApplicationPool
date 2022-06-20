using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IVerificationDocumentRepository
    {
        Task<long> CreateVerificationDocument(VerificationDocument verificationDocument);
        Task<bool> UpdateVerificationDocument(VerificationDocument verificationDocument);
        Task<VerificationDocument> GetVerificationDocumentByAssessmentId(long assessmentId);
    }
    public class VerificationDocumentRepository : IVerificationDocumentRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public VerificationDocumentRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateVerificationDocument(VerificationDocument verificationDocument)
        {
            _unitOfWork.Attach(verificationDocument.Assessment);
            await _unitOfWork.AddAsync(verificationDocument);
            await _unitOfWork.CommitAsync();
            return verificationDocument.Id;
        }

        public async Task<bool> UpdateVerificationDocument(VerificationDocument verificationDocument)
        {
            _unitOfWork.Attach(verificationDocument.Assessment);
            _unitOfWork.Update(verificationDocument);
            return await _unitOfWork.CommitAsync();
            
        }

        public async Task<VerificationDocument> GetVerificationDocumentByAssessmentId(long assessmentId)
        {
           return await _unitOfWork.GetEntityAsync<VerificationDocument>(x => x.Assessment.Id == assessmentId);
        }
    }
}
