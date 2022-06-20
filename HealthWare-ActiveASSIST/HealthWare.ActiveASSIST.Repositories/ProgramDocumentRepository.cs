using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IProgramDocumentRepository
    {
        Task<ProgramDocument> GetProgramDocumentDetails(long programDocumentId);
        Task<IEnumerable<ProgramDocument>> GetProgramDocumentDetailsByProgramId(long programId);
        Task<long> CreateProgramDocument(ProgramDocument programDocument);

    }
    public class ProgramDocumentRepository : IProgramDocumentRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public ProgramDocumentRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProgramDocument> GetProgramDocumentDetails(long programDocumentId)
        {
            return await _unitOfWork.GetEntityAsync<ProgramDocument>(y => y.Id == programDocumentId);
        }

        public async Task<IEnumerable<ProgramDocument>> GetProgramDocumentDetailsByProgramId(long programId)
        {
            var programDocuments = await _unitOfWork.GetAllAsync<ProgramDocument>(y => y.Program.Id == programId);
            return programDocuments;
        }
        public async Task<long> CreateProgramDocument(ProgramDocument programDocument)
        {
            _unitOfWork.Attach(programDocument.Program);
            await _unitOfWork.AddAsync(programDocument);
            await _unitOfWork.CommitAsync();
            return programDocument.Id;
        }
    }
}
;