using Healthware.Core.Base;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using System;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IPasswordPolicyRepository
    {

        public Task<long> CreatePasswordPolicy();
        public Task<long> UpdatePasswordPolicy();
        public Task<PasswordPolicy> GetPasswordPolicy(string tenantId);
        public Task<long> CreateLoginHistory(UserLoginHistory userLoginHistory);
        public Task<bool> UpdateLoginHistory(UserLoginHistory userLoginHistory);
        public Task<UserLoginHistory> GetLoginHistoryByUserId(long userId);
    }
    public class PasswordPolicyRepository : IPasswordPolicyRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public PasswordPolicyRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateLoginHistory(UserLoginHistory userLoginHistory)
        {
            _unitOfWork.Attach(userLoginHistory.User);
            await _unitOfWork.AddAsync(userLoginHistory);
            await _unitOfWork.CommitAsync();
            return userLoginHistory.Id;
        }

        public Task<long> CreatePasswordPolicy()
        {
            throw new NotImplementedException();
        }
        public async Task<PasswordPolicy> GetPasswordPolicy(string tenantId)
        {
            var passwordPolicy = await _unitOfWork.GetEntityAsync<PasswordPolicy>(x => x.TenantId == tenantId);
            return passwordPolicy;
        }
        public async Task<bool> UpdateLoginHistory(UserLoginHistory userLoginHistory)
        {
            _unitOfWork.Update(userLoginHistory);
            return await _unitOfWork.CommitAsync();
        }
        public Task<long> UpdatePasswordPolicy()
        {
            throw new NotImplementedException();
        }
        public async Task<UserLoginHistory> GetLoginHistoryByUserId(long userId)
        {
            var userHistory = await _unitOfWork.GetEntityAsync<UserLoginHistory>(x => x.User.Id == userId);
            return userHistory;
        }
    }
}
