using SprintSummary.server.Models.Sprint;

namespace SprintSummary.server.Models.Capacity
{
    public class CapacityStatisticsModel
    {
        public int? SprintID { get; set; }
        public int? Capacity { get; set; }
        public List<SprintVelocityModel>? SprintStatistics { get; set; }
    }
}
