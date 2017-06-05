using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Siemplify.Integrations.PaloAlto.Data
{
    [XmlRoot("entry")]
    public class PaloAltoLogEntry //: PaloAltoObject
    {
        [XmlAttribute("logid")]
        public uint Id { get; set; }

        //[XmlElement("domain")]
        //public uint Domain { get; set; }

        //[XmlElement("receive_time")]
        //public DateTime ReceiveTime { get; set; }

        //[XmlElement("seqno")]
        //public uint SeqNumber { get; set; }

        //[XmlElement("type")]
        //public string Type { get; set; }

        //[XmlElement("subtype")]
        //public string SubType { get; set; }

        //[XmlElement("device_name")]
        //public string DeviceName { get; set; }

        //[XmlElement("vsys_id")]
        //public uint VSysId { get; set; }
    }
}
