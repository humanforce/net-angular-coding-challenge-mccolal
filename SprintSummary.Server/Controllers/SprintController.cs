
using AngularApp3.Server.Services;
using Microsoft.AspNetCore.Mvc;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.Sprint;

namespace AngularApp3.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private ISprintDataService _sprintDataService;
        public SprintController(ISprintDataService sprintDataService)
        {
            _sprintDataService = sprintDataService;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SprintModel sprintData = _sprintDataService.FetchSprintById(id);
            return Ok(sprintData);
        }

        //this is the first call made by angular to find a sprint based on a given date.
        // The first date used when the page loads is the current date. 
        [HttpGet("{date}/{id}")]
        public IActionResult GetByDate(DateTime date)
        {
            SprintModel sprintData = _sprintDataService.FetchSprintByDate(date);
            return Ok(sprintData); 
        }
    }
}
