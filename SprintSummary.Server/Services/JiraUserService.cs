
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.JiraUser;
using SprintSummary.server.Repository;

namespace AngularApp3.Server.Services
{
    public class JiraUserService : IJiraUserService
    {
        private JiraUserRepository _jiraUserRepository;
        public JiraUserService() {
            _jiraUserRepository = new JiraUserRepository();
        }

        public List<JiraUserModel> GetJiraUsers()
        {
            return _jiraUserRepository.GetAllJiraUsers();
        }

    }
}
