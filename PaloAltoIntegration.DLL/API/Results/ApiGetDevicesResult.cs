using System.Collections.Generic;
using System.Xml.Serialization;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    [XmlRoot("devices")]
    public class ApiGetDevicesResult
    {
        public List<PaloaltoDevice> Devices { get; set; }
    }
}
