# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore
COPY src/MarsRoverPhotoFetcher/MarsRoverPhotoFetcher.csproj src/MarsRoverPhotoFetcher/
RUN dotnet restore src/MarsRoverPhotoFetcher/MarsRoverPhotoFetcher.csproj

# Copy everything and publish
COPY . .
RUN dotnet publish src/MarsRoverPhotoFetcher/MarsRoverPhotoFetcher.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "MarsRoverPhotoFetcher.dll"]
