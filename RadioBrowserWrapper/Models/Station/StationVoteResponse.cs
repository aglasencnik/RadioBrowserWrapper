using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the response of a station vote.
    /// </summary>
    public class StationVoteResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the vote was successful.
        /// </summary>
        [JsonPropertyName("ok")]
        public bool IsOk { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
