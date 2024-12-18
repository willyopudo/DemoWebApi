using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync() =>
            await _context.Movies.ToListAsync();

        public async Task<Movie> GetMovieByIdAsync(int id) =>
            await _context.Movies.FindAsync(id);

        public async Task AddMovieAsync(Movie movie) =>
            await _context.Movies.AddAsync(movie);

        public async Task UpdateMovieAsync(Movie movie) =>
            _context.Movies.Update(movie);

        public void saveChanges()
        {
            _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }
    }

}