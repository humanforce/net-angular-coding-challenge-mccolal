using AngularApp3.Server.Helpers;
using Newtonsoft.Json;
using SprintSummary.server.Models.JiraData;
using SprintSummary.server.Models.RawResponses;


namespace SprintSummary.server.Repository
{
    public class JiraRepository : BaseRepository
    {
        
        private List<JiraModel> _jiraData = new List<JiraModel>();

        public JiraRepository() : base(Paths.JiraBacklogJson){}

        public List<JiraModel> GetAllJiraData()
        {
            try
            {
                var data = Read();

                RawJiraDataResponseModel responseModel = JsonConvert.DeserializeObject<RawJiraDataResponseModel>(data);

                if (responseModel == null)
                {
                    responseModel = new RawJiraDataResponseModel(); ;
                }

                var targetList = responseModel.issues
                    .Select(x => new JiraModel()
                    {
                        id = x.id,
                        expand = x.expand,
                        self = x.self,
                        key = x.key,
                        fields = new Properties()
                        {
                            StoryPoints = x.fields.customfield_10016,
                            Sprints = x.fields.customfield_10020
                                .Select(x => new Sprint()
                                {
                                    id=x.id,
                                    name = x.name,
                                    state = x.state,
                                    boardId = x.boardId,
                                    goal = x.goal,
                                    startDate = x.startDate,
                                    endDate = x.endDate
                                }).ToList(),
                            Status = new Models.JiraData.Status()
                            {
                                name = x.fields.status.name
                            },
                            Priority = new Models.JiraData.Priority()
                            {
                                name = x.fields.priority.name
                            }
                        }
                    })
                    .ToList();
                _jiraData = targetList;
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
            
            return _jiraData;
        }
    }
}
;