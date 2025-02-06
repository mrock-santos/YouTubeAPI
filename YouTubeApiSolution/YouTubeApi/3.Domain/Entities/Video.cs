namespace YouTubeApi._3.Domain.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Canal { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Duracao { get; set; }
        public bool Excluido { get; set; } = false;
    }
}
