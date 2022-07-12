using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetSession.Response
{
    public class GetSessionResponse
    {
        public string Status { get; set; }
        public Data Data { get; set; }
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }
        public object Controller { get; set; }

        [JsonProperty("client-request-id")]
        public object ClientRequestId { get; set; }
    }
}
