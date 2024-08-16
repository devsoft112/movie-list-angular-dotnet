using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAPI.Models; // Add this line

namespace MovieAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<PaginatedResponse<Movie>> GetAllMoviesAsync(int pageNumber, int pageSize);
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}
