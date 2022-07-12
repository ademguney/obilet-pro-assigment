using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetBusLocation.Response
{
    public class Datum
    {
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("tz-code")]
        public string TzCode { get; set; }

        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public string ReferenceCode { get; set; }
        public string Keywords { get; set; }
    }
}
