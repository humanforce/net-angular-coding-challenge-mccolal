using Newtonsoft.Json;

namespace SprintSummary.server.Models
{
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        [JsonProperty("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }

    public class AppSettingsModel
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public UseAPIOverMockService useAPIOverMockService { get; set; }
    }

    public class UseAPIOverMockService
    {
        public bool IsEnabled { get; set; }
    }
}
