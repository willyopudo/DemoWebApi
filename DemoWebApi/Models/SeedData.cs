using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                SeedDB(context);
            }
        }

        public static void SeedDB(MovieContext context)
        {
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
               new Movie()
               {
                   Title = "Movie 1",
                   Genre = "Horror",
                   ReleaseDate = DateTime.Parse("2024-12-18T07:10:56.157Z")
               },
               new Movie()
               {
                    Title = "Movie 2",
                    Genre = "RomCom",
                    ReleaseDate = DateTime.Parse("2024-12-17T07:10:56.157Z")
               },
                new Movie()
                {
                    Title = "Movie 3",
                    Genre = "Adventure",
                    ReleaseDate = DateTime.Parse("2024-12-15T07:10:56.157Z")
                }
             );
            context.SaveChanges();
        }

    }
}