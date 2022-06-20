using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;
using HealthWare.ActiveASSIST.Entities.Mappings;
using HealthWare.ActiveASSIST.Entities;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface ITenantDataRepository
    {
        Task<long> UpdateMappingTables(ScreenTenantMapping screenTenant);
        Task<TenantDetails> GetTenantDetails(long tenantId);
        Task<TenantDetails> GetTenantByCode(string tenantCode);
    }

    public class TenantDataRepository : ITenantDataRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public TenantDataRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TenantDetails> GetTenantDetails(long tenantId)
        {
            var tenantDetails = await _unitOfWork.GetEntityAsync<TenantDetails>(x => x.Id == tenantId);
            return tenantDetails;
        }

        public async Task<TenantDetails> GetTenantByCode(string tenantCode)
        {
            var tenantDetails = await _unitOfWork.GetEntityAsync<TenantDetails>(x => x.TenantCode == tenantCode);
            return tenantDetails;
        }

        public async Task<long> UpdateMappingTables(ScreenTenantMapping screenTenant)
        {
            _unitOfWork.Attach(screenTenant.Screen);
            _unitOfWork.Attach(screenTenant.Tenant);
            await _unitOfWork.AddAsync(screenTenant);
            await _unitOfWork.CommitAsync();
            return screenTenant.Id;
        }
        
    }
}