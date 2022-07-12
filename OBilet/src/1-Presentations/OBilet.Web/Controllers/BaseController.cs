using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OBilet.Web.Controllers
{
    public class BaseController : Controller
    {
        public void Notify(string message, string title = "obilet", NotificationType notificationType = NotificationType.success)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }

        public enum NotificationType
        {
            error,
            success,
            warning
        }
    }
}
