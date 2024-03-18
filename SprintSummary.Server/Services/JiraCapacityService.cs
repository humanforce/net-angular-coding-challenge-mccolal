using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.JiraUser;
using SprintSummary.server.Models.PublicHolidays;
using SprintSummary.server.Models.Regionn;
using SprintSummary.server.Models.Sprint;

namespace AngularApp3.Server.Services
{
    public class JiraCapacityService : IJiraCapacityService
    {
        private IJiraUserService _jiraUserService;
        private ISprintDataService _sprintDataService;
        private IPublicHolidayService _publicHolidayService;
        public JiraCapacityService(
            IJiraUserService jiraUserService, 
            ISprintDataService sprintDataService,
            IPublicHolidayService publicHolidayService) {
            _jiraUserService = jiraUserService;
            _sprintDataService = sprintDataService;
            _publicHolidayService = publicHolidayService;
        }

        public List<SprintCapacityModel> GetJiraUsersCapacityForSprintAsync(int sprintId)
        {
            Regions regions = new Regions();


            SprintModel sprintInfo = _sprintDataService.FetchSprintById(sprintId);
            DateTime sprintStartDate = sprintInfo.StartDate.Date;
            DateTime spintEndDate = sprintInfo.EndDate.Date;
            List<JiraUserModel> jiraUsers = _jiraUserService.GetJiraUsers();
            List<SprintCapacityModel> jiraUserCapactiyForSprint = new List<SprintCapacityModel>();

            List<PublicHolidayTotalForCountryModel> counts = _publicHolidayService.GetPublicHolidayCountForCountryBetweenDates(sprintStartDate, spintEndDate);

            foreach (JiraUserModel user in jiraUsers)
            {
                // Assumption: Each user has 10 capacity points per sprint.
                // If a public holiday falls within the sprint, remove 1 capacity point.
                jiraUserCapactiyForSprint.Add(new SprintCapacityModel
                {
                    SprintId = sprintId,
                    Capacity = 10 - counts.Find(x => x.name.ToLower() == user.Location.Country.ToLower()).count,
                    User = user
                });
            }

            return jiraUserCapactiyForSprint;
        }
    }
}
