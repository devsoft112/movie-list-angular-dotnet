using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data.Seeding
{
    public static class MovieSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Dark Knight",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Genre = new List<string> { "Action", "Drama", "Thriller" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 2,
                    Title = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                    Genre = new List<string> { "Sci-Fi", "Action", "Thriller" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 3,
                    Title = "Forrest Gump",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Genre = new List<string> { "Drama", "Romance" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 4,
                    Title = "Up",
                    Description = "Seventy-eight year old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.",
                    Genre = new List<string> { "Animation", "Adventure", "Family" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Genre = new List<string> { "Drama" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 6,
                    Title = "The Godfather",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    Genre = new List<string> { "Crime", "Drama" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 7,
                    Title = "The Godfather: Part II",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Genre = new List<string> { "Crime", "Drama" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 8,
                    Title = "The Dark Knight Rises",
                    Description = "Eight years after the Joker's reign of anarchy, Batman is forced from his exile with the help of the enigmatic Selina Kyle to save Gotham City from the brutal guerrilla terrorist Bane.",
                    Genre = new List<string> { "Action", "Drama", "Thriller" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 9,
                    Title = "Interstellar",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    Genre = new List<string> { "Adventure", "Drama", "Sci-Fi" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 10,
                    Title = "Gladiator",
                    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                    Genre = new List<string> { "Action", "Adventure", "Drama" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 11,
                    Title = "Braveheart",
                    Description = "Scottish warrior William Wallace leads his countrymen in a rebellion to free his homeland from the tyranny of King Edward I of England.",
                    Genre = new List<string> { "Biography", "Drama", "History" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 12,
                    Title = "Saving Private Ryan",
                    Description = "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.",
                    Genre = new List<string> { "Drama", "War" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 13,
                    Title = "Schindler's List",
                    Description = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Genre = new List<string> { "Biography", "Drama", "History" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 14,
                    Title = "The Silence of the Lambs",
                    Description = "A young FBI cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.",
                    Genre = new List<string> { "Crime", "Drama", "Thriller" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 15,
                    Title = "Fight Club",
                    Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                    Genre = new List<string> { "Drama" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 16,
                    Title = "The Matrix",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    Genre = new List<string> { "Action", "Sci-Fi" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 17,
                    Title = "The Lord of the Rings: The Return of the King",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Genre = new List<string> { "Adventure", "Drama", "Fantasy" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 18,
                    Title = "The Lord of the Rings: The Two Towers",
                    Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                    Genre = new List<string> { "Adventure", "Drama", "Fantasy" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 19,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Genre = new List<string> { "Adventure", "Drama", "Fantasy" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 20,
                    Title = "Star Wars: Episode IV - A New Hope",
                    Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                    Genre = new List<string> { "Action", "Adventure", "Fantasy" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 21,
                    Title = "Star Wars: Episode V - The Empire Strikes Back",
                    Description = "After the Rebels are overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jeditraining with Yoda, while his friends are pursued by Darth Vader and a bounty hunter named Boba Fett all over the galaxy.",
                    Genre = new List<string> { "Action", "Adventure", "Fantasy" },
                    CoverImage = ""
                },
                new Movie
                {
                    Id = 22,
                    Title = "Star Wars: Episode VI - Return of the Jedi",
                    Description = "After a daring mission to rescue Han Solo from Jabba the Hutt, the Rebels dispatch to Endor to destroy the second Death Star. Meanwhile, Luke struggles to help Darth Vader back from the dark side without falling into the Emperor's trap.",
                    Genre = new List<string> { "Action", "Adventure", "Fantasy" },
                    CoverImage = ""
                }
            );
        }
    }
}
