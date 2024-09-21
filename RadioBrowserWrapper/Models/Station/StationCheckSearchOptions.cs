using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    public class StationCheckSearchOptions
    {
        /// <summary>
        /// Gets or sets the last check UUID.
        /// </summary>
        [JsonPropertyName("lastcheckuuid")]
        public string LastCheckUuid { get; set; } = null;

        /// <summary>
        /// Gtes or sets the history entries from the last number of seconds.
        /// </summary>
        [JsonPropertyName("seconds")]
        public int Seconds { get; set; } = 0;

        /// <summary>
        /// Gets or sets the top number limit of the results.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 999999;
    }
}
