using Microsoft.EntityFrameworkCore;
using RecommendationService.Context;
using RecommendationService.services;

namespace RecommendationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<Recommendationcontext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IRecommedationservice,services.RecommendationService>();
             var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
