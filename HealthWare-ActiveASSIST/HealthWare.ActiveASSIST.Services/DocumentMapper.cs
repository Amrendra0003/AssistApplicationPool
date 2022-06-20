using System;
using System.Collections.Generic;
using System.Linq;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IFileUploadMapper
    {
        IncomeDocument MapIncomeDocumentFrom(IEnumerable<IncomeVerificationDocument> incomeDocumentDetails);
        List<ProgramFiles> MapProgramDocumentFrom(IEnumerable<ProgramDocument> programDetailsResult, IEnumerable<ProgramDocumentMappingDetail> programDocumentMappingDetail, long assessmentId, bool isEvaluated);
        Document MapFrom(long documentMappingId, FileDetails fileDetailsDto);
        HouseholdMemberDocument MapFrom(long? houseHoldMemberId, long documentId);
        DocumentProgramMapping MapDocumentProgramMappingFrom(long documentId, long programDocumentId);
    }
    public class DocumentMapper : IFileUploadMapper
    {
        private readonly IFileUploadServiceHelper _fileHelper;
        private readonly IDocumentRepository _documentRepository;
        public DocumentMapper(IFileUploadServiceHelper fileHelper, IDocumentRepository documentRepository)
        {
            _fileHelper = fileHelper;
            _documentRepository = documentRepository;
        }

        public IncomeDocument MapIncomeDocumentFrom(IEnumerable<IncomeVerificationDocument> incomeDocumentDetails)
        {

            var householdMember = incomeDocumentDetails.GroupBy(c => c.HouseHoldMemberId);
            var houseHoldMemberDocument = new List<HouseHoldMemberDocument>();
            foreach (var group in householdMember)
            {
                var doc = new List<IncomeVerificationDocument>();
                var fName = string.Empty; var mName = string.Empty; var lName = string.Empty; long householdmemberId = 0; string relation = string.Empty;

                foreach (var item in group)
                {
                    doc.Add(item);
                    fName = item.FirstName;
                    mName = item.MiddleName;
                    lName = item.LastName;
                    householdmemberId = item.HouseHoldMemberId;
                    relation = item.Relationship;
                }
                var typeGroup = doc.GroupBy(o => o.DocumentType);
                var documentType = new List<string>();
                var documents = new List<Documents>();

                foreach (var item in typeGroup)
                {
                    var docList = new List<Documents>();
                    foreach (var data in item)
                    {
                        documents.Add(new Documents
                        {
                            DocumentId = data.DocumentId,
                            DocumentName = data.DocumentName
                        });
                    }
                    documentType.Add(item.Key);
                }

                houseHoldMemberDocument.Add(new HouseHoldMemberDocument
                {
                    HouseHoldMemberId = householdmemberId,
                    FirstName = fName,
                    MiddleName = mName,
                    LastName = lName,
                    RelationshipType = relation,
                    DocumentType = documentType,
                    DocumentDetail = documents
                });

            }
            return new IncomeDocument
            {
                HouseHoldMemberDocument = houseHoldMemberDocument
            };
        }

        public List<ProgramFiles> MapProgramDocumentFrom(IEnumerable<ProgramDocument> programDetailsResult, IEnumerable<ProgramDocumentMappingDetail> programDocumentMappingDetail, long assessmentId, bool isEvaluated)
        {
            var programFileDetail = new List<ProgramFiles>();
            var programDocumentIds = new List<long>();


            foreach (var detail in programDetailsResult)
            {
                var isProgramEsgined = _documentRepository.IsProgramDocumentEsigned(assessmentId, detail.Id, isEvaluated).GetAwaiter().GetResult();
                var document = _documentRepository.GetProgramDocumentEsigned(assessmentId, detail.Id, isEvaluated).GetAwaiter().GetResult();
                programFileDetail.Add(new ProgramFiles
                {
                    ProgramDocumentId = detail.Id,
                    DocumentName = detail.DocumentName,
                    DocumentDescription = detail.DocumentDescription,
                    ProgramId = detail.Program.Id,
                    DocumentId = programDocumentMappingDetail.IsNull() ? document.ToString() : GetDocumentId(programDocumentMappingDetail, detail.Id).ToString(),
                    IsProgramDocumentEsigned = isProgramEsgined,
                    EsignFlag = detail.ESignFlag
                });

                programDocumentIds.Add(detail.Id);
            }

            //If user updated the program status to No then return IsProgramDocumentEsigned flag false.
            //If its true then leave as it is. user may uploaded or not uploaded. Assign IsProgramDocumentEsigned value from db.
            if (!isEvaluated) programFileDetail.ForEach(x=>x.IsProgramDocumentEsigned = false);
            return programFileDetail;
        }

        public Document MapFrom(long documentMappingId, FileDetails fileDetailsDto)
        {
            var document = new Document
            {
                Name = fileDetailsDto.DocumentName,
                Path = fileDetailsDto.DocumentPath,
                Assessment = new Assessment { Id = fileDetailsDto.AssessmentId },
                DocumentTypeMaster = new DocumentTypeMaster { Id = documentMappingId },
                CreatedDate = DateTime.UtcNow,
            };
            return document;
        }

        public HouseholdMemberDocument MapFrom(long? houseHoldMemberId, long documentId)
        {
            var householdMemberDocument = new HouseholdMemberDocument()
            {
                HouseholdMember = new HouseHoldMember { Id = Convert.ToInt64(houseHoldMemberId) },
                Document = new Document { Id = documentId }
            };
            return householdMemberDocument;
        }

        public DocumentProgramMapping MapDocumentProgramMappingFrom(long documentId, long programDocumentId)
        {
            var documentProgramMapping = new DocumentProgramMapping()
            {
                Document = new Document { Id = documentId },
                ProgramDocument = new ProgramDocument { Id = programDocumentId }
            };
            return documentProgramMapping;
        }

        public long GetDocumentId(IEnumerable<ProgramDocumentMappingDetail> programDocumentMappingDetail, long programDocumentId)
        {
            try
            {
                if (programDocumentMappingDetail.Any())
                {
                    var detail = programDocumentMappingDetail.FirstOrDefault(o => o.ProgramDocumentId.Equals(programDocumentId));
                    if (detail.IsNotNull()) return detail.DocumentId;
                    return 0;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public byte[] ReadBytes(string filePath)
        {
            var byteData = _fileHelper.ReadBytes(filePath);
            return byteData;
        }
    }
}
