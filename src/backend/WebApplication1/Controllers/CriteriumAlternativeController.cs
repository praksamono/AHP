using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AHP.Service.Common;
using Model.Common;
using AutoMapper;

namespace WebAPI
{
    [Route("api/criteriumalternatives")]
    [ApiController]
    public class CriteriumAlternativeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMainService _mainService;
        private readonly ICriteriumAlternativeService _criteriumAlternativeService;
        private readonly ICriteriumService _criteriumService;
        private readonly IAlternativeService _alternativeService;
        public CriteriumAlternativeController(IMainService mainService, ICriteriumService criteriumService, IAlternativeService alternativeService, ICriteriumAlternativeService criteriumAlternativeService, IMapper mapper)
        {
            _mainService = mainService;
            _criteriumService = criteriumService;
            _alternativeService = alternativeService;
            _criteriumAlternativeService = criteriumAlternativeService;
            _mapper = mapper;
        }

        [HttpGet("{goalId}")]
        public async Task<ActionResult<CriteriumAlternativeDTO>> GetCriteriumAlternativesAsync(Guid criteriumId)
        {
            List<ICriteriumAlternative> criteriumAlternatives = await _criteriumAlternativeService.GetAllCriteriumAlternativeAsync(criteriumId);
            return Ok(_mapper.Map<List<ICriteriumAlternative>, List<AlternativeDTO>>(criteriumAlternatives));
        }

        [HttpPost("{criteriumId}")]
        public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync([FromBody]int[] values, Guid criteriumId)
        {
            if (criteriumId == null)
            {
                return BadRequest(new { message = "Criterion id is not set." });
            }

            Guid goalId = (await _criteriumService.GetCriteriumAsync(criteriumId)).GoalId;
            string errorMessage = await AreValidComparisonValues(values, goalId);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(new { message = errorMessage });
            }

            CriteriumAlternativeDTO criteriumAlternative = new CriteriumAlternativeDTO();

            //Assign ICriterium
            criteriumAlternative.criterium = await _criteriumService.GetCriteriumAsync(criteriumId);
            criteriumAlternative.CriteriumId = criteriumId;
            //Fetch list of alternatives connected to the current goal
            List<IAlternative> alternativesList = await _alternativeService.GetAllAlternativesAsync(criteriumAlternative.criterium.GoalId);
            //Calculate priorities using AHP
            float[] priorities = await _mainService.AHPMethod(values, alternativesList.Count);

            int index = 0;
            foreach (IAlternative alternative in alternativesList)
            {
                criteriumAlternative.alternative = alternative; //Assign alternative from list
                criteriumAlternative.AlternativeId = alternative.Id;
                criteriumAlternative.LocalPriority = priorities[index]; //Assign i-th priority from priorities
                var scaledPriority = priorities[index] * criteriumAlternative.criterium.GlobalCriteriumPriority;
                await _alternativeService.UpdateAlternativeAsync(alternative, scaledPriority);
                index++;
                ICriteriumAlternative _criteriumAlternative =_mapper.Map<CriteriumAlternativeDTO, ICriteriumAlternative>(criteriumAlternative); //Map DTO object to I object
                await _criteriumAlternativeService.AddCriteriumAlternativeAsync(_criteriumAlternative); //Add to database
            }
            return Ok();
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
            var alternatives = await _alternativeService.GetAllAlternativesAsync(goalId);
            int numOfComparisons = (alternatives.Count * (alternatives.Count - 1)) / 2;
            return numOfComparisons;
        }
    }

    public class CriteriumAlternativeDTO
    {   //Sent in the POST request
        public Guid CriteriumId;
        //Calculated in controller methods
        public float LocalPriority;
        //Fetched in controller methods
        public Guid AlternativeId;
        public ICriterium criterium;
        public IAlternative alternative;
    }
}
