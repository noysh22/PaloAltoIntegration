using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public class ApiGetKeyResult : ApiResult
    {
        [XmlElement("key")]
        public string Key { get; set; }
    }
}
