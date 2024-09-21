using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a station creation request.
    /// </summary>
    public class StationCreationRequest
    {
        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the station homepage.
        /// </summary>
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets the station favicon.
        /// </summary>
        [JsonPropertyName("favicon")]
        public string Favicon { get; set; }

        /// <summary>
        /// Gets or sets the station country code.
        /// </summary>
        [JsonPropertyName("countrycode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the station state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the station language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the station tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the station geo latitude.
        /// </summary>
        [JsonPropertyName("geo_lat")]
        public double? GeoLat { get; set; }

        /// <summary>
        /// Gets or sets the station geo longitude.
        /// </summary>
        [JsonPropertyName("geo_long")]
        public double? GeoLong { get; set; }
    }
}
