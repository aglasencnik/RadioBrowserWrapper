using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;

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

        #endregion

        #region Methods



        #endregion
    }
}
