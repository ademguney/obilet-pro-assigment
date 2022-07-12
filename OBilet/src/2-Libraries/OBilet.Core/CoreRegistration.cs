using Microsoft.Extensions.DependencyInjection;
using OBilet.Core.Cache;
using OBilet.Core.Utility;

namespace OBilet.Core
{
    public static class CoreRegistration
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection service)
        {
            service.AddScoped<IMemoryCacheService, MemoryCacheService>();
            service.AddScoped<IHttpHandler, HttpClientHandlers>();
            return service; 
        }
    }
}
