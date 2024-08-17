# Movie List Application

This application is a full-stack movie viewer developed with Angular 18 and .NET 8. It enables users to view, create, update, and delete movies, each with a title, description, genre, and cover image. The back-end API manages movie data stored in an SQL database.

## Features

### Front-End

- **Movie List**: Displays all movies in a paginated format.
- **Movie Detail View**: Shows detailed information about each movie.
- **CRUD Operations**: Allows users to create, update, and delete movies.
- **Drag-and-Drop Image Upload**: Users can set a movie's cover image by dragging and dropping an image file.
- **Responsive Design**: Optimized for a wide range of devices.
- **Loading Indicators**: Displayed while data is being fetched or submitted.
- **Error Messages**: Handles and displays error messages for validation failures and other issues.

### Back-End

- **RESTful API**: Manages movies with GET, POST, PUT, and DELETE operations.
- **Image Handling**: Supports uploading and managing movie cover images.
- **Sorting and Pagination**: Allows sorting of movies by Id and supports pagination.
- **Swagger Integration**: Provides interactive API documentation.
- **Data Seeding**: Seeds the database with initial movie data.
- **CORS Configuration**: Allows cross-origin requests from the front-end application.

## Project Structure

The project is divided into two main parts:

- **MovieAPI (Back-End)**
  - Framework: C# .NET 8
  - Functionality: RESTful API, Entity Framework Core 8 for database operations, Docker support, Swagger documentation, sorting and pagination support.
- **MovieAppUI (Front-End)**
  - Framework: Angular 18
  - Functionality: Displays list of movies, provides forms for movie creation and editing, uses Angular Material for UI components and styling, supports search and filtering.

## Technologies Used

- .NET 8.0
- Angular 18
- Entity Framework Core (PostgreSQL)
- Swashbuckle (Swagger)
- Docker
- PostgreSQL

## Setup Instructions

### Prerequisites

- .NET 8 SDK
- Node.js
- Docker (Optional)
- PostgreSQL (Optional)

### Option 1: Running with Docker for .NET Backend

1. Navigate to the root directory of .net backend: `cd sb-space-angular18-dotnet8\MovieAPI`
2. Build and run the Docker containers: `docker-compose up --build -d`
3. Access the API at http://localhost:5103 and Swagger UI at http://localhost:5103/index.html

### Option 2: Running Without Docker

#### Back-End (MovieAPI)

1. Set Up PostgreSQL: Ensure PostgreSQL is installed and running. Create a database named `movie_db`.
2. Update the Connection String in `appsettings.json`.
Modify the `ConnectionStrings.MovieDbConnection` in `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "MovieDbConnection": "Host=localhost;Database=movie_db;Username=[username];Password=[password]"
}
```
3. Run the Migrations: `dotnet ef database update`
4. Run the API: `dotnet run`
5. Access the API at http://localhost:5103 and Swagger UI at http://localhost:5103/index.html

#### Front-End (MovieAppUI)

1. Navigate to the MovieAppUI directory: `cd sb-space-angular18-dotnet8/MovieAppUI`
2. Install npm packages: `npm install`
3. Run the Angular application: `ng serve`
4. The application should be running on http://localhost:4200.

## API Endpoints

- GET /api/movies: Retrieves a paginated list of movies, sorted by Id.
- GET /api/movies/{id}: Retrieves a specific movie by ID.
- POST /api/movies: Creates a new movie.
- PUT /api/movies/{id}: Updates an existing movie.
- DELETE /api/movies/{id}: Deletes a movie by ID.

## Swagger Documentation

Swagger is integrated into this project for API documentation and testing. Access Swagger UI at http://localhost:5103/index.html.

## Database Seeding

The application seeds the database with initial data on startup if the database is empty. To modify the seed data, edit the `MovieSeedData.cs` file in the `Data/Seeding` folder.

## Assumptions and Design Decisions

- **Data Seeding**: The database is seeded with initial movies to simplify testing and validation.
- **Error Handling**: Basic error handling is implemented for both API and UI to manage common scenarios.
- **Validation**: Form validation is implemented on the front-end to ensure that all required fields are filled before submission.