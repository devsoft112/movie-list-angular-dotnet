# Movie Viewing Application

This application is a comprehensive, full-stack movie viewing platform developed with Angular 18 for front-end and .NET 8 for back-end. It provides users with the ability to view a list of movies and add new ones by providing a title, description, genre, and cover image. The back-end API manages movie data stored in an SQL database.

## Project Structure

The project is divided into two main parts:

### 1. MovieAPI (Back-End)
- **Framework:** C# .NET 8
- **Functionality:**
  - RESTful API with the following endpoints:
    - GET /api/movies: Retrieve a list of movies.
    - POST /api/movies: Create a new movie.
    - PUT /api/movies/{id}: Update a movie.
    - DELETE /api/movies/{id}: Delete a movie.
  - Uses Entity Framework Core 8 for database operations.
  - Data seeding with initial movies for easier testing and development.
  - Docker support for containerized deployment.

### 2. MovieAppUI (Front-End)
- **Framework:** Angular 18
- **Functionality:**
  - Displays a list of movies with their title, description, genre, and cover image.
  - Allows users to view detailed information about each movie.
  - A form to create or edit a movie, with form validation for required fields.
  - Utilizes Angular Material for UI components and styling.
  - Includes drag-and-drop functionality for uploading movie cover images.

## Front-End Features

- **Movie List:** Displays all available movies in a paginated format. Users can click on any movie to view more details.
- **Movie Detail View:** Provides comprehensive information about a selected movie.
- **CRUD Operations:** Users can create, update, and delete movies. The form includes validation to ensure all necessary fields are completed before submission.
- **Drag-and-Drop Image Upload:** Users can drag and drop an image file to set the movie's cover image, with an option to preview the image before submission.
- **Responsive Design:** The application is fully responsive, providing an optimal viewing experience across a wide range of devices.

## Angular Component Overview

- **MoviesListComponent:** Displays a list of all movies with pagination controls and options to edit or delete movies.
- **MovieDetailComponent:** Shows detailed information for a selected movie and provides options to edit or delete the movie.
- **CreateMovieComponent:** Contains the form for creating a new movie or editing an existing one, including drag-and-drop functionality for image uploads.
- **ConfirmDialogComponent:** A modal dialog used for confirming the deletion of a movie.

## Styling and Theming

- **Dark Theme:** The application uses a dark theme to provide a modern and visually appealing interface. Custom SCSS styles are applied to Angular Material components to maintain a consistent look and feel.
- **Component Styling:** Each component has its own SCSS file to manage styling, allowing for modular and maintainable design.

## Getting Started

### Prerequisites

- .NET 8 SDK: Ensure that .NET 8 SDK is installed on your machine.
- Node.js: Install Node.js to manage npm packages for the Angular project.
- Docker (Optional): To run the application in a containerized environment.
- PostgreSQL (Optional): If running without Docker.

### Setup Instructions

#### Option 1: Running with Docker

1. Navigate to the root directory:

```bash
cd sb-space-angular18-dotnet8
```

2. Build and run the Docker containers:

```bash
docker-compose up --build -d
```

3. Access the API:

- API: http://localhost:5103
- Swagger UI: http://localhost:5103/index.html

4. Access the front-end:

- The application should be running on http://localhost:4200.

#### Option 2: Running Without Docker

##### Back-End (MovieAPI)

1. Set Up PostgreSQL:
   - Ensure PostgreSQL is installed and running on your machine.
   - Create a database named movie_db.

2. Update the Connection String:
   - Modify the ConnectionStrings.MovieDbConnection in appsettings.json:

```json
"ConnectionStrings": {
  "MovieDbConnection": "Host=localhost;Database=movie_db;Username=postgres;Password=yourpassword"
}
```

3. Run the Migrations:

```bash
dotnet ef database update
```

4. Run the API:

```bash
dotnet run
```

5. Access the API:

- API: http://localhost:5103
- Swagger UI: http://localhost:5103/index.html

##### Front-End (MovieAppUI)

1. Navigate to the MovieAppUI directory:

```bash
cd sb-space-angular18-dotnet8/MovieAppUI
```

2. Install npm packages:

```bash
npm install
```

3. Run the Angular application:

```bash
ng serve
```

4. Access the front-end:

- The application should be running on http://localhost:4200.

## Assumptions and Design Decisions

- **Data Seeding:** The database is seeded with initial movies to simplify testing and validation.
- **Error Handling:** Basic error handling is implemented for both API and UI to manage common scenarios.
- **Validation:** Form validation is implemented on the front-end to ensure that all required fields are filled before submission.
