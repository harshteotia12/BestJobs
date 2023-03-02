using System;
using System.Net.Http;

namespace HRWebLayer.Helper
{
    public class API : IAPI
    {
        string _baseUrl;
        public API(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            return client;
        }
    }
}
