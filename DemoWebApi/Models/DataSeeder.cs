namespace DemoWebApi.Models{
    public class DataSeeder
    {
        private readonly MovieContext movieContext;

        public DataSeeder(MovieContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public void Seed()
        {
            if(!movieContext.Movies.Any())
            {
                var movies = new List<Movie>()
                {
                        new Movie()
                        {
                            Title = "Movie 1",
                            Genre = "Horror",
                            ReleaseDate = "2024-12-18T07:10:56.157Z"
                        },
                        new Movie()
                        {
                            Title = "Movie 2",
                            Genre = "RomCom",
                            ReleaseDate = "2024-12-17T07:10:56.157Z"
                        },
                        new Movie()
                        {
                            Title = "Movie 3",
                            Genre = "Adventure",
                            ReleaseDate = "2024-12-15T07:10:56.157Z"
                        }
                };

                movieContext.Movies.AddRange(movies);
                movieContext.SaveChanges();
            }
        }
    }
}