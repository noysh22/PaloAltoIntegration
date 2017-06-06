using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{

    public enum JobStatus
    {
        [XmlEnum("FIN")] FIN = 0x1
    }

    [DeserializeAs(Name = "job")]
    public class PaloaltoJob
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "status")]
        public JobStatus Status { get; set; }
    }
}
