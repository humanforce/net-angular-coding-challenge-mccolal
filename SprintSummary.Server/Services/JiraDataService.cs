using SprintSummary.server.Models.Capacity;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.JiraData;
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

        public List<JiraModel> FetchAllJiras()
        {
            return _jiraDataRepository.GetAllJiraData();
        }

        public List<JiraModel> GetJirasBySprintId(int scrumId)
        {
            List<JiraModel> allJiras = FetchAllJiras();
            List<JiraModel> jirasWithinSprintId = allJiras.FindAll(x => x.fields.Sprints.FirstOrDefault(y => y.id == scrumId) != null
            );
            return jirasWithinSprintId;
        }

        public CapacityStatisticsModel GetSprintStatistics(int sprintId, int previousSprintCount = 3)

        {
            CapacityStatisticsModel response = new CapacityStatisticsModel();
            int lowerSprintID = Math.Max(sprintId - previousSprintCount, 0);

            List<JiraModel> allJiras = FetchAllJiras();
            List<JiraModel> issuesInCurrentSprint = allJiras
                .FindAll(x =>
                    x.fields.Sprints
                        .FirstOrDefault(y => y.id == sprintId) != null);

            List<JiraModel> completedIssuesInPreviousSprints = allJiras
                .FindAll(x =>
                    x.fields.Sprints
                        .Find(y =>
                            y.id < sprintId && y.id >= lowerSprintID) != null
                    && x.fields.Status.name.ToLower() == "done"        
                            );

            List<SprintVelocityModel> completedStoryPointsBySprint = completedIssuesInPreviousSprints
                .Select(issue =>
                    new SprintVelocityModel()
                    {
                        SprintId = issue.fields.Sprints.FirstOrDefault().id,
                        CompletedStoryPoints = issue.fields.StoryPoints
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
