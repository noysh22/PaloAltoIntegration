using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{
    public class JobMsg
    {
        [DeserializeAs(Name = "job")]
        public int Job { get; set; }

        [DeserializeAs(Name = "line")]
        public string Msg { get; set; }
    }
}
