using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Siemplify.Integrations.PaloAlto.Data
{
    [XmlRoot("devices")]
    public class ApiGetDevicesResult
    {
        public List<PaloAltoDevice> Devices { get; set; }
    }
}
