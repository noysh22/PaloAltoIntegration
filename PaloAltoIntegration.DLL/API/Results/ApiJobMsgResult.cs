using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;
using Siemplify.Common.Model;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    [XmlRoot("response")]
    public class ApiJobMsgResult : ApiResult
    {
        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlIgnore]
        public bool IsSuccess => Status.Equals("success");

        [XmlElement("result")]
        public JobDetails Result { get; set; }
    }

    public class JobDetails
    {
        [XmlElement("job")]
        public int Job { get; set; }
    }
}
