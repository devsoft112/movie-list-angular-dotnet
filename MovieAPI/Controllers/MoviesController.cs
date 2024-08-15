using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
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

        /// <summary>
        /// Retrieves a list of all movies.
        /// </summary>
        /// <returns>A list of movies</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves a list of all movies.", Description = "Returns a list of movies.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved movies.", typeof(IEnumerable<Movie>))]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Retrieves a specific movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie</param>
        /// <returns>A movie</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific movie by its ID.", Description = "Returns the requested movie.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved movie.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Movie not found.")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Creates a new movie.
        /// </summary>
        /// <param name="movie">The movie to create</param>
        /// <param name="coverImage">The cover image file</param>
        /// <param name="genre">The genre string, comma-separated</param>
        /// <returns>The newly created movie</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new movie.", Description = "Creates a new movie and returns the created movie.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Successfully created movie.", typeof(Movie))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        public async Task<ActionResult<Movie>> PostMovie([FromForm] Movie movie, [FromForm] IFormFile coverImage, [FromForm] string genre)
        {
            if (!string.IsNullOrWhiteSpace(genre))
            {
                movie.Genre = genre.Split(',')
                                   .Select(g => g.Trim())
                                   .ToList();
            }

            var createdMovie = await _movieService.CreateMovieAsync(movie, coverImage);
            return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie);
        }

        /// <summary>
        /// Updates an existing movie.
        /// </summary>
        /// <param name="id">The ID of the movie to update</param>
        /// <param name="movie">The updated movie data</param>
        /// <param name="coverImage">The updated cover image file</param>
        /// <param name="genre">The genre string, comma-separated</param>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing movie.", Description = "Updates the specified movie with new data.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully updated movie.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Movie not found.")]
        public async Task<IActionResult> PutMovie(int id, [FromForm] Movie movie, [FromForm] IFormFile? coverImage, [FromForm] string genre)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                movie.Genre = genre.Split(',')
                                   .Select(g => g.Trim())
                                   .ToList();
            }

            try
            {
                await _movieService.UpdateMovieAsync(movie, coverImage);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete</param>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a specific movie by its ID.", Description = "Deletes the specified movie.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully deleted movie.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Movie not found.")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.DeleteMovieAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
