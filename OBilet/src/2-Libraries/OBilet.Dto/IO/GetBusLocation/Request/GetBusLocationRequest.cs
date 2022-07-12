using Newtonsoft.Json;
using OBilet.Dto.IO.Common;

namespace OBilet.Dto.IO.GetBusLocation.Request
{
    public class GetBusLocationRequest
    {
        public object Data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }

    }
}
