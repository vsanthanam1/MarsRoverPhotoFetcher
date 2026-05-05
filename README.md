Mars Rover Photo Fetcher
This project is a .NET application that reads a list of dates, validates them, calls the NASA Mars Rover Photos API, downloads rover images, and returns a summary of the results. It was built as part of a Senior Software Engineer coding exercise, with an emphasis on clean structure, async programming, and thoughtful AI‑assisted development.

The goal was to create something simple, reliable, and easy to understand — the kind of codebase you can walk someone through confidently.

What the application does
The workflow is intentionally straightforward:

1. Reads dates from a text file
The file lives under Data/dates.txt and contains dates in different formats. Some are valid, some intentionally invalid.

2. Parses and validates each date
The app supports multiple date formats and gracefully handles invalid ones (like “April 31”).
Invalid dates are skipped but logged so the user knows what happened.

3. Calls the NASA Mars Rover Photos API
For each valid date, the app queries the Curiosity rover’s photos for that day using NASA’s public API.

4. Downloads rover images
The first few photos (up to 3–5) are downloaded and stored in a folder structure like:

Code
photos/2017-02-27/
photos/2018-06-02/
If an image already exists, it’s skipped to avoid unnecessary downloads.

5. Produces a summary
The API returns a JSON summary showing:

The date

How many photos NASA returned

How many were downloaded

Any errors that occurred

This makes it easy to verify the job ran correctly.

How to run the project
1. Clone the repository
Code
git clone https://github.com/<your-username>/MarsRoverPhotoFetcher.git
cd MarsRoverPhotoFetcher
2. Add your NASA API key
Open appsettings.json and update the Nasa section:

json
"Nasa": {
  "ApiKey": "YOUR_API_KEY",
  "BaseUrl": "https://api.nasa.gov",
  "RoverName": "curiosity"
}
You can get a free API key from NASA’s developer portal.

3. Run the project
Code
dotnet run
4. Trigger the job
If you exposed the endpoint as GET:

Code
GET http://localhost:5000/api/RoverPhotos/photos
Or open Swagger UI:

Code
http://localhost:5000/swagger
Example output
json
[
  {
    "date": "2017-02-27T00:00:00",
    "totalPhotosFromApi": 1,
    "downloadedCount": 1,
    "error": null