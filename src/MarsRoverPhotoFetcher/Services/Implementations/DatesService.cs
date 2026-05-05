using MarsRoverPhotoFetcher.Services.Interfaces;

namespace MarsRoverPhotoFetcher.Services.Implementations
{
    public class DatesService : IDatesService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDateParser _dateParser;
        private readonly ILogger<DatesService> _logger;


        public DatesService(IWebHostEnvironment env, IDateParser dateParser, ILogger<DatesService> logger)
        {
            _env = env;
            _dateParser = dateParser;
            _logger = logger;
        }

        public async Task<List<DateTime>> GetDatesAsync()
        {
            _logger.LogInformation("GetDatesAsync started");

            try
            {
                var filePath = Path.Combine(_env.ContentRootPath, "Data/dates.txt");

                if (!File.Exists(filePath))
                {
                    _logger.LogError("dates.txt not found at path: {Path}", filePath);
                    throw new FileNotFoundException("dates.txt not found", filePath);
                }

                var lines = await File.ReadAllLinesAsync(filePath);

                if (lines.Length == 0)
                {
                    _logger.LogWarning("dates.txt is empty");
                    return new List<DateTime>();
                }

                var dates = new List<DateTime>();

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var normalized = _dateParser.Normalize(line);

                    if (normalized == null)
                    {
                        _logger.LogWarning("Skipping invalid date: {Line}", line);
                        continue;
                    }

                    if (DateTime.TryParse(normalized, out var parsed))
                    {
                        dates.Add(parsed);
                    }
                    else
                    {
                        _logger.LogWarning("Failed to parse normalized date: {Normalized}", normalized);
                    }
                }

                _logger.LogInformation("Parsed {Count} valid dates", dates.Count);

                return dates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetDatesAsync");
                throw;
            }
        }

    }

}
