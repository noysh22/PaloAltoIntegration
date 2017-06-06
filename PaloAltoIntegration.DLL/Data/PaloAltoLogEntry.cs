using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public partial class Entry
    {
        //[XmlAttribute("logid")]
        [DeserializeAs(Name = "logid", Attribute = true)]
        public uint Id { get; set; }

        [DeserializeAs(Name = "domain")]
        public uint Domain { get; set; }

        [DeserializeAs(Name = "receive_time")]
        public DateTime ReceiveTime { get; set; }

        [DeserializeAs(Name = "time_generated")]
        public DateTime GenerateTime { get; set; }

        [DeserializeAs(Name = "seqno")]
        public uint SeqNumber { get; set; }

        [DeserializeAs(Name = "type")]
        public string Type { get; set; }

        [DeserializeAs(Name = "subtype")]
        public string SubType { get; set; }

        [DeserializeAs(Name = "device_name")]
        public string DeviceName { get; set; }

        [DeserializeAs(Name = "vsys_id")]
        public uint VSysId { get; set; }
    }
}
