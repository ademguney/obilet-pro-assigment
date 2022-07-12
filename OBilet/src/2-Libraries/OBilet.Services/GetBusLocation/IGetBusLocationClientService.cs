using OBilet.Core.Response;
using OBilet.Dto.IO.GetBusLocation.Request;
using OBilet.Dto.IO.GetBusLocation.Response;

namespace OBilet.Service.GetBusLocation
{
    public interface IGetBusLocationClientService
    {
        Task<BaseResponse<GetBusLocationResponse>> GetBusLocationAsync(GetBusLocationRequest request);
    }
}
