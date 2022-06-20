using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.DTO;

namespace HealthWare.ActiveASSIST.Services
{
    public interface ISubDomainService
    {
        Task<Result<string>> GetTenantBySubDomain(string subDomain);


        Task<Result<PasswordPolicyResponse>> GetPasswordPolicyBySubDomain(string subDomain);
    }
    public class SubDomainService : ISubDomainService
    {
        private readonly ISubDomainRepository _subDomainRepository;
        private readonly IPasswordPolicyRepository _passwordPolicyRepository;

        public SubDomainService(ISubDomainRepository subDomainRepository, IPasswordPolicyRepository passwordPolicyRepository)
        {
            _subDomainRepository = subDomainRepository;
            _passwordPolicyRepository = passwordPolicyRepository;
        }

        public async Task<Result<string>> GetTenantBySubDomain(string subDomain)
        {
            var subDomainMaster = await _subDomainRepository.GetTenantBySubDomain(subDomain);
            return new Result<string>() { Data = subDomainMaster.TenantId };
        }

        public async Task<Result<PasswordPolicyResponse>> GetPasswordPolicyBySubDomain(string subDomain)
        {
            var subDomainMaster = await _subDomainRepository.GetTenantBySubDomain(subDomain);
            var passwordPolicy = await _passwordPolicyRepository.GetPasswordPolicy(subDomainMaster.TenantId);

            var passwordPolicyResponse = new PasswordPolicyResponse
            {
                Pattern = passwordPolicy.Pattern,
                MaximumLength = passwordPolicy.MaximumLength,
                MinimumLength = passwordPolicy.MinimumLength
            };
            return new Result<PasswordPolicyResponse>() { Data = passwordPolicyResponse };
        }
    }

}
