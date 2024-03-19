using SprintSummary.server.Models.JiraUser;

namespace SprintSummary.server.Models.Interfaces
{
    public interface IJiraUserService
    {
        public List<JiraUserModel> GetJiraUsers();
    }
}
