using SprintSummary.server.Models.Sprint;

namespace SprintSummary.server.Models.Interfaces
{
    public interface IJiraCapacityService
    {
        public List<SprintCapacityModel> GetJiraUsersCapacityForSprintAsync(int sprintId);
    }
}
