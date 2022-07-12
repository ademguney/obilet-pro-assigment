using OBilet.Core.Response;
using OBilet.Dto.IO.GetBusJourneys.Request;
using OBilet.Dto.IO.GetBusJourneys.Response;

namespace OBilet.Service.GetBusJourneys
{
    public interface IGetBusJourneysClientService
    {
        Task<BaseResponse<GetBusJourneysResponse>> GetBusJourneysAsync(GetBusJourneysRequest request);
    }
}
