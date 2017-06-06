using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Serializers;
using Siemplify.Common.Extensions;
using Siemplify.Integrations.PaloAlto.API.Results;
using Siemplify.Integrations.PaloAlto.Common;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API
{
    public class PaloaltoApiClient
    {
        private const string PaloaltoBaseApiFormat = @"https://{0}/api/";
        private const string PaloAltoApiKeyParamFormat = @"&key={0}";
        private const string JobIdKey = "job-id";
        private const string ActionKey = "action";
        private const string GetActionValue = "get";

        private readonly RestClient _client;
        private readonly string _apiUser;
        private readonly string _apiKey;
        private readonly string _baseHost;

        public static RestRequest CreateRestRequest(string url, Method method)
        {
            return new RestRequest(url, method) {RequestFormat = DataFormat.Xml};
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
            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(ApiRequestTypes.KEYGEN,
                "user".PairWith(_apiUser), "password".PairWith(pass));

            var request = CreateRestRequest(requestUrl, Method.GET);

            var keyResponse = _client.Execute<ApiKey>(request);

            return keyResponse.Data.Key;
        }

        public string ExecuteApiRequest(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl), response.ErrorException);
            }

            return response.Content;
        }

        public T ExecuteApiRequest<T>(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams) 
            where T : new()
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute<T>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl), response.ErrorException);
            }

            return response.Data;
        }

        //public ApiJobMsgData StartApiJob(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
        //{
        //    if (string.IsNullOrEmpty(_apiKey))
        //    {
        //        throw new PaloAltoApiException("Cannot execute an api request without an api Key");
        //    }

        //    var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

        //    if (ApiRequestTypes.KEYGEN != type)
        //    {
        //        requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
        //    }

        //    var request = CreateRestRequest(requestUrl, Method.GET);

        //    var response = _client.Execute<ApiJobMsgData>(request);

        //    if (response.StatusCode != HttpStatusCode.OK)
        //    {
        //        throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl),
        //            response.ErrorException);
        //    }

        //    return response.Data;
        //}

        public JobMsg StartApiJob(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute<JobMsg>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl),
                    response.ErrorException);
            }

            return response.Data;
        }

        public ApiAsyncRawResult GetAsyncJobResult(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            // Check params contain job-id and action=get keys
            if (!additionalParams.Any(pair => pair.Key.Equals(JobIdKey))
                && !additionalParams.Any(pair => pair.Key.Equals(ActionKey) && pair.Value.Equals(GetActionValue)))
            {
                throw new PaloAltoApiException(
                    string.Format("Get job result must contains the key-value pair {0}:{1} and key {2}",
                        ActionKey, GetActionValue, JobIdKey));
            }

            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute<ApiAsyncRawResult>(request);
    
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl),
                    response.ErrorException);
            }

            response.Data.RawJobResult = response.Content;

            return response.Data;
        }

        public T GetAsyncJobResult<T>(ApiRequestTypes type, params KeyValuePair<string, object>[] additionalParams)
            where T : new()
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new PaloAltoApiException("Cannot execute an api request without an api key");
            }

            // Check params contain job-id and action=get keys
            if (!additionalParams.Any(pair => pair.Key.Equals(JobIdKey))
                && !additionalParams.Any(pair => pair.Key.Equals(ActionKey) && pair.Value.Equals(GetActionValue)))
            {
                throw new PaloAltoApiException(
                    string.Format("Get job result must contains the key-value pair {0}:{1} and key {2}",
                        ActionKey, GetActionValue, JobIdKey));
            }

            var requestUrl = PaloAltoApiUrlBuilder.BuildApiRequest(type, additionalParams);

            if (ApiRequestTypes.KEYGEN != type)
            {
                requestUrl += string.Format(PaloAltoApiKeyParamFormat, _apiKey);
            }

            var request = CreateRestRequest(requestUrl, Method.GET);

            var response = _client.Execute<T>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new PaloAltoApiException(string.Format("Failed executing api request: {0}", requestUrl),
                    response.ErrorException);
            }

            return response.Data;
        }
    }
}
