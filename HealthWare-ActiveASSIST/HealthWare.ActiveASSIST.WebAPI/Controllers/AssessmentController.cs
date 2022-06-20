using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Web.Web.Authorization;
using HealthWare.ActiveASSIST.Web.Controllers;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CreateContactPreference = HealthWare.ActiveASSIST.DTOs.CreateContactPreference;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class AssessmentController : BaseApiController
    {
        private readonly IAssessmentService _assessmentService;

        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [HttpPost(Constants.GetPatientById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewPatient)]
        public async Task<ActionResult> GetBasicInfoById([FromBody, Required] BasePatientAssessment basePatientAssessment)
        {
            if (basePatientAssessment.PatientId < 1) return BadRequest();
            var messageDto = await _assessmentService.GetBasicInfoById(basePatientAssessment);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.UpdatePersonalDetail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.UpdatePatient)]
        public async Task<ActionResult> UpdatePersonalDetail([FromBody] PatientPersonalDetail patientPersonalDetail)
        {
            var messageDto = await _assessmentService.UpdatePersonalDetail(patientPersonalDetail);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.GetContactDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewAddress)]
        public async Task<ActionResult> GetContactDetails([FromBody] GetContactDetails contactDto)
        {
            var messageDto = await _assessmentService.GetContactDetails(contactDto);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.InsertContactDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.CreateAddress)]
        public async Task<ActionResult> InsertContactDetails([FromBody] ContactDetailsInfo contactDetailsDto)
        {
            var messageDto = await _assessmentService.InsertContactDetails(contactDetailsDto);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.UpdateContactDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.UpdateAddress)]
        public async Task<ActionResult> UpdateContactDetails([FromBody] UpdateContactDetails contactDto)
        {
            var messageDto = await _assessmentService.UpdateContactDetails(contactDto);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.DeleteContactDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.UpdateAddress)]
        public async Task<ActionResult> DeleteContactDetails([FromBody] DeleteContactDetailsRequest deleteContactDetailsRequest)
        {
            var messageDto = await _assessmentService.DeleteContactDetails(deleteContactDetailsRequest);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetGuarantorByAssessmentId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewComponentGuarantor)]
        public async Task<ActionResult> GetGuarantor([FromQuery, Required] long assessmentId)
        {
            var messageDto = await _assessmentService.GetGuarantor(assessmentId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.CreateGuarantor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.CreateGuarantor)]
        public async Task<ActionResult> CreateGuarantor([FromBody] CreateGuarantorRequest createGuarantorRequest)
        {
            var messageDto = await _assessmentService.CreateGuarantor(createGuarantorRequest);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.UpdateGuarantor)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.UpdateGuarantor)]
        public async Task<ActionResult> UpdateGuarantor([FromBody] UpdateGuarantorRequest updateGuarantorRequest)
        {
            var messageDto = await _assessmentService.UpdateGuarantor(updateGuarantorRequest);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.UpdatePatientReviewPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> UpdatePatientReviewPrograms([FromBody] List<UpdateReviewProgramRequest> updateReviewProgramRequest)
        {
            var result = await _assessmentService.UpdateReviewProgramStatus(updateReviewProgramRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetActiveReviewPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetActiveReviewPrograms([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetActiveReviewPrograms(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetAllReviewPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetAllReviewPrograms([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetAllReviewPrograms(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost(Constants.GetNotEvaluatedActiveReviewPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetNotEvaluatedActiveReviewPrograms([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetNotEvaluatedActiveReviewPrograms(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetEFormData)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetEFormData([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetEFormData(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetPreferredCell)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetPreferredCell([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetPreferredCell(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetPreferredEmail)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetPreferredEmail([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetPreferredEmail(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetPreferredAddress)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetPreferredAddress([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetPreferredContactDetails(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.CreateContactPreference)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.CreateContactPreference)]
        public async Task<ActionResult<Result<MessageDto>>> CreateContactPreference([FromBody] CreateContactPreference createContactPreferenceRequest)
        {
            var result = await _assessmentService.CreateContactPreference(createContactPreferenceRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.UpdateContactPreference)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.UpdateContactPreference)]
        public async Task<ActionResult<Result<MessageDto>>> UpdateContactPreference([FromBody] UpdateContactPreference updateContactPreferenceRequest)
        {
            var result = await _assessmentService.UpdateContactPreference(updateContactPreferenceRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetContactPreference)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewContactPreference)]
        public async Task<ActionResult<Result<MessageDto>>> GetContactPreference([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetContactPreference(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.UpdateAssessmentStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> UpdateAssessmentStatus([FromBody] UpdateAssessmentStatus assessmentStatus)
        {
            var result = await _assessmentService.UpdateAssessmentStatus(assessmentStatus);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.DeleteAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.DeleteAssessment)]
        public async Task<ActionResult<Result<MessageDto>>> DeleteAssessment([FromBody, Required] BasePatientAssessment basePatientAssessment)
        {
            var result = await _assessmentService.DeleteAssessment(basePatientAssessment.AssessmentId);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.AddReviewNotes)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.CreateReviewNotes)]
        public async Task<ActionResult<Result<MessageDto>>> AddReviewNotes([FromBody] ReviewNotesRequest reviewNotesRequest)
        {
            var result = await _assessmentService.AddReviewNotes(reviewNotesRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetReviewNotes)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewReviewNotes)]
        public async Task<ActionResult<Result<MessageDto>>> GetReviewNotes([FromBody] BasePatientAssessment basePatientAssessment)
        {
            var result = await _assessmentService.GetReviewNotes(basePatientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetPrograms([FromBody] GetProgramsRequest getProgramsRequest)
        {
            var result = await _assessmentService.GetPrograms(getProgramsRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost(Constants.CreatePatientProgramMapping)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> CreatePatientProgramMapping([FromBody] ProgramMappingRequest patientProgramMapping)
        {
            var result = await _assessmentService.CreatePatientProgramMapping(patientProgramMapping);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost(Constants.CreateProgramMapping)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> CreateProgramMapping([FromBody] ProgramMappingRequest patientProgramMapping)
        {
            var result = await _assessmentService.CreateProgramMapping(patientProgramMapping);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost(Constants.GetPatientProgram)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetPatientProgram([FromQuery] int assessmentId)
        {
            try
            {
                var messageDto = await _assessmentService.GetPatientProgram(assessmentId);

                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }

                return Ok(messageDto);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status504GatewayTimeout);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost(Constants.GetTabCompletionStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetTabCompletionStatus([FromBody] TabStatusRequest tabStatusRequest)
        {
            var result = await _assessmentService.GetTabCompletionStatus(tabStatusRequest);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.EvaluateAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> EvaluateAssessment(BasePatientAssessment basePatientAssessment)
        {
            var result = await _assessmentService.EvaluateAssessment(basePatientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetEvaluatedPrograms)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetEvaluatedPrograms([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _assessmentService.GetEvaluatedPrograms(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}