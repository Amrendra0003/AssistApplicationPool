using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IDocumentProgramMappingRepository
    {
        Task<long> CreateDocumentProgramMapping(DocumentProgramMapping documentProgramMapping);
        Task<bool> HasProgramDocument(long programDocumentId);
        Task<bool> UpdateDocumentProgramMapping(DocumentProgramMapping documentProgramMapping);
        Task<long> GetProgramDocumentMappingIdByProgramDocument(long programDocumentId);
        Task<IEnumerable<DocumentProgramMapping>> GetProgramDocumentMappingByDocumentId(long documentId);
        Task<bool> DeleteDocumentProgramMapping(DocumentProgramMapping documentProgramMapping);
        Task<long> GetProgramDocumentMappingIdByProgramDocumentAndAssessmentId(long assessmentId, long programDocumentId);
    }
    public class DocumentProgramMappingRepository: IDocumentProgramMappingRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public DocumentProgramMappingRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreateDocumentProgramMapping(DocumentProgramMapping documentProgramMapping)
        {
            _unitOfWork.Attach(documentProgramMapping.Document);
            _unitOfWork.Attach(documentProgramMapping.ProgramDocument);
            await _unitOfWork.AddAsync(documentProgramMapping);
            await _unitOfWork.CommitAsync();
            return documentProgramMapping.Id;
        }

        public async Task<bool> HasProgramDocument(long programDocumentId)
        {
                var documentProgramMapping =
                await _unitOfWork.GetAllAsync<Entities.DocumentProgramMapping>(x =>
                    x.ProgramDocument.Id == programDocumentId);
            return documentProgramMapping.Any();
        }

        public async Task<bool> UpdateDocumentProgramMapping(DocumentProgramMapping documentProgramMapping)
        {
            _unitOfWork.Attach(documentProgramMapping.Document);
            _unitOfWork.Attach(documentProgramMapping.ProgramDocument);
            _unitOfWork.Update(documentProgramMapping);
            return await _unitOfWork.CommitAsync();

        }

        public async Task<long> GetProgramDocumentMappingIdByProgramDocument(long programDocumentId)
        {
            var documentProgramMapping =
                await _unitOfWork.GetAllAsync<Entities.DocumentProgramMapping>(x =>
                    x.ProgramDocument.Id == programDocumentId);
            if (documentProgramMapping.Count() > 0)
            {
                return documentProgramMapping.FirstOrDefault().Id;
            }

            return 0;
        }

        public async Task<IEnumerable<DocumentProgramMapping>> GetProgramDocumentMappingByDocumentId(long documentId)
        {
            var documentProgramMappings =
                await _unitOfWork.GetAllAsync<Entities.DocumentProgramMapping>(x =>
                    x.Document.Id == documentId);
            return documentProgramMappings;
        }

        public async Task<bool> DeleteDocumentProgramMapping(DocumentProgramMapping documentProgramMapping)
        {
            _unitOfWork.Remove(documentProgramMapping);
            return await _unitOfWork.CommitAsync();

        }

        public async Task<long> GetProgramDocumentMappingIdByProgramDocumentAndAssessmentId(long assessmentId, long programDocumentId)
        {
            var programDocuments = (from a in _unitOfWork.GetEntities<Document>()
                join b in _unitOfWork.GetEntities<DocumentProgramMapping>() on a.Id equals b.Document.Id
                where a.Assessment.Id == assessmentId && b.ProgramDocument.Id == programDocumentId
                select b.ProgramDocument.Id);
            if (programDocuments.Count() > 0)
            {
                return programDocuments.FirstOrDefault();
            }

            return 0;
        }
    }
}
