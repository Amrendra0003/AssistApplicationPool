using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IHouseHoldIncomeRepository
    {
        Task<long> CreateHouseHoldIncome(HouseHoldMemberIncome houseHoldIncome);
        Task<HouseHoldMemberIncome> GetHouseHoldIncomeById(long id);
        Task<bool> UpdateHouseHoldIncome(HouseHoldMemberIncome updatedHouseHoldIncome);
        Task<bool> DeleteHouseHoldIncome(HouseHoldMemberIncome houseHoldIncome);
        Task<IEnumerable<HouseHoldMemberIncome>> GetHouseHoldIncomeByHouseHoldMemberId(long houseHoldMemberId);
        Task<IEnumerable<HouseHoldMemberIncome>> GetHouseHoldIncomeByHouseHoldMemberIds(List<long> houseHoldMemberIds);
        Task<HouseHoldMemberIncome> GetHouseHoldIncomeByContactId(long contactId);
    }

    public class HouseHoldIncomeRepository : IHouseHoldIncomeRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public HouseHoldIncomeRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateHouseHoldIncome(HouseHoldMemberIncome houseHoldIncome)
        {
            _unitOfWork.Attach(houseHoldIncome.HouseHoldMember);
            _unitOfWork.Attach(houseHoldIncome.ContactDetails);
            await _unitOfWork.AddAsync(houseHoldIncome);
            await _unitOfWork.CommitAsync();
            return houseHoldIncome.Id;
        }

        public Task<HouseHoldMemberIncome> GetHouseHoldIncomeById(long id)
        {
            return _unitOfWork.GetEntityAsync<HouseHoldMemberIncome>(a => a.Id == id);
        }
        public async Task<IEnumerable<HouseHoldMemberIncome>> GetHouseHoldIncomeByHouseHoldMemberIds(
            List<long> houseHoldMemberIds)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMemberIncome>
                (a => houseHoldMemberIds.Contains(a.HouseHoldMember.Id));
        }

        public async Task<bool> UpdateHouseHoldIncome(HouseHoldMemberIncome updatedHouseHoldIncome)
        {
            updatedHouseHoldIncome.ContactDetails = null;
            _unitOfWork.Update(updatedHouseHoldIncome);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteHouseHoldIncome(HouseHoldMemberIncome houseHoldIncome)
        {
            houseHoldIncome.ContactDetails = null;
            _unitOfWork.Remove(houseHoldIncome);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<HouseHoldMemberIncome>> GetHouseHoldIncomeByHouseHoldMemberId(long houseHoldMemberId)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMemberIncome>(a => a.HouseHoldMember.Id == houseHoldMemberId);
        }

        public Task<HouseHoldMemberIncome> GetHouseHoldIncomeByContactId(long contactId)
        {
            return _unitOfWork.GetEntityAsync<HouseHoldMemberIncome>(a => a.ContactDetails.Id == contactId);
        }
    }
}