using System;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;
using HealthWare.ActiveASSIST.Entities.UserManagement;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.Attributes;
using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class UserManagementController : BaseApiController
    {
        private readonly IUserManagementService _userManagementService;
        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet(Constants.GetProfileDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetProfileDetails([FromQuery] long userId)
        {
            var messageDto = await _userManagementService.GetProfileDetails(userId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.UpdateProfileDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProfileDetails([FromBody] UpdateProfileDetail updateProfileDetail)
        {
            var messageDto = await _userManagementService.UpdateProfileDetails(updateProfileDetail);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.CreateUserProfile)]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserProfile([FromBody] PatientBasicInfo patientBasicProfileInfo)
        {
            var messageDto = await _userManagementService.CreateUserProfile(patientBasicProfileInfo);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.VerifyAddressDetails)]
        [AllowAnonymous]
        [ApiExceptionsHandlerFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> VerifyAddressDetails([FromQuery] string addressLine1, string addressLine2, string city, string state, string zip)
        {
            var address2 = addressLine2 == null ? "" : addressLine2;
            var addressDetails = new AddressVerificationRequest
            {
                Address1 = Convert.ToString(addressLine1),
                Address2 = Convert.ToString(address2),
                City = Convert.ToString(city),
                State = Convert.ToString(state),
                Zip = Convert.ToString(zip),
                ObjectId = new Random().Next()
            };
            var messageDto = await _userManagementService.VerifyAddressDetails(addressDetails);
            messageDto.Data.CassResult.Address2 = messageDto.Data.CassResult.Address2.Trim();
            if (messageDto.Data.CassResult.Address2.ToUpper() == "NULL")
            {
                messageDto.Data.CassResult.Address2 = "";
            }
            if (messageDto.Data.CassResult.County.ToUpper() == "NULL")
            {
                messageDto.Data.CassResult.County = "";
            }
            messageDto.Data.CassResult.Address1 = messageDto.Data.CassResult.Address1.Trim();
            messageDto.Data.CassResult.City = messageDto.Data.CassResult.City.Trim();
            messageDto.Data.CassResult.State = messageDto.Data.CassResult.State.Trim();
            messageDto.Data.CassResult.County = messageDto.Data.CassResult.County.Trim();
            messageDto.Data.CassResult.Zip = messageDto.Data.CassResult.Zip.Trim();
            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet("GetPermissionsForUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> GetPermissionsForUser([FromQuery] long roleId)
        {
            var messageDto = await _userManagementService.GetPermissionsForUser(roleId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet("ValidateUserAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> ValidateUserAccount([FromQuery] string token)
        {
            var messageDto = await _userManagementService.ValidateUserAccount(token);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }
    }
}
