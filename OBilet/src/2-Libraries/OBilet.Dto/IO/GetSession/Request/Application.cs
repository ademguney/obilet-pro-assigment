using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetSession.Request
{
    public class Application
    {
        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
