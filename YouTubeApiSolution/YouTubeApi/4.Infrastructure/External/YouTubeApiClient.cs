namespace YouTubeApi._4.Infrastructure.External
{
    public class YouTubeApiClient
    {
        private readonly HttpClient _httpClient;

        public YouTubeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSearchResultsAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
