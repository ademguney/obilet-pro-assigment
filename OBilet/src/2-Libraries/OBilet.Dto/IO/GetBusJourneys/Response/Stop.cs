using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetBusJourneys.Response
{
    public class Stop
    {
        public string Name { get; set; }
        public string Station { get; set; }
        public DateTime Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
