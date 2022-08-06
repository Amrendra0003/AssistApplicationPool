using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.Logging;
using Healthware.Core.Utility;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Web.Common.HttpClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerificationDocument = HealthWare.ActiveASSIST.DTOs.VerificationDocument;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IDocumentService
    {
        public Result<MessageDto> UploadProfileImage(IFormFile file, long assessmentId);
        public Result<MessageDto> UploadUserProfileImage(IFormFile file, long userId);
        public Task<string> LoadProfileImage(long assessmentId);
        public Task<string> LoadUserProfileImage(long userId);
        public Task<string> LoadDefaultImage();
        public Task<Result<long>> UploadFile(IFormFile file, FileDetails fileDetails);
        public bool DeleteFiles(FileDetails fileDetails);
        Task<Result<VerificationDocument>> GetVerificationDocumentDetail(long assessmentId, string documentCategory);
        Result<IncomeDocument> GetIncomeVerificationDocumentDetail(long assessmentId);
        Task<Result<List<ProgramFiles>>> GetProgramDocumentDetails(long programId, long assessmentId, bool isEvaluated);
        Task<Result<ProgramDocumentDetail>> GetProgramDocumentPath(long programDocumentId);
        Task<Result<MessageDto>> DeleteDocument(long documentId, long householdMemberId);
        byte[] ReadBytes(string filePath);
        Task<string> GetDocumentPath(long documentId);
        string GetContentType(string type);
        public FileLocationDetail GetFileLocation(FileDetails fileDetails);
        Task<Result<VerificationDocument>> GetDocumentByAssessmentIdTypeName(long assessmentId, string documentTypeName);
        Task<Result<string>> UpdateVerificationDocument(long assessmentId, string documentTypeName, string category);
        Task<Result<long>> LoadProgramDocument(FileDetails fileDetailsDto);
        Task<Result<bool>> UpdateFilePath(long docId, string filePath);
        Task<Result<bool>> UpdateFileAgreementId(long docId, string fileAgreementId);
        Task<Result<bool>> DeleteeDocumentById(long docId, long downloadDocId);
        byte[] FetchDocumentFromUrlAsync(string documentPath, string name);
        Task<byte[]> UploadSignature(IFormFile originalFile, IFormFile signatureCanvas, StringValues signatureText, StringValues docId);
        Task<Result<MessageDto>> CompleteUploadedDocument(long documentId);
        Task<long> UpdateOrInsertDocumentDownloaded(long pgrmdocId, long assessmentId, long documentDownloadId);
    }
    public class DocumentService : IDocumentService
    {
        private static string TokenKey = "Bearer 3AAABLblqZhBQVKfASPxFqDTKPQG40NlIxK1JR81T-GtWKVLgKZWaBzboxoo-wedoGjfejOLDXr9hml1RLcTb0Uxtl_hSYD-k";
        private readonly IFileUploadServiceHelper _fileHelper;
        private readonly DocumentConfiguration _fileUploadConfig;
        private readonly IProgramDocumentRepository _programDocumentRepository;
        private readonly IFileUploadMapper _fileUploadMapper;
        private readonly IDocumentLocationMapper _documentLocationMapper;
        private readonly IDocumentCategoryMasterRepository _documentCategoryMasterRepository;
        private readonly IDocumentTypeMasterRepository _documentTypeMasterRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IHouseholdMemberDocumentMappingRepository _householdMemberDocumentMappingRepository;
        private readonly IDocumentProgramMappingRepository _documentProgramMappingRepository;
        private readonly ITabStatusRepository _tabStatusRepository;
        private readonly IPatientProgramMappingRepository _patientProgramMappingRepository;
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly IAssessmentService _assessmentService;
        private readonly IVerificationDocumentRepository _verificationDocumentRepository;
        private readonly IDocumentCategoryDocumentTypeMappingRepository _documentCategoryDocumentTypeMappingRepository;
        private readonly IHttpClientService _httpClientService;
        public DocumentService(IFileUploadServiceHelper fileUploadServiceHelper, DocumentConfiguration Config,
            IFileUploadMapper fileUploadMapper, IProgramDocumentRepository programDocumentRepository, IDocumentLocationMapper documentLocationMapper,
            IDocumentCategoryMasterRepository documentCategoryMasterRepository, IDocumentTypeMasterRepository documentTypeMasterRepository,
            IDocumentRepository documentRepository, IHouseholdMemberDocumentMappingRepository householdMemberDocumentMappingRepository,
            IDocumentProgramMappingRepository documentProgramMappingRepository, ITabStatusRepository tabStatusRepository,
            IPatientProgramMappingRepository patientProgramMappingRepository, IHouseHoldMemberRepository houseHoldMemberRepository,
            IVerificationDocumentRepository verificationDocumentRepository, IAssessmentService assessmentService,
            IDocumentCategoryDocumentTypeMappingRepository documentCategoryDocumentTypeMappingRepository, IHttpClientService httpClientService)
        {
            _fileUploadConfig = Config;
            _fileHelper = fileUploadServiceHelper;
            _fileUploadMapper = fileUploadMapper;
            _programDocumentRepository = programDocumentRepository;
            _documentLocationMapper = documentLocationMapper;
            _documentCategoryMasterRepository = documentCategoryMasterRepository;
            _documentTypeMasterRepository = documentTypeMasterRepository;
            _documentRepository = documentRepository;
            _householdMemberDocumentMappingRepository = householdMemberDocumentMappingRepository;
            _documentProgramMappingRepository = documentProgramMappingRepository;
            _tabStatusRepository = tabStatusRepository;
            _patientProgramMappingRepository = patientProgramMappingRepository;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _verificationDocumentRepository = verificationDocumentRepository;
            _assessmentService = assessmentService;
            _documentCategoryDocumentTypeMappingRepository = documentCategoryDocumentTypeMappingRepository;
            _httpClientService = httpClientService;
        }
        public async Task<string> GetDocumentPath(long documentId)
        {
            try
            {
                var documentDetails = await _documentRepository.GetDocumentById(documentId);
                return documentDetails.Path;
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return string.Empty;
            }

        }
        public async Task<Result<MessageDto>> CompleteUploadedDocument(long documentId)
        {
            try
            {
                var documentDetails = await _documentRepository.GetDocumentById(documentId);
                if (documentDetails.IsNotNull())
                {
                    byte[] fileContents = this.ReadBytes(documentDetails.Path);
                    var stream = new MemoryStream(fileContents);
                    IFormFile file = new FormFile(stream, 0, fileContents.Length, documentDetails.Name, documentDetails.Name);
                    
                    if (_fileHelper.SaveFile(file, documentDetails.Path, true, true))
                    {
                        stream.Close();
                        return new Result<MessageDto>()
                            { Data = new MessageDto().AddMessage(Constants.DocumentUploadSuccessMessage) };
                    }
                }
                
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
            }
            return new Result<MessageDto>()
                { Data = new MessageDto().AddMessage(Constants.DocumentUploadErrorMessage) };
        }
        public async Task<long> UpdateOrInsertDocumentDownloaded(long pgrmdocId, long assessmentId, long documentDownloadId)
        {
            var documentDownload = await _documentRepository.GetDocumentDownloaded(documentDownloadId);
            if (documentDownload != null)
            {
                documentDownload.isDownloaded = true;
                return await _documentRepository.UpdateDocumentDownloaded(documentDownload);
            }
            else
            {
                DownloadDocument doc = new DownloadDocument();
                doc.isDownloaded = true;
                doc.AssessmentId = assessmentId;
                doc.ProgramDocumentId = pgrmdocId;
                return await _documentRepository.InsertDocumentDownloaded(doc);
            }
        }



        public async Task<Result<ProgramDocumentDetail>> GetProgramDocumentPath(long programDocumentId)
        {

            try
            {
                var detail = await _programDocumentRepository.GetProgramDocumentDetails(programDocumentId);
                //string contentRootPath = await _httpClientService.ContentRootPathForProgramFiles(detail.FormLocation);
                if (detail == null) return new Result<ProgramDocumentDetail>().AddError(Constants.NoDocumentFound);
                return new Result<ProgramDocumentDetail>()
                {
                    Data = new ProgramDocumentDetail
                    {
                        DocumentName = detail.DocumentName,
                        DocumentPath = detail.FormLocation
                    }
                };
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
            }
            return new Result<ProgramDocumentDetail>().AddError(Constants.ErrorMessageDuringFetch);
        }
        public Result<MessageDto> UploadProfileImage(IFormFile file, long assessmentId)
        {
            try
            {
                var fileLocation = _documentLocationMapper.GetFileLocation(new FileDetails { DocumentTitle = nameof(_fileUploadConfig.assessmentprofileimage), AssessmentId = assessmentId });

                if (_fileHelper.CreateDirectory(fileLocation.FolderPath))
                {
                    if (_fileHelper.SaveFile(file, fileLocation.FilePath))
                        return new Result<MessageDto>()
                        { Data = new MessageDto().AddMessage(Constants.ImageUploadSuccessMessage) };
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
            }
            return new Result<MessageDto>().AddError(Constants.ImageUploadError);
        }

        public Result<MessageDto> UploadUserProfileImage(IFormFile file, long userId)
        {
            try
            {
                var fileLocation = _documentLocationMapper.GetFileLocation(new FileDetails { DocumentTitle = nameof(_fileUploadConfig.userprofileimage), UserId = userId });

                if (_fileHelper.CreateDirectory(fileLocation.FolderPath))
                {
                    if (_fileHelper.SaveFile(file, fileLocation.FilePath))
                        return new Result<MessageDto>()
                        { Data = new MessageDto().AddMessage(Constants.ImageUploadSuccessMessage) };
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
            }
            return new Result<MessageDto>().AddError(Constants.ImageUploadError);
        }

        public async Task<string> LoadProfileImage(long assessmentId)
        {
            try
            {
                var fileLocation = _documentLocationMapper.GetFileLocation(new FileDetails { DocumentTitle = nameof(_fileUploadConfig.assessmentprofileimage), AssessmentId = assessmentId });
                var filePath = fileLocation.FilePath;
                byte[] byteData;
                string imageBase64Data;
                if (!_fileHelper.IsFileExists(filePath))
                {
                    byteData = _fileHelper.ReadBytes(_fileUploadConfig.DefaultProfileImagePath);
                    imageBase64Data = _fileHelper.ImageBase64Data(byteData);
                    return _fileHelper.ImageDataUrl(imageBase64Data);
                }

                byteData = _fileHelper.ReadBytes(filePath);

                if (!(byteData.Length > 0))
                    byteData = _fileHelper.ReadBytes(_fileUploadConfig.DefaultProfileImagePath);

                imageBase64Data = _fileHelper.ImageBase64Data(byteData);
                return _fileHelper.ImageDataUrl(imageBase64Data);

            }
            catch (Exception ex)
            {
                this.Log().Error(ex); 
                var data = await LoadDefaultImage();
                return data;
            }
        }
        public async Task<string> LoadUserProfileImage(long userId)
        {
            try
            {
                var fileLocation = _documentLocationMapper.GetFileLocation(new FileDetails { DocumentTitle = nameof(_fileUploadConfig.userprofileimage), UserId = userId });
                var filePath = fileLocation.FilePath;
                var byteData = _fileHelper.ReadBytes(filePath);

                if (!(byteData.Length > 0))
                    byteData = _fileHelper.ReadBytes(_fileUploadConfig.DefaultProfileImagePath);
                string imageBase64Data = _fileHelper.ImageBase64Data(byteData);
                return _fileHelper.ImageDataUrl(imageBase64Data);

            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                var data = await LoadDefaultImage();
                return data;
            }
        }
        public async Task<string> LoadDefaultImage()
        {
            try
            {
                string contentRootPath = await _httpClientService.ContentRootPath();
                var byteData = _fileHelper.ReadBytes(contentRootPath);
                string imageBase64Data = _fileHelper.ImageBase64Data(byteData);
                return _fileHelper.ImageDataUrl(imageBase64Data);

            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return String.Empty;
            }
        }
        public async Task<Result<VerificationDocument>> GetVerificationDocumentDetail(long assessmentId, string documentCategory)
        {
            try
            {
                var documentCategoryId =
                    await _documentCategoryMasterRepository.GetDocumentCategoryMaster(documentCategory);

                //var documentCategoryTypeMappingList = await _documentCategoryDocumentTypeMappingRepository.GetDocumentMappingId(documentCategoryId);
                var verificationDocument =
                    await _verificationDocumentRepository.GetVerificationDocumentByAssessmentId(assessmentId);
                long? documentTypeId = null;
                var document = new Entities.Document();
                documentTypeId = documentCategory switch
                {
                    Constants.Identification => verificationDocument.IdVerification,
                    Constants.Address => verificationDocument.AddressVerification,
                    Constants.Other => verificationDocument.OtherVerification,
                    _ => documentTypeId
                };
                if (documentTypeId != null)
                {
                    document = await _documentRepository.GetDocumentByAssessmentIdTypeId(assessmentId, (long)documentTypeId, 0);
                    if (document == null) return new Result<VerificationDocument>();
                }
                else
                {
                    return new Result<VerificationDocument>();
                }

                var documentTypeMaster =
                    await _documentTypeMasterRepository.GetDocumentTypeMasterId((long)documentTypeId);

                var documentId = document.Id;
                var documentName = document.Name;
                var documentType = documentTypeMaster.DocumentTypeName;
                var IdVerificationDetail = new VerificationDocument
                {
                    DocumentType = documentType,
                    DocumentName = documentName,
                    DocumentId = documentId
                };
                return new Result<VerificationDocument> { Data = IdVerificationDetail };
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return new Result<VerificationDocument>().AddError(Constants.DocumentFetchError);
            }

        }
        public async Task<Result<long>> UploadFile(IFormFile file, FileDetails fileDetailsDto)
        {
            try
            {
                fileDetailsDto.DocumentName = file.FileName;

                var fileLocation = _documentLocationMapper.GetFileLocation(fileDetailsDto);
                string folderPath = fileLocation.FolderPath;
                var filePath = fileLocation.FilePath;
                _fileHelper.CheckCategory(fileDetailsDto, fileLocation);
                fileDetailsDto.DocumentPath = filePath;

                if (_fileHelper.CreateDirectory(folderPath))
                {
                    if (_fileHelper.SaveFile(file, filePath, fileDetailsDto.Esigned))
                    {
                        var documentCategoryId =
                            await _documentCategoryMasterRepository.GetDocumentCategoryMaster(fileDetailsDto
                                .DocumentCategory);
                        var documentTypeId =
                            await _documentTypeMasterRepository.GetDocumentTypeMaster(fileDetailsDto.DocumentType);
                        var documentNew = _fileUploadMapper.MapFrom(documentTypeId, fileDetailsDto);
                        var document = await _documentRepository.GetDocumentByAssessmentIdTypeId(fileDetailsDto.AssessmentId, documentTypeId, (long)fileDetailsDto.ProgramDocumentId);
                        long documentId = Constants.ZeroAsNumber;
                        if (document.IsNull())
                        {
                            documentId = await _documentRepository.InsertDocument(documentNew);
                        }
                        else
                        {
                            document.isDeleted = false;
                            documentId = document.Id;
                            document.Name = documentNew.Name;
                            document.Path = documentNew.Path;
                            await _documentRepository.UpdateDocument(document);
                        }

                        var verificationDocument = await _verificationDocumentRepository.GetVerificationDocumentByAssessmentId(fileDetailsDto
                            .AssessmentId);
                        switch (fileDetailsDto.DocumentCategory)
                        {
                            case Constants.Address:
                                verificationDocument.AddressVerification = documentTypeId;
                                _ = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                                break;
                            case Constants.Identification:
                                verificationDocument.IdVerification = documentTypeId;
                                _ = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                                break;
                            case Constants.Other:
                                verificationDocument.OtherVerification = documentTypeId;
                                _ = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                                break;
                        }


                        if (fileDetailsDto.DocumentCategory.Equals(Constants.Eforms))
                        {
                            var documentProgramMapping = _fileUploadMapper.MapDocumentProgramMappingFrom(documentId, (long)fileDetailsDto.ProgramDocumentId);
                            var programDocument =
                                await _documentProgramMappingRepository.HasProgramDocument(
                                    (long)fileDetailsDto.ProgramDocumentId);
                            if (programDocument)
                            {
                                documentProgramMapping.Id =
                                    await _documentProgramMappingRepository
                                        .GetProgramDocumentMappingIdByProgramDocument(
                                            (long)fileDetailsDto.ProgramDocumentId);
                                var documentProgramMappingId =
                                    await _documentProgramMappingRepository.UpdateDocumentProgramMapping(
                                        documentProgramMapping);
                            }
                            else
                            {
                                var documentProgramMappingId =
                                    await _documentProgramMappingRepository.CreateDocumentProgramMapping(
                                        documentProgramMapping);
                            }
                        }
                        if (fileDetailsDto.DocumentCategory.Equals(Constants.Income.ToPascalCase()))
                        {
                            var householdMemberDocument = _fileUploadMapper.MapFrom(fileDetailsDto.HouseHoldMemberId, documentId);
                            var householdMemberDocumentMappingId =
                                await _householdMemberDocumentMappingRepository.CreateHouseholdMemberDocumentMapping(
                                    householdMemberDocument);
                        }

                        //Update tab status
                        var tabStatus = await _tabStatusRepository.GetTabStatus(fileDetailsDto.AssessmentId);
                        switch (fileDetailsDto.DocumentCategory)
                        {
                            case "Identification":
                                tabStatus.IsIdVerificationComplete = true;
                                break;
                            case "Address":
                                tabStatus.IsAddressVerificationComplete = true;
                                break;
                            case "Income":
                                tabStatus.IsIncomeVerificationComplete = true;
                                break;
                            case "Other":
                                tabStatus.IsOtherVerificationComplete = true;
                                break;
                            case "Eforms":
                                //var programDocumentCount = _patientProgramMappingRepository.GetProgramDocumentCount(fileDetailsDto.AssessmentId);
                                //var eSignedDocumentCount = _documentRepository.GetESignedDocumentCountForActivePrograms(fileDetailsDto.AssessmentId);

                                var isProgramDocumentSigned = new List<bool>();
                                var patientProgramMappings = await _patientProgramMappingRepository.GetPatientProgramMappingOfActiveAndEvaluatedPrograms(fileDetailsDto.AssessmentId);
                                foreach (var patientProgramMapping in patientProgramMappings)
                                {
                                    var programDocuments = await _programDocumentRepository.GetProgramDocumentDetailsByProgramId(patientProgramMapping.Program.Id);
                                    foreach (var programDocument in programDocuments)
                                    {
                                        var documentProgramMappingId = await _documentProgramMappingRepository.GetProgramDocumentMappingIdByProgramDocumentAndAssessmentId(fileDetailsDto.AssessmentId, programDocument.Id);
                                        if (documentProgramMappingId != 0)
                                        {
                                            isProgramDocumentSigned.Add(true);
                                            break;
                                        }
                                    }
                                }

                                if (patientProgramMappings.Count().Equals(isProgramDocumentSigned.Count))
                                {
                                    tabStatus.IsApplicationFormsComplete = true;
                                }
                                else
                                {
                                    tabStatus.IsApplicationFormsComplete = false;
                                }
                                break;
                        }
                        var isTabStatusUpdated = await _tabStatusRepository.Update(tabStatus);

                        return new Result<long>()
                        { Data = documentId };
                    }

                }

            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
            }
            return new Result<long>().AddError(Constants.DocumentUploadErrorMessage);

        }
        public Result<IncomeDocument> GetIncomeVerificationDocumentDetail(long assessmentId)
        {
            try
            {
                var details = _documentRepository.GetIncomeVerificationDocumentDetailsByAssessmentId(assessmentId);
                var incomeDocumentDetails = _fileUploadMapper.MapIncomeDocumentFrom(details);
                incomeDocumentDetails.AssessmentId = assessmentId;
                return new Result<IncomeDocument> { Data = incomeDocumentDetails };
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return new Result<IncomeDocument>().AddError(Constants.ErrorWhileDocumentFetch);
            }

        }
        public async Task<Result<MessageDto>> DeleteDocument(long documentId, long householdMemberId)
        {
            try
            {
                var document = await _documentRepository.GetDocumentById(documentId);
                if (document != null)
                {
                    var filePath = document.Path;
                    _fileHelper.DeleteFile(filePath);
                    var isDocumentMappingDeleted = await _householdMemberDocumentMappingRepository.DeleteDocumentMapping(documentId, householdMemberId);
                    if (isDocumentMappingDeleted)
                        await _documentRepository.DeleteDocument(document);

                    //Update tab status
                    var houseHoldMember =
                        await _houseHoldMemberRepository.GetHouseHoldMemberByAssessmentId(document.Assessment.Id);
                    var tabStatus = await _tabStatusRepository.GetTabStatus(document.Assessment.Id);
                    var incomeDocumentUploadedCount = 0;
                    foreach (var member in houseHoldMember)
                    {
                        var isIncomeDocumentUploaded = await _documentRepository.IsIncomeDocumentUploaded(member.Id);
                        if (!isIncomeDocumentUploaded)
                        {
                            tabStatus.IsIncomeVerificationComplete = false;
                        }
                        else
                        {
                            incomeDocumentUploadedCount += 1;
                        }
                    }

                    if (incomeDocumentUploadedCount > 0 && !houseHoldMember.Count().Equals(0))
                        tabStatus.IsIncomeVerificationComplete = true;

                    var isTabStatusUpdated = await _tabStatusRepository.Update(tabStatus);
                    return new Result<MessageDto>()
                    { Data = new MessageDto().AddMessage(Constants.DocumentDeleteMessage) };
                }
                else
                    return new Result<MessageDto>().AddError(Constants.DocumentNotExists);
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return new Result<MessageDto>().AddError(Constants.DocumentDeleteErrorMessage);
            }

        }

        public bool DeleteFiles(FileDetails fileDetails)
        {
            try
            {
                var fileLocation = _documentLocationMapper.GetFileLocation(fileDetails);
                return _fileHelper.DeleteFiles(fileLocation.FolderPath);
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return false;
            }
        }
        public byte[] ReadBytes(string filePath)
        {
            var byteData = _fileHelper.ReadFileBytes(filePath);
            return byteData;
        }

        public async Task<Result<List<ProgramFiles>>> GetProgramDocumentDetails(long programId, long assessmentId, bool isEvaluated)
        {
            try
            {
                var details = await _programDocumentRepository.GetProgramDocumentDetailsByProgramId(programId);
                var programDocumentDetails = await _fileUploadMapper.MapProgramDocumentFrom(details, null, assessmentId, isEvaluated);
                return new Result<List<ProgramFiles>> { Data = programDocumentDetails };
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return new Result<List<ProgramFiles>>().AddError(Constants.ErrorWhileDocumentFetch);
            }
        }
        public string GetContentType(string extension)
        {
            return FileContentType.GetMimeType(extension);
        }

        public async Task<Result<long>> LoadProgramDocument(FileDetails fileDetailsDto)
        {
            var formData = await _assessmentService.GetEFormData
                (new BasePatientAssessment
                {
                    AssessmentId = fileDetailsDto.AssessmentId,
                    PatientId = fileDetailsDto.UserId
                });
            var applicationData = JsonConvert.SerializeObject(formData.Data.MainApplicantDetails);
            var formDataElements = JsonConvert.DeserializeObject<Dictionary<string, string>>(applicationData);
            formDataElements.Add("CurrentDate", Clock.Now().Date.ToString("MM/dd/yyyy"));
            if (fileDetailsDto.ProgramDocumentId == null)
                return new Result<long> { Data = -1 };

            var programDocumentId = (long)fileDetailsDto.ProgramDocumentId;
            var programDocumentPath = GetProgramDocumentPath(programDocumentId).Result.Data.DocumentPath;
            var filePath = _documentLocationMapper.GetFileLocation(fileDetailsDto);
            var path = await GetDocumentPath(fileDetailsDto.DocumentId);
            var isProgramDocumentCreated =
                CreateProgramDocument(path, filePath.FilePath, fileDetailsDto.DocumentName, formDataElements);
            long documentId = 0;
            if (!isProgramDocumentCreated) return new Result<long> { Data = documentId };

            var documentCategoryId =
                await _documentCategoryMasterRepository.GetDocumentCategoryMaster(fileDetailsDto
                    .DocumentCategory);
            var documentTypeId =
                await _documentTypeMasterRepository.GetDocumentTypeMaster(fileDetailsDto.DocumentType);
            //var documentMappingId =
            //    await _documentCategoryDocumentTypeMappingRepository.GetDocumentCategoryDocumentTypeMapping(
            //        documentCategoryId, documentTypeId);

            //Update the created document name and path
            var documentName = string.Concat(fileDetailsDto.DocumentName, ".pdf");
            fileDetailsDto.DocumentPath = Path.Combine(filePath.FilePath, documentName);
            fileDetailsDto.DocumentName = documentName;
            var documentNew = _fileUploadMapper.MapFrom(documentTypeId, fileDetailsDto);
            var signedDocument = await _documentRepository.GetProgramDocumentEsigned(fileDetailsDto.AssessmentId, programDocumentId, true);
            if (signedDocument > 0)
            {
                documentNew.Id = signedDocument;
                var previousDocument = await _documentRepository.GetDocumentById(signedDocument);
                var signedDoc = await _documentRepository.UpdateDocument(documentNew);
                return new Result<long> { Data = signedDoc, NextAction = previousDocument.Path};
            }
            documentId = await _documentRepository.InsertDocument(documentNew);
            return new Result<long> { Data = documentId };
        }

        public async Task<Result<bool>> UpdateFilePath(long docId, string filePath)
        {
            var document = await _documentRepository.GetDocumentById(docId);
            document.Path = filePath;
            var updatedDoc = await _documentRepository.UpdateDocument(document);
            return new Result<bool> { Data = updatedDoc>0};
        }
        public async Task<Result<bool>> UpdateFileAgreementId(long docId, string fileAgreementId)
        {
            //bool signed = false;
            //for(long i=0; i<10000000000; i++)
            //{
            //    Thread.Sleep(1000);
            //    int result = GetAgreementData(fileAgreementId);
            //    if(result == 1)
            //    {
            //        signed = true;
            //        break;
            //    }
            //    else if(result == 2)
            //    {
            //        signed =false;
            //        break;
            //    }
            //}
            //if (signed)
            //{
                var document = await _documentRepository.GetDocumentById(docId);
                document.AgreementId = fileAgreementId;
                var updatedDoc = await _documentRepository.UpdateDocument(document);
                return new Result<bool> { Data = updatedDoc > 0 };
            //}
            //else
            //{
            //    return new Result<bool> { Data = false };
            //}
        }
        private static int GetAgreementData(string AgreementId)
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
                            return UpdateFileData(data);
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
        private static int UpdateFileData(dynamic FileStatus)
        {
            try
            {
                if (FileStatus.status.ToString() == "SIGNED")
                {
                    return 1;
                }
                else if(FileStatus.status.ToString() == "CANCELLED")
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }

        }
        public async Task<Result<bool>> DeleteeDocumentById(long docId, long downloadDocId)
        {
            var document = await _documentRepository.GetDocumentById(docId);
            var documentDownload = await _documentRepository.GetDocumentDownloaded(downloadDocId);
            document.isDocumentSigned = false;
            document.AgreementId = null;
            document.isDeleted = true;
            string[] subs = document.Path.Split('\\');
            var number = subs.Count();
            var filePath = string.Empty;
            var count = 0;
            var filePathDest = string.Empty;
            foreach (var sub in subs)
            {
                if (number > count + 1)
                {
                    filePath = filePath + sub + '\\';
                    count++;
                }
                else
                {
                    filePathDest = filePath + "Deleted\\";
                }
            }
            Directory.CreateDirectory(filePathDest);
            DirectoryInfo directory = new DirectoryInfo(filePathDest);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir1 in directory.GetDirectories())
            {
                dir1.Delete(true);
            }
            var dir = new DirectoryInfo(filePath);
            FileInfo[] files = dir.GetFiles("*.pdf");
            foreach (var item in files)
            {
                File.Copy(item.FullName, Path.Combine(filePath + "Deleted\\", item.Name), true); // overwrite = true 
            }
            File.Delete(document.Path);
            var updatedDoc = await _documentRepository.UpdateDocument(document);
            if(updatedDoc > 0)
            {
                if (documentDownload != null)
                {
                    documentDownload.isDownloaded = false;
                    await _documentRepository.UpdateDocumentDownloaded(documentDownload);
                }
            }
            return new Result<bool> { Data = updatedDoc > 0 };
        }

        public byte[] FetchDocumentFromUrlAsync(string documentPath, string name)
        {
           return _httpClientService.FetchDocumentFromURLAsync(documentPath, name).GetAwaiter().GetResult();
        }

        public async Task<byte[]> UploadSignature(IFormFile originalFile, IFormFile signatureCanvas, StringValues signatureText, StringValues docId)
        {
            PdfReader reader = null;
            FileStream programDocumentStream = null;
            PdfStamper pdfEditorInstance = null;
            MemoryStream fileStream = null;

            try
            {
                fileStream = new MemoryStream();
                using (var ms = new MemoryStream())
                {
                    originalFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    reader = new PdfReader(fileBytes);
                    pdfEditorInstance = new PdfStamper(reader, fileStream);
                    pdfEditorInstance.FormFlattening = false;
                    var pdfDocumentFields = pdfEditorInstance.AcroFields;
                    if (signatureCanvas?.Length > 0)
                    {
                        //FillSignatureCanvas("VAF", pdfDocumentFields, signatureCanvas, pdfEditorInstance);
                        var fps = pdfDocumentFields.GetFieldPositions("Text19");
                        Rectangle rect = new Rectangle(fps[1], fps[2], fps[3] + 200, fps[4] + 100);
                        using (var img = new MemoryStream())
                        {
                            signatureCanvas.CopyTo(img);
                            var imgBytes = img.ToArray();
                            Image image = Image.GetInstance(imgBytes);
                            image.ScaleToFit(rect.Width, rect.Height);
                            image.SetAbsolutePosition(rect.Left, rect.Bottom);
                            PdfContentByte canvas = pdfEditorInstance.GetOverContent((int)fps[0]);
                            canvas.AddImage(image);

                        }

                    }
                    else
                    {
                        pdfDocumentFields.SetField("Text19", signatureText);
                    }

                    pdfEditorInstance?.Close();
                    File.WriteAllBytes("filename.pdf", fileStream.ToArray());
                    return fileStream.ToArray();

                }
            }
            catch (Exception ex)
            {
                return default;
            }
            finally
            {
                if (pdfEditorInstance != null)
                {
                    pdfEditorInstance?.Reader?.Close();
                    pdfEditorInstance?.Close();
                }
                reader?.Close();
                fileStream?.Close();
            }


        }

        private bool CreateProgramDocument(string url, string filePath, string fileName,
            Dictionary<string, string> formData)
        {
            var programDocumentFromUrl = new PdfReader(url);
            FileStream programDocumentStream = null;
            PdfStamper pdfEditorInstance = null;
            try
            {
                if (!_fileHelper.CreateDirectory(filePath)) return false;
                var documentName = Path.Combine(filePath, string.Concat(fileName, ".pdf"));
                programDocumentStream = new FileStream(documentName, FileMode.Create);
                pdfEditorInstance = new PdfStamper(programDocumentFromUrl, programDocumentStream);
                var pdfDocumentFields = pdfEditorInstance.AcroFields;
                FillFormFields("VAF", pdfDocumentFields, formData);
                pdfEditorInstance.FormFlattening = false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (pdfEditorInstance != null)
                {
                    pdfEditorInstance.Reader.Close();
                    pdfEditorInstance.Close();
                }
                programDocumentFromUrl.Close();
                programDocumentStream?.Close();
            }

            return true;
        }

        public FileLocationDetail GetFileLocation(FileDetails fileDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<VerificationDocument>> GetDocumentByAssessmentIdTypeName(long assessmentId, string documentTypeName)
        {
            var documentTypeId = await _documentTypeMasterRepository.GetDocumentTypeMaster(documentTypeName);
            return new Result<VerificationDocument>() { Data = await _documentRepository.GetDocumentByAssessmentIdTypeId(assessmentId, documentTypeId, 0) };

        }

        public async Task<Result<string>> UpdateVerificationDocument(long assessmentId, string documentTypeName, string category)
        {
            var verificationDocument = await _verificationDocumentRepository.GetVerificationDocumentByAssessmentId(assessmentId);
            var documentTypeId = await _documentTypeMasterRepository.GetDocumentTypeMaster(documentTypeName);
            var tabStatus = await _tabStatusRepository.GetTabStatus(assessmentId);
            bool isUpdated;
            switch (category)
            {
                case Constants.Address:
                    verificationDocument.AddressVerification = documentTypeId;
                    isUpdated = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                    tabStatus.IsAddressVerificationComplete = true;
                    break;
                case Constants.Identification:
                    verificationDocument.IdVerification = documentTypeId;
                    isUpdated = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                    tabStatus.IsIdVerificationComplete = true;
                    break;
                case Constants.Other:
                    verificationDocument.OtherVerification = documentTypeId;
                    isUpdated = await _verificationDocumentRepository.UpdateVerificationDocument(verificationDocument);
                    tabStatus.IsOtherVerificationComplete = true;
                    break;
                default:
                    isUpdated = true;
                    break;
            }
            var isTabStatusUpdated = await _tabStatusRepository.Update(tabStatus);

            return isUpdated
                ? new Result<string>() { Data = Constants.DocumentUpdatedSuccessfully }
                : new Result<string>() { }.AddError(Constants.DocumentNotUpdated);
        }
        private bool FillFormFields(string formName, AcroFields formFields, Dictionary<string, string> formData)
        {

            var programDocumentFieldMap = GetProgramDocumentFieldMap();
            foreach (var programDocumentField in programDocumentFieldMap)
            {
                formFields.GetField(programDocumentField.Key);
                formFields.SetField(programDocumentField.Key, formData[programDocumentField.Value]);
            }

            return true;
        }

        private bool FillSignatureFields(string formName, AcroFields formFields, string signature)
        {
                
                formFields.SetField("", signature);
            

            return true;
        }

        private bool FillSignatureCanvas(string formName, AcroFields formFields, IFormFile signatureCanvas, PdfStamper stamper)
        {
            var ad = formFields.GetSignatureDictionary("Text11");
            //PdfStamper.CreateSignature()
            //ad.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
            //ad.ProportionalIcon = true;
            //ad.Image = Image.GetInstance("E:/signature/signature.png");
            //formFields.ReplacePushbuttonField("advertisement", ad.Field);


            //var fieldPosition = stamper.AcroFields.GetFieldPositions("")[0];
            //PushbuttonField imageField = new PushbuttonField(stamper.Writer, fieldPosition.position, fieldName);
            //imageField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
            //imageField.Image = iTextSharp.text.Image.GetInstance(imageFile);
            //imageField.ScaleIcon = PushbuttonField.SCALE_ICON_ALWAYS;
            //imageField.ProportionalIcon = false;
            //imageField.Options = BaseField.READ_ONLY;

            //stamper.AcroFields.RemoveField(fieldName);
            //stamper.AddAnnotation(imageField.Field, fieldPosition.page);

            //List <AcroFields.> positions = formFields.GetFieldPositions("Signature");
            //int page = f.page;
            //Rectangle rect = f.position;
            //Image image = Image.GetInstance("ImageFileName");
            //image.ScaleToFit(rect.Width, rect.Height);
            //image.SetAbsolutePosition(rect.Left, rect.Bottom);
            //PdfContentByte canvas = stamper.GetOverContent(page);
            //canvas.AddImage(image);

            return true;
        }

        private Dictionary<string, string> GetProgramDocumentFieldMap()
        {
            return _veteranFormFields;
        }

        private Dictionary<string, string> _veteranFormFields = new Dictionary<string, string>()
        {
            {"PATLastFirst","Forename"},
            {"PATHomePhone","HomeCellNumber"},
            {"PATWorkPhone","WorkCellNumber"},
            {"6 MY ADDRESS IS Number Street or losl Oflice Rox City State  ZIP ode","Address"},
            {"12 DATE MM JI J YYYY","CurrentDate"}
        };



    }
}
