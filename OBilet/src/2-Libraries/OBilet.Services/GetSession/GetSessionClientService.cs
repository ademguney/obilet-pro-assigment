using Newtonsoft.Json;
using OBilet.Core.Constants;
using OBilet.Core.DummyData;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetSession.Response;
using System.Text;

namespace OBilet.Service.GetSession
{
    public class GetSessionClientService : IGetSessionClientService
    {
        private readonly IHttpHandler _client;

        public GetSessionClientService(IHttpHandler client)
        {
            _client = client;
        }

        public async Task<BaseResponse<GetSessionResponse>> GetSessionAsync()
        {
            var result = new BaseResponse<GetSessionResponse>();
            var jsonModel = JsonConvert.SerializeObject(GetSessionData.SessionRequestData());

            try
            {
                var response = await _client.PostAsync(EndPointUrl.GetSession, new StringContent(jsonModel, Encoding.UTF8, "application/json"));
                var jsonData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var map = JsonConvert.DeserializeObject<GetSessionResponse>(jsonData);
                    result.Info = ClientServiceInfo.GetSessionClientServiceInfo;
                    result.Success = true;
                    result.Result = map;
                }
                else
                {
                    result.Success = false;
                    result.Errors = jsonData;
                    result.Info = ClientServiceInfo.GetSessionClientServiceInfo;

                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Errors = ex.Message;
                result.Info = ClientServiceInfo.GetSessionClientServiceInfo;


            }
            return result;

        }
    }
}
