using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.SqlServer.Server;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    public class ApiAsyncRawResult
    {
        [XmlElement("result")]
        public JobDetails Result { get; set; }

        [XmlIgnore]
        public string RawJobResult { get; set; }
    }
}
