using Healthware.Core.Logging;
using Healthware.Core.Utility;
using Healthware.Core.Web.Web.Common.HttpClient;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs.HealthWareServices;

namespace HealthWare.ActiveASSIST.Web.Common.HttpClient
{
    public interface IHealthWareSharedService
    {
        Task<AddressVerificationResponse> VerifyAddress(AddressVerificationRequest addressDetails);
        Task<PatientProgramResponse> GetPatientProgram(PatientProgramRequest patientAssessmentDetails);
    }

    public class HealthWareSharedService : IHealthWareSharedService
    {
        private readonly RestClient _client;
        private readonly ClientCredentialsTokenRequest _tokenRequest;

        public HealthWareSharedService(ClientCredentialsTokenRequest tokenRequest)
        {
            _tokenRequest = tokenRequest;

            _client = new RestClient
            {
                BaseUrl = new Uri(Constants.HealthWareBaseApiUrl)
            };
        }

        public async Task<AddressVerificationResponse> VerifyAddress(AddressVerificationRequest addressDetails)
        {
            this.Log().Informational(Constants.LogEnteringInformation, Constants.VerifyAddress);
            addressDetails.ClientName = Constants.ClientName;

            var token = await RequestClientCredentialsTokenAsync();
            if(token == null)
            {
                return null;
            }

            _client.BaseUrl = new Uri(Constants.HealthWareBaseApiUrl + Constants.CassApiPath);

            var address = JsonConvert.SerializeObject(addressDetails);
            var requestContent = CreateHwsRequest(Method.POST, token, address);
            var addressResponse = await _client.ExecuteAsync(requestContent);

            if (!addressResponse.IsSuccessful)
                throw new TimeoutException(string.Format(Constants.ServiceCallError, Constants.VerifyAddress),
                    addressResponse.ErrorException);

            var result = JsonConvert.DeserializeObject<AddressVerificationResponse>(addressResponse.Content);
            this.Log().Informational(Constants.LogExitingInformation, Constants.VerifyAddress);
            return result;
        }

        public async Task<PatientProgramResponse> GetPatientProgram(PatientProgramRequest patientAssessmentDetails)
        {
            this.Log().Informational(Constants.LogEnteringInformation, Constants.GetPatientProgram);
            var token = await RequestClientCredentialsTokenAsync();

            _client.BaseUrl = new Uri(Constants.HealthWareBaseApiUrl + Constants.FindProgramApiPath);

            var patientAssessmentRequest = JsonConvert.SerializeObject(patientAssessmentDetails);

            var requestContent = CreateHwsRequest(Method.POST, token, patientAssessmentRequest);

            var programResponse = await _client.ExecuteAsync(requestContent);

            if (!programResponse.IsSuccessful)
                throw new TimeoutException(string.Format(Constants.ServiceCallError, Constants.GetPatientProgram),
                    programResponse.ErrorException);

            var result = JsonConvert.DeserializeObject<PatientProgramResponse>(programResponse.Content);
            this.Log().Informational(Constants.LogExitingInformation, Constants.GetPatientProgram);
            return result;
        }

        private async Task<string> RequestClientCredentialsTokenAsync()
        {
            try
            {
                this.Log().Informational(Constants.LogEnteringInformation, Constants.RequestClientCredentialsTokenAsync);
                _client.BaseUrl = new Uri(_tokenRequest.Address);
                if (_tokenRequest.ExpirationTime > Clock.Now())
                    return _tokenRequest.Token;
                var response = await _client.ExecuteAsync(_tokenRequest.GetHealthWareServiceTokenRequest());
                if (!response.IsSuccessful)
                {
                    return null;
                }

                var content = JsonConvert.DeserializeObject<TokenResponse>(response.Content);

                //set buffer of 100 seconds
                //_tokenRequest.ExpirationTime = Clock.Now().AddSeconds(content.ExpiresIn - 100);
                //set to 60 seconds since token is getting invalid within expiration time
                _tokenRequest.ExpirationTime = Clock.Now().AddSeconds(5);
                _tokenRequest.Token = content.AccessToken;
                this.Log().Informational(Constants.LogExitingInformation,
                    Constants.RequestClientCredentialsTokenAsync);
                return content.AccessToken;
            }
            catch (Exception exe)
            {
                this.Log().Informational(exe.Message);
                throw exe;
            }
        }

        private RestRequest CreateHwsRequest(Method methodType, string token, string requestBody)
        {
            this.Log().Informational(Constants.LogEnteringInformation, Constants.CreateHwsRequest);
            var request = new RestRequest(methodType);
            request.AddHeader(Constants.Authorization, string.Format(Constants.BearerToken, token));
            request.AddHeader(Constants.ContentType, Constants.Application);
            request.AddParameter(Constants.Application, requestBody, ParameterType.RequestBody);
            this.Log().Informational(Constants.LogExitingInformation, Constants.CreateHwsRequest);
            return request;
        }
    }
}
