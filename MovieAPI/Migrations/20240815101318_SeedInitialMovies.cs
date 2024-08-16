using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CoverImage", "Description", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "thedarkknight.jpg", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "Action,Drama,Thriller", "The Dark Knight" },
                    { 2, "inception.jpg", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", "Sci-Fi,Action,Thriller", "Inception" },
                    { 3, "forrestgump.jpg", "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "Drama,Romance", "Forrest Gump" },
                    { 4, "up.jpg", "Seventy-eight year old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.", "Animation,Adventure,Family", "Up" },
                    { 5, "shawshankredemption.jpg", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Drama", "The Shawshank Redemption" },
                    { 6, "godfather.jpg", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Crime,Drama", "The Godfather" },
                    { 7, "godfather2.jpg", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "Crime,Drama", "The Godfather: Part II" },
                    { 8, "thedarkknightrises.jpg", "Eight years after the Joker's reign of anarchy, Batman is forced from his exile with the help of the enigmatic Selina Kyle to save Gotham City from the brutal guerrilla terrorist Bane.", "Action,Drama,Thriller", "The Dark Knight Rises" },
                    { 9, "interstellar.jpg", "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "Adventure,Drama,Sci-Fi", "Interstellar" },
                    { 10, "gladiator.jpg", "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", "Action,Adventure,Drama", "Gladiator" },
                    { 11, "braveheart.jpg", "Scottish warrior William Wallace leads his countrymen in a rebellion to free his homeland from the tyranny of King Edward I of England.", "Biography,Drama,History", "Braveheart" },
                    { 12, "savingprivateryan.jpg", "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.", "Drama,War", "Saving Private Ryan" },
                    { 13, "schindlerslist.jpg", "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Biography,Drama,History", "Schindler's List" },
                    { 14, "silenceofthelambs.jpg", "A young FBI cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", "Crime,Drama,Thriller", "The Silence of the Lambs" },
                    { 15, "fightclub.jpg", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "Drama", "Fight Club" },
                    { 16, "matrix.jpg", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Action,Sci-Fi", "The Matrix" },
                    { 17, "lordoftherings3.jpg", "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "Adventure,Drama,Fantasy", "The Lord of the Rings: The Return of the King" },
                    { 18, "lordoftherings2.jpg", "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.", "Adventure,Drama,Fantasy", "The Lord of the Rings: The Two Towers" },
                    { 19, "lordoftherings1.jpg", "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "Adventure,Drama,Fantasy", "The Lord of the Rings: The Fellowship of the Ring" },
                    { 20, "starwars4.jpg", "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", "Action,Adventure,Fantasy", "Star Wars: Episode IV - A New Hope" },
                    { 21, "starwars5.jpg", "After the Rebels are overpowered by the Empire on the ice planet Hoth, Luke Skywalker begins Jeditraining with Yoda, while his friends are pursued by Darth Vader and a bounty hunter named Boba Fett all over the galaxy.", "Action,Adventure,Fantasy", "Star Wars: Episode V - The Empire Strikes Back" },
                    { 22, "starwars6.jpg", "After a daring mission to rescue Han Solo from Jabba the Hutt, the Rebels dispatch to Endor to destroy the second Death Star. Meanwhile, Luke struggles to help Darth Vader back from the dark side without falling into the Emperor's trap.", "Action,Adventure,Fantasy", "Star Wars: Episode VI - Return of the Jedi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
