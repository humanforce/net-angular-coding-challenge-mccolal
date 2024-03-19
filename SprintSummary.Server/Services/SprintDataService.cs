using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.Sprint;
using SprintSummary.server.Repository;

namespace AngularApp3.Server.Services
{
    public class SprintDataService: ISprintDataService
    {
        private SprintRepository _sprintRepository;
        public SprintDataService() {
            _sprintRepository = new SprintRepository();
        }

        public List<SprintModel> FetchAllSprints()
        {
            return _sprintRepository.GetAllSprintData();
        }

        public SprintModel FetchSprintByDate(DateTime date)
        {
            List<SprintModel> sprints = FetchAllSprints();
            SprintModel sprint = sprints
                .OrderByDescending(y => y.StartDate)
                .ToList()
                .FirstOrDefault(x => x.StartDate <= date && x.EndDate >= date);
            if (sprint == null)
            {
                return sprints
                .OrderByDescending(y => y.EndDate)
                .ToList()
                .FirstOrDefault();
            } 

            return sprint;
        }

        public SprintModel FetchSprintById(int id)
        {
            List<SprintModel> sprints = FetchAllSprints();
            SprintModel sdm = sprints
                .OrderByDescending(y => y.StartDate)
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            
            // If no sprint is found, find the closest sprint to the current date.
            if (sdm == null)
            {
                return sprints
                .OrderByDescending(y => y.EndDate)
                .ToList()
                .First();
            }

            return sdm;
        }

    }
}
