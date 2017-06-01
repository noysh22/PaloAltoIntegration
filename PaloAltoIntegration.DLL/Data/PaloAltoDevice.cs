using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Siemplify.Integrations.PaloAlto.Common;

namespace Siemplify.Integrations.PaloAlto.Data
{
    [XmlRoot("entry")]
    public class PaloAltoDevice
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("serial")]
        public long Serial { get; set; }

        [XmlElement("connected")]
        public string IsConnectedStr { get; set; }

        //[XmlIgnore]
        //public bool IsConnected => IsConnectedStr.Equals("yes");

        [XmlElement("deactivated")]
        public string IsDeactivatedStr { get; set; }

        //[XmlIgnore]
        //public bool IsDeactivated => IsDeactivatedStr.Equals("yes");

        [XmlElement("hostname")]
        public string Hostname { get; set; }

        [XmlElement("ip-address")]
        public string IpAddress { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }
    }
}
