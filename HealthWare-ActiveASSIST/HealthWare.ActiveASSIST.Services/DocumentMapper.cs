using System;
using System.Collections.Generic;
using System.Linq;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.Extensions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IFileUploadMapper
    {
        IncomeDocument MapIncomeDocumentFrom(IEnumerable<IncomeVerificationDocument> incomeDocumentDetails);
        Task<List<ProgramFiles>> MapProgramDocumentFrom(IEnumerable<ProgramDocument> programDetailsResult, IEnumerable<ProgramDocumentMappingDetail> programDocumentMappingDetail, long assessmentId, bool isEvaluated);
        Document MapFrom(long documentMappingId, FileDetails fileDetailsDto);
        HouseholdMemberDocument MapFrom(long? houseHoldMemberId, long documentId);
        DocumentProgramMapping MapDocumentProgramMappingFrom(long documentId, long programDocumentId);
    }
    public class DocumentMapper : IFileUploadMapper
    {
        private static string TokenKey = "Bearer 3AAABLblqZhBQVKfASPxFqDTKPQG40NlIxK1JR81T-GtWKVLgKZWaBzboxoo-wedoGjfejOLDXr9hml1RLcTb0Uxtl_hSYD-k";
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

        public async Task<List<ProgramFiles>> MapProgramDocumentFrom(IEnumerable<ProgramDocument> programDetailsResult, IEnumerable<ProgramDocumentMappingDetail> programDocumentMappingDetail, long assessmentId, bool isEvaluated)
        {
            var programFileDetail = new List<ProgramFiles>();
            var programDocumentIds = new List<long>();
            foreach (var detail in programDetailsResult)
            {
                var isProgramEsgined = _documentRepository.IsProgramDocumentEsigned(assessmentId, detail.Id, isEvaluated).GetAwaiter().GetResult();
                var document = _documentRepository.GetProgramDocumentEsigned(assessmentId, detail.Id, isEvaluated).GetAwaiter().GetResult();
                bool isSigned = false;
                var downloadDocument = await _documentRepository.IsDocumentDownloaded(detail.Id, assessmentId);
                bool isDeleted = false;
                bool isDownloaded = false;
                long documentDownloadId = 0;
                if (downloadDocument != null)
                {
                    isDownloaded = (bool)downloadDocument.isDownloaded;
                    documentDownloadId = downloadDocument.Id;
                }
                else
                {
                    isDownloaded = false;
                }

                if (document != 0)
                {
                    var doc = await _documentRepository.GetDocumentById(document);
                    long programDocumentID = doc.ProgramDocumentId ?? default(long);
                    if(doc.isDeleted == true)
                    {
                        isDeleted = true;
                    }
                    if (doc.isDocumentSigned == null)
                    {
                        doc.isDocumentSigned = false;
                    }
                    if(doc.isDocumentSigned == true)
                    {
                        isSigned = true;
                    }
                    else
                    {
                        if (doc.AgreementId != null)
                        {
                            int success = GetAgreementData(doc.AgreementId, doc.Path);
                            if (success == 1)
                            {
                                doc.isDocumentSigned = true;
                                isSigned = true;
                                await _documentRepository.UpdateDocument(doc);
                            }
                        }
                    }
                }
                programFileDetail.Add(new ProgramFiles
                {
                    ProgramDocumentId = detail.Id,
                    DocumentName = detail.DocumentName,
                    DocumentDescription = detail.DocumentDescription,
                    ProgramId = detail.Program.Id,
                    DocumentId = programDocumentMappingDetail.IsNull() ? document.ToString() : GetDocumentId(programDocumentMappingDetail, detail.Id).ToString(),
                    IsProgramDocumentEsigned = isProgramEsgined,
                    EsignFlag = isSigned,
                    IsDeleted = isDeleted,
                    IsDownloaded = isDownloaded,
                    DocumentDownloadId = documentDownloadId
                });
                programDocumentIds.Add(detail.Id);
            }

            //If user updated the program status to No then return IsProgramDocumentEsigned flag false.
            //If its true then leave as it is. user may uploaded or not uploaded. Assign IsProgramDocumentEsigned value from db.
            if (!isEvaluated) programFileDetail.ForEach(x=>x.IsProgramDocumentEsigned = false);
            return programFileDetail;
        }
        private static int GetAgreementData(string AgreementId, string path)
        {

            string GetAgreementById = "https://api.in1.adobesign.com/api/rest/v6/agreements/" + AgreementId;
            try
            {
                var webRequest = System.Net.WebRequest.Create(GetAgreementById);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization", TokenKey);

                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                            string getData = jsonResponse;
                            dynamic data = JObject.Parse(getData);
                            return UpdateFileData(data,path);
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        private static int UpdateFileData(dynamic FileStatus, string path)
        {
            try
            {
                if (FileStatus.status.ToString() == "SIGNED")
                {
                    return DownloadFiles(FileStatus.id.ToString(),path);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static int DownloadFiles(string AgreementId, string path)
        {
            string DownloadWEBSERVICE_URL = "https://api.in1.adobesign.com:443/api/rest/v6/agreements/" + AgreementId + "/documents";
            try
            {
                var webRequest = System.Net.WebRequest.Create(DownloadWEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";

                    webRequest.Headers.Add("Authorization", TokenKey);
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {

                            var jsonResponse = sr.ReadToEnd();
                            string getData = jsonResponse;
                            dynamic data = JObject.Parse(getData);
                            var id = data.documents[0].id;
                            string DownloadWEBSERVICE_URL1 = "https://api.in1.adobesign.com:443/api/rest/v6/agreements/" + AgreementId + "/documents/" + id;
                            try
                            {
                                var webRequest1 = System.Net.WebRequest.Create(DownloadWEBSERVICE_URL1);
                                if (webRequest1 != null)
                                {
                                    webRequest1.Method = "GET";
                                    webRequest1.Timeout = 12000;
                                    webRequest1.ContentType = "application/json";

                                    webRequest1.Headers.Add("Authorization", TokenKey);
                                    File.Delete(path);
                                    using (System.IO.Stream s1 = webRequest1.GetResponse().GetResponseStream())
                                    {
                                        using (System.IO.StreamReader sr1 = new System.IO.StreamReader(s1))
                                        {

                                            var jsonResponse1 = sr1.ReadToEnd();
                                            byte[] byteArray = Encoding.UTF8.GetBytes(jsonResponse1);
                                            MemoryStream ms = new MemoryStream(byteArray);
                                            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                                            ms.WriteTo(file);
                                            file.Close();
                                            ms.Close();
                                            return 1;
                                        }
                                    }
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                return 0;
                            }
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
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
                ProgramDocumentId = (long)fileDetailsDto.ProgramDocumentId 
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
