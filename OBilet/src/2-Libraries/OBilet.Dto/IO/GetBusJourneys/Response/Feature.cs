using Newtonsoft.Json;

namespace OBilet.Dto.IO.GetBusJourneys.Response
{
    public class Feature
    {
        public int Id { get; set; }
        public int? Priority { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("back-color")]
        public object BackColor { get; set; }

        [JsonProperty("fore-color")]
        public object ForeColor { get; set; }
    }
}
