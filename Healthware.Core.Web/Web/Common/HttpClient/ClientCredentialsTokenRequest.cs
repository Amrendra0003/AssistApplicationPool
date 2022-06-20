using System;
using System.Collections.Generic;
using RestSharp;

namespace Healthware.Core.Web.Web.Common.HttpClient
{
    public class ClientCredentialsTokenRequest
    {
        public string Address { get; }
        public DateTime ExpirationTime { get; set; }

        public string Token { get; set; }

        public readonly IDictionary<string, string> Params;

        public ClientCredentialsTokenRequest(string baseUrl, string address, string userName, string apiKey,
            string secretKey, string grantType)
        {
            Params = new Dictionary<string, string>();
            Address = baseUrl + address;
            Params.Add(Constants.UserName, userName);
            Params.Add(Constants.Password, apiKey);
            Params.Add(Constants.GrantType, grantType);
            Params.Add(Constants.SiteId, secretKey);
        }

        public RestRequest GetHealthWareServiceTokenRequest()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader(Constants.ContentType, Constants.ContentFormat);
            request.AddParameter(Constants.UserName, Params[Constants.UserName]);
            request.AddParameter(Constants.Password, Params[Constants.Password]);
            request.AddParameter(Constants.GrantType, Params[Constants.GrantType]);
            request.AddParameter(Constants.SiteId, Params[Constants.SiteId]);

            return request;
        }
    }
}