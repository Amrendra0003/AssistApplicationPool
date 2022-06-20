using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IDocumentTypeMasterRepository
    {
        Task<long> GetDocumentTypeMaster(string documentType);
        Task<Entities.DocumentTypeMaster> GetDocumentTypeMasterId(long id);
    }
    public class DocumentTypeMasterRepository: IDocumentTypeMasterRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public DocumentTypeMasterRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> GetDocumentTypeMaster(string documentType)
        {
            var documentTypeMaster =
                await _unitOfWork.GetEntityAsync<Entities.DocumentTypeMaster>(x => x.DocumentTypeName == documentType);
            return documentTypeMaster.Id;
        }

        public async Task<Entities.DocumentTypeMaster> GetDocumentTypeMasterId(long id)
        {
            var documentTypeMaster = await _unitOfWork.GetEntityAsync<Entities.DocumentTypeMaster>(x => x.Id == id);
            return documentTypeMaster;
        }
    }
}
