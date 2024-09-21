using RadioBrowserWrapper.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RadioBrowserWrapper
{
    /// <summary>
    /// Represents the RadioBrowser service.
    /// </summary>
    public interface IRadioBrowser
    {
        #region Codecs

        /// <summary>
        /// Gets the available codecs.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Simple search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Codec"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Codec>> GetCodecsAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        #endregion

        #region Countries

        /// <summary>
        /// Gets the available countries.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Country"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Country>> GetCountriesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the available country codes.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="CountryCode"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        [Obsolete("DEPRECATED: Please use countries instead of country codes. It has name and countrycode information.")]
        Task<IEnumerable<CountryCode>> GetCountryCodesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the available country states.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="CountryState"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<CountryState>> GetCountryStatesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the available country states by country.
        /// </summary>
        /// <param name="country">Country</param>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="CountryState"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<CountryState>> GetCountryStatesByCountryAsync(string country, string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        #endregion

        #region Languages

        /// <summary>
        /// Gets the available languages.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Simple search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Language"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Language>> GetLanguagesAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        #endregion

        #region Tags

        /// <summary>
        /// Gets the available tags.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="searchOptions">Simple search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Tag"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Tag>> GetTagsAsync(string filter = null, SimpleSearchOptions searchOptions = null, CancellationToken cancellation = default);

        #endregion

        #region Server Info

        /// <summary>
        /// Gets the server statistics.
        /// </summary>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// Server statistics.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<ServerStats> GetServerStatsAsync(CancellationToken cancellation = default);

        /// <summary>
        /// Gets the server mirrors.
        /// </summary>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of server mirrors.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<ServerMirror>> GetServerMirrorsAsync(CancellationToken cancellation = default);

        /// <summary>
        /// Gets the server configuration.
        /// </summary>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// Server configuration.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<ServerConfig> GetServerConfigAsync(CancellationToken cancellation = default);

        /// <summary>
        /// Gets the Prometheus monitoring result.
        /// </summary>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of Prometheus monitoring result lines.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<string>> GetPrometheusMonitoringResultAsync(CancellationToken cancellation = default);

        #endregion

        #region Stations

        #region List

        /// <summary>
        /// Gets all the stations.
        /// </summary>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetAllStationsAsync(ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by name.
        /// </summary>
        /// <param name="name">Station name</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByNameAsync(string name, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact name.
        /// </summary>
        /// <param name="exactName">Exact station name</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactNameAsync(string exactName, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by codec.
        /// </summary>
        /// <param name="codec">Station codec</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByCodecAsync(string codec, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact codec.
        /// </summary>
        /// <param name="exactCodec">Exact station codec</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactCodecAsync(string exactCodec, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by country.
        /// </summary>
        /// <param name="country">Station country</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByCountryAsync(string country, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact country.
        /// </summary>
        /// <param name="exactCountry">Exact station country</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactCountryAsync(string exactCountry, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact country code.
        /// </summary>
        /// <param name="exactCountryCode">Exact station country code</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactCountryCodeAsync(string exactCountryCode, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by state.
        /// </summary>
        /// <param name="state">Station state</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByStateAsync(string state, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact state.
        /// </summary>
        /// <param name="exactState">Exact station state</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactStateAsync(string exactState, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by language.
        /// </summary>
        /// <param name="language">Station language</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByLanguageAsync(string language, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact language.
        /// </summary>
        /// <param name="exactLanguage">Exact station language</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactLanguageAsync(string exactLanguage, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by tag.
        /// </summary>
        /// <param name="tag">Station tag</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByTagAsync(string tag, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by exact tag.
        /// </summary>
        /// <param name="exactTag">Exact station tag</param>
        /// <param name="searchOptions">List stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByExactTagAsync(string exactTag, ListStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the station checks.
        /// </summary>
        /// <param name="stationUuid">Station uuid</param>
        /// <param name="searchOptions">Station check search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="StationCheck"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<StationCheck>> GetStationCheckResultsAsync(string stationUuid = null, StationCheckSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the station clicks.
        /// </summary>
        /// <param name="stationUuid">Station uuid</param>
        /// <param name="searchOptions">Station click search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="StationClick"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<StationClick>> GetStationClicksAsync(string stationUuid = null, StationClickSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the station check steps.
        /// </summary>
        /// <param name="uuids">Station uuids</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="StationCheckStep"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<StationCheckStep>> GetStationCheckStepsAsync(IEnumerable<string> uuids, CancellationToken cancellation = default);

        /// <summary>
        /// Searches the stations.
        /// </summary>
        /// <param name="searchOptions">Advanced station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> SearchStationsAsync(AdvancedStationSearchOptions searchOptions, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the station by uuid.
        /// </summary>
        /// <param name="stationUuid">Station uuid</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A <see cref="Station"/> object.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<Station> GetStationByUuidAsync(string stationUuid, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by uuids.
        /// </summary>
        /// <param name="uuids">Station uuids</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> SearchStationsByUuid(IEnumerable<string> uuids, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the stations by url.
        /// </summary>
        /// <param name="url">Station url</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetStationsByUrlAsync(string url, CancellationToken cancellation = default);

        #endregion

        #region Search

        /// <summary>
        /// Gets the top stations by clicks.
        /// </summary>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByClicksAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the top stations by clicks.
        /// </summary>
        /// <param name="stationCount">Station count</param>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByClicksAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the top stations by votes.
        /// </summary>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByVotesAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the top stations by votes.
        /// </summary>
        /// <param name="stationCount">Station count</param>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByVotesAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the top stations by recent clicks.
        /// </summary>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByRecentClicksAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the top stations by recent clicks.
        /// </summary>
        /// <param name="stationCount">Station count</param>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetTopStationsByRecentClicksAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the recently changed stations.
        /// </summary>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetRecentlyChangedStationsAsync(StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the recently changed stations.
        /// </summary>
        /// <param name="stationCount">Station count</param>
        /// <param name="searchOptions">Station search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetRecentlyChangedStationsAsync(int stationCount, StationSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the old versions of stations.
        /// </summary>
        /// <param name="stationUuid">Station Uuid</param>
        /// <param name="searchOptions">Old versions of stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetOldVersionsOfStationsAsync(string stationUuid = null, OldVersionsOfStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the broken stations.
        /// </summary>
        /// <param name="searchOptions">Broken stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetBrokenStationsAsync(BrokenStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        /// <summary>
        /// Gets the broken stations.
        /// </summary>
        /// <param name="stationCount">Station count</param>
        /// <param name="searchOptions">Broken stations search options</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// A collection of <see cref="Station"/>.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<IEnumerable<Station>> GetBrokenStationsAsync(int stationCount, BrokenStationsSearchOptions searchOptions = null, CancellationToken cancellation = default);

        #endregion

        #region Modify

        /// <summary>
        /// Clicks a station.
        /// </summary>
        /// <param name="stationUuid">Station Uuid</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// Station click counter response.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<StationClickCounterResponse> ClickStationAsync(string stationUuid, CancellationToken cancellation = default);

        /// <summary>
        /// Votes a station.
        /// </summary>
        /// <param name="stationUuid">Station Uuid</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// Station vote response.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<StationVoteResponse> VoteStationAsync(string stationUuid, CancellationToken cancellation = default);

        /// <summary>
        /// Adds a new station.
        /// </summary>
        /// <param name="creationRequest">Station creation request</param>
        /// <param name="cancellation">Cancellation token</param>
        /// <returns>
        /// Station creation result.
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task<StationCreationResult> AddStationAsync(StationCreationRequest creationRequest, CancellationToken cancellation = default);

        #endregion

        #endregion
    }
}
