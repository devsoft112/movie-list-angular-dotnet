# MovieAPI

## How to Run the Project

### Option 1: Running with Docker

#### Build and Run the Containers:

```bash
docker-compose up -d
```

#### Access the API:

- API: [http://localhost:5103](http://localhost:5103)
- Swagger UI: [http://localhost:5103/index.html](http://localhost:5103/index.html)

### Option 2: Running Without Docker

#### Set Up PostgreSQL:

- Ensure PostgreSQL is installed and running on your machine.
- Create a database named `movie_db`.

#### Update the Connection String:

Modify the `ConnectionStrings.MovieDbConnection` in `appsettings.json`:

```json
"ConnectionStrings": {
  "MovieDbConnection": "Host=localhost;Database=movie_db;Username=postgres;Password=yourpassword"
}
```

#### Run the Migrations:

```bash
dotnet ef database update
```

#### Run the Application:

```bash
dotnet run
```

#### Access the API:

- API: [http://localhost:5103](http://localhost:5103)
- Swagger UI: [http://localhost:5103/index.html](http://localhost:5103/index.html)