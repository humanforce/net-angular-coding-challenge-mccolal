using SprintSummary.server.Models.Capacity;
using SprintSummary.server.Models.RawResponses;

namespace SprintSummary.server.Models.Interfaces
{
    public interface IJiraDataService
    {
        public List<Issue> FetchAllJiras();
        public List<Issue> GetJirasBySprintId(int scrumId);
        public CapacityStatisticsModel GetSprintStatistics(int sprintId, int previousSprintCount = 3);

    }
}
