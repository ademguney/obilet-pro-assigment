using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetSession.Request
{
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }
}
