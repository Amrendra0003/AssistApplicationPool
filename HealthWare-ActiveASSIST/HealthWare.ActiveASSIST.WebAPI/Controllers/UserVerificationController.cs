using HealthWare.ActiveASSIST.Web.Controllers;
using HealthWare.ActiveASSIST.Entities.UserManagement;
using HealthWare.ActiveASSIST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Constants.JwtBearer)]
    [AllowAnonymous]
    public class UserVerificationController : BaseApiController
    {
        private readonly IUserVerificationService _userVerificationService;
        public UserVerificationController(IUserVerificationService userVerificationService)
        {
            _userVerificationService = userVerificationService;
        }

        [HttpGet(Constants.GetUserDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserDetails([FromQuery] string email)
        {
            var messageDto = await _userVerificationService.GetUserProfileDetail(email);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpPost(Constants.CreateUserDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateUserDetails([FromBody] UpdateUserDetails updateUserDetails)
        {
            var messageDto = await _userVerificationService.UpdateUserVerification(updateUserDetails);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }



    }
}
