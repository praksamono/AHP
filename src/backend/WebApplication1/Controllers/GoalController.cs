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
        public async Task<ActionResult<GoalDto>> GetByIdAsync(Guid id)
        {
            var goal = await _service.GetGoalAsync(id);

            if (goal == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GoalDto>(goal));
        }


        [HttpPost]
        public async Task<ActionResult<IGoal>> CreateGoalAsync(GoalDto goal)
        {
            if (string.IsNullOrEmpty(goal.GoalName))
            {
                return BadRequest(new {message = "Goal name is not set."});
                // throw new HttpResponseException("Goal name is not set.", HttpStatusCode.BadRequest);
            }
            //IGoal g = IGoalService.AddGoalAsync(_mapper.Map<IGoal, GoalDto>(goal));

            var mappedGoal = _mapper.Map<GoalDto, IGoal>(goal);
            var returnedGoal = await _service.AddGoalAsync(mappedGoal);

            //return Ok(_mapper.Map<GoalDto>(returnedGoal));

            return CreatedAtAction(nameof(GetByIdAsync), new { id = returnedGoal.GoalId }, returnedGoal);
        }
    }

    public class GoalDto
    {

        public string GoalName { get; set; }

    }
}
