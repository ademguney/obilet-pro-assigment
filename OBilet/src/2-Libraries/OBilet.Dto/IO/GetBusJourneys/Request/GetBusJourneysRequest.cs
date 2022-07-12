using Newtonsoft.Json;
using OBilet.Dto.IO.Common;

namespace OBilet.Dto.IO.GetBusJourneys.Request
{
    public class GetBusJourneysRequest
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
        public Data Data { get; set; }        
    }
}