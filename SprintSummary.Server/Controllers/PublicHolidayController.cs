using AngularApp3.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SprintSummary.server.Models.Interfaces;
using SprintSummary.server.Models.PublicHolidays;
using System.Collections.Generic;

namespace AngularApp3.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicHolidayController : ControllerBase
    {
        private IPublicHolidayService _publicHolidayService;
        private readonly ILogger<PublicHolidayController> _logger;

        public PublicHolidayController(ILogger<PublicHolidayController> logger, IPublicHolidayService publicHolidayService)
        {
            _logger = logger;
            _publicHolidayService = publicHolidayService;
        }

        [HttpGet("{regionName}/{startDate}/{endDate}")]
        public IActionResult GetAsync(string regionName, DateTime startDate, DateTime endDate)
        {
            List<PublicHolidayModel> publicHolidays = _publicHolidayService
                .GetAllPublicHolidayByRegionBetweenDates(regionName, startDate, endDate);
            return Ok(publicHolidays);
        }

        [HttpGet("{startDate}/{endDate}")]
        public IActionResult GetAsync(DateTime startDate, DateTime endDate)
        {
            List <PublicHolidayModel> publicHolidays = _publicHolidayService.GetAllPublicHolidaysBetweenDates(startDate, endDate);
            return Ok(publicHolidays);        }


    }
}
