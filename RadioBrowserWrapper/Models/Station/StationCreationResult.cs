using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the result of a station creation.
    /// </summary>
    public class StationCreationResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool IsOk { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the created station UUID.
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }
    }
}
