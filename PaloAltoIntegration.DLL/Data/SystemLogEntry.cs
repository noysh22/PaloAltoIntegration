using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public partial class Entry
    {
        [DeserializeAs(Name = "fmt")]
        public int Fmt { get; set; }

        [DeserializeAs(Name = "module")]
        public string Module { get; set; }

        [DeserializeAs(Name = "severity")]
        public string Severity { get; set; }

        [DeserializeAs(Name = "opaque")]
        public string Opaque { get; set; }
    }
}
