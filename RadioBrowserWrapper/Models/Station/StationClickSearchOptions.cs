using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the options for a station click search.
    /// </summary>
    public class StationClickSearchOptions
    {
        /// <summary>
        /// Gets or sets the last click UUID.
        /// </summary>
        [JsonPropertyName("lastclickuuid")]
        public string LastClickUuid { get; set; } = null;

        /// <summary>
        /// Gtes or sets the history entries from the last number of seconds.
        /// </summary>
        [JsonPropertyName("seconds")]
        public int Seconds { get; set; } = 0;
    }
}
