using Microsoft.AspNetCore.Http;
using MovieAPI.Models;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> CreateMovieAsync(Movie movie, IFormFile coverImage);
        Task UpdateMovieAsync(Movie movie, IFormFile? coverImage);
        Task DeleteMovieAsync(int id);
        Task<string> UploadCoverImageAsync(IFormFile coverImage);
    }
}
