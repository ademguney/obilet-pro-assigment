using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetSession.Response
{
    public class Data
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
        public object Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }
        public object Device { get; set; }
    }
}
