# Use the official .NET 8.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the project files and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port on which the API will run
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "MovieAPI.dll"]
