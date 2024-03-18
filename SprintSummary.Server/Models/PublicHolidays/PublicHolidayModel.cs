using System;

namespace SprintSummary.server.Models.PublicHolidays
{
    // TODO get rid of this

    public class PublicHolidayModel
    {
        public string description { get; set; }
        public string summary { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string region { get; set; }

    }
}
