using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AHP.Service.Common;
using Model.Common;

namespace WebAPI
{
    [Route("api/criteria")]
    [ApiController]
    public class CriteriumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICriteriumService _criteriumService;
        private readonly IMainService _mainService;
        public CriteriumController(IMapper mapper, ICriteriumService criteriumService, IMainService mainService)
        {
            _mapper = mapper;
            _criteriumService = criteriumService;
            _mainService = mainService;
        }


        [HttpGet("{goalId}")]
        public async Task<ActionResult<List<CriteriumDTO>>> GetAsync(Guid goalId)
        {
            if (goalId == null)
            {
                return BadRequest(new { message = "Goal id is not set." });
            }

            var criteria = await _criteriumService.GetAllCriteriumsAsync(goalId);

            if (criteria == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<ICriterium>, List<CriteriumDTO>>(criteria));
        }

        [HttpPost("{goalId}")]
        public async Task<ActionResult<List<ICriterium>>> PostAsync([FromBody]List<CriteriumDTO> Criteria, Guid goalId)
        {
            if (goalId == null)
            {
                return BadRequest(new { message = "Goal id is not set." });
            }

            foreach (var criterium in Criteria)
            {
                string errorMessage = await IsValidCriterionName(criterium.CriteriumName);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return BadRequest(new { message = errorMessage });
                }
            }

            var mappedCriteria = _mapper.Map<List<ICriterium>>(Criteria);
            var status = await _criteriumService.AddCriteriumListAsync(mappedCriteria, goalId);

            return Ok(_mapper.Map<List<ICriterium>, List<CriteriumDTO>>(mappedCriteria));
        }

        [HttpPut("{goalId}")]
        public async Task<ActionResult<List<ICriterium>>> PutAsync([FromBody]int[] comparisons, Guid goalId){
            if (goalId == null)
            {
                return BadRequest(new { message = "GoalId is not set." });
            }

            string errorMessage = await AreValidComparisonValues(comparisons, goalId);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(new { message = errorMessage });
            }

            var allCriteria = await _criteriumService.GetAllCriteriumsAsync(goalId);
            var mappedCriteria = _mapper.Map<List<CriteriumDTO>>(allCriteria);

            float[] priorities = await _mainService.AHPMethod(comparisons);

            int index = 0;

            foreach (var criterium in mappedCriteria)
            {
                criterium.GlobalCriteriumPriority = priorities[index++];
            }

            var reMappedCriteria = _mapper.Map<List<ICriterium>>(mappedCriteria);

            foreach (var criterion in reMappedCriteria)
            {
                await _criteriumService.UpdateCriteriumAsync(criterion, goalId);
            }

            return Ok();
        }

        private async Task<string> IsValidCriterionName(string criterionName)
        {
            if (string.IsNullOrEmpty(criterionName))
            {
                return "Criterion name is not set.";
            }
            if (!Regex.IsMatch(criterionName, @"^[a-zA-Z0-9 ]+$"))
            {
                return "Criterion name contains invalid characters: " + criterionName;
            }
            return "";
        }

        private async Task<string> AreValidComparisonValues(int[] comparisons, Guid goalId)
        {
            if (comparisons == null || comparisons.Length == 0)
            {
                return "No comparison values.";
            }
            foreach (int comparison in comparisons)
            {
                if (Math.Abs(comparison) > 4)
                {
                    return "Comparison value out of range: " + comparison.ToString();
                }
            }

            int requiredNumOfValues = await CalculateNumOfValues(goalId);
            if (comparisons.Length > requiredNumOfValues)
            {
                return String.Format("Too many values ({0} passed, {1} needed)", comparisons.Length, requiredNumOfValues);
            }
            if (comparisons.Length < requiredNumOfValues)
            {
                return String.Format("Not enough values ({0} passed, {1} needed)", comparisons.Length, requiredNumOfValues);
            }
            return "";
        }

        private async Task<int> CalculateNumOfValues(Guid goalId)
        {
            var criteria = await _criteriumService.GetAllCriteriumsAsync(goalId);
            int numOfComparisons = (criteria.Count * (criteria.Count - 1)) / 2;
            return numOfComparisons;
        }
      }

    public class CriteriumDTO
    {
        public string CriteriumName { get; set; }
        public float GlobalCriteriumPriority { get; set; }
        public Guid GoalId { get; set; }
        public Guid Id { get; set; }
    }
}
