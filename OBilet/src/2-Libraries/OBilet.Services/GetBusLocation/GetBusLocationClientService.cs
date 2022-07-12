using Newtonsoft.Json;
using OBilet.Core.Cache;
using OBilet.Core.Constants;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetBusLocation.Request;
using OBilet.Dto.IO.GetBusLocation.Response;
using OBilet.Dto.Model;
using System.Text;

namespace OBilet.Service.GetBusLocation
{
    public class GetBusLocationClientService : IGetBusLocationClientService
    {
        private readonly IMemoryCacheService _memoryCacheService;
        private readonly IHttpHandler _client;
        public GetBusLocationClientService(IMemoryCacheService memoryCacheService, IHttpHandler client)
        {
            _memoryCacheService = memoryCacheService;
            _client = client;
        }
        public async Task<BaseResponse<GetBusLocationResponse>> GetBusLocationAsync(GetBusLocationRequest request)
        {
            var result = new BaseResponse<GetBusLocationResponse>();
            var jsonModel = JsonConvert.SerializeObject(request);

            var userLastJourneyExist = await _memoryCacheService.GetAsync<UserSelectLastJourney>(CacheKeys.UserSelectLastJourneyKey);
            var getBusLocationExist = await _memoryCacheService.GetAsync<BaseResponse<GetBusLocationResponse>>(CacheKeys.GetBusLocationCacheKey);

            if (getBusLocationExist != null)
            {
                if (userLastJourneyExist != null)
                {
                    getBusLocationExist.Result.OriginId = userLastJourneyExist.OriginId;
                    getBusLocationExist.Result.DestinationId = userLastJourneyExist.DestinationId;
                    return getBusLocationExist;
                }
                return getBusLocationExist;
            }

            try
            {
                var response = await _client.PostAsync(EndPointUrl.GetBusLocations, new StringContent(jsonModel, Encoding.UTF8, "application/json"));
                var jsonData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var map = JsonConvert.DeserializeObject<GetBusLocationResponse>(jsonData);
                    result.Info = ClientServiceInfo.GetBusLocationClientServiceInfo;
                    result.Success = true;
                    result.Result = map;
                    _memoryCacheService.Set<BaseResponse<GetBusLocationResponse>>(CacheKeys.GetBusLocationCacheKey, result);
                }
                else
                {
                    result.Success = false;
                    result.Errors = jsonData;
                    result.Info = ClientServiceInfo.GetBusLocationClientServiceInfo;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Errors = ex.Message;
                result.Info = ClientServiceInfo.GetBusLocationClientServiceInfo;
            }
            return result;
        }
    }
}
