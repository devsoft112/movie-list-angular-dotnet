using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<string> Genre { get; set; } = new List<string>(); // Updated to List<string>

        public string? CoverImage { get; set; }
    }
}
