using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a codec.
    /// </summary>
    public class Codec
    {
        /// <summary>
        /// Gets or sets the codec's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the codec's station count.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
