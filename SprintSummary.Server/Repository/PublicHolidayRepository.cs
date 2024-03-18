using Newtonsoft.Json;
using SprintSummary.server.Models.PublicHolidays;
using SprintSummary.server.Models.Regionn;
using System.Dynamic;

namespace SprintSummary.server.Repository
{
    public class PublicHolidayRepository 
    {
        private List<PublicHolidayModel> _publicHolidays;

        public PublicHolidayRepository()
        {
            this._publicHolidays = new List<PublicHolidayModel>();
            Regions regions = new Regions();
            try
            {
                foreach (Region region in regions.RegionList)
                {
                    BasePublicHolidayRepository bph = new BasePublicHolidayRepository(region.FileURL);
                    string responseString = bph.Read();

                    dynamic googleAPIResponseModel = JsonConvert.DeserializeObject<ExpandoObject>(responseString);

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
            }
            catch (JsonException e)
            {
                throw new JsonException("Json Serialization Exception! " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.FileName + " could not be found! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong! " + e.Message);
            }
        }

        public List<PublicHolidayModel> GetAllPublicHolidays()
        {
            return _publicHolidays;
        }
    }
}
