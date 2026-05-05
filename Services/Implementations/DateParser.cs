using MarsRoverPhotoFetcher.Services.Interfaces;
using System.Globalization;

namespace MarsRoverPhotoFetcher.Services.Implementations
{
    public class DateParser : IDateParser
    {
        private static readonly string[] AllowedFormats =
        {
            "yyyy-MM-dd",
            "MM-dd-yyyy",
            "M-d-yyyy",
            "yyyy/MM/dd",
            "MM/dd/yyyy",
            "M/d/yyyy",
            "MM/dd/yy",
            "M/d/yy",
            "dd-MM-yyyy",
            "d-M-yyyy",
            "dd/MM/yyyy",
            "d/M/yyyy",
            "MMMM d, yyyy",
            "MMM d, yyyy",
            "MMM-dd-yyyy"
        };


        public string? Normalize(string rawDate)
        {
            if (DateTime.TryParseExact(rawDate.Trim(), AllowedFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            {
                return parsed.ToString("yyyy-MM-dd");
            }

            return null;
        }
    }
}
