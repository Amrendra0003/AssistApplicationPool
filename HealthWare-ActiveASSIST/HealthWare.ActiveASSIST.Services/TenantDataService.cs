using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.Mappings;
using HealthWare.ActiveASSIST.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface ITenantDataService
    {
        Task<Result<string>> UpdateMappingTables();
        Task<Result<GetTenantDetails>> GetTenantDetails(long tenantId);
    }
    public class TenantDataService : ITenantDataService
    {
        private readonly ITenantDataRepository _tenantDataRepository;
        private readonly IAssessmentRepository _assessmentRepository;

        public TenantDataService(ITenantDataRepository tenantDataRepository, IAssessmentRepository assessmentRepository)
        {
            _tenantDataRepository = tenantDataRepository;
            _assessmentRepository = assessmentRepository;

        }
        public async Task<Result<GetTenantDetails>> GetTenantDetails(long tenantId)
        {
            var tenentDetails = await _tenantDataRepository.GetTenantDetails(tenantId);
            return new Result<GetTenantDetails> { Data = tenentDetails };
        }

        public async Task<Result<string>> UpdateMappingTables()
        {

            var screenList = await _assessmentRepository.GetDynamicScreenIdList();
            var tenantList = await _assessmentRepository.GetTenantIdList();

            foreach (var tenant in tenantList)
            {
                var mappingList = new List<ScreenTenantMapping>();
                foreach (var screenId in screenList)
                {
                    _ = await _tenantDataRepository.UpdateMappingTables(new ScreenTenantMapping()
                    {
                        Tenant = new TenantDetails() { Id = tenant },
                        Screen = new DynamicScreens() { Id = screenId },
                        RecordStatus = 1
                    });
                }
            }
            return new Result<string>() { Data = Constants.Success };
        }
    }
}
