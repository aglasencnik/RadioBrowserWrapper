using RadioBrowserWrapper.Converters;
using System;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a station.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Gets or sets the last change UUID.
        /// </summary>
        [JsonPropertyName("changeuuid")]
        public string ChangeUuid { get; set; }

        /// <summary>
        /// Gets or sets the station UUID.
        /// </summary>
        [JsonPropertyName("stationuuid")]
        public string StationUuid { get; set; }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the station URL resolved.
        /// </summary>
        [JsonPropertyName("url_resolved")]
        public string UrlResolved { get; set; }

        /// <summary>
        /// Gets or sets the station homepage.
        /// </summary>
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets the station favicon.
        /// </summary>
        [JsonPropertyName("favicon")]
        public string Favicon { get; set; }

        /// <summary>
        /// Gets or sets the station tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the station country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

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
        /// Gets or sets the station language.
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the station language codes.
        /// </summary>
        [JsonPropertyName("languagecodes")]
        public string LanguageCodes { get; set; }

        /// <summary>
        /// Gets or sets the station votes.
        /// </summary>
        [JsonPropertyName("votes")]
        public int Votes { get; set; }

        /// <summary>
        /// Gets or sets the last change datetime.
        /// </summary>
        [JsonPropertyName("lastchangetime_iso8601")]
        public DateTime? LastChangeDateTime { get; set; }

        /// <summary>
        /// Gets or sets the station codec.
        /// </summary>
        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// Gets or sets the station bitrate.
        /// </summary>
        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        /// <summary>
        /// Gets or sets whether the station is has HLS.
        /// </summary>
        [JsonPropertyName("hls")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsHLS { get; set; }

        /// <summary>
        /// Gets or sets whether the last check was ok.
        /// </summary>
        [JsonPropertyName("lastcheckok")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool LastCheckOk { get; set; }

        /// <summary>
        /// Gets or sets the station last check datetime.
        /// </summary>
        [JsonPropertyName("lastchecktime_iso8601")]
        public DateTime? LastCheckDateTime { get; set; }

        /// <summary>
        /// Gets or sets the station last check ok datetime.
        /// </summary>
        [JsonPropertyName("lastcheckoktime_iso8601")]
        public DateTime? LastCheckOkDateTime { get; set; }

        /// <summary>
        /// Gets or sets the station last local check datetime.
        /// </summary>
        [JsonPropertyName("lastlocalchecktime_iso8601")]
        public DateTime? LastLocalCheckDateTime { get; set; }

        /// <summary>
        /// Gets or sets the station click timestamp.
        /// </summary>
        [JsonPropertyName("clicktimestamp_iso8601")]
        public DateTime? LastClickDateTime { get; set; }

        /// <summary>
        /// Gets or sets the station click count.
        /// </summary>
        [JsonPropertyName("clickcount")]
        public int ClickCount { get; set; }

        /// <summary>
        /// Gets or sets the station click trend in the last 2 days.
        /// </summary>
        [JsonPropertyName("clicktrend")]
        public int ClickTrend { get; set; }

        /// <summary>
        /// Gets or sets whether the station has an SSL error.
        /// </summary>
        [JsonPropertyName("ssl_error")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsSSLError { get; set; }

        /// <summary>
        /// Gets or sets the station geo latitude.
        /// </summary>
        [JsonPropertyName("geo_lat")]
        public double? GeoLat { get; set; }

        /// <summary>
        /// Gets or sets the station geo longitude.
        /// </summary>
        [JsonPropertyName("geo_long")]
        public double? GeoLong { get; set; }

        /// <summary>
        /// Gets or sets whether the station has extended info.
        /// </summary>
        [JsonPropertyName("has_extended_info")]
        public bool HasExtendedInfo { get; set; }
    }
}
