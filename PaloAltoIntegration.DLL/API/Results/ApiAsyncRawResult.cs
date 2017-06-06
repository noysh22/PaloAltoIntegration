using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.SqlServer.Server;
using RestSharp.Deserializers;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    public class ApiAsyncRawResult
    {
        [DeserializeAs(Name = "result")]
        public PaloaltoJob Job { get; set; }

        [XmlIgnore]
        public string RawJobResult { get; set; }
    }
}
