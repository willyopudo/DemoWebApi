using DemoWebApi.Models;
using DemoWebApi.Repository;

namespace DemoWebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync() =>
            await _movieRepository.GetAllMoviesAsync();

        public async Task<Movie> GetMovieByIdAsync(int id) =>
            await _movieRepository.GetMovieByIdAsync(id);

        public async Task AddMovieAsync(Movie movie) =>
            await _movieRepository.AddMovieAsync(movie);

        public async Task UpdateMovieAsync(Movie movie) =>
            await _movieRepository.UpdateMovieAsync(movie);

        public async Task DeleteMovieAsync(int id) =>
            await _movieRepository.DeleteMovieAsync(id);

        public void saveChangesAsync()
        {
            _movieRepository.saveChanges();
        }
    }

}