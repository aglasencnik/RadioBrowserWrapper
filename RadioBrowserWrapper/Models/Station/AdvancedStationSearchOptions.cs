using RadioBrowserWrapper.Converters;
using RadioBrowserWrapper.Enums;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the options for an advanced station search.
    /// </summary>
    public class AdvancedStationSearchOptions
    {
        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the station name is exact.
        /// </summary>
        [JsonPropertyName("nameExact")]
        public bool IsExactName { get; set; } = false;

        /// <summary>
        /// Gets or sets the station country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets whether the station country is exact.
        /// </summary>
        [JsonPropertyName("countryExact")]
        public bool IsExactCountry { get; set; } = false;

        /// <summary>
        /// Gets or sets the station country code.
        /// </summary>
        [JsonPropertyName("countrycode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the station state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets whether the station state is exact.
        /// </summary>
        [JsonPropertyName("stateExact")]
        public bool IsExactState { get; set; } = false;

        /// <summary>
        /// Gets or sets the station language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets whether the station language is exact.
        /// </summary>
        [JsonPropertyName("languageExact")]
        public bool IsExactLanguage { get; set; } = false;

        /// <summary>
        /// Gets or sets the station tags.
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets whether the station tags are exact.
        /// </summary>
        [JsonPropertyName("tagExact")]
        public bool IsExactTag { get; set; } = false;

        /// <summary>
        /// Gets or sets the station tags seperated by commas.
        /// </summary>
        [JsonPropertyName("tagList")]
        public string TagList { get; set; }

        /// <summary>
        /// Gets or sets the station codec.
        /// </summary>
        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// Gets or sets the station bitrate.
        /// </summary>
        [JsonPropertyName("bitrateMin")]
        public int MinBitrate { get; set; } = 0;

        /// <summary>
        /// Gets or sets the station bitrate.
        /// </summary>
        [JsonPropertyName("bitrateMax")]
        public int MaxBitrate { get; set; } = 1000000;

        /// <summary>
        /// Gets or sets whether the station has geo info.
        /// </summary>
        [JsonPropertyName("has_geo_info")]
        [JsonConverter(typeof(CustomEnumConverter<StationInfo>))]
        public StationInfo HasGeoInfo { get; set; } = StationInfo.True;

        /// <summary>
        /// Gets or sets whether the station has extended info.
        /// </summary>
        [JsonPropertyName("has_extended_info")]
        [JsonConverter(typeof(CustomEnumConverter<StationInfo>))]
        public StationInfo HasExtendedInfo { get; set; } = StationInfo.True;

        /// <summary>
        /// Gets or sets whether the station is https.
        /// </summary>
        [JsonPropertyName("is_https")]
        [JsonConverter(typeof(CustomEnumConverter<StationInfo>))]
        public StationInfo IsHttps { get; set; } = StationInfo.True;

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
