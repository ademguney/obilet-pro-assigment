using OBilet.Core.Constants;
using System.Net.Http.Headers;

namespace OBilet.Core.Utility
{
    public class HttpClientHandlers : IHttpHandler
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ApiClientToken.WebApiAccessToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ApiClientToken.WebApiAccessToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _client.PostAsync(url, content);
        }
    }
}
