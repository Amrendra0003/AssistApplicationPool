using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace HealthWare.ActiveASSIST.Web.Common.HttpClient
{
    public interface IHttpClientService
    {

        Task<CityStateRoot> GetCityState(string zipcode);
        Task<QuickAssessmentSelfResponse> GetSelfDetails(long userId);
        bool ValidatePolicyNumber(string policyNumber);
        AdvocatePatient GetAdvocatePatients();
        Task<IEnumerable<Entities.Program>> GetPrograms();
        Task<string> ContentRootPath();
        PatientProgramResponse GetProgramsResponse(bool isEvaluated);
        Task<byte[]> FetchDocumentFromURLAsync(string url, string documentName);
    }
    public class HttpClientService : IHttpClientService
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly IUserRepository _userRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProgramRepository _programRepository;
        public HttpClientService(System.Net.Http.HttpClient client,
            IUserRepository userRepository, IHostingEnvironment hostingEnvironment, IProgramRepository programRepository)
        {
            _client = client;
            _userRepository = userRepository;
            _hostingEnvironment = hostingEnvironment;
            _programRepository = programRepository;

        }

        public async Task<CityStateRoot> GetCityState(string zipcode)
        {
            var apiResponse = await _client.GetAsync("https://api.zippopotam.us/us/" + zipcode);
            if (!apiResponse.IsSuccessStatusCode)
            {
                return null;
            }
            var responseStream = await apiResponse.Content.ReadAsStreamAsync();

            var responseString = string.Empty;
            using (var stream = responseStream)
            {
                var reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }

            var content = JsonConvert.DeserializeObject<CityStateRoot>(responseString);
            return content;
        }

        public async Task<QuickAssessmentSelfResponse> GetSelfDetails(long userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var quickAssessmentSelfResponse = new QuickAssessmentSelfResponse
            {
                Citizenship = "U.S. Citizen",
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                Gender = user.Gender,
                MaritalStatus = user.MaritalStatus,
                Email = user.EmailAddress,
                Cell = user.Cell,
                SSN = user.SSNNumber
            };
            return quickAssessmentSelfResponse;
        }

        public bool ValidatePolicyNumber(string policyNumber)
        {
            if (Convert.ToInt64(policyNumber) % 2 == 0)
            {
                return true;
            }

            return false;
        }

        public AdvocatePatient GetAdvocatePatients()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var json = File.ReadAllText(String.Concat(contentRootPath, Constants.WebRootPath, "/Advocate_Patient.json"));
            var advocatePatients = JsonConvert.DeserializeObject<AdvocatePatient>(json);
            return advocatePatients;
        }
        public async Task<string> ContentRootPath()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var filePath = String.Concat(contentRootPath, Constants.WebRootPath, "/Images/DefaultImage.png");
            return filePath;
        }
        public async Task<IEnumerable<Entities.Program>> GetPrograms()
        {
            var programs = await _programRepository.GetAllPrograms();
            return programs;
        }
        public PatientProgramResponse GetProgramsResponse(bool isEvaluated)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var json = "";
            if (isEvaluated)
            {
                json = File.ReadAllText(String.Concat(contentRootPath, Constants.WebRootPath, "/Evaluatedprogram.json"));
            }
            else
            {
                json = File.ReadAllText(String.Concat(contentRootPath, Constants.WebRootPath, "/program.json"));
            }
            var advocatePatients = JsonConvert.DeserializeObject<PatientProgramResponse>(json);
            return advocatePatients;
        }

        public async Task<byte[]> FetchDocumentFromURLAsync(string url, string documentName)
        {
            try
            {
                var response = await _client.GetAsync(@url);

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            await stream.CopyToAsync(ms);
                            return ms.ToArray();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(ex);
                return default;
            }
        }
    }
}
