using Healthware.Core.MultiTenancy.Entities;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using System;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IPasswordPolicyService
    {
        public Task<PasswordPolicy> GetPasswordPolicy(string tenantId);
        public Task<long> CreateLoginHistory(long userId, string expiryTime);
        public Task<long> UpdateLoginHistory(UserLoginHistory userLoginHistory, User user, PasswordPolicy passwordPolicy);
        public Task<UserLoginHistory> GetUserLoginHistory(long userId);
    }
    public class PasswordPolicyService : IPasswordPolicyService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordPolicyRepository _passwordPolicyRepository;

        public PasswordPolicyService(IUserRepository userRepository, IPasswordPolicyRepository passwordPolicyRepository)
        {
            _userRepository = userRepository;
            _passwordPolicyRepository = passwordPolicyRepository;

        }
        public async Task<long> CreateLoginHistory(long userId, string expiryTime)
        {
            double expirationHours = Convert.ToDouble(expiryTime);
            var userLogin = new UserLoginHistory()
            {
                NoOfAttempts = 1,
                ExpireTime = DateTime.UtcNow.AddHours(expirationHours),
                User = new User { Id = userId }
            };
            var userHistoryId = await _passwordPolicyRepository.CreateLoginHistory(userLogin);
            return userHistoryId;
        }
        public async Task<PasswordPolicy> GetPasswordPolicy(string tenantId)
        {
            var passwordPolicy = await _passwordPolicyRepository.GetPasswordPolicy(tenantId);
            return passwordPolicy;
        }
        public async Task<UserLoginHistory> GetUserLoginHistory(long userId)
        {
            var getUserHistory = await _passwordPolicyRepository.GetLoginHistoryByUserId(userId);
            return getUserHistory;
        }
        public async Task<long> UpdateLoginHistory(UserLoginHistory userLoginHistory, User user, PasswordPolicy passwordPolicy)
        {
            var attemptLimit = passwordPolicy.AttemptLimits;
            double expirationHours = Convert.ToDouble(passwordPolicy.ExpireTime);
            if (userLoginHistory.NoOfAttempts < attemptLimit - 1 && DateTime.UtcNow < userLoginHistory.ExpireTime)
            {
                userLoginHistory.NoOfAttempts = userLoginHistory.NoOfAttempts + 1;
                await _passwordPolicyRepository.UpdateLoginHistory(userLoginHistory);
            }
            else if (userLoginHistory.NoOfAttempts < attemptLimit - 1 && DateTime.UtcNow > userLoginHistory.ExpireTime)
            {
                userLoginHistory.NoOfAttempts = 1;
                userLoginHistory.ExpireTime = DateTime.UtcNow.AddHours(expirationHours);
                await _passwordPolicyRepository.UpdateLoginHistory(userLoginHistory);
            }
            else if (userLoginHistory.NoOfAttempts == attemptLimit - 1 && DateTime.UtcNow < userLoginHistory.ExpireTime)
            {
                userLoginHistory.NoOfAttempts = userLoginHistory.NoOfAttempts + 1;
                user.IsActive = false;
                await _userRepository.Update(user);
                await _passwordPolicyRepository.UpdateLoginHistory(userLoginHistory);
            }
            else if (userLoginHistory.NoOfAttempts > attemptLimit - 1 && user.IsActive.Equals(false))
            {
                user.IsActive = true;
                userLoginHistory.NoOfAttempts = 1;
                userLoginHistory.ExpireTime = DateTime.UtcNow.AddHours(expirationHours);
                await _userRepository.Update(user);
                await _passwordPolicyRepository.UpdateLoginHistory(userLoginHistory);
            }
            return userLoginHistory.NoOfAttempts;
        }
    }
}
