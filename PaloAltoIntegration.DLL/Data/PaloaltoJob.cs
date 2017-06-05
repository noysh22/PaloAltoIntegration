using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Siemplify.Integrations.PaloAlto.Data
{

    public enum JobStatus
    {
        [XmlEnum("FIN")] FIN = 0x1
    }

    [XmlRoot("job")]
    public class PaloaltoJob
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("status")]
        public JobStatus Status { get; set; }
    }
}
