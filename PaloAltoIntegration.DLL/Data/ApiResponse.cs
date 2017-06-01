using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{
    [XmlRoot("response")]
    public class ApiResponse<T> where T : ApiResult
    {
        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlIgnore]
        public bool IsSuccess => Status.Equals("success");

        [XmlElement("result")]
        public T Result { get; set; }
    }

    public abstract class ApiResult { }
}
