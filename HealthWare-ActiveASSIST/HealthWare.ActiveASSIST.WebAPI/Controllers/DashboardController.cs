using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Services;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Web.Web.Authorization;
using System;
using HealthWare.ActiveASSIST.Web.Controllers;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Constants.JwtBearer)]
    public class DashboardController : BaseApiController
    {
        private readonly IDashboardService _dashboardService;
        private readonly ITenantDataService _tenantDataService;
        private HttpContext _httpContext;

        public DashboardController(IDashboardService dashboardService, ITenantDataService tenantDataService, IHttpContextAccessor contextAccessor)
        {
            _dashboardService = dashboardService;
            _tenantDataService = tenantDataService;
            _httpContext = contextAccessor.HttpContext;

        }

        [HttpGet(Constants.GetDashboardDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewPatientDashboard)]
        public async Task<ActionResult<Result<DashboardResponse>>> GetDashboardDetails([FromQuery] int userId, string partialName)
        {
            _httpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
            var dashboardResponseDto = await _dashboardService.GetDashboardDetails(userId, partialName, Convert.ToInt64(tenantId));
            
                var tenantDetails = await _tenantDataService.GetTenantDetails(Convert.ToInt64(tenantId));
                foreach (var assessment in dashboardResponseDto.Data.DashboardDetailResponse)
                {
                    assessment.CellNumber = $"({tenantDetails.Data.CellNumber.Substring(0, 3)}) {tenantDetails.Data.CellNumber.Substring(3, 3)}-{tenantDetails.Data.CellNumber.Substring(6)}";
                    assessment.CountyCode = tenantDetails.Data.CountyCode;
                }

                if (dashboardResponseDto.Errors.Count > 0)
            {
                return Unauthorized(dashboardResponseDto);
            }

            return Ok(dashboardResponseDto);
        }
        [HttpGet(Constants.GetAdvocateDashboardDetails)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewAdvocateDashboard)]

        public async Task<ActionResult<Result<DashboardDetailResponse>>> GetAdvocateDashboardDetails
            ([FromQuery, Required] int userId, [Required] string filterDays,
            [Required] string orderBy, string partialName, string browserDate)
        {
            _httpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
            var dashboardResponseDto = await _dashboardService.GetAdvocateDashboardDetailsList
                (userId, filterDays, orderBy, partialName, browserDate, Convert.ToInt64(tenantId));

            if (dashboardResponseDto.Errors.Count > 0)
            {
                return Unauthorized(dashboardResponseDto);
            }

            return Ok(dashboardResponseDto);
        }

        [HttpPost(Constants.GetAssessmentSummary)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HasPermission(Permissions.ViewComponentAssessmentSummary)]
        public async Task<ActionResult<Result<DashboardDetailResponse>>> GetAssessmentSummary(BasePatientAssessment basePatientAssessment)
        {
            var dashboardResponseDto = await _dashboardService.GetAssessmentSummary(basePatientAssessment);

            if (dashboardResponseDto.Errors.Count > 0)
            {
                return Unauthorized(dashboardResponseDto);
            }
            return Ok(dashboardResponseDto);
        }

        [HttpPost(Constants.GetEstimatedCostForVisit)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Result<long>> GetEstimatedCostForVisit(int patientId)
        {
            var dashboardResponseDto = _dashboardService.GetEstimatedCostForVisit(patientId);

            if (dashboardResponseDto.Errors.Count > 0)
            {
                return Unauthorized(dashboardResponseDto);
            }
            return Ok(dashboardResponseDto);
        }
    }
}