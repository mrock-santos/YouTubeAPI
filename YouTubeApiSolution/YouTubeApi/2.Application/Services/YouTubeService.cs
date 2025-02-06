using Newtonsoft.Json;
using YouTubeApi._2.Application.Interfaces;
using YouTubeApi._3.Domain.Entities;

namespace YouTubeApi._2.Application.Services
{
    public class YouTubeService : IYouTubeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public YouTubeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Obtém as configurações do appsettings.json
            _apiKey = configuration["YouTubeApi:ApiKey"];
            _baseUrl = configuration["YouTubeApi:BaseUrl"];

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new ArgumentNullException(nameof(_apiKey), "A chave da API do YouTube não foi configurada.");
            }

            if (string.IsNullOrEmpty(_baseUrl))
            {
                throw new ArgumentNullException(nameof(_baseUrl), "A URL base da API do YouTube não foi configurada.");
            }
        }

        public async Task<List<Video>> SearchVideosAsync(string query, DateTime publishedAfter)
        {
            // Constrói a URL completa usando a baseUrl e a apiKey
            var url = $"{_baseUrl}search?part=snippet&q={query}&maxResults=50&publishedAfter={publishedAfter:yyyy-MM-ddTHH:mm:ssZ}&regionCode=BR&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var searchResponse = JsonConvert.DeserializeObject<YouTubeSearchResponse>(json);

            var videos = new List<Video>();
            foreach (var item in searchResponse.Items)
            {
                videos.Add(new Video
                {
                    Titulo = item.Snippet.Title,
                    Descricao = item.Snippet.Description,
                    Canal = item.Snippet.ChannelTitle,
                    DataPublicacao = item.Snippet.PublishedAt,
                    Duracao = "PT0S" // Duração precisa ser obtida de outra API
                });
            }

            return videos;
        }
    }
}
