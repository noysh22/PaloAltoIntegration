using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using Siemplify.Integrations.PaloAlto.Data;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public partial class Entry
    {
        [DeserializeAs(Name = "host")]
        public string Host { get; set; }

        [DeserializeAs(Name = "cmd")]
        public string Cmd { get; set; }

        [DeserializeAs(Name = "admin")]
        public string Admin { get; set; }

        [DeserializeAs(Name = "client")]
        public string Client { get; set; }

        [DeserializeAs(Name = "result")]
        public string Result { get; set; }

        [DeserializeAs(Name = "path")]
        public string Path { get; set; }

    }
}
