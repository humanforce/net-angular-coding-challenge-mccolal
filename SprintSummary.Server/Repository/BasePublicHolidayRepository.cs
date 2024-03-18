using AngularApp3.Server.Controllers;

namespace SprintSummary.server.Repository
{
    public class BasePublicHolidayRepository : BaseRepository
    {
        // Assumption: As the google calendar API calls and mock data source is unique per region/country,
        // I have used a BasePublicHolidayRepository so a separate class can call this base class for each
        // region.
        public BasePublicHolidayRepository(string path) : base(path)
        {

        }

    }
}
