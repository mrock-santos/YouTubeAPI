using Microsoft.EntityFrameworkCore;
using YouTubeApi._3.Domain.Entities;
using YouTubeApi._3.Domain.Interfaces;
using YouTubeApi._4.Infrastructure.Data;

namespace YouTubeApi._4.Infrastructure.Repositories
{
    public class VideoRepository : IRepository<Video>
    {
        private readonly ApplicationDbContext _context;

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task AddAsync(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                video.Excluido = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
