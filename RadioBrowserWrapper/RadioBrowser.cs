using Microsoft.Extensions.Options;
using RadioBrowserWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Countries

        /// <inheritdoc />
        public async Task<IEnumerable<Country>> GetCountriesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Country>, SimpleSearchOptions>($"/json/countries/{filter}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CountryCode>> GetCountryCodesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<CountryCode>, SimpleSearchOptions>($"/json/countrycodes/{filter}", searchOptions, cancellation);
        }

        public async Task<IEnumerable<CountryState>> GetCountryStatesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<CountryState>, SimpleSearchOptions>($"/json/states/{filter}", searchOptions, cancellation);
        }

        public async Task<IEnumerable<CountryState>> GetCountryStatesByCountryAsync(string country, string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<CountryState>, SimpleSearchOptions>($"/json/states/{country}/{filter}", searchOptions, cancellation);
        }

        #endregion

        #region Languages

        /// <inheritdoc />
        public async Task<IEnumerable<Language>> GetLanguagesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Language>, SimpleSearchOptions>($"/json/languages/{filter}", searchOptions, cancellation);
        }

        #endregion

        #region Tags

        /// <inheritdoc />
        public async Task<IEnumerable<Tag>> GetTagsAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Tag>, SimpleSearchOptions>($"/json/tags/{filter}", searchOptions, cancellation);
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

        #region Stations

        #region List

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetAllStationsAsync(ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>("/json/stations", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByNameAsync(string name, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/byname/{name}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactNameAsync(string exactName, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bynameexact/{exactName}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByCodecAsync(string codec, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bycodec/{codec}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactCodecAsync(string exactCodec, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bycodecexact/{exactCodec}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByCountryAsync(string country, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bycountry/{country}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactCountryAsync(string exactCountry, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bycountryexact/{exactCountry}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactCountryCodeAsync(string exactCountryCode, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bycountrycodeexact/{exactCountryCode}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByStateAsync(string state, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bystate/{state}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactStateAsync(string exactState, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bystateexact/{exactState}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByLanguageAsync(string language, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bylanguage/{language}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactLanguageAsync(string exactLanguage, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bylanguageexact/{exactLanguage}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByTagAsync(string tag, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bytag/{tag}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByExactTagAsync(string exactTag, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, ListStationsSearchOptions>($"/json/stations/bytagexact/{exactTag}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StationCheck>> GetStationCheckResultsAsync(string stationUuid = null, StationCheckSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            var url = $"/json/checks" + ((!string.IsNullOrEmpty(stationUuid)) ? $"/{stationUuid}" : "");
            return await GetAsync<IEnumerable<StationCheck>, StationCheckSearchOptions>(url, searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StationClick>> GetStationClicksAsync(string stationUuid = null, StationClickSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            var url = $"/json/clicks" + ((!string.IsNullOrEmpty(stationUuid)) ? $"/{stationUuid}" : "");
            return await GetAsync<IEnumerable<StationClick>, StationClickSearchOptions>(url, searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StationCheckStep>> GetStationCheckStepsAsync(IEnumerable<string> uuids, CancellationToken cancellation = default)
        {
            var obj = new { uuids = string.Join(",", uuids).TrimEnd(',') };
            return await GetAsync<IEnumerable<StationCheckStep>, object>("/json/checksteps", obj, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> SearchStationsAsync(AdvancedStationSearchOptions searchOptions, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, AdvancedStationSearchOptions>("/json/stations/search", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<Station> GetStationByUuidAsync(string stationUuid, CancellationToken cancellation = default)
        {
            var obj = new { uuids = stationUuid };
            return (await GetAsync<IEnumerable<Station>, object>("/json/stations/byuuid", obj, cancellation)).FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> SearchStationsByUuid(IEnumerable<string> uuids, CancellationToken cancellation = default)
        {
            var obj = new { uuids = string.Join(",", uuids).TrimEnd(',') };
            return await GetAsync<IEnumerable<Station>, object>("/json/stations/byuuid", obj, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetStationsByUrlAsync(string url, CancellationToken cancellation = default)
        {
            var obj = new { url = url };
            return await GetAsync<IEnumerable<Station>, object>("/json/stations/byurl", obj, cancellation);
        }

        #endregion

        #region Search

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByClicksAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>("/json/stations/topclick", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByClicksAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>($"/json/stations/topclick/{stationCount}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByVotesAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>("/json/stations/topvote", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByVotesAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>($"/json/stations/topvote/{stationCount}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByRecentClicksAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>("/json/stations/lastclick", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetTopStationsByRecentClicksAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>($"/json/stations/lastclick/{stationCount}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetRecentlyChangedStationsAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>("/json/stations/lastchange", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetRecentlyChangedStationsAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, StationSearchOptions>($"/json/stations/lastchange/{stationCount}", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetOldVersionsOfStationsAsync(string stationUuid, OldVersionsOfStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            var url = $"/json/stations/changed" + ((!string.IsNullOrEmpty(stationUuid)) ? $"/{stationUuid}" : "");
            return await GetAsync<IEnumerable<Station>, OldVersionsOfStationsSearchOptions>(url, searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetBrokenStationsAsync(BrokenStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, BrokenStationsSearchOptions>("/json/stations/broken", searchOptions, cancellation);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Station>> GetBrokenStationsAsync(int stationCount, BrokenStationsSearchOptions searchOptions = null, CancellationToken cancellation = default)
        {
            return await GetAsync<IEnumerable<Station>, BrokenStationsSearchOptions>($"/json/stations/broken/{stationCount}", searchOptions, cancellation);
        }

        #endregion

        #region Modify

        /// <inheritdoc />
        public async Task<StationClickCounterResponse> ClickStationAsync(string stationUuid, CancellationToken cancellation = default)
        {
            return await GetAsync<StationClickCounterResponse, object>($"/json/url/{stationUuid}", null, cancellation) ?? new StationClickCounterResponse
            {
                IsOk = false,
                Message = "Station not found!"
            };
        }

        /// <inheritdoc />
        public async Task<StationVoteResponse> VoteStationAsync(string stationUuid, CancellationToken cancellation = default)
        {
            return await GetAsync<StationVoteResponse, object>($"/json/vote/{stationUuid}", null, cancellation) ?? new StationVoteResponse
            {
                IsOk = false,
                Message = "Station not found!"
            };
        }

        /// <inheritdoc />
        public async Task<StationCreationResult> AddStationAsync(StationCreationRequest creationRequest, CancellationToken cancellation = default)
        {
            return await GetAsync<StationCreationResult, StationCreationRequest>("/json/add", creationRequest, cancellation) ?? new StationCreationResult
            {
                IsOk = false,
                Message = "Station could not be created!"
            };
        }

        #endregion

        #endregion

        #endregion
    }
}
