namespace OBilet.Dto.IO.GetSession.Request
{
    public class GetSessionRequest
    {
        public int Type { get; set; }
        public Connection Connection { get; set; }
        public Application Application { get; set; }
        public Browser Browser { get; set; }
    }
}
