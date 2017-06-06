using RestSharp.Deserializers;

namespace Siemplify.Integrations.PaloAlto.Data
{
    [DeserializeAs(Name = "Key")]
    public class ApiKey
    {
        public string Key { get; set; }
    }
}
