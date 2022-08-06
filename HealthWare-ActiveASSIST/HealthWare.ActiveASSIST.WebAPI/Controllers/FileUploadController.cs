using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.Web.Controllers;
using JetBrains.Annotations;
using System;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class FileUploadController : BaseApiController
    {
        private readonly IDocumentService _documentService;
        private readonly DocumentConfiguration _documentServiceConfig;
        public FileUploadController(IDocumentService documentService, DocumentConfiguration fileUploadConfig)
        {
            _documentService = documentService;
            _documentServiceConfig = fileUploadConfig;
        }

        [HttpPost(Constants.UploadAssessmentProfileImage)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadAssessmentProfileImage(long AssmtId)
        {
            if (Request.Form.Files.Count <= 0)
                return BadRequest();

            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                var messageDto = _documentService.UploadProfileImage(file, AssmtId);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }

        [HttpPost(Constants.UploadUserProfileImage)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadUserProfileImage(long userId)
        {
            if (Request.Form.Files.Count <= 0)
                return BadRequest();

            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                var messageDto = _documentService.UploadUserProfileImage(file, userId);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }

        [HttpPost(Constants.UpdateVerificationDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVerificationDocument(UpdateVerificationDocumentRequest verificationDocumentRequest)
        {

            var messageDto = await _documentService.UpdateVerificationDocument(verificationDocumentRequest.AssessmentId, verificationDocumentRequest.DocumentTypeName, verificationDocumentRequest.Category);
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpGet(Constants.GetAssessmentProfileImage)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> GetAssessmentProfileImage(long AssmtId)
        {
            return await _documentService.LoadProfileImage(AssmtId); 
        }

        [HttpGet(Constants.GetUserProfileImage)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> GetUserProfileImage(long userId)
        {
            return await _documentService.LoadUserProfileImage(userId);
        }

        [HttpGet(Constants.DeleteDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDocument(long DocId, long householdMemberId)
        {
            var messageDto = _documentService.DeleteDocument(DocId, householdMemberId).GetAwaiter().GetResult();
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpGet(Constants.GetIncomeVerificationFileDetail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetIncomeVerificationFileDetail(long AssmtId)
        {
            var messageDto = _documentService.GetIncomeVerificationDocumentDetail(AssmtId);
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpPost(Constants.UploadFile)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile()
        {
            if (Request.Form.Files.Count == 0)
                return BadRequest();

            var file = Request.Form.Files[0];
            var fileDetail = BindData(Request.Form);
            if (file.Length > 0)
            {
                var messageDto = await _documentService.UploadFile(file, fileDetail);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }
        [HttpGet(Constants.GetIDVerificationFileDetail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetIDVerificationFileDetail(long AssmtId)
        {
            var messageDto = await _documentService.GetVerificationDocumentDetail(AssmtId, nameof(_documentServiceConfig.Identification));
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }
        [HttpGet(Constants.GetAddressVerificationFileDetail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAddressVerificationFileDetail(long AssmtId)
        {
            var messageDto = _documentService.GetVerificationDocumentDetail(AssmtId, nameof(_documentServiceConfig.Address)).GetAwaiter().GetResult();
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpGet(Constants.GetOtherVerificationFileDetail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOtherVerificationFileDetail(long AssmtId)
        {
            var messageDto = _documentService.GetVerificationDocumentDetail(AssmtId, nameof(_documentServiceConfig.Other)).GetAwaiter().GetResult();
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpGet(Constants.PreviewDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<FileResult> PreviewDocument(long DocId)
        {
            var documentPath = await _documentService.GetDocumentPath(DocId);
            byte[] fileContents = _documentService.ReadBytes(documentPath);
            var contentType = _documentService.GetContentType(Path.GetExtension(documentPath).Replace(".", string.Empty));
            return File(fileContents, contentType);
        }

        [HttpGet(Constants.PreviewProgramDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public FileResult PreviewProgramDocument(long PgrmdocId, long assessmentId, long documentDownloadId)
        {
                var document = _documentService.GetProgramDocumentPath(PgrmdocId).GetAwaiter().GetResult();
            //byte[] fileContents = _documentService.ReadBytes(document.Data.DocumentPath);
            byte[] fileContents = _documentService.FetchDocumentFromUrlAsync(document.Data.DocumentPath, document.Data.DocumentName);
            var contentType = _documentService.GetContentType(Path.GetExtension(document.Data.DocumentPath)?.Replace(".", string.Empty));
            if (fileContents != null)
            {
                _ = _documentService.UpdateOrInsertDocumentDownloaded(PgrmdocId, assessmentId, documentDownloadId);
            }

            return File(fileContents, contentType);
        }

        [HttpGet(Constants.DownloadProgramDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DownloadProgramDocument(long PgrmdocId)
        {
            var fileDetail = _documentService.GetProgramDocumentPath(PgrmdocId).GetAwaiter().GetResult();
            if (fileDetail.Errors.Count == 0)
            {
                byte[] fileContents = _documentService.ReadBytes(fileDetail.Data.DocumentPath);
                return File(fileContents, "application/" + Path.GetExtension(fileDetail.Data.DocumentName)?.Replace(".", string.Empty), Path.GetFileName(fileDetail.Data.DocumentPath));
            }
            else return BadRequest(fileDetail.Errors);
        }

        [HttpGet(Constants.GetProgramDocumentDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProgramDocumentDetails(long PrgmId, long AssessmentId, bool isEvaluated)
        {
            var messageDto = _documentService.GetProgramDocumentDetails(PrgmId, AssessmentId, isEvaluated).GetAwaiter().GetResult();
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [HttpGet(Constants.GetDocumentByAssessmentIdTypeName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDocumentByAssessmentIdTypeName(long assessmentId, string documentTypeName)
        {
            var messageDto =
             await _documentService.GetDocumentByAssessmentIdTypeName(assessmentId, documentTypeName);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
         }
        [HttpPost("GetAssessmentProgramDocument")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAssessmentProgramDocument([FromBody] FileDetails fileDetails)
        {
            //Todo: Need to be replace with URL from HWS API
            var isResult = _documentService.LoadProgramDocument(fileDetails).GetAwaiter().GetResult();

            if (isResult.Errors.Count > 0)
            {
                return BadRequest(isResult);
            }
            return Ok(isResult);
        }

        [HttpPost(Constants.UpdateFilePath)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFilePath(long docId, string filePath)
        {
            if (docId <= 0&& filePath.isNullOrEmpty())
                return BadRequest();

            if (docId > 0)
            {
                var messageDto = await _documentService.UpdateFilePath(docId, filePath);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }

        [HttpPost(Constants.UpdateFileAgreementId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFileAgreementId(long docId, string AgreementId)
        {
            if (docId <= 0 && AgreementId.isNullOrEmpty())
                return BadRequest();

            if (docId > 0)
            {
                var messageDto = await _documentService.UpdateFileAgreementId(docId, AgreementId);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }

        [HttpPost(Constants.DeleteeDocumentById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteeDocumentById(string docId, string downloadDocId)
        {
            var docId1 = Convert.ToInt64(docId);
            var downloadDocId1 = Convert.ToInt64(downloadDocId);
            if (docId1 <= 0)
                return BadRequest();

            if (docId1 > 0)
            {
                var messageDto = await _documentService.DeleteeDocumentById(docId1, downloadDocId1);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }
                return Ok(messageDto);
            }
            return BadRequest();
        }

        [HttpPost(Constants.UploadSignature)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ItemCanBeNull]
        public async Task<ActionResult<Result<FileResult>>> UploadSignatureAsync()
        {
            if (Request.Form.Files.Count == 0)
            {
                var result  = new Result<FileResult>().AddError("Please provide the valid file");
                return BadRequest(result);
            }

            
            var originalFile = Request.Form.Files.GetFile(Constants.File);
            var SignatureCanvas = Request.Form.Files.GetFile(Constants.SignatureCanvas);
            var DocId = Request.Form[Constants.DocumentId];
            var SignatureText = Request.Form[Constants.SignatureText];
            if (originalFile?.Length > 0)
            {
                byte[] fileContents = await _documentService.UploadSignature(originalFile, SignatureCanvas, SignatureText, DocId);
                var contentType = _documentService.GetContentType(Path.GetExtension(originalFile.FileName).Replace(".", string.Empty));
                return File(fileContents, contentType);
            }
            return BadRequest();
        }

        [HttpPost(Constants.CompleteUploadedDocument)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ItemCanBeNull]
        public async Task<IActionResult> CompleteUploadedDocumentAsync()
        {
            if (!Request.Form.ContainsKey(Constants.DocumentId))
            {
                var result = new Result<FileResult>().AddError("Invalid Document Id");
                return BadRequest(result);
            }
            var DocId = long.Parse(Request.Form[Constants.DocumentId]);
            var uploadResult = _documentService.CompleteUploadedDocument(DocId).GetAwaiter().GetResult();
            if (uploadResult.Errors.Count > 0)
            {
                return BadRequest(uploadResult);
            }
            return Ok(uploadResult);

        }

        private FileDetails BindData(IFormCollection form)
        {

            var details = new FileDetails
            {
                AssessmentId = long.Parse(form[Constants.AssessmentId]),
                UserId = long.Parse(form[Constants.UserId]),
                HouseHoldMemberId = long.Parse(form[Constants.HouseHoldMemberId]),
                ProgramId = long.Parse(form[Constants.ProgramId]),
                DocumentTitle = form[Constants.DocumentTitle],
                DocumentCategory = form[Constants.DocumentCategory],
                DocumentType = form[Constants.DocumentType],
                ProgramDocumentId = long.Parse(form[Constants.ProgramDocumentId])
            };
            if (details.HouseHoldMemberId == 0) details.HouseHoldMemberId = null;
            if (details.ProgramId == 0) details.ProgramId = null;
            details.Esigned = form[Constants.Esign].Count > 0 && form[Constants.Esign].ToString() == "true";
            return details;
        }
    }
}
