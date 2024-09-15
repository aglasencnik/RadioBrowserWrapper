using RadioBrowserWrapper.Models;
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
    }
}
