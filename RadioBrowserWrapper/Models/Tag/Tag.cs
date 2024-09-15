using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station count of the tag.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
