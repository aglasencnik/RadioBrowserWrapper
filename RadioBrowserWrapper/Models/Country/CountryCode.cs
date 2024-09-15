using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a country code.
    /// </summary>
    public class CountryCode
    {
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of stations in the country.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
