using Microsoft.AspNetCore.Http;
using MovieAPI.Models;
using MovieAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task<Movie> CreateMovieAsync(Movie movie, IFormFile coverImage)
        {
            if (coverImage != null)
            {
                movie.CoverImage = await UploadCoverImageAsync(coverImage);
            }

            return await _movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie, IFormFile? coverImage)
        {
            var existingMovie = await _movieRepository.GetMovieByIdAsync(movie.Id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException();
            }

            if (coverImage != null)
            {
                // Optionally, delete the old image if a new one is uploaded
                if (!string.IsNullOrEmpty(existingMovie.CoverImage))
                {
                    var oldImagePath = Path.Combine(_imageDirectory, existingMovie.CoverImage);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                movie.CoverImage = await UploadCoverImageAsync(coverImage);
            }
            else
            {
                movie.CoverImage = existingMovie.CoverImage;
            }

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.Genre = movie.Genre;
            existingMovie.CoverImage = movie.CoverImage;

            await _movieRepository.UpdateMovieAsync(existingMovie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                throw new KeyNotFoundException();
            }

            // Optionally, delete the associated image file
            if (!string.IsNullOrEmpty(movie.CoverImage))
            {
                var imagePath = Path.Combine(_imageDirectory, movie.CoverImage);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            await _movieRepository.DeleteMovieAsync(movie);
        }

        public async Task<string> UploadCoverImageAsync(IFormFile coverImage)
        {
            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(coverImage.FileName)}";
            var filePath = Path.Combine(_imageDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await coverImage.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
