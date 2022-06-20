using System;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IAssessmentVerificationRepository
    {
        Task<Entities.AssessmentVerification> GetVerification(long assessmentId);
        Task<long> CreateVerification(Entities.AssessmentVerification verification);
        Task<bool> UpdateVerificationByCellNumberOtp(Entities.AssessmentVerification verification, string otp);
        Task<bool> UpdateVerificationByCellNumberConfirmed(Entities.AssessmentVerification verification, bool isCellConfirmed);
        Task<bool> UpdateVerificationByEmailConfirmed(Entities.AssessmentVerification verification, bool isEmailConfirmed);
        Task<bool> UpdateVerificationByToken(Entities.AssessmentVerification verification, string token);
    }
    public class AssessmentVerificationRepository : IAssessmentVerificationRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public AssessmentVerificationRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Entities.AssessmentVerification> GetVerification(long assessmentId)
        {
            var assessmentVerification = await _unitOfWork.GetEntityAsync<Entities.AssessmentVerification>(z => z.Assessment.Id == assessmentId);
            return assessmentVerification;
        }

        public async Task<long> CreateVerification(Entities.AssessmentVerification verification)
        {
            _unitOfWork.Attach(verification.Assessment);
            await _unitOfWork.AddAsync(verification);
            await _unitOfWork.CommitAsync();
            return verification.Id;
        }

        public async Task<bool> UpdateVerificationByCellNumberOtp(Entities.AssessmentVerification verification, string otp)
        {
            verification.CellNumberOTP = otp;
            verification.CellNumberOTPUpdatedTime = DateTime.UtcNow;
            _unitOfWork.Update(verification);
            var isVerificationUpdated = await _unitOfWork.CommitAsync();
            return isVerificationUpdated;
        }
        public async Task<bool> UpdateVerificationByCellNumberConfirmed(Entities.AssessmentVerification verification, bool isCellConfirmed)
        {
            verification.IsCellNumberConfirmed = isCellConfirmed;
            _unitOfWork.Update(verification);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateVerificationByEmailConfirmed(Entities.AssessmentVerification verification, bool isEmailConfirmed)
        {
            verification.IsEmailConfirmed = isEmailConfirmed;
            _unitOfWork.Update(verification);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> UpdateVerificationByToken(Entities.AssessmentVerification verification, string token)
        {
            verification.EmailVerificationToken = token;
            _unitOfWork.Update(verification);
            return await _unitOfWork.CommitAsync();
        }
    }
}
