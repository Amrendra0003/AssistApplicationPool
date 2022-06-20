using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class SubDomainController : BaseApiController
    {
        private readonly ISubDomainService _subDomainService;
        public SubDomainController(ISubDomainService subDomainService)
        {
            _subDomainService = subDomainService;
        }

        [HttpGet(Constants.GetTenantBySubDomain)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<string>>> GetTenantBySubDomain(string subDomain)
        {
            var tenant = await _subDomainService.GetTenantBySubDomain(subDomain);

            if (tenant.Errors.Count > 0)
            {
                return Unauthorized(tenant);
            }

            return Ok(tenant);
        }
        [HttpGet(Constants.GetPasswordPolicyBySubDomain)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<string>>> GetPasswordPolicyBySubDomain(string subDomain)
        {
            var tenant = await _subDomainService.GetPasswordPolicyBySubDomain(subDomain);

            if (tenant.Errors.Count > 0)
            {
                return Unauthorized(tenant);
            }

            return Ok(tenant);
        }

    }
}