using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IDocumentCategoryMasterRepository
    {
        Task<long> GetDocumentCategoryMaster(string documentCategoryName);
    }
    public class DocumentCategoryMasterRepository: IDocumentCategoryMasterRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public DocumentCategoryMasterRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> GetDocumentCategoryMaster(string documentCategoryName)
        {
            var documentCategoryMaster =
                await _unitOfWork.GetEntityAsync<Entities.DocumentCategoryMaster>(x =>
                    x.CategoryName == documentCategoryName);
            return documentCategoryMaster.Id;
        }
    }
}
