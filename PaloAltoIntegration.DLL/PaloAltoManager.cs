
using RestSharp;

namespace Siemplify.Integrations.PaloAlto
{
    public class PaloAltoManager
    {
        private readonly RestClient _client;
        private readonly string _apiUser;
        private readonly string _apiKey;

        public PaloAltoManager(string apiHost, string apiUser, string apiKey)
        {
            _client = new RestClient(apiHost);

            _apiKey = apiKey;
            _apiUser = apiUser;


        }
    }
}
