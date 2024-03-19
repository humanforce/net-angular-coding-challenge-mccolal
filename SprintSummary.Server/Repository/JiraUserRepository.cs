using AngularApp3.Server.Helpers;
using Newtonsoft.Json;
using SprintSummary.server.Models.JiraUser;

namespace SprintSummary.server.Repository
{
    public class JiraUserRepository : BaseRepository 
    {
        private List<JiraUserModel> _users = new List<JiraUserModel>();
        public JiraUserRepository() : base(Paths.JiraUsersJson) {

        }

        public List<JiraUserModel> GetAllJiraUsers()
        {
            try
            {
                var data = this.Read();
                _users = JsonConvert.DeserializeObject<List<JiraUserModel>>(data);
                if (_users == null)
                {
                    _users = new List<JiraUserModel>();
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
            
            return _users;
        }

    }
}
