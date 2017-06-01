using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Serializers;
using Siemplify.Integrations.PaloAlto.Common;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API
{
    public class PaloaltoApiClient
    {
        private const string PaloaltoBaseApiFormat = @"https://{0}/api/";
        private const string PaloaltoApiRequestFormat = @"?type={0}&{1}";
        private const string PaloAltoApiKeyParamFormat = @"&key={0}";

        private readonly RestClient _client;
        private readonly string _apiUser;
        private readonly string _apiKey;
        private readonly string _baseHost;

        public static RestRequest CreateRestRequest(string url, Method method)
        {
            return new RestRequest(url, method) { XmlSerializer = new DotNetXmlSerializer(), RequestFormat = DataFormat.Xml};
        }

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

            var request = CreateRestRequest(requestUrl, Method.GET);

            var keyResponse = _client.Execute<ApiResponse<ApiGetKeyResult>>(request).Data;

            return keyResponse.Result.Key;
        }

        public string ExecuteApiRequest(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            var requestUrl = BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute(request).Content;

            return response;
        }

        public T ExecuteApiRequest<T>(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams) 
            where T : new()
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            var requestUrl = BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            return _client.Execute<T>(request).Data;
        }

        private static string BuildApiCmdXml(List<string> commandList)
        {
            var commandXml = new XElement(commandList.First());
            var root = commandXml;
            foreach (var cmd in commandList.Skip(1))
            {
                var nextElement = new XElement(cmd);
                root.Add(nextElement);
                root = nextElement;
            }

            return commandXml.ToString(SaveOptions.DisableFormatting);
;        }

        public static string BuildApiRequest(ApiRequestTypes type,
            params KeyValuePair<string, object>[] additionalParams)
        {
            string additionalParamsString;

            switch (type)
            {
                case ApiRequestTypes.OP:
                    additionalParamsString = string.Join("&",
                        additionalParams.Select(pair =>
                        {
                            if (pair.Key.Equals("cmd"))
                            {
                                return string.Format("{0}={1}", pair.Key, BuildApiCmdXml((List<string>) pair.Value));

                            }
                            return string.Format("{0}={1}", pair.Key, pair.Value);
                        }));
                    break;
                default:
                    additionalParamsString = string.Join("&",
                        additionalParams.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));
                    break;

            }

            var request = string.Format(PaloaltoApiRequestFormat, type.ToString().ToLower(),
                additionalParamsString);

            return request;
        }
    }
}
