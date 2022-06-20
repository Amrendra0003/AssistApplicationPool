using CsvHelper;
using CsvHelper.Configuration;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using HealthWare.ActiveASSIST.Web.Controllers;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TenantController : BaseApiController
    {
        private readonly IUserManagementService _userManagementService;
        private HttpContext _httpContext;
        public TenantController(IUserManagementService userManagementService, IHttpContextAccessor httpContextAccessor)
        {
            _userManagementService = userManagementService;
            _httpContext = httpContextAccessor.HttpContext;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMultipleUsersTask(IFormFile sourceFile)
        {
            _httpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
            if (!sourceFile.FileName.EndsWith(".csv")) return BadRequest(new Result() { Data = null }.AddError("Only Csv files are allowed"));
            List<PatientEntity> bulkList;
            await using (var memoryStream = new MemoryStream())
            {
                await sourceFile.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                TextReader textReader = new StreamReader(memoryStream);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
                var csv = new CsvReader(textReader, config);

                bulkList = csv.GetRecords<PatientEntity>().Where(x => !(x.EmailAddress.IsNullOrWhiteSpace() && (x.CountyCode.IsNullOrWhiteSpace() || x.Cell.IsNullOrWhiteSpace()))).ToList();
                

                
                bulkList.ForEach(a=>a.TenantId = tenantId);
            }
            
            int count = 0;
            ICollection<ValidationResult> results = null;
            var bulkListValidated =  _userManagementService.ValidateCsv(bulkList);
          
            foreach (var patient in bulkListValidated)
            {
                if (!Validate(patient, out results) || await _userManagementService.CheckIfPatientExists(patient.EmailAddress))
                {
                    continue;
                }

                //Create Patient
                _ = await _userManagementService.CreatePatient(patient);
                var user = JsonConvert.DeserializeObject<BulkUserUpload>(JsonConvert.SerializeObject(patient));
                _ =await _userManagementService.CreateUser(user);
                count++;
            }

            static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
            {
                results = new List<ValidationResult>();

                return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
            }

            return Ok($"{count} records were successfully inserted");

        }

    }
}