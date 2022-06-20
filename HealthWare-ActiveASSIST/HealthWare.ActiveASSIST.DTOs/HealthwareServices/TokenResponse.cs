using Newtonsoft.Json;

namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class TokenResponse
    {
        [JsonProperty(Constants.AccessToken)]
        public string AccessToken { get; set; }

        [JsonProperty(Constants.TokenType)]
        public string TokenType { get; set; }

        [JsonProperty(Constants.ExpiresIn)]
        public int ExpiresIn { get; set; }
    }
}
