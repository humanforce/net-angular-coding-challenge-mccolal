using SprintSummary.server.Models.Capacity;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.RawResponses;
using SprintSummary.server.Models.Sprint;
using SprintSummary.server.Repository;


namespace AngularApp3.Server.Services
{
    public class JiraDataService : IJiraDataService
    {
        private JiraDataRepository _jiraDataRepository;
        public JiraDataService() {
            _jiraDataRepository = new JiraDataRepository();
        }

        public List<Issue> FetchAllJiras()
        {
            return _jiraDataRepository.GetAllJiraData();
        }

        public List<Issue> GetJirasBySprintId(int scrumId)
        {
            List<Issue> allJiras = FetchAllJiras();
            List<Issue> jirasWithinSprintId = allJiras.FindAll(x => x.fields.customfield_10020.FirstOrDefault(y => y.id == scrumId) != null
            );
            return jirasWithinSprintId;
        }

        public CapacityStatisticsModel GetSprintStatistics(int sprintId, int previousSprintCount = 3)

        {
            CapacityStatisticsModel response = new CapacityStatisticsModel();
            int lowerSprintID = Math.Max(sprintId - previousSprintCount, 0);

            List<Issue> allJiras = FetchAllJiras();
            List<Issue> issuesInCurrentSprint = allJiras
                .FindAll(x =>
                    x.fields.customfield_10020
                        .FirstOrDefault(y => y.id == sprintId) != null);

            List<Issue> completedIssuesInPreviousSprints = allJiras
                .FindAll(x =>
                    x.fields.customfield_10020
                        .Find(y =>
                            y.id < sprintId && y.id >= lowerSprintID) != null
                    && x.fields.status.name.ToLower() == "done"        
                            );

            List<SprintVelocityModel> completedStoryPointsBySprint = completedIssuesInPreviousSprints
                .Select(issue =>
                    new SprintVelocityModel()
                    {
                        SprintId = issue.fields.customfield_10020.FirstOrDefault().id,
                        CompletedStoryPoints = issue.fields.customfield_10016
                    }).ToList();

            response.SprintStatistics = completedStoryPointsBySprint
                .GroupBy(d => d.SprintId)
                .Select(issue => new SprintVelocityModel
                {
                    SprintId = issue.First().SprintId,
                    CompletedStoryPoints = issue.Sum(z => z.CompletedStoryPoints)
                })
                .OrderBy(d => d.SprintId)
                .ToList();

            //response.Capacity = 10;
            response.SprintID = sprintId;

            return response;
        }

    }
}
