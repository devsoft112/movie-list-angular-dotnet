using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Services;
using MovieAPI.Repositories;
using MovieAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Use custom Swagger configuration
builder.Services.AddCustomSwagger();

// Configure DbContext
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDbConnection")));

// Register services and repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
