using SprintSummary.server.Models.Sprint;

namespace SprintSummary.server.Models.Interfaces
{
    public interface ISprintDataService
    {
        public List<SprintModel> FetchAllSprints();

        public SprintModel FetchSprintByDate(DateTime date);

        public SprintModel FetchSprintById(int id);
    }
}
