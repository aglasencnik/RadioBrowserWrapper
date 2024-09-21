using System;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a click on a station.
    /// </summary>
    public class StationClick
    {
        /// <summary>
        /// Gets or sets the station UUID.
        /// </summary>
        [JsonPropertyName("stationuuid")]
        public string StationUuid { get; set; }

        /// <summary>
        /// Gets or sets the click UUID.
        /// </summary>
        [JsonPropertyName("clickuuid")]
        public string ClickUuid { get; set; }

        /// <summary>
        /// Gets or sets the click date time.
        /// </summary>
        [JsonPropertyName("clicktimestamp_iso8601")]
        public DateTime? ClickDateTime { get; set; }
    }
}
