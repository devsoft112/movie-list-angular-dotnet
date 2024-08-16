using Microsoft.AspNetCore.Http;
using MovieAPI.Models;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public interface IMovieService
    {
        Task<PaginatedResponse<Movie>> GetAllMoviesAsync(int pageNumber, int pageSize);
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> CreateMovieAsync(Movie movie, IFormFile coverImage);
        Task UpdateMovieAsync(Movie movie, IFormFile? coverImage);
        Task DeleteMovieAsync(int id);
        Task<string> UploadCoverImageAsync(IFormFile coverImage);
    }
}
