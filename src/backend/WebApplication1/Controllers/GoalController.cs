using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AHP.Service.Common;
using Model.Common;

namespace WebAPI
{
    [Route("api/goals")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _service;
        private readonly IMapper _mapper;

        public GoalController(IGoalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("id")]
        public async Task<ActionResult<GoalDTO>> GetByIdAsync(Guid id)
        // change int to guid
        {
            var goal = await _service.GetGoalAsync(id); //pozovi funkciju iz servicea

            if (goal == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GoalDTO>(goal));
        }

        [HttpPost]
        public async Task<ActionResult<IGoal>> CreateGoalAsync(GoalDTO goal)
        {
            if (string.IsNullOrEmpty(goal.GoalName))
            {
                return BadRequest(new {message = "Goal name is not set."});
                // throw new HttpResponseException("Goal name is not set.", HttpStatusCode.BadRequest);
            }

            var mappedGoal = _mapper.Map<IGoal>(goal);
            await _service.CreateGoalAsync(mappedGoal);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = mappedGoal.GoalId }, mappedGoal);
        }
    }

    public class GoalDTO
    {
        public string GoalName { get; set; }
    }

}
