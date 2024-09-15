using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the statistics of the server.
    /// </summary>
    public class ServerStats
    {
        /// <summary>
        /// Gets or sets the supported version.
        /// </summary>
        [JsonPropertyName("supported_version")]
        public int SupportedVersion { get; set; }

        /// <summary>
        /// Gets or sets the software version.
        /// </summary>
        [JsonPropertyName("software_version")]
        public string SoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the server status.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the number of stations.
        /// </summary>
        [JsonPropertyName("stations")]
        public int Stations { get; set; }

        /// <summary>
        /// Gets or sets the number of stations broken.
        /// </summary>
        [JsonPropertyName("stations_broken")]
        public int StationsBroken { get; set; }

        /// <summary>
        /// Gets or sets the number of tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public int Tags { get; set; }

        /// <summary>
        /// Gets or sets the number of clicks in the last hour.
        /// </summary>
        [JsonPropertyName("clicks_last_hour")]
        public int ClicksLastHour { get; set; }

        /// <summary>
        /// Gets or sets the number of clicks in the last day.
        /// </summary>
        [JsonPropertyName("clicks_last_day")]
        public int ClicksLastDay { get; set; }

        /// <summary>
        /// Gets or sets the number of languages.
        /// </summary>
        [JsonPropertyName("languages")]
        public int Languages { get; set; }

        /// <summary>
        /// Gets or sets the number of countries.
        /// </summary>
        [JsonPropertyName("countries")]
        public int Countries { get; set; }
    }
}
