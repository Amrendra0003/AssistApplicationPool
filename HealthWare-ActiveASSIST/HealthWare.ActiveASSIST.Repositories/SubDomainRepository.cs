using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;
using Healthware.Core.MultiTenancy.Entities;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface ISubDomainRepository
    {
        Task<SubDomainMaster> GetTenantBySubDomain(string subDomain);
    }

    public class SubDomainRepository : ISubDomainRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public SubDomainRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SubDomainMaster> GetTenantBySubDomain(string subDomain)
        {
            var subDomainMaster = await _unitOfWork.GetEntityAsync<SubDomainMaster>(x => x.SubDomain == subDomain);
            return subDomainMaster;
        }
    }
}