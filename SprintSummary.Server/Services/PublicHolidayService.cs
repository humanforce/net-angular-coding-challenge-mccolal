using AngularApp3.Server.Helpers;
using SprintSummary.server.Helpers;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.PublicHolidays;
using SprintSummary.server.Models.Regionn;
using SprintSummary.server.Repository;
using SprintSummary.Server.Models;

namespace AngularApp3.Server.Services
{
    public class PublicHolidayService : IPublicHolidayService
    {
        private PublicHolidayRepository _publicHolidayRepository;
        private IConfiguration _configuration;
        public PublicHolidayService(IConfiguration configuration) {
            this._publicHolidayRepository = new PublicHolidayRepository();
            this._configuration = configuration;
        }

        public List<PublicHolidayModel> GetPublicHolidaysByRegion(Region region)
        {
            return
               GetAllPublicHolidays()
               .FindAll(ph =>
                   ph.region.ToLower() == region.Name.ToLower())
               .ToList();
        }

        public List<PublicHolidayModel> GetPublicHolidaysByRegion(string name)
        {
            Regions regions = new Regions();
            Region regionToFind = regions.RegionList.Find(r => r.Name.ToLower() == name.ToLower());

            return
               GetPublicHolidaysByRegion(regionToFind);
        }

        public List<PublicHolidayTotalForCountryModel> GetPublicHolidayCountForCountryBetweenDates(DateTime startDate, DateTime endDate)
        {
            Regions regions = new Regions();
            
            List<PublicHolidayModel> allPHs = GetAllPublicHolidaysBetweenDates(startDate,endDate);

            var regionPublicHolidayCount = allPHs
                .GroupBy(i => i.region)
                .Select(grp => new PublicHolidayTotalForCountryModel
                {
                    name = grp.Key,
                    count = grp.Count()
                })
                .ToList();

            // Add a manual PH count for regions/countries that do not have any public holidays 
            // to avoid null errors
            regions.RegionList.ForEach(region =>
            {
                if (allPHs != null && !allPHs.Any(i => i.region.ToLower() == region.Name.ToLower()))
                {
                    regionPublicHolidayCount.Add(new PublicHolidayTotalForCountryModel
                    {
                        name = region.Name,
                        count = 0
                    });
                } 
                
            });
            return regionPublicHolidayCount;
        }

        public List<PublicHolidayModel> GetAllPublicHolidays()
        {
            UseAPIOverMockData useAPIOverMockData = new UseAPIOverMockData();
            _configuration.GetSection(UseAPIOverMockData.UseAPIOverMockService).Bind(useAPIOverMockData);
            
            if (useAPIOverMockData.IsEnabled && File.Exists(Paths.GoogleCalendarAPIKey))
            {
                GoogleCalendarAPIHTTPHelper http = new GoogleCalendarAPIHTTPHelper();
                return http.GetAllPublicHolidaysAsync().Result;
            }
            else
            {
                return _publicHolidayRepository.GetAllPublicHolidays();
            }
        }

        public List<PublicHolidayModel> GetAllPublicHolidaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return GetAllPublicHolidays()
                .FindAll(ph =>
                    ph.startDate >= startDate && ph.endDate <= endDate)
                .ToList();
        }

        public List<PublicHolidayModel> GetAllPublicHolidayByRegionBetweenDates(Region region, DateTime startDate, DateTime endDate)
        {
            return GetAllPublicHolidays()
                .FindAll(ph =>
                    ph.startDate >= startDate && ph.endDate <= endDate && ph.region.ToLower() == region?.Name?.ToLower())
                .ToList();
        }

        public List<PublicHolidayModel> GetAllPublicHolidayByRegionBetweenDates(string region, DateTime startDate, DateTime endDate)
        {
            Regions regions = new Regions();
            Region regionToFind = regions.RegionList.Find(r => r.Name.ToLower() == region.ToLower());
            return GetAllPublicHolidayByRegionBetweenDates(regionToFind, startDate, endDate);
        }


    }
}

