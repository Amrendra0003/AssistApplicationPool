using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface ITabStatusRepository
    {
        Task<long> CreateTabStatus(Entities.TabCompletionStatus tabCompletionStatus);
        Task<Entities.TabCompletionStatus> GetTabStatus(long assessmentId);
        Task<bool> Update(Entities.TabCompletionStatus tabStatus);
    }
    public class TabStatusRepository: ITabStatusRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public TabStatusRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreateTabStatus(Entities.TabCompletionStatus tabCompletionStatus)
        {
            _unitOfWork.Attach(tabCompletionStatus.Assessment);
            await _unitOfWork.AddAsync(tabCompletionStatus);
            await _unitOfWork.CommitAsync();
            return tabCompletionStatus.Id;
        }

        public async Task<Entities.TabCompletionStatus> GetTabStatus(long assessmentId)
        {
            var tabCompletionStatus =
                await _unitOfWork.GetEntityAsync<Entities.TabCompletionStatus>(x => x.Assessment.Id == assessmentId);
            return tabCompletionStatus;
        }

        public async Task<bool> Update(Entities.TabCompletionStatus tabStatus)
        {
            _unitOfWork.Update(tabStatus);
            return await _unitOfWork.CommitAsync();
        }
    }
}
