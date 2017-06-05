using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.API.Results
{
    [XmlRoot("result")]
    public class ApiGetLogAsyncResult
    {
        public PaloaltoJob Job { get; set; }

        //[XmlElement("log")]
        //public LogContainer LogContainer { get; set; }

        [XmlArrayItem(ElementName = "entry", Type = typeof(PaloAltoLogEntry))]
        [XmlArray("logs")]
        public PaloAltoLogEntry[] LogEntries { get; set; }
        //public string LogContainer { get; set; }
    }

    //[XmlRoot("log")]
    //public class ApiGetLogAsyncResult
    //{
    //    [XmlElement("logs")]
    //    public List<PaloAltoLogEntry> LogEntries { get; set; }
    //}
}
