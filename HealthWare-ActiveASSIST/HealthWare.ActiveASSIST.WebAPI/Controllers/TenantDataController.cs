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
    public class TenantDataController : BaseApiController
    {
        private readonly ITenantDataService _tenantDataService;
        public TenantDataController(ITenantDataService tenantDataService)
        {
            _tenantDataService = tenantDataService;
        }

        [HttpGet(Constants.UpdateMappingTables)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<string>>> UpdateMappingTables()
        {
            var tenant = await _tenantDataService.UpdateMappingTables();

            if (tenant.Errors.Count > 0)
            {
                return Unauthorized(tenant);
            }

            return Ok(tenant);
        }

    }
}