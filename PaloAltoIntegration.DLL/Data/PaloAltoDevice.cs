using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;
using Siemplify.Integrations.PaloAlto.Common;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public class PaloaltoDevice
    {
        public string Name { get; set; }

        public long Serial { get; set; }

        [DeserializeAs(Name = "connected")]
        public string IsConnectedStr { get; set; }

        [XmlIgnore]
        public bool IsConnected => IsConnectedStr.Equals("yes");

        [DeserializeAs(Name = "deactivated")]
        public string IsDeactivatedStr { get; set; }

        [XmlIgnore]
        public bool IsDeactivated => IsDeactivatedStr.Equals("yes");

        [XmlElement("hostname")]
        public string Hostname { get; set; }

        [XmlElement("ip-address")]
        public string IpAddress { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }
    }
}
