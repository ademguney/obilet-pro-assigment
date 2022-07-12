using OBilet.Dto.Model;

namespace OBilet.Dto.ViewModel
{
    public class HomeViewModel
    {
        public List<BusLocationList> BusLocationList { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public string Errors { get; set; }

    }
}
