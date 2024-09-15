using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a country state.
    /// </summary>
    public class CountryState
    {
        /// <summary>
        /// Gets or sets the name of the country state.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country name of the country state.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the number of stations in the country state.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
