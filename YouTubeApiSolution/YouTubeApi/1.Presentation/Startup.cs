using Microsoft.EntityFrameworkCore;
using YouTubeApi._2.Application.Interfaces;
using YouTubeApi._2.Application.Services;
using YouTubeApi._3.Domain.Entities;
using YouTubeApi._3.Domain.Interfaces;
using YouTubeApi._4.Infrastructure.Data;
using YouTubeApi._4.Infrastructure.Repositories;

namespace YouTubeApi._1.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do SQLite
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Registro dos serviços
            //services.AddScoped<IYouTubeService, YouTubeService>();
            services.AddHttpClient<IYouTubeService, YouTubeService>();
            services.AddScoped<IRepository<Video>, VideoRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        /// <summary>
        /// Chamada no Link https://localhost:7215/swagger/index.html
        /// publishedAfter: 2025-01-01
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
