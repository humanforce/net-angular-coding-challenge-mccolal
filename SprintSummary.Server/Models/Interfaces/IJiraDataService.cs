using SprintSummary.server.Models.Capacity;
using SprintSummary.server.Models.JiraData;
using SprintSummary.server.Models.RawResponses;

namespace SprintSummary.server.Models.Interfaces
{
    public interface IJiraDataService
    {
        public List<JiraModel> FetchAllJiras();
        public List<JiraModel> GetJirasBySprintId(int scrumId);
        public CapacityStatisticsModel GetSprintStatistics(int sprintId, int previousSprintCount = 3);

    }
}
