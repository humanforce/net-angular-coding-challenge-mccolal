using SprintSummary.server.Models.JiraUser;

namespace SprintSummary.server.Models.Sprint
{
    public class SprintCapacityModel
    {
        public int SprintId { get; set; }

        public int Capacity { get; set; }

        public JiraUserModel User { get; set; }
    }
}
