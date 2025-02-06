namespace YouTubeApi._3.Domain.Entities
{
    public class YouTubeSearchResponse
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public Snippet Snippet { get; set; }
    }

    public class Snippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
