using DemoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using DemoWebApi.Services;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);

        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _movieService.AddMovieAsync(movie);
            _movieService.saveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);

        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movie);
            _movieService.saveChangesAsync();
            return NoContent();

        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {

            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }

        [HttpGet("GetAllHeaders")]
        public ActionResult<Dictionary<string, string>> GetAllHeaders()
        {
            Dictionary<string, string> requestHeaders =
                new Dictionary<string, string>();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
            return requestHeaders;
        }

        [HttpGet("GetHeaderData")]
        public ActionResult<string> GetHeaderData(string headerKey)
        {
        Request.Headers.TryGetValue(headerKey, out var headerValue);
        return Ok(headerValue);
        }

        // private bool MovieExists(long id)
        // {
        //     return (_movieService.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
