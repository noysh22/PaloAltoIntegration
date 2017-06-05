using System.Xml.Serialization;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    public class ApiGetKeyResult : ApiResult
    {
        [XmlElement("key")]
        public string Key { get; set; }
    }
}
