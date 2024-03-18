using AngularApp3.Server.Helpers;
using Newtonsoft.Json;

using SprintSummary.server.Models.RawResponses;


namespace SprintSummary.server.Repository
{
    public class JiraDataRepository : BaseRepository
    {
        
        private List<Issue> _jiraData = new List<Issue>();

        public JiraDataRepository() : base(Paths.JiraBacklogJson){}

        public List<Issue> GetAllJiraData()
        {
            try
            {
                var data = Read();

                RawJiraDataResponseModel responseModel = JsonConvert.DeserializeObject<RawJiraDataResponseModel>(data);
                var targetList = responseModel.issues
                    .Select(x => new Issue()
                    {
                        id = x.id,
                        expand = x.expand,
                        self = x.self,
                        key = x.key,
                        fields = new Fields()
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
                            customfield_10016 = x.fields.customfield_10016,
                            customfield_10020 = x.fields.customfield_10020,
                            status = new Models.RawResponses.Status()
                            {
                                name = x.fields.status.name
                            },
                            priority = new Priority()
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