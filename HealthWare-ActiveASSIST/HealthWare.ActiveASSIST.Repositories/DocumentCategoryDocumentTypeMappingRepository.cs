using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IDocumentCategoryDocumentTypeMappingRepository
    {
        Task<IEnumerable<Entities.DocumentCategoryDocumentTypeMapping>> GetDocumentMappingId(long documentCategoryId);
    }
    public class DocumentCategoryDocumentTypeMappingRepository : IDocumentCategoryDocumentTypeMappingRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public DocumentCategoryDocumentTypeMappingRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Entities.DocumentCategoryDocumentTypeMapping>> GetDocumentMappingId(long documentCategoryId)
        {
            var documentMappingList =
                await _unitOfWork.GetAllAsync<Entities.DocumentCategoryDocumentTypeMapping>(x =>
                    x.DocumentCategoryMaster.Id == documentCategoryId);
            return documentMappingList;
        }

    }
}
