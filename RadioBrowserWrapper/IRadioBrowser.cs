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
    }
}
