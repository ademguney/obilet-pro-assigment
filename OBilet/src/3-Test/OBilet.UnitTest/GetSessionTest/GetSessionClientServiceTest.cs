using Moq;
using Newtonsoft.Json;
using OBilet.Core.DummyData;
using OBilet.Core.Response;
using OBilet.Core.Utility;
using OBilet.Dto.IO.GetSession.Response;
using OBilet.Service.GetSession;
using System.Net.Http;
using Xunit;

namespace OBilet.UnitTest.GetSessionTest
{
    public class GetSessionClientServiceTest
    {
        private readonly Mock<IGetSessionClientService> _getSessionMock;
        private readonly Mock<IHttpHandler> _clientMock;
        public GetSessionClientServiceTest()
        {
            _getSessionMock = new Mock<IGetSessionClientService>();
            _clientMock = new Mock<IHttpHandler>();
        }


        [Fact]
        public void GetSessionClientService_JsonConvertSerializeObject_NotNull()
        {
            #region Arrange
            var requestData = GetSessionData.SessionRequestData();
            #endregion

            #region Act
            var jsonModel = JsonConvert.SerializeObject(requestData);
            #endregion

            #region Assert
            Assert.NotNull(jsonModel);
            #endregion
        }


        [Fact]
        public async void GetSessionClientService_BaseResponse_SuccesToTrue()
        {

            #region Arrange
            var httpResponse = new HttpResponseMessage();
            var response = new BaseResponse<GetSessionResponse>();
            _clientMock.Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).ReturnsAsync(httpResponse);
            _getSessionMock.Setup(x => x.GetSessionAsync()).ReturnsAsync(response);

            var sut = new GetSessionClientService(_clientMock.Object);
            #endregion

            #region Act
            var result = await sut.GetSessionAsync();
            #endregion

            #region Assert
            Assert.True(result.Success);
            #endregion
        }

        [Fact]
        public async void GetSessionClientService_JsonConvertDesirializeObject_NotNull()
        {

            #region Arrange
            var httpHandler = new HttpClientHandlers();
            var httpResponse = new HttpResponseMessage();
            var response = new BaseResponse<GetSessionResponse>();

            _getSessionMock.Setup(x => x.GetSessionAsync()).ReturnsAsync(response);

            var sut = new GetSessionClientService(httpHandler);
            #endregion

            #region Act
            var result = await sut.GetSessionAsync();
            #endregion

            #region Assert
            Assert.NotNull(result.Result.Data);
            #endregion
        }
    }
}
