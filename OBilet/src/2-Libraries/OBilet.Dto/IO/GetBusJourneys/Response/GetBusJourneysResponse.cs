using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetBusJourneys.Response
{
    public class GetBusJourneysResponse
    {
        public string Status { get; set; }
        public List<Datum> Data { get; set; }
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }
        public string Controller { get; set; }
    }
}
