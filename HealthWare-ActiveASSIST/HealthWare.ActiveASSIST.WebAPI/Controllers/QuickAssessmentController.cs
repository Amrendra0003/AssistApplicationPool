using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthWare.ActiveASSIST.Web.Controllers;
using Healthware.Core.DTO;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class QuickAssessmentController : BaseApiController
    {
        private readonly IQuickAssessmentService _quickAssessmentService;
        public QuickAssessmentController(IQuickAssessmentService quickAssessmentService)
        {
            _quickAssessmentService = quickAssessmentService;
        }

        [Authorize(Constants.JwtBearer)]
        [HttpGet(Constants.GetQuickAssessmentData)]
        [ProducesResponseType(StatusCodes.Status200OK)]                                                                                                                                                                                                                                                             
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult QuickAssessment()
        {
            var messageDto = _quickAssessmentService.QuickAssessment();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetQuickAssessmentDataByAssessmentId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult QuickAssessment(string assessmentId)
        {
            var messageDto = _quickAssessmentService.QuickAssessment(assessmentId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.CreateNewAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Constants.JwtBearer)]
        public async Task<ActionResult> CreateNewAssessment([FromBody] CreateAssessment createAssessmentDto)
        {
            Result<AssessmentEvaluationResponse> messageDto;
            if (createAssessmentDto.BasicInfoId > 0 || createAssessmentDto.IsDynamic.Equals(false))
            {
                messageDto = await _quickAssessmentService.CreateNewAdvocateAssessment(createAssessmentDto);
            }
            else
            {
                messageDto = await _quickAssessmentService.CreateNewAssessment(createAssessmentDto);
            }


            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.SavePartialAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Constants.JwtBearer)]
        public async Task<ActionResult> SavePartialAssessment(PartialSaveResponse partialAssessmentJson)
        {
            var partialSaveResponse = await _quickAssessmentService.SavePartialAssessment(partialAssessmentJson.QuestionAnswerJson);
            if (partialSaveResponse.Errors.Count > 0)
            {
                return BadRequest(partialSaveResponse);
            }

            return Ok(partialSaveResponse);
        }

        [HttpGet(Constants.GetPartialAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Constants.JwtBearer)]
        public async Task<ActionResult> GetPartialAssessment(int partialSaveId)
        {
            var partialAssessmentResult = await _quickAssessmentService.GetPartialAssessment(partialSaveId);

            if (partialAssessmentResult.Errors.Count > 0)
            {
                return BadRequest(partialAssessmentResult);
            }

            return Ok(partialAssessmentResult);
        }

        [HttpPost(Constants.UpdatePartialAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Constants.JwtBearer)]
        public async Task<ActionResult> UpdatePartialAssessment(PartialSaveResponse partialAssessmentJson)
        {
            var partialAssessmentResult = await _quickAssessmentService.UpdatePartialAssessment(partialAssessmentJson);

            if (partialAssessmentResult.Errors.Count > 0)
            {
                return BadRequest(partialAssessmentResult);
            }

            return Ok(partialAssessmentResult);
        }
        [HttpPost(Constants.DeletePartialAssessment)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Constants.JwtBearer)]
        public async Task<ActionResult> DeletePartialAssessment(long quickAssessmentResultId)
        {
            var partialAssessmentResult = await _quickAssessmentService.DeletePartialAssessment(quickAssessmentResultId);

            if (partialAssessmentResult.Errors.Count > 0)
            {
                return BadRequest(partialAssessmentResult);
            }

            return Ok(partialAssessmentResult);
        }



        [HttpGet(Constants.GetStateAndCounty)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetStateAndCounty([FromQuery] string zipcode)
        {
            var messageDto = await _quickAssessmentService.GetStateAndCounty(zipcode);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetSelfDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetSelfDetails([FromQuery] long userId)
        {
            var messageDto = await _quickAssessmentService.GetSelfDetails(userId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Application.GetAdvocatePatient)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetPatientSelfDetails([FromQuery] long patientId)
        {
            var messageDto = await _quickAssessmentService.GetBasicInfoSelfDetails(patientId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.ValidatePolicyNumber)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ValidatePolicyNumber([FromQuery] string policyNumber)
        {
            var messageDto = await _quickAssessmentService.ValidatePolicyNumber(policyNumber);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.IsUserNameExists)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> IsUserNameExists([FromQuery] string emailAddress)
        {
            var messageDto = await _quickAssessmentService.IsUserNameExists(emailAddress);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetUserNameInfo)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserNameInfo([FromQuery] string emailAddress)
        {
            var messageDto = await _quickAssessmentService.GetUserNameInfo(emailAddress);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Application.GetAdvocatePatientsNames)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAdvocatePatients([FromBody] GetPatientNamesRequest getPatientNamesRequest)
        {
            var messageDto = await _quickAssessmentService.GetAdvocatePatients(getPatientNamesRequest);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Application.getDynamicQuestions)]
        public async Task<ActionResult> GetDynamicScreens(long tenantId = 1)
        {
            var screens = await _quickAssessmentService.GetDynamicScreens(tenantId);
            if (screens.Errors.Count > 0)
            {
                return BadRequest(screens);
            }
            return Ok(screens);
        }
    }
}
