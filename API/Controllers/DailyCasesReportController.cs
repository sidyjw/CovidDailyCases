using Application.DailyCases.DTOs;
using Application.DailyCases.Queries;
using MediatR;
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
        private readonly IMediator _mediator;

        public DailyCasesReportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok("Fullstack Challenge 2021 🏅 - Covid Daily Cases");
        }

        [HttpGet("/dates")]
        [ProducesResponseType(typeof(List<DateTime>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AvailableDates()
        {
            var result = await _mediator.Send(new Dates.Query());
            
            return Ok(result.Value);
        }

        [HttpGet("/cases/{date}/count")]
        [ProducesResponseType(typeof(List<AllCasesByDayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCasesByDate(DateTime date)
        {
            var result = await _mediator.Send(new GetAllCasesByDate.Query { Date = date });

            if(!result.IsSuccess) return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("/cases/{date}/cumulative")]
        [ProducesResponseType(typeof(List<AllCasesAmountByDateDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCasesAmountByDate(string date)
        {
            var result = await _mediator.Send(new GetAllCasesAmountByDate.Query { Date = date});

            if (!result.IsSuccess) return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}
