using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    public class ApiGetLogAsyncResult
    {
        public PaloaltoJob Job { get; set; }

        [DeserializeAs(Name = "logs")]
        public LogEntriesList EntriesList { get; set; }
    }

    public class LogEntriesList
    {
        public List<Entry> LogEntries { get; set; }
    }
}
