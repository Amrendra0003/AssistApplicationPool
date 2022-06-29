using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.Web.Controllers;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class VerificationController : BaseApiController
    {
        private readonly IVerificationService _verificationService;

        public VerificationController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpPost(Constants.GetVerificationStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> GetEmailVerificationStatus([FromBody] BasePatientAssessment basePatientAssessment)
        {
            var result = await _verificationService.GetEmailVerificationStatus(basePatientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.SendEmailVerification)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SendEmailVerification([FromBody] BasePatientAssessment basePatientAssessment)
        {
            var messageDto = await _verificationService.SendEmailVerification(basePatientAssessment);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [AllowAnonymous]
        [HttpGet(Constants.ValidateEmailConfirmationToken)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> ValidateEmailConfirmationToken([FromQuery] string token, [FromQuery] string assessmentId)
        {
            var result = await _verificationService.ValidateEmailConfirmationToken(token);
            if (result.Errors.Count > 0)
            {
                if (result.Errors[0] == "Email confirmation already done. ")
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.SendOtpToCell)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> SendOtpToCell([FromBody] CellConfirmationOTPModel otpModel)
        {
            var result = await _verificationService.SendOtpToCell(otpModel);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.ValidateCellVerificationOtp)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> ValidateCellVerificationOtp([FromBody] ValidateOTP otpModel)
        {
            var result = await _verificationService.ValidateCellVerificationOtp(otpModel);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(Constants.GetHouseHoldMemberNames)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetHouseHoldMemberNames([FromBody] BasePatientAssessment patientAssessment)
        {
            var result = await _verificationService.GetHouseHoldMemberNames(patientAssessment);

            if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}