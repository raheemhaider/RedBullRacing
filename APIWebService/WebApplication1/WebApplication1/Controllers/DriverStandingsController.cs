namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using WebApplication1.Service;

    [Route("api/[controller]")]
    [ApiController]
    public class DriverStandingsController : ControllerBase
    {
        private readonly DriverStandingsService _service;

        public DriverStandingsController(DriverStandingsService service)
        {
            _service = service;
        }

        [HttpGet("{season}")]
        [Produces("application/json", "application/xml")]
        public async Task<ActionResult<List<DriverStanding>>> GetDriverStandings(int season)
        {
            string test = Request.Headers["Accept"];

            var standings = await _service.GetDriverStandingsAsync(season);
            return Ok(standings);
        }
    }

}
