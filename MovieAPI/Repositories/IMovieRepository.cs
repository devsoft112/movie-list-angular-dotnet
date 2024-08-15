using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAPI.Models; // Add this line

namespace MovieAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}
