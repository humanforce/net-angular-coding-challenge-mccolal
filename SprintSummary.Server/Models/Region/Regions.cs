using AngularApp3.Server.Helpers;

namespace SprintSummary.server.Models.RegionItem
{
    public class Regions
    {
        public List<Region> RegionList { get; set; }

        public Regions()
        {
            RegionList = new List<Region>()
            {
                new Region()
                {
                    Name = "Australia",
                    Id = 0,
                    GoogleCalendarAPIURL = "https://www.googleapis.com/calendar/v3/calendars/en.australian%23holiday%40group.v.calendar.google.com/events?key=",
                    FileURL = Paths.AustraliaPublicHolidayJson
                },
                new Region()
                {
                    Name = "Phillipines",
                    Id = 1,
                    GoogleCalendarAPIURL = "https://www.googleapis.com/calendar/v3/calendars/en.philippines%23holiday%40group.v.calendar.google.com/events?key=",
                    FileURL = Paths.PhillipinesPublicHolidayJson
                },
                new Region()
                {
                    Name = "Packistan",
                    Id = 2,
                    GoogleCalendarAPIURL = "https://www.googleapis.com/calendar/v3/calendars/en.pk%23holiday%40group.v.calendar.google.com/events?key=",
                    FileURL = Paths.PakistanPublicHolidayJson
                }
            };
        }
    }
}
