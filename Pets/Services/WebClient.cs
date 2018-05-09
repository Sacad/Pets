using AGLTest.Configuration;

namespace AGLTest.Services
{
    public class WebClient : IWebClient
    {
        private readonly System.Net.WebClient _webClient = new System.Net.WebClient();
        private readonly IConfiguration _configuration;

        public WebClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DownloadString()
        {
            var url = _configuration.PersonServiceUrl;
            return _webClient.DownloadString(url);
        }
    }
}