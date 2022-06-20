using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Services;
using HealthWare.ActiveASSIST.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class HouseHoldController : BaseApiController
    {
        private readonly IHouseHoldService _houseHoldService;

        public HouseHoldController(IHouseHoldService houseHoldService)
        {
            _houseHoldService = houseHoldService;
        }

        [HttpPost(Constants.CreateHouseHoldMember)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateHouseHoldMember([FromBody] HouseHoldMemberDetails houseHoldMemberDto)
        {
            var messageDto = await _houseHoldService.CreateHouseHoldMember(houseHoldMemberDto);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetHouseHoldMembersList)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetHouseHoldMembersList([FromQuery] long assessmentId)
        {
            var messageDto = await _houseHoldService.GetHouseHoldMembersList(assessmentId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.GetHouseHoldMemberById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetHouseHoldMemberById([FromQuery] long houseHoldMemberId)
        {
            var messageDto = await _houseHoldService.GetHouseHoldMemberById(houseHoldMemberId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [HttpGet(Constants.DeleteHouseHoldMember)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteHouseHoldMember([FromQuery, Required] long householdMemberId)
        {
            var messageDto = await _houseHoldService.DeleteHouseHoldMember(householdMemberId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }

        [AllowAnonymous]
        [HttpGet(Constants.GetIncomeResourcesAmount)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetIncomeResourcesAmount([FromQuery, Required] long assessmentId)
        {
            var messageDto = await _houseHoldService.GetIncomeResourcesAmount(assessmentId);

            if (messageDto.Errors.Count > 0)
            {
                return BadRequest(messageDto);
            }

            return Ok(messageDto);
        }
    }
}
