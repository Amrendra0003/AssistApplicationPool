using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services;
using HealthWare.ActiveASSIST.Services.Authentication.Validation;
using Healthware.Core.Common.Session;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using HealthWare.ActiveASSIST.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LoginController : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISessionService<PatientDbContext> _sessionService;

        private readonly IRunValidationsCommand<ForgotPassword> _forgotPasswordDto;
        private readonly IRunValidationsCommand<ResetPassword> _resetPassword;
        private readonly IRunValidationsCommand<ChangePassword> _changePassword;

        public LoginController(IAuthenticationService authenticationService,
            IRunValidationsCommand<ForgotPassword> forgotPasswordDto,
            IRunValidationsCommand<ResetPassword> resetPassword, ISessionService<PatientDbContext> sessionService, IRunValidationsCommand<ChangePassword> changePassword)
        {
            _authenticationService = authenticationService;
            _forgotPasswordDto = forgotPasswordDto;
            _resetPassword = resetPassword;
            _sessionService = sessionService;
            _changePassword = changePassword;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Authenticate authenticate)
        {
            var messageDto = await _authenticationService.Authenticate(authenticate);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.LoginWithoutOTP)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LoginWithoutOTP([FromBody] Authenticate authenticate)
        {
            var messageDto = await _authenticationService.LoginWithoutOTP(authenticate);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.SendOTP)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SendOTP([FromBody] SendOTP sendOtp)
        {
            var messageDto = await _authenticationService.SendOTP(sendOtp);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.ValidateOTP)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> ValidateOTP([FromBody] ValidateOTP validateOtp)
        {
            var patientAccountDto = await _authenticationService.ValidateOTP(validateOtp);

            if (patientAccountDto.Errors.Count > 0)
            {
                return BadRequest(patientAccountDto);
            }

            return Ok(patientAccountDto);
        }

        [HttpPost(Constants.ForgotMyPassword)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ForgotMyPassword([FromBody, Required] ForgotPassword forgotPassword)
        {
            var validationResult = _forgotPasswordDto.Validate(forgotPassword);
            var result = new Result<MessageDto>()
            {
                Data = new MessageDto()
            };

            if (validationResult.IsNull())
            {
                var messageDto = _authenticationService.ForgotMyPassword(forgotPassword);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }

                return Ok(messageDto);
            }

            validationResult.ErrorMessages.Each(x => result.AddError(x));
            return BadRequest(result);
        }

        [HttpPost(Constants.UpdateNewPassword)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> UpdateNewPassword([FromBody] ResetPassword resetPassword)
        {
            var validationResult = _resetPassword.Validate(resetPassword);
            var result = new Result<MessageDto>()
            {
                Data = new MessageDto()
            };
            if (validationResult.IsNull())
            {
                var messageDto = await _authenticationService.UpdateNewPassword(resetPassword);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }

                return Ok(messageDto);
            }

            validationResult.ErrorMessages.Each(x => result.AddError(x));
            return BadRequest(result);
        }

        [HttpPost(Constants.ChangePassword)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> ChangePassword([FromBody] ChangePassword changePassword)
        {
            var validationResult = _changePassword.Validate(changePassword);
            var result = new Result<MessageDto>()
            {
                Data = new MessageDto()
            };
            if (validationResult.IsNull())
            {
                var messageDto = await _authenticationService.ChangePassword(changePassword);
                if (messageDto.Errors.Count > 0)
                {
                    return BadRequest(messageDto);
                }

                return Ok(messageDto);
            }

            validationResult.ErrorMessages.Each(x => result.AddError(x));
            return BadRequest(result);
        }

        [HttpPost(Constants.IsSessionActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> IsSessionActive([FromQuery] long userId)
        {
            var messageDto = await _sessionService.IsSessionActive(userId);
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }

        [Authorize(Constants.JwtBearer)]
        [HttpPost(Constants.Logout)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<MessageDto>>> Logout([FromQuery] long userId)
        {
            var messageDto = await _authenticationService.Logout(userId);
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }
            return Ok(messageDto);
        }
    }
}