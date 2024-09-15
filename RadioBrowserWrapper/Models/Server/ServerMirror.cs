using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the mirror of the server.
    /// </summary>
    public class ServerMirror
    {
        /// <summary>
        /// Gets or sets the IP address of the mirror.
        /// </summary>
        [JsonPropertyName("ip")]
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the name of the mirror.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
