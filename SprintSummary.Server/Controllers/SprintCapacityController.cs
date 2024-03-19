
using Microsoft.AspNetCore.Mvc;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.Sprint;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp3.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SprintCapacityController : ControllerBase
    {
        private IJiraCapacityService _jiraCapacityService;
        public SprintCapacityController(IJiraCapacityService jiraCapacityService) {
            _jiraCapacityService = jiraCapacityService;
        }
        
        [Route("{sprintId}")]
        [HttpGet]
        public List<SprintCapacityModel>  Get(int sprintId)
        {
            List<SprintCapacityModel> userCapacityForSprint =  _jiraCapacityService.GetJiraUsersCapacityForSprintAsync(sprintId);

            return userCapacityForSprint;
        }


    }
}
