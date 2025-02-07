using Microsoft.AspNetCore.Mvc;
using YouTubeApi._2.Application.Interfaces;
using YouTubeApi._3.Domain.Entities;
using YouTubeApi._3.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YouTubeApi._1.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IYouTubeService _youTubeService;
        private readonly IRepository<Video> _repository;

        public VideosController(IYouTubeService youTubeService, IRepository<Video> repository)
        {
            _youTubeService = youTubeService;
            _repository = repository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchVideos([FromQuery] string consulta, [FromQuery] DateTime DataPublicacaoPosterior)
        {
            var videos = await _youTubeService.SearchVideosAsync(consulta, DataPublicacaoPosterior);
            return Ok(videos);
        }
        // Endpoint para inserir um vídeo
        [HttpPost("inserir")]
        public async Task<IActionResult> InserirVideo([FromBody] Video video)
        {
            if (video == null)
            {
                return BadRequest("Dados do vídeo inválidos.");
            }

            try
            {
                await _repository.AddAsync(video);
                return Ok(video);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao inserir o vídeo: {ex.Message}");
            }
        }
        // Endpoint para atualizar um vídeo
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarVideo(int id, [FromBody] Video video)
        {
            if (video == null || id != video.Id)
            {
                return BadRequest("Dados do vídeo inválidos ou ID incompatível.");
            }

            try
            {
                var videoExistente = await _repository.GetByIdAsync(id);
                if (videoExistente == null)
                {
                    return NotFound("Vídeo não encontrado.");
                }

                await _repository.UpdateAsync(video);
                return Ok(video);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o vídeo: {ex.Message}");
            }
        }

        // Endpoint para excluir (logicamente) um vídeo
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirVideo(int id)
        {
            try
            {
                var video = await _repository.GetByIdAsync(id);
                if (video == null)
                {
                    return NotFound("Vídeo não encontrado.");
                }

                video.Excluido = true; // Marca como excluído
                await _repository.UpdateAsync(video); // Atualiza o registro no banco de dados

                return Ok("Vídeo marcado como excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir o vídeo: {ex.Message}");
            }
        }

    }
}
