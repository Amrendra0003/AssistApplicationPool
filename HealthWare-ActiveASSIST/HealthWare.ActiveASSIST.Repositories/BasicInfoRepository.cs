using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IBasicInfoRepository
    {
        Task<long> CreateBasicInfo(Entities.BasicInfo basicInfo);
        Task<Entities.BasicInfo> GetBasicInfoById(long id);
        Task<bool> UpdateBasicInfo(Entities.BasicInfo updatedBasicInfo);
        Task<Entities.BasicInfo> GetBasicInfoByAssessment(long id);
        Task<IEnumerable<Entities.BasicInfo>> GetAllBasicInfo(Expression<Func<Entities.BasicInfo, bool>> predicate = null);

    }

    public class BasicInfoRepository : IBasicInfoRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public BasicInfoRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateBasicInfo(Entities.BasicInfo basicInfo)
        {
            _unitOfWork.Attach(basicInfo.Assessment);
            await _unitOfWork.AddAsync(basicInfo);
            await _unitOfWork.CommitAsync();
            return basicInfo.Id;
        }

        public async Task<Entities.BasicInfo> GetBasicInfoById(long id)
        {
            return await _unitOfWork.GetEntityAsync<Entities.BasicInfo>(x => x.Id == id);
        }
        public async Task<Entities.BasicInfo> GetBasicInfoByAssessment(long id)
        {
            return await _unitOfWork.GetEntityAsync<Entities.BasicInfo>(x => x.Assessment.Id == id);
        }

        public Task<IEnumerable<Entities.BasicInfo>> GetAllBasicInfo(Expression<Func<Entities.BasicInfo, bool>> predicate = null)
        {
            return _unitOfWork.GetAllAsync(predicate); 
        }

        public async Task<bool> UpdateBasicInfo(Entities.BasicInfo updatedBasicInfo)
        {
            _unitOfWork.Update(updatedBasicInfo);
            var isBasicInfoUpdated = await _unitOfWork.CommitAsync();
            return isBasicInfoUpdated;
        }
    }
}