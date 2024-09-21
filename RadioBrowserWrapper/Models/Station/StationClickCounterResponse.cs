using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the response of a station click counter.
    /// </summary>
    public class StationClickCounterResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the response is ok.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool IsOk { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the station uuid.
        /// </summary>
        [JsonPropertyName("stationuuid")]
        public string StationUuid { get; set; }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [JsonPropertyName("name")]
        public string StationName { get; set; }

        /// <summary>
        /// Gets or sets the station url.
        /// </summary>
        [JsonPropertyName("url")]
        public string StationUrl { get; set; }
    }
}
