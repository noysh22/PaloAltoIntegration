using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemplify.Integrations.PaloAlto.API;
using Siemplify.Integrations.PaloAlto.API.Results;
using Siemplify.Integrations.PaloAlto.Common;
using Siemplify.Integrations.PaloAlto.Data;

namespace PaloAltoIntegration.EXE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Debugger.Break();
            //Console.ReadLine();

            const string HOST = "CHANGEHERE";
            const string USER = "CHANGEHERE";
            const string PASS = "CHANGEHERE";

            var apiClient = new PaloaltoApiClient(HOST, USER, PASS);

            //var command = PaloaltoApiClient.BuildApiRequest(ApiRequestTypes.OP, "cmd".PairWith(new List<string> {"show", "admins", "all"}));

            //var response = apiClient.ExecuteApiRequest(ApiRequestTypes.OP,
            //    "cmd".PairWith(new List<string> {"show", "admins", "all"}));

            //var response = apiClient.ExecuteApiRequest(ApiRequestTypes.OP,
            //    "cmd".PairWith(new List<string> { "show", "devices", "connected" }));

            var response = apiClient.ExecuteApiRequest<ApiGetDevicesResult>(ApiRequestTypes.OP,
                "cmd".PairWith(new List<string> { "show", "devices", "all" }));

            //var jobResponse = apiClient.StartApiJob(ApiRequestTypes.LOG, "log-type".PairWith("system"));

            //var jobResult = apiClient.GetAsyncJobResult<ApiGetLogAsyncResult>(ApiRequestTypes.LOG, "action".PairWith("get"),
            //    "job-id".PairWith(jobResponse.Job));

            //Console.WriteLine(jobResult.EntriesList.LogEntries.Count);

            Console.WriteLine(response);
        }
    }
}
