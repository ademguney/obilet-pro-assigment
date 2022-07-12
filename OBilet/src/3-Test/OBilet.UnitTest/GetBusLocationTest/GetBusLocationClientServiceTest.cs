using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using OBilet.Core.Cache;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetBusLocation.Request;
using OBilet.Dto.IO.GetBusLocation.Response;
using OBilet.Service.GetBusLocation;
using System;
using System.Net.Http;
using Xunit;

namespace OBilet.UnitTest.GetBusLocationTest
{
    public class GetBusLocationClientServiceTest
    {
        private readonly Mock<IHttpHandler> _clientMock;
        private readonly Mock<IMemoryCacheService> _memoryCacheServiceMock;
        private readonly Mock<IGetBusLocationClientService> _getBusLocationMock;
        private readonly Mock<IMemoryCache> _cacheMock;


        public GetBusLocationClientServiceTest()
        {
            _getBusLocationMock = new Mock<IGetBusLocationClientService>();
            _clientMock = new Mock<IHttpHandler>();
            _memoryCacheServiceMock = new Mock<IMemoryCacheService>();
            _cacheMock = new Mock<IMemoryCache>();

        }

        [Fact]
        public void GetBusLocationClientService_JsonConvertSerializeObject_NotNull()
        {
            #region Arrange
            var requestData = new GetBusLocationRequest();
            requestData.Date = DateTime.Now;
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
        public async void GetBusLocationClientService_BaseResponse_SuccesToTrue()
        {
            #region Arrange
            var httpResponse = new HttpResponseMessage();
            var response = new BaseResponse<GetBusLocationResponse>();
            var request = new GetBusLocationRequest
            {
                Date = DateTime.Now,
                Language = "tr-Tr",
                Data = null,
                DeviceSession = new Dto.IO.Common.DeviceSession { DeviceId = "test_device_id", SessionId = "test_session_id" }
            };

            _clientMock.Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).ReturnsAsync(httpResponse);
            _getBusLocationMock.Setup(x => x.GetBusLocationAsync(request)).ReturnsAsync(response);
            var sut = new GetBusLocationClientService(_memoryCacheServiceMock.Object, _clientMock.Object);
            #endregion

            #region Act
            var result = await sut.GetBusLocationAsync(request);
            #endregion

            #region Assert
            Assert.True(result.Success);
            #endregion

        }
    }
}
