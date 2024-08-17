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

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves a paginated list of all movies.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved movies.", typeof(PaginatedResponse<Movie>))]
        public async Task<ActionResult<PaginatedResponse<Movie>>> GetMovies(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var paginatedMovies = await _movieService.GetAllMoviesAsync(pageNumber, pageSize);
            return Ok(paginatedMovies);
        }

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

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing movie.", Description = "Updates the specified movie with new data.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully updated movie.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Movie not found.")]
        public async Task<IActionResult> PutMovie(int id, [FromForm] Movie movie, [FromForm] IFormFile? coverImage, [FromForm] string genre)
        {
            Console.WriteLine($"Movie ID: {id}");
            Console.WriteLine($"Title: {movie.Title}");
            Console.WriteLine($"Description: {movie.Description}");
            Console.WriteLine($"Genre: {string.Join(", ", movie.Genre)}");
            Console.WriteLine($"CoverImage: {coverImage?.FileName ?? "No image uploaded"}");
            Console.WriteLine($"Existing CoverImage Path: {movie.CoverImage}");
            
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
