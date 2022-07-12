using Moq;
using Newtonsoft.Json;
using OBilet.Core.Cache;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetBusJourneys.Request;
using OBilet.Dto.IO.GetBusJourneys.Response;
using OBilet.Service.GetBusJourneys;
using System;
using System.Net.Http;
using Xunit;

namespace OBilet.UnitTest.GetBusJourneysTest
{
    public class GetBusJourneysClientServiceTest
    {
        private readonly Mock<IHttpHandler> _clientMock;
        private readonly Mock<IMemoryCacheService> _memoryCacheMock;
        private readonly Mock<IGetBusJourneysClientService> _journeysMock;
        public GetBusJourneysClientServiceTest()
        {
            _clientMock = new Mock<IHttpHandler>();
            _memoryCacheMock = new Mock<IMemoryCacheService>();
            _journeysMock = new Mock<IGetBusJourneysClientService>();

        }

        [Fact]
        public void GetBusJourneysClientService_JsonConvertSerializeObject_NotNull()
        {
            #region Arrange
            var requestData = new GetBusJourneysRequest();
            requestData.Date = DateTime.Now.ToString();
            requestData.Language = "tr-Tr";
            requestData.DeviceSession = new Dto.IO.Common.DeviceSession { DeviceId = "test_device_id", SessionId = "test_session_id" };
            requestData.Data = null;
            #endregion

            #region Act
            var jsonModel = JsonConvert.SerializeObject(requestData);
            #endregion

            #region Assert
            Assert.NotNull(jsonModel);
            #endregion
        }

        [Fact]
        public async void GetBusJourneysClientService_BaseResponse_SuccesToTrue()
        {
            #region Arrange
            var httpResponse = new HttpResponseMessage();
            var response = new BaseResponse<GetBusJourneysResponse>();
            var request = new GetBusJourneysRequest
            {
                Date = DateTime.Now.ToString(),
                Language = "tr-Tr",
                Data = new Data { DepartureDate = DateTime.Now, OriginId = 34, DestinationId = 63 },
                DeviceSession = new Dto.IO.Common.DeviceSession { DeviceId = "test_device_id", SessionId = "test_session_id" },

            };

            _clientMock.Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).ReturnsAsync(httpResponse);
            _journeysMock.Setup(x => x.GetBusJourneysAsync(request)).ReturnsAsync(response);
            var sut = new GetBusJourneysClientService(_memoryCacheMock.Object, _clientMock.Object);
            #endregion

            #region Act
            var result = await sut.GetBusJourneysAsync(request);
            #endregion

            #region Assert
            Assert.True(result.Success);
            #endregion

        }
    }
}
