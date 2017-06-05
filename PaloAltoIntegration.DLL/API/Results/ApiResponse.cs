using System.Xml.Serialization;

namespace Siemplify.Integrations.PaloAlto.API.Results
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
