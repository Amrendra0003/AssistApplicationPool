using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities.DropDown;
using HealthWare.ActiveASSIST.Services;
using HealthWare.ActiveASSIST.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class DropDownController: BaseApiController
    {
        private readonly IDropDownService _dropDownService;
        public DropDownController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        [HttpGet(Constants.GetGenderValues)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> GetGenderValues()
        {
            var messageDto = await _dropDownService.GetDropDownValues<Gender>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetMaritalStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> GetMaritalStatus()
        {
            var messageDto = await _dropDownService.GetDropDownValues<MaritalStatus>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetRelationshipToPatient)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRelationshipToPatient()
        {
            var messageDto = await _dropDownService.GetDropDownValues<RelationshipToPatient>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetIncomeType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetIncomeType()
        {
            var messageDto = await _dropDownService.GetDropDownValues<IncomeType>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetIncomeTypeCurrentStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCurrentStatus()
        {
            var messageDto = await _dropDownService.GetDropDownValues<IncomeTypeCurrentStatus>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetVerification)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetVerification()
        {
            var messageDto = await _dropDownService.GetDropDownValues<Verification>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetPayPeriod)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetPayPeriod()
        {
            var messageDto = await _dropDownService.GetDropDownValues<PayPeriod>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetResourceType)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetResourceType(string value)
        {
            var messageDto = await _dropDownService.GetDropDownValues<ResourceType>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetResourceTypeCurrentStatus)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetResourceTypeCurrentStatus()
        {
            var messageDto = await _dropDownService.GetDropDownValues<ResourceTypeCurrentStatus>();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }
        [HttpGet(Constants.GetReasonNoSSN)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> GetReasonNoSsn()
        {
            var messageDto = await _dropDownService.GetReasonNoSsn();

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }
    }
}
