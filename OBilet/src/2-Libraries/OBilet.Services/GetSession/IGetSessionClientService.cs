using OBilet.Core.Response;
using OBilet.Dto.IO.GetSession.Response;

namespace OBilet.Service.GetSession
{
    public interface IGetSessionClientService
    {
        Task<BaseResponse<GetSessionResponse>> GetSessionAsync();
    }
}
