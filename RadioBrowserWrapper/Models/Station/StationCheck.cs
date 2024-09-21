using RadioBrowserWrapper.Converters;
using System;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a station check.
    /// </summary>
    public class StationCheck
    {
        /// <summary>
        /// Gets or sets the station check UUID.
        /// </summary>
        [JsonPropertyName("checkuuid")]
        public string CheckUuid { get; set; }

        /// <summary>
        /// Gets or sets the station UUID.
        /// </summary>
        [JsonPropertyName("stationuuid")]
        public string StationUuid { get; set; }

        /// <summary>
        /// Gets or sets the DNS name of the stream.
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

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
        /// Gets or sets whether the station is HSL.
        /// </summary>
        [JsonPropertyName("hls")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsHLS { get; set; }

        /// <summary>
        /// Gets or sets whether the station is OK.
        /// </summary>
        [JsonPropertyName("ok")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsOK { get; set; }

        /// <summary>
        /// Gets or sets the check creation timestamp.
        /// </summary>
        [JsonPropertyName("timestamp_iso8601")]
        public DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Gets or sets the url cache.
        /// </summary>
        [JsonPropertyName("urlcache")]
        public string UrlCache { get; set; }

        /// <summary>
        /// Gets or sets whether meta info overrides the database.
        /// </summary>
        [JsonPropertyName("metainfo_overrides_database")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool MetaInfoOverridesDatabase { get; set; }

        /// <summary>
        /// Gets or sets whether the station is public.
        /// </summary>
        [JsonPropertyName("public")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the station name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the station tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the station country code.
        /// </summary>
        [JsonPropertyName("countrycode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the country subdivision code.
        /// </summary>
        [JsonPropertyName("countrysubdivisioncode")]
        public string CountrySubdivisionCode { get; set; }

        /// <summary>
        /// Gets or sets the homepage url.
        /// </summary>
        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets the station favicon.
        /// </summary>
        [JsonPropertyName("favicon")]
        public string Favicon { get; set; }

        /// <summary>
        /// Gets or sets the station loadbalancer.
        /// </summary>
        [JsonPropertyName("loadbalancer")]
        public string Loadbalancer { get; set; }

        /// <summary>
        /// Gets or sets the server software.
        /// </summary>
        [JsonPropertyName("server_software")]
        public string ServerSoftware { get; set; }

        /// <summary>
        /// Gets or sets the station sampling.
        /// </summary>
        [JsonPropertyName("sampling")]
        public uint? Sampling { get; set; }

        /// <summary>
        /// Gets or sets the timing in ms.
        /// </summary>
        [JsonPropertyName("timing_ms")]
        public uint? TimingMS { get; set; }

        /// <summary>
        /// Gets or sets the station language codes.
        /// </summary>
        [JsonPropertyName("languagecodes")]
        public string LanguageCodes { get; set; }

        /// <summary>
        /// Gets or sets whether there has been an SSL error.
        /// </summary>
        [JsonPropertyName("ssl_error")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool SSLError { get; set; }

        /// <summary>
        /// Gets or sets the station latitude.
        /// </summary>
        [JsonPropertyName("geo_lat")]
        public double? GeoLat { get; set; }

        /// <summary>
        /// Gets or sets the station longitude.
        /// </summary>
        [JsonPropertyName("geo_long")]
        public double? GeoLong { get; set; }
    }
}
