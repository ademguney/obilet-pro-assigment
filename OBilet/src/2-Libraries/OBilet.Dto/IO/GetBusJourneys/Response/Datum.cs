using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet.Dto.IO.GetBusJourneys.Response
{
    public class Datum
    {
        public int Id { get; set; }

        [JsonProperty("partner-id")]
        public int PartnerId { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("route-id")]
        public int RouteId { get; set; }

        [JsonProperty("bus-type")]
        public string BusType { get; set; }

        [JsonProperty("total-seats")]
        public int TotalSeats { get; set; }

        [JsonProperty("available-seats")]
        public int AvailableSeats { get; set; }
        public Journey Journey { get; set; }
        public List<Feature> Features { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("is-active")]
        public bool IsActive { get; set; }

        [JsonProperty("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonProperty("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("cancellation-offset")]
        public int CancellationOffset { get; set; }

        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonProperty("display-offset")]
        public object DisplayOffset { get; set; }

        [JsonProperty("partner-rating")]
        public double PartnerRating { get; set; }
    }
}
