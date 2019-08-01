using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        // [HttpGet]
        // public async Task<ActionResult<GoalDTO>> GetAllGoalsAsync(int page, int pageSize)
        // {
        //     page =  2;
        //     pageSize =  10;
        //
        //     var allGoals = await _service.GetAllGoalsAsync(page, pageSize);
        //
        //     if(allGoals == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return Ok(_mapper.Map<List<IGoal>, List<GoalDTO>>(allGoals)); ;
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalDTO>> GetByIdAsync(Guid id)
        {
            var goal = await _service.GetGoalAsync(id);

            if (goal == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IGoal, GoalDTO>(goal));
        }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteGoalAsync(Guid id)
        // {
        //     if (id == null)
        //     {
        //         return BadRequest(new { message = "Goal id is not set." });
        //     }
        //
        //     var goal = await _service.DeleteGoalAsync(id);
        //
        //     return Ok();
        // }

        [HttpPost]
        public async Task<ActionResult<IGoal>> CreateGoalAsync(GoalDTO goal)

        {
            string errorMessage = await IsValidGoalName(goal.GoalName);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(new { message = errorMessage });
            }

            var mappedGoal = _mapper.Map<GoalDTO, IGoal>(goal);
            var returnedGoal = await _service.AddGoalAsync(mappedGoal);

            return Ok(_mapper.Map<GoalDTO>(returnedGoal));

        }


        // [HttpPut]
        // public async Task<ActionResult> UpdateGoalAsync(GoalDTO goal)
        // {
        //     if (string.IsNullOrEmpty(goal.GoalName))
        //     {
        //         return BadRequest(new { message = "Goal name is not set." });
        //     }
        //     var mappedGoal = _mapper.Map<GoalDTO, IGoal>(goal);
        //     var newGoal = await _service.UpdateGoalAsync(mappedGoal);
        //     return Ok();
        // }

        private async Task<string> IsValidGoalName(string goalName)
        {
            if (string.IsNullOrEmpty(goalName))
            {
                return "Goal name is not set.";
            }
            if (!Regex.IsMatch(goalName, @"^[a-zA-Z ]+$"))
            {
                return "Goal name contains invalid characters.";
            }
            return "";
        }
    }



    public class GoalDTO
    {
        public string GoalName { get; set; }
        public Guid Id { get; set; }
    }

}
