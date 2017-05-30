using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Siemplify.Integrations.PaloAlto.Common;

namespace Siemplify.Integrations.PaloAlto.API
{
    public class PaloaltoApiClient
    {
        private const string PaloaltoBaseApiFormat = @"https://{0}/api/";
        private const string PaloaltoApiRequestFormat = @"?type={0}&{1}";

        private readonly RestClient _client;
        private readonly string _apiUser;
        private readonly string _apiKey;
        private readonly string _baseHost;

        public PaloaltoApiClient(string paloaltoHost, string username, string pass, bool ignoreSsl = true)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);

            _baseHost = string.Format(PaloaltoBaseApiFormat, paloaltoHost);
            _apiUser = username;

            _client = new RestClient(_baseHost);

            _apiKey = GetApiKey(pass);
            
        }

        private string GetApiKey(string pass)
        {
            var requestUrl = BuildApiRequest(ApiRequestTypes.KEYGEN,
                "user".PairWith(_apiUser), "password".PairWith(pass));

            var request = new RestRequest(requestUrl, Method.GET);

            var key = _client.Execute(request);

            return key.ToString();
        }

        public static string BuildApiRequest(ApiRequestTypes type,
            params KeyValuePair<string, string>[] additionalParams)
        {
            var additionalParamsString = string.Join("&",
                additionalParams.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));

            var request = string.Format(PaloaltoApiRequestFormat, type.ToString().ToLower(),
                additionalParamsString);

            return request;
        }
    }
}
