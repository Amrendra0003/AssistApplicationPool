using Healthware.Core.Base;
using Healthware.Core.Constants;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IHouseHoldMemberRepository
    {
        Task<long> CreateHouseHoldMember(HouseHoldMember houseHoldMember);
        Task<HouseHoldMember> GetHouseHoldMemberById(long id);
        Task<bool> UpdateHouseHoldMember(HouseHoldMember updatedHouseHoldMember);
        Task<bool> DeleteHouseHoldMember(HouseHoldMember houseHoldMember);
        Task<IEnumerable<HouseHoldMember>> GetHouseHoldMemberByAssessmentId(long assessmentId);
        Task<IEnumerable<HouseHoldMember>> GetHouseHoldNames(long assessmentId);
        Task<HouseHoldMember> GetSelfHouseHoldMember(long assessmentId);
        Task<IEnumerable<HouseHoldMember>> GetRelativeHouseHoldMember(long assessmentId);
        Task<bool> IsAccountOwnerAMember(long assessmentId, string userEmail);
        Task<bool> IsGuarantorMemberPresent(string guarantorSsnNumber, string guarantorRelationShipWithPatient);
        Task<HouseHoldMember> GetHouseholdBySSN(long assessmentId, string ssn, string relation, string firstName, string middleName, string lastName, DateTime dateOfBirth);
    }

    public class HouseHoldMemberRepository : IHouseHoldMemberRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public HouseHoldMemberRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateHouseHoldMember(HouseHoldMember houseHoldMember)
        {
            _unitOfWork.Attach(houseHoldMember.Assessment);
            await _unitOfWork.AddAsync(houseHoldMember);
            await _unitOfWork.CommitAsync();
            return houseHoldMember.Id;
        }

        public async Task<HouseHoldMember> GetHouseHoldMemberById(long id)
        {
            return await _unitOfWork.GetEntityAsync<HouseHoldMember>(x => x.Id == id);
        }

        public async Task<bool> UpdateHouseHoldMember(HouseHoldMember updatedHouseHoldMember)
        {
            _unitOfWork.Update(updatedHouseHoldMember);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteHouseHoldMember(HouseHoldMember houseHoldMember)
        {
            _unitOfWork.Remove(houseHoldMember);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<HouseHoldMember>> GetHouseHoldMemberByAssessmentId(long assessmentId)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMember>(x => x.Assessment.Id == assessmentId);
        }

        public async Task<IEnumerable<HouseHoldMember>> GetHouseHoldNames(long assessmentId)
        {
            var houseHoldMemberList = await _unitOfWork.GetAllAsync<Entities.HouseHoldMember>(x => x.Assessment.Id == assessmentId);
            return houseHoldMemberList;
        }

        //Todo:Use an identifier to get member for that particular assessment
        public async Task<HouseHoldMember> GetSelfHouseHoldMember(long assessmentId)
        {
            var selfHouseHoldMember = await _unitOfWork.GetEntityAsync<HouseHoldMember>(y => y.Relationship == Application.SelfRelation && y.Assessment.Id == assessmentId);
            return selfHouseHoldMember;
        }

        public async Task<IEnumerable<HouseHoldMember>> GetRelativeHouseHoldMember(long assessmentId)
        {
            return await _unitOfWork.GetAllAsync<HouseHoldMember>(x => x.Assessment.Id == assessmentId && x.Relationship != Application.SelfRelation);
        }

        public async Task<bool> IsAccountOwnerAMember(long assessmentId, string userEmail)
        {
            var accountOwner = await _unitOfWork.GetEntityAsync<User>(a => a.EmailAddress == userEmail);
            var houseHoldMember = await _unitOfWork.GetEntityAsync<HouseHoldMember>(a => a.FirstName == accountOwner.FirstName && a.MiddleName == accountOwner.MiddleName && a.LastName == accountOwner.LastName && a.DateOfBirth == accountOwner.DateOfBirth);
            if (houseHoldMember.IsNotNull()) return true;
            return false;
        }

        public async Task<bool> IsGuarantorMemberPresent(string guarantorSsnNumber, string guarantorRelationShipWithPatient)
        {
            var houseHoldMember = await _unitOfWork.GetEntityAsync<HouseHoldMember>(a => a.SSNNumber == guarantorSsnNumber && a.Relationship == guarantorRelationShipWithPatient);
            if (houseHoldMember.IsNotNull()) return true;
            return false;
        }

        public async Task<HouseHoldMember> GetHouseholdBySSN(long assessmentId, string ssn, string relation, string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            var houseHoldMember = await _unitOfWork.GetEntityAsync<HouseHoldMember>(a => a.SSNNumber == ssn && a.Assessment.Id == assessmentId && a.Relationship != "Self" && a.Relationship == relation && a.FirstName == firstName && a.MiddleName == middleName && a.LastName == lastName && a.DateOfBirth == dateOfBirth && a.CanDeleteHousehold.Equals(false));
            return houseHoldMember;
        }
    }
}