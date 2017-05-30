using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemplify.Integrations.PaloAlto.API;

namespace PaloAltoIntegration.EXE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Debugger.Break();
            var apiClient = new PaloaltoApiClient("CHANGEHERE", "CHANGEHERE", "CHANGEHERE");
            Console.WriteLine(ApiRequestTypes.COMMIT.ToString().ToLower());
        }
    }
}
