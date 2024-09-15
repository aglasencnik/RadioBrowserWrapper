using Microsoft.Extensions.Options;
using RadioBrowserWrapper.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RadioBrowserWrapper
{
    /// <inheritdoc />
    public class RadioBrowser : IRadioBrowser
    {
        #region Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        public RadioBrowser(RadioBrowserOptions options)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(EnsureValidUrl(options.ServerUrl, "http")),
                DefaultRequestHeaders =
                {
                    { "User-Agent", options.UserAgent }
                }
            };
        }

        public RadioBrowser() : this(new RadioBrowserOptions { ServerUrl = GetRadioBrowserServerUrl() }) { }

        public RadioBrowser(IOptions<RadioBrowserOptions> options) : this(options.Value) { }

        #endregion

        #region Utils

        private static string GetRadioBrowserServerUrl()
        {
            // Get fastest ip of dns
            var baseUrl = @"all.api.radio-browser.info";
            var ips = Dns.GetHostAddresses(baseUrl);
            var lastRoundTripTime = long.MaxValue;
            var searchUrl = @"de1.api.radio-browser.info"; // Fallback
            foreach (var ipAddress in ips)
            {
                var reply = new Ping().Send(ipAddress);
                if (reply != null &&
                    reply.RoundtripTime < lastRoundTripTime)
                {
                    lastRoundTripTime = reply.RoundtripTime;
                    searchUrl = ipAddress.ToString();
                }
            }

            // Get clean name
            var hostEntry = Dns.GetHostEntry(searchUrl);
            if (!string.IsNullOrEmpty(hostEntry.HostName))
                searchUrl = hostEntry.HostName;

            return searchUrl;
        }

        private string EnsureValidUrl(string serverUrl, string defaultScheme = "https")
        {
            if (Uri.IsWellFormedUriString(serverUrl, UriKind.Absolute))
                return serverUrl;

            return $"{defaultScheme}://{serverUrl}";
        }

        private async Task<string> GetAsStringAsync<TRequest>(string uri, TRequest requestModel, CancellationToken cancellation)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
                {
                    if (requestModel != null)
                    {
                        var json = JsonSerializer.Serialize(requestModel);
                        request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    }

                    using (var response = await _httpClient.SendAsync(request, cancellation))
                    {
                        if (!response.IsSuccessStatusCode)
                            return default;

                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch
            {
                return default;
            }
        }

        private async Task<TResponse> GetAsync<TResponse, TRequest>(string uri, TRequest requestModel, CancellationToken cancellation)
        {
            var result = await GetAsStringAsync(uri, requestModel, cancellation);

            try
            {
                return result == null ? default : JsonSerializer.Deserialize<TResponse>(result);
            }
            catch
            {
                return default;
            }
        }

        #endregion

        #region Methods

        #region Codecs

        /// <inheritdoc />
        public async Task<IEnumerable<Codec>> GetCodecsAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Codec>, SimpleSearchOptions>($"/json/codecs/{filter}", searchOptions, cancellation);
        }

        #endregion

        #region Languages

        /// <inheritdoc />
        public async Task<IEnumerable<Language>> GetLanguagesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Language>, SimpleSearchOptions>($"/json/languages/{filter}", searchOptions, cancellation);
        }

        #endregion

        #region Server Info

        /// <inheritdoc />
        public async Task<ServerStats> GetServerStatsAsync(CancellationToken cancellation = default)
        {
            return await GetAsync<ServerStats, object>("/json/stats", null, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ServerMirror>> GetServerMirrorsAsync(CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<ServerMirror>, object>("/json/servers", null, cancellation);
        }

        /// <inheritdoc />
        public async Task<ServerConfig> GetServerConfigAsync(CancellationToken cancellation = default)
        {
            return await GetAsync<ServerConfig, object>("/json/config", null, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetPrometheusMonitoringResultAsync(CancellationToken cancellation = default)
        {
            var result = await GetAsStringAsync<object>("/metrics", null, cancellation);
            return result?.Split('\n');
        }

        #endregion

        #endregion
    }
}
