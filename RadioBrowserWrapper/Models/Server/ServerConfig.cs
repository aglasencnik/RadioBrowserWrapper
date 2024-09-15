using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents the configuration of the server.
    /// </summary>
    public class ServerConfig
    {
        /// <summary>
        /// Gets or sets whether the checks are enabled.
        /// </summary>
        [JsonPropertyName("check_enabled")]
        public bool CheckEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether the prometheus exporter is enabled.
        /// </summary>
        [JsonPropertyName("prometheus_exporter_enabled")]
        public bool PrometheusExporterEnabled { get; set; }

        /// <summary>
        /// Gets or sets the pull servers.
        /// </summary>
        [JsonPropertyName("pull_servers")]
        public IEnumerable<string> PullServers { get; set; }

        /// <summary>
        /// Gets or sets the tcp timeout in seconds.
        /// </summary>
        [JsonPropertyName("tcp_timeout_seconds")]
        public int TcpTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the broken stations never working timeout in seconds.
        /// </summary>
        [JsonPropertyName("broken_stations_never_working_timeout_seconds")]
        public int BrokenStationsNeverWorkingTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the broken stations timeout in seconds.
        /// </summary>
        [JsonPropertyName("broken_stations_timeout_seconds")]
        public int BrokenStationsTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the checks timeout in seconds.
        /// </summary>
        [JsonPropertyName("checks_timeout_seconds")]
        public int ChecksTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the clicks valid timeout in seconds.
        /// </summary>
        [JsonPropertyName("click_valid_timeout_seconds")]
        public int ClicksValidTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the clicks timeout in seconds.
        /// </summary>
        [JsonPropertyName("clicks_timeout_seconds")]
        public int ClicksTimeoutSeconds { get; set; }

        /// <summary>
        /// Gets or sets the mirror pull interval in seconds.
        /// </summary>
        [JsonPropertyName("mirror_pull_interval_seconds")]
        public int MirrorPullIntervalSeconds { get; set; }

        /// <summary>
        /// Gets or sets the update caches interval in seconds.
        /// </summary>
        [JsonPropertyName("update_caches_interval_seconds")]
        public int UpdateCachesIntervalSeconds { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [JsonPropertyName("server_name")]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the server location.
        /// </summary>
        [JsonPropertyName("server_location")]
        public string ServerLocation { get; set; }

        /// <summary>
        /// Gets or sets the server country code.
        /// </summary>
        [JsonPropertyName("server_country_code")]
        public string ServerCountryCode { get; set; }

        /// <summary>
        /// Gets or sets the check retries count.
        /// </summary>
        [JsonPropertyName("check_retries")]
        public int CheckRetries { get; set; }

        /// <summary>
        /// Gets or sets the check batch size.
        /// </summary>
        [JsonPropertyName("check_batchsize")]
        public int CheckBatchSize { get; set; }

        /// <summary>
        /// Gets or sets the check pause in seconds.
        /// </summary>
        [JsonPropertyName("check_pause_seconds")]
        public int CheckPauseSeconds { get; set; }

        /// <summary>
        /// Gets or sets the number of api threads.
        /// </summary>
        [JsonPropertyName("api_threads")]
        public int ApiThreads { get; set; }

        /// <summary>
        /// Gets or sets the cache type.
        /// </summary>
        [JsonPropertyName("cache_type")]
        public string CacheType { get; set; }

        /// <summary>
        /// Gets or sets the cache ttl.
        /// </summary>
        [JsonPropertyName("cache_ttl")]
        public int CacheTTL { get; set; }

        /// <summary>
        /// Gets or sets the language replace filepath.
        /// </summary>
        [JsonPropertyName("language_replace_filepath")]
        public string LanguageReplaceFilepath { get; set; }

        /// <summary>
        /// Gets or sets the language to code filepath.
        /// </summary>
        [JsonPropertyName("language_to_code_filepath")]
        public string LanguageToCodeFilepath { get; set; }
    }
}
