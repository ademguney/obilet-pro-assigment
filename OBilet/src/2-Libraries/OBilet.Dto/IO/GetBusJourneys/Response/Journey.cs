using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetBusJourneys.Response
{
    public class Journey
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public List<Stop> Stop { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }
        public object Booking { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }
        public Policy Policy { get; set; }
        public List<string> Features { get; set; }
        public object Description { get; set; }
        public object Available { get; set; }
    }
}
