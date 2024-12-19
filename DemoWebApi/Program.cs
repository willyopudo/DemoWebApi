using DemoWebApi.Models;
using DemoWebApi.Repository;
using DemoWebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MovieContext>(options =>
                //options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));
                options.UseInMemoryDatabase("MovieContext"));

            builder.Services.AddControllers();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                await SeedData.Initialize(services);
                await using var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
                //await dbContext.Database.MigrateAsync();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }

}