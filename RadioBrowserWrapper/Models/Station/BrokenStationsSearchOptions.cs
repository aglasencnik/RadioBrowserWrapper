using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the search options for broken stations.
    /// </summary>
    public class BrokenStationsSearchOptions
    {
        /// <summary>
        /// Gets or sets the offset of the results.
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Gets or sets the top number limit of the results.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 100000;
    }
}
