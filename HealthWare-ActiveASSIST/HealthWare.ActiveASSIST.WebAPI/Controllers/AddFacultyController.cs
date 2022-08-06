using CsvHelper;
using CsvHelper.Configuration;
using Healthware.Core.DTO;
using HealthWare.ActiveASSIST.DTOs;
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
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AddFacultyController : Controller
    {
        private readonly IFacultyManagementService _facultyManagementService;

        public AddFacultyController(IFacultyManagementService facultyManagementService)
        {
            _facultyManagementService = facultyManagementService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMultipleFacultyTask(IFormFile sourceFile)
        {
            if (!sourceFile.FileName.EndsWith(".csv")) return BadRequest(new Result() { Data = null }.AddError("Only Csv files are allowed"));
            List<FacultyEntity> bulkList;
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

                bulkList = csv.GetRecords<FacultyEntity>().ToList();
            }

            int count = 0;
            ICollection<ValidationResult> results = null;
            var bulkListValidated = _facultyManagementService.ValidateCsv(bulkList);
            foreach (var faculty in bulkListValidated)
            {
                if (await _facultyManagementService.CheckIfFacultyExists(faculty.FacilityName, faculty.FacilityCode))
                {
                    continue;
                }

                //Create faculty
                _ = await _facultyManagementService.CreateFaculty(faculty);
                count++;
            }
            return Ok($"{count} records were successfully inserted");
        }
    }
}
