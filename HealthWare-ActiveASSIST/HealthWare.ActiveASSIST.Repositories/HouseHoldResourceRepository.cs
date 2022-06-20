using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IHouseHoldResourceRepository
    {
        Task<long> CreateHouseHoldResource(HouseHoldMemberResource houseHoldResource);
        Task<HouseHoldMemberResource> GetHouseHoldResourceById(long id);
        Task<bool> UpdateHouseHoldResource(HouseHoldMemberResource updatedHouseHoldResource);
        Task<bool> DeleteHouseHoldResource(HouseHoldMemberResource houseHoldResource);
        Task<IEnumerable<HouseHoldMemberResource>> GetHouseHoldResourceByHouseHoldMemberId(long houseHoldMemberId);
        Task<IEnumerable<HouseHoldMemberResource>> GetHouseHoldResourceByHouseHoldMemberIds(
            List<long> houseHoldMemberIds);
    }

    public class HouseHoldResourceRepository : IHouseHoldResourceRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public HouseHoldResourceRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateHouseHoldResource(HouseHoldMemberResource houseHoldResource)
        {
            _unitOfWork.Attach(houseHoldResource.HouseHoldMember);
            await _unitOfWork.AddAsync(houseHoldResource);
            await _unitOfWork.CommitAsync();
            return houseHoldResource.Id;
        }

        public async Task<HouseHoldMemberResource> GetHouseHoldResourceById(long id)
        {
            return await _unitOfWork.GetEntityAsync<HouseHoldMemberResource>(a => a.Id == id);
        }

        public async Task<bool> UpdateHouseHoldResource(HouseHoldMemberResource updatedHouseHoldResource)
        {
            _unitOfWork.Update(updatedHouseHoldResource);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteHouseHoldResource(HouseHoldMemberResource houseHoldResource)
        {
            _unitOfWork.Remove(houseHoldResource);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<HouseHoldMemberResource>> GetHouseHoldResourceByHouseHoldMemberId(long houseHoldMemberId)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMemberResource>(a => a.HouseHoldMember.Id == houseHoldMemberId);
        }

        public async Task<IEnumerable<HouseHoldMemberResource>> GetHouseHoldResourceByHouseHoldMemberIds(
            List<long> houseHoldMemberIds)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMemberResource>
                (a => houseHoldMemberIds.Contains(a.HouseHoldMember.Id));
        }
    }
}