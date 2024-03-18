using AngularApp3.Server.Helpers;
using Newtonsoft.Json;
using SprintSummary.server.Models.PublicHolidays;
using SprintSummary.server.Models.Regionn;
using System.Dynamic;

namespace SprintSummary.server.Helpers
{
    public class GoogleCalendarAPIHTTPHelper : HTTP
    {
        private List<PublicHolidayModel>? _publicHolidays;
        private readonly string APIKEY = File.ReadAllText(Paths.GoogleCalendarAPIKey);
        public GoogleCalendarAPIHTTPHelper() : base() { }

        public async Task<List<PublicHolidayModel>> GetAllPublicHolidaysAsync()
        {
            _publicHolidays = new List<PublicHolidayModel>();
            Regions regions = new Regions();
            foreach (Region region in regions.RegionList)
            {

                string responseString = await CallURLAsync(region.GoogleCalendarAPIURL + APIKEY);

                dynamic googleAPIResponseModel = JsonConvert.DeserializeObject<ExpandoObject>(responseString);

                if (googleAPIResponseModel != null )
                {
                    foreach (var itm in googleAPIResponseModel.items)
                    {
                        PublicHolidayModel newObj = new PublicHolidayModel();

                        newObj.description = itm.description;
                        newObj.summary = itm.summary;
                        newObj.endDate = DateTime.Parse(itm.end.date);
                        newObj.startDate = DateTime.Parse(itm.start.date);
                        newObj.region = region.Name;

                        this._publicHolidays.Add(newObj);
                    }
                }
            };

            return _publicHolidays;
        }


    }
}
