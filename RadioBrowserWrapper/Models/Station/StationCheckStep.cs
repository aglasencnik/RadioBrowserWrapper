using System;
using System.Text.Json.Serialization;

namespace RadioBrowserWrapper.Models
{
    /// <summary>
    /// Represents a step in the station check process.
    /// </summary>
    public class StationCheckStep
    {
        /// <summary>
        /// Gets or sets the UUID of the step.
        /// </summary>
        [JsonPropertyName("stepuuid")]
        public string StepUuid { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the parent step.
        /// </summary>
        [JsonPropertyName("parent_stepuuid")]
        public string ParentStepUuid { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the check.
        /// </summary>
        [JsonPropertyName("checkuuid")]
        public string CheckUuid { get; set; }

        /// <summary>
        /// Gets or sets the UUID of the station.
        /// </summary>
        [JsonPropertyName("stationuuid")]
        public string StationUuid { get; set; }

        /// <summary>
        /// Gets or sets the URL of the step.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the type of the URL.
        /// </summary>
        [JsonPropertyName("urltype")]
        public string UrlType { get; set; }

        /// <summary>
        /// Gets or sets the error of the step.
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the step.
        /// </summary>
        [JsonPropertyName("creation_iso8601")]
        public DateTime? CreationDateTime { get; set; }
    }
}
