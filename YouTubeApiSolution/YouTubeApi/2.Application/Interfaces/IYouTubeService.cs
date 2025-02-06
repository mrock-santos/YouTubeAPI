using YouTubeApi._3.Domain.Entities;

namespace YouTubeApi._2.Application.Interfaces
{
    public interface IYouTubeService
    {
        Task<List<Video>> SearchVideosAsync(string query, DateTime publishedAfter);
    }
}
