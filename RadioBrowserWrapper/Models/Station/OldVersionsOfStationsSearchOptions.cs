using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the search options for old versions of stations.
    /// </summary>
    public class OldVersionsOfStationsSearchOptions
    {
        /// <summary>
        /// Gets or sets the last change Uuid.
        /// </summary>
        public string LastChangeUuid { get; set; } = null;

        /// <summary>
        /// Gets or sets the top number limit of the results.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 999999;
    }
}
