using Application.DailyCases.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DailyCasesReportController : ControllerBase
    {
        public DailyCasesReportController()
        {
           
        }
        
        [HttpGet("/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok("Fullstack Challenge 2021 🏅 - Covid Daily Cases");
        }

        [HttpGet("/dates")]
        [ProducesResponseType(typeof(List<AvailableDatesDTO>), StatusCodes.Status200OK)]
        public async Task<List<AvailableDatesDTO>> AvailableDates()
        {
            throw new NotImplementedException();
        }
    }
}
