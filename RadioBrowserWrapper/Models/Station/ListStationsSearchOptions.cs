using RadioBrowserWrapper.Converters;
using RadioBrowserWrapper.Enums;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the search options for a list of stations.
    /// </summary>
    public class ListStationsSearchOptions
    {
        /// <summary>
        /// Gets or sets the order of the results.
        /// </summary>
        [JsonPropertyName("order")]
        [JsonConverter(typeof(CustomEnumConverter<StationOrder>))]
        public StationOrder Order { get; set; } = StationOrder.Name;

        /// <summary>
        /// Gets or sets whether to reverse the results.
        /// </summary>
        [JsonPropertyName("reverse")]
        public bool Reverse { get; set; } = false;

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

        /// <summary>
        /// Gets or sets whether to not count broken stations.
        /// </summary>
        [JsonPropertyName("hidebroken")]
        public bool HideBroken { get; set; } = false;
    }
}
