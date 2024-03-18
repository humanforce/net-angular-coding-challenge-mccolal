
using AngularApp3.Server.Services;
using Microsoft.AspNetCore.Mvc;
using SprintSummary.server.Models.Capacity;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.RawResponses;
using System.Collections.Generic;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SprintSummary.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private IJiraDataService _jiraDataService;
        public JiraController(IJiraDataService jiraDataService) { 
            this._jiraDataService = jiraDataService;
        }
        // GET: api/<JiraDataController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Issue> issues = _jiraDataService.FetchAllJiras();

            return Ok(issues);
        }

        [HttpGet("{sprintId}")]
        public IActionResult GetJirasBySprintId(int sprintId)
        {
            List<Issue> issues = _jiraDataService.GetJirasBySprintId(sprintId);
            return Ok(issues);
        }

        [HttpGet("{sprintId}/{previousSprintCount}")]
        public IActionResult GetSprintStatistics(int sprintId, int previousSprintCount)
        {
            {
                CapacityStatisticsModel capacityStats = _jiraDataService.GetSprintStatistics(sprintId, previousSprintCount);
                return Ok(capacityStats);
            }
        }

    }
}
