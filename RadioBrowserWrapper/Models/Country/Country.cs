using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a country.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ISO_3166_1 country code.
        /// </summary>
        [JsonPropertyName("iso_3166_1")]
        public string ISO_3166_1 { get; set; }

        /// <summary>
        /// Gets or sets the number of stations in the country.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
