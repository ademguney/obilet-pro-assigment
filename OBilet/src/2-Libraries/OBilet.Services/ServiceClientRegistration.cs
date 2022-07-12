using Microsoft.Extensions.DependencyInjection;
using OBilet.Service.GetBusJourneys;
using OBilet.Service.GetBusLocation;
using OBilet.Service.GetSession;

namespace OBilet.Service
{
    public static class ServiceClientRegistration
    {
        public static IServiceCollection AddHttpServiceClient(this IServiceCollection service)
        {
            service.AddScoped<IGetSessionClientService, GetSessionClientService>();
            service.AddScoped<IGetBusLocationClientService, GetBusLocationClientService>();
            service.AddScoped<IGetBusJourneysClientService, GetBusJourneysClientService>();
            return service;
        }
    }
}
