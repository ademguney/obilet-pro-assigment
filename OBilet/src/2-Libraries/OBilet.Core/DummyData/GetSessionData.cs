using OBilet.Core.Utility;
using OBilet.Dto.IO.GetSession.Request;

namespace OBilet.Core.DummyData
{
    public static class GetSessionData
    {
        
        public static  GetSessionRequest SessionRequestData()
        {
            var data = new GetSessionRequest
            {
                Type = 7,
                Connection = new Connection { IpAddress = NetworkUtil.GetIP(), Port = "5117" },
                Application = new Application { Version = "1.0.0.0", EquipmentId = "distribusion" },
                Browser = new Browser { Name = "Chrome", Version = "47.0.0.12" }
            };
            return data;
        }
    }
}
