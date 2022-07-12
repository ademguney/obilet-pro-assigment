using Newtonsoft.Json;
using OBilet.Core.Cache;
using OBilet.Core.Constants;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetBusJourneys.Request;
using OBilet.Dto.IO.GetBusJourneys.Response;
using OBilet.Dto.Model;
using System.Text;

namespace OBilet.Service.GetBusJourneys
{
    public class GetBusJourneysClientService : IGetBusJourneysClientService
    {
        private readonly IMemoryCacheService _memoryCacheService;
        private readonly IHttpHandler _client;
        public GetBusJourneysClientService(IMemoryCacheService memoryCacheService, IHttpHandler client)
        {
            _memoryCacheService = memoryCacheService;
            _client = client;
        }

        public async Task<BaseResponse<GetBusJourneysResponse>> GetBusJourneysAsync(GetBusJourneysRequest request)
        {
            var result = new BaseResponse<GetBusJourneysResponse>();
            var jsonModel = JsonConvert.SerializeObject(request);

            try
            {
                var response = await _client.PostAsync(EndPointUrl.GetBusJourneys, new StringContent(jsonModel, Encoding.UTF8, "application/json"));
                var jsonData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var map = JsonConvert.DeserializeObject<GetBusJourneysResponse>(jsonData);
                    result.Info = ClientServiceInfo.GetBusJourneysClientServiceInfo;
                    result.Success = true;
                    result.Result = map;
                }
                else
                {
                    result.Success = false;
                    result.Errors = jsonData;
                    result.Info = ClientServiceInfo.GetBusJourneysClientServiceInfo;
                }

                var userSelectJourney = new UserSelectLastJourney { DestinationId = request.Data.DestinationId, OriginId = request.Data.OriginId };
                _memoryCacheService.Set<UserSelectLastJourney>(CacheKeys.UserSelectLastJourneyKey, userSelectJourney);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Errors = ex.Message;
                result.Info = ClientServiceInfo.GetBusJourneysClientServiceInfo;
            }
            return result;
        }
    }
}
