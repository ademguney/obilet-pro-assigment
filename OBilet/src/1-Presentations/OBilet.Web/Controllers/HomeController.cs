using Microsoft.AspNetCore.Mvc;
using OBilet.Core.Extension;
using OBilet.Dto.IO.Common;
using OBilet.Dto.IO.GetBusJourneys.Request;
using OBilet.Dto.IO.GetBusLocation.Request;
using OBilet.Dto.Model;
using OBilet.Dto.ViewModel;
using OBilet.Service.GetBusJourneys;
using OBilet.Service.GetBusLocation;
using OBilet.Service.GetSession;

namespace OBilet.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IGetBusLocationClientService _getBusLocationClientService;
        private readonly IGetBusJourneysClientService _getBusJourneysClientService;
        private readonly IGetSessionClientService _getSessionClientService;


        public HomeController
            (
            IGetBusLocationClientService _getBusLocationClientService,
            IGetBusJourneysClientService _getBusJourneysClientService,
            IGetSessionClientService _getSessionClientService
            )
        {
            this._getBusLocationClientService = _getBusLocationClientService;
            this._getBusJourneysClientService = _getBusJourneysClientService;
            this._getSessionClientService = _getSessionClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            var getSessionRes = await _getSessionClientService.GetSessionAsync();
            if (!getSessionRes.Success)
            {
                Notify(message: getSessionRes.Errors, notificationType: NotificationType.error);
                viewModel.Errors = getSessionRes.Errors;
                return View(viewModel);
            }

            var request = new GetBusLocationRequest
            {
                Data = null,
                Language = "tr-TR",
                Date = DateTime.Now,
                DeviceSession = new DeviceSession { DeviceId = getSessionRes.Result.Data.DeviceId, SessionId = getSessionRes.Result.Data.SessionId }
            };
            var response = await _getBusLocationClientService.GetBusLocationAsync(request);
            if (response.Success)
            {
                viewModel.BusLocationList = response.Result.Data.Select(x => new BusLocationList { Id = x.Id, Name = x.Name }).ToList();
                viewModel.OriginId = response.Result.OriginId;
                viewModel.DestinationId = response.Result.DestinationId;
                return View(viewModel);
            }

            Notify(message: response.Errors, notificationType: NotificationType.error);
            viewModel.Errors = response.Errors;
            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Journeys(HomeJourneysInput request)
        {
            if (request.DestinationId == request.OriginId)
            {
                Notify(message: "Kalkış Noktası ve Varış Noktası aynı olamaz!", notificationType: NotificationType.error);
                return RedirectToAction("Index", "Home");
            }

            var getSessionRes = await _getSessionClientService.GetSessionAsync();
            if (!getSessionRes.Success)
            {
                Notify(message: getSessionRes.Errors, notificationType: NotificationType.error);
                return RedirectToAction("Index", "Home");
            }

            var model = new GetBusJourneysRequest
            {
                DeviceSession = new DeviceSession { DeviceId = getSessionRes.Result.Data.DeviceId, SessionId = getSessionRes.Result.Data.SessionId },
                Data = new Data { OriginId = request.OriginId, DestinationId = request.DestinationId, DepartureDate = request.DepartureDate.ConvertDt() },
                Language = "tr-TR",
                Date = DateTime.Now.ToString()

            };
            var response = await _getBusJourneysClientService.GetBusJourneysAsync(model);
            if (!response.Success)
            {
                Notify(message: response.Errors, notificationType: NotificationType.error);
                return RedirectToAction("Index", "Home");
            }

            return View(response.Result);
        }
    }
}