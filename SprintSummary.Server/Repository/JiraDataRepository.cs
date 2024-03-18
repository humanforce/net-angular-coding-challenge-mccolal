using AngularApp3.Server.Helpers;
using Newtonsoft.Json;
using SprintSummary.server.Models.JiraData;
using SprintSummary.server.Models.RawResponses;


namespace SprintSummary.server.Repository
{
    public class JiraDataRepository : BaseRepository
    {
        
        private List<JiraModel> _jiraData = new List<JiraModel>();

        public JiraDataRepository() : base(Paths.JiraBacklogJson){}

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
                            /* Alex M: Using customfield_xxxx is not intuitive.  A mapper 
                             * should be used to map the poorly named properties from the raw 
                             * JSON string, to properly name properties that are easily ledgible. 
                             * 
                             * Dictionary for the below is as follows:
                             * customfield_10016    -       Story Points
                             * customfield_10020    -       Sprint Information
                             * status.name          -       Jira status (To Do, Done, etc).
                             * status.priority      -       Low, Medium, High, etc
                             */
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