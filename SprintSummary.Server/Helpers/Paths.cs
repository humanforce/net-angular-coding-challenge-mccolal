using System;
using System.IO;

namespace AngularApp3.Server.Helpers
{
    public static class Paths
    {
        public static string JiraBacklogJson { 
            get => Path.Combine(Environment.CurrentDirectory, @"Data\JiraAPI\backlog.json"); 
        }


        public static string SprintsJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\JiraAPI\sprints.json");
        }

        public static string AustraliaPublicHolidayJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\GoogleCalendarAPI\australian.json");
        }

        public static string PakistanPublicHolidayJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\GoogleCalendarAPI\pakistan.json");
        }

        public static string PhillipinesPublicHolidayJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\GoogleCalendarAPI\philippines.json");
        }

        public static string JiraUsersJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\TeamMembers.json");
        }

        public static string AppSettingsJson
        {
            get => Path.Combine(Environment.CurrentDirectory, @"appsettings.json");
        }

        public static string GoogleCalendarAPIKey
        {
            get => Path.Combine(Environment.CurrentDirectory, @"Data\GoogleAPIKey.key");
        }

    }
}
