using SprintSummary.server.Models.PublicHolidays;
using SprintSummary.server.Models.Regionn;

namespace SprintSummary.server.Models.Interfaces
{
    public interface IPublicHolidayService
    {
        public List<PublicHolidayModel> GetPublicHolidaysByRegion(Region region);

        public List<PublicHolidayModel> GetPublicHolidaysByRegion(string name);
        public List<PublicHolidayTotalForCountryModel> GetPublicHolidayCountForCountryBetweenDates(DateTime startDate, DateTime endDate);

        public List<PublicHolidayModel> GetAllPublicHolidays();

        public List<PublicHolidayModel> GetAllPublicHolidaysBetweenDates(DateTime startDate, DateTime endDate);

        public List<PublicHolidayModel> GetAllPublicHolidayByRegionBetweenDates(Region region, DateTime startDate, DateTime endDate);

        public List<PublicHolidayModel> GetAllPublicHolidayByRegionBetweenDates(string region, DateTime startDate, DateTime endDate);
    }
}
