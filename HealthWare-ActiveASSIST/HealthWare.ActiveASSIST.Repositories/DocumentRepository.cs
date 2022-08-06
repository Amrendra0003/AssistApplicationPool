using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Base;


namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IDocumentRepository
    {
        Task<long> InsertDocument(Document document);
        Task<long> UpdateDocumentDownloaded(DownloadDocument document);
        Task<long> InsertDocumentDownloaded(DownloadDocument document);
        Task<Document> GetDocumentById(long documentId);
        Task<DownloadDocument> IsDocumentDownloaded(long ProgramDocumentId, long AgreementId);
        Task<DownloadDocument> GetDocumentDownloaded(long Id);
        Task<bool> DeleteDocument(Document document);
        int GetESignedDocumentCount(long assessmentId);
        int GetESignedDocumentCountForActivePrograms(long assessmentId);
        IEnumerable<IncomeVerificationDocument> GetIncomeVerificationDocumentDetailsByAssessmentId(long assessmentId);
        Task<bool> IsIncomeDocumentUploaded(long memberId);
        Task<bool> DeleteDocument(long id);
        Task<Document> GetDocumentByAssessmentIdTypeId(long documentId, long documentTypeId, long programDocumentId);
        Task<long> UpdateDocument(Document document);
        Task<bool> IsProgramDocumentEsigned(long assessmentId, long id, bool isEvaluated);
        Task<long> GetProgramDocumentEsigned(long assessmentId, long id, bool isEvaluated);
    }
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public DocumentRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> InsertDocument(Document document)
        {
            _unitOfWork.Attach(document.Assessment);
            _unitOfWork.Attach(document.DocumentTypeMaster);
            await _unitOfWork.AddAsync(document);
            await _unitOfWork.CommitAsync();

            return document.Id;
        }

        public async Task<Document> GetDocumentById(long documentId)
        {
            var document = await _unitOfWork.GetEntityAsync<Document>(x => x.Id == documentId);
            return document;
        }
        public async Task<DownloadDocument> IsDocumentDownloaded(long ProgramDocumentId, long AgreementId)
        {
            var document = await _unitOfWork.GetEntityAsync<DownloadDocument>(x => x.ProgramDocumentId == ProgramDocumentId && x.AssessmentId == AgreementId);
            return document;
        }
        public async Task<DownloadDocument> GetDocumentDownloaded(long Id)
        {
            var document = await _unitOfWork.GetEntityAsync<DownloadDocument>(x => x.Id == Id);
            return document;
        }
        public async Task<long> UpdateDocumentDownloaded(DownloadDocument document)
        {
            _unitOfWork.Update(document);
            await _unitOfWork.CommitAsync();
            return document.Id;
        }
        public async Task<long> InsertDocumentDownloaded(DownloadDocument document)
        {
            await _unitOfWork.AddAsync(document);
            await _unitOfWork.CommitAsync();
            return document.Id;
        }
        public async Task<bool> DeleteDocument(Document document)
        {
            _unitOfWork.Remove(document);
            return await _unitOfWork.CommitAsync();
        }

        public int GetESignedDocumentCount(long assessmentId)
        {
            var documents = (from a in _unitOfWork.GetEntities<Document>()
                             join b in _unitOfWork.GetEntities<DocumentProgramMapping>() on a.Id equals b.Document.Id
                             where a.Assessment.Id == assessmentId
                             select b.ProgramDocument.Id).Distinct();

            return documents.Count();
        }
        public int GetESignedDocumentCountForActivePrograms(long assessmentId)
        {
            var documents = (from a in _unitOfWork.GetEntities<ProgramDocument>()
                             join b in _unitOfWork.GetEntities<PatientProgramMapping>() on a.Program.Id equals b.Program.Id
                             join c in _unitOfWork.GetEntities<Document>() on b.Assessment.Id equals c.Assessment.Id
                             join d in _unitOfWork.GetEntities<DocumentProgramMapping>() on c.Id equals d.Document.Id

                             where b.Assessment.Id == assessmentId && b.IsActive.Equals(true)
                                 & d.ProgramDocument.Id == a.Id
                             select a.Id).Distinct();

            return documents.Count();
        }
        public IEnumerable<IncomeVerificationDocument> GetIncomeVerificationDocumentDetailsByAssessmentId(long assessmentId)
        {
            var result = (from a in _unitOfWork.GetEntities<HouseholdMemberDocument>()
                          join b in _unitOfWork.GetEntities<Document>() on a.Document.Id equals b.Id
                          join c in _unitOfWork.GetEntities<HouseHoldMember>() on a.HouseholdMember.Id equals c.Id
                          join e in _unitOfWork.GetEntities<DocumentTypeMaster>() on b.DocumentTypeMaster.Id equals e.Id
                          where b.Assessment.Id == assessmentId
                          select new IncomeVerificationDocument
                          {
                              DocumentId = a.Document.Id,
                              DocumentName = b.Name,
                              DocumentType = e.DocumentTypeName,
                              HouseHoldMemberId = a.HouseholdMember.Id,
                              FirstName = c.FirstName,
                              MiddleName = c.MiddleName,
                              LastName = c.LastName,
                              Relationship = c.Relationship
                          });

            return result;
        }
        public async Task<bool> IsIncomeDocumentUploaded(long memberId)
        {
            var householdDocuments =
                await _unitOfWork.GetAllAsync<HouseholdMemberDocument>(x => x.HouseholdMember.Id == memberId);
            return householdDocuments.Any();
        }
        public async Task<bool> DeleteDocument(long id)
        {
            var document = await GetDocumentById(id);
            _unitOfWork.Remove(document);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<Document> GetDocumentByAssessmentIdTypeId(long assessmentId, long documentTypeId, long programDocumentId)
        {
            if (programDocumentId == 0)
                return await _unitOfWork.GetEntityAsync<Document>(x => x.Assessment.Id == assessmentId && x.DocumentTypeMaster.Id == documentTypeId);
            else
                return await _unitOfWork.GetEntityAsync<Document>(x => x.Assessment.Id == assessmentId && x.DocumentTypeMaster.Id == documentTypeId && x.ProgramDocumentId == programDocumentId);
        }

        public async Task<long> UpdateDocument(Document document)
        {
            _unitOfWork.Attach(document.Assessment);
            _unitOfWork.Attach(document.DocumentTypeMaster);
            _unitOfWork.Update(document);
            await _unitOfWork.CommitAsync();
            return document.Id;
        }

        public async Task<bool> IsProgramDocumentEsigned(long assessmentId, long id, bool isEvaluated)
        {
            var isProgramDocumentUploaded = (from a in _unitOfWork.GetEntities<Document>()
                join b in _unitOfWork.GetEntities<DocumentProgramMapping>() on a.Id equals b.Document.Id
                join c in _unitOfWork.GetEntities<ProgramDocument>() on b.ProgramDocument.Id equals c.Id
                join d in _unitOfWork.GetEntities<PatientProgramMapping>() on c.Program.Id equals d.Program.Id
                where a.Assessment.Id == assessmentId && b.ProgramDocument.Id == id && d.IsActive.Equals(isEvaluated) && d.IsEvaluated.Equals(true)
                select new Document
                {
                    Name = a.Name
                });

            if (isProgramDocumentUploaded.Count() > 0) return true;
            return false;
        }
        public async Task<long> GetProgramDocumentEsigned(long assessmentId, long id, bool isEvaluated)
        {
            var isProgramDocumentUploaded = (from a in _unitOfWork.GetEntities<Document>()
                join b in _unitOfWork.GetEntities<DocumentProgramMapping>() on a.Id equals b.Document.Id
                join c in _unitOfWork.GetEntities<ProgramDocument>() on b.ProgramDocument.Id equals c.Id
                join d in _unitOfWork.GetEntities<PatientProgramMapping>() on c.Program.Id equals d.Program.Id
                                             where a.Assessment.Id == assessmentId && b.ProgramDocument.Id == id && d.IsActive.Equals(isEvaluated) && d.IsEvaluated.Equals(true)
                                             select a.Id);

            return isProgramDocumentUploaded.OrderByDescending(s=>s).FirstOrDefault();
        }
    }
}
