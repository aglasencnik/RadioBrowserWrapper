using Microsoft.Extensions.DependencyInjection;
using System;

namespace RadioBrowserWrapper
{
    /// <summary>
    /// RadioBrowser service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the RadioBrowser service to the service collection.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void AddRadioBrowser(this IServiceCollection services)
        {
            services.AddSingleton<IRadioBrowser, RadioBrowser>();
        }

        /// <summary>
        /// Adds the RadioBrowser service to the service collection.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="options">RadioBrowser options</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if options are null</exception>
        public static void AddRadioBrowser(this IServiceCollection services, Action<RadioBrowserOptions> options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(RadioBrowserOptions));

            services.Configure(options);
            services.AddSingleton<IRadioBrowser, RadioBrowser>();
        }
    }
}
