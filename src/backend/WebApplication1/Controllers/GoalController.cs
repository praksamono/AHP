using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Service.Common;
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
        public async Task<ActionResult<Goal>> GetByIdAsync(int id)
        // change int to guid
        {
            var goal = _service.GetGoalAsync(id); //pozovi funkciju iz servicea

            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> CreateAsync(GoalDTO goal)
        {
            if (IsNullOrEmpty(goal.GoalName))
            {
                return BadRequest(new {message = "Goal name is not set."});
                // throw new HttpResponseException("Goal name is not set.", HttpStatusCode.BadRequest);
            }
            else 
            {
                var mappedGoal = _mapper.Map<IGoal>(goal);
                await _service.AddGoalAsync(mappedGoal);
            }

            return CreatedAtAction(nameof(GetById), new { id = goal.GoalId }, goal);
        }
    }

    public class GoalDTO
    {
        public string GoalName { get; set; }
    }

}