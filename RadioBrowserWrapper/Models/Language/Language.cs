using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a language.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets or sets the language name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the language ISO_639 code.
        /// </summary>
        [JsonPropertyName("iso_639")]
        public string ISO_639 { get; set; }

        /// <summary>
        /// Gets or sets the number of stations that use this language.
        /// </summary>
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
