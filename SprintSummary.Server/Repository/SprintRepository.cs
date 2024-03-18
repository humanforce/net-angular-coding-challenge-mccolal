using AngularApp3.Server.Helpers;

using Newtonsoft.Json;
using SprintSummary.server.Models.RawResponses;
using SprintSummary.server.Models.Sprint;

namespace SprintSummary.server.Repository
{
    public class SprintRepository : BaseRepository
    {
        private List<SprintModel> _sprints = new List<SprintModel>();
        public SprintRepository() : base(Paths.SprintsJson)
        {

        }

        public List<SprintModel> GetAllSprintData()
        {
            try
            {
                var data = this.Read();

                RawSprintDataResponseModel responseModel = JsonConvert.DeserializeObject<RawSprintDataResponseModel>(data);
                
                _sprints = responseModel.values
                    .Select(x => new SprintModel()
                    {
                        Id = x.id,
                        Self = x.self,
                        State = x.state,
                        Name = x.name,
                        StartDate = x.startDate,
                        EndDate = x.endDate,
                        OriginBoardId = x.originBoardId,
                        Goal = x.goal

                    })
                    .ToList();
            } catch (JsonException e)
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
            

            return _sprints;
        }

    }
}
