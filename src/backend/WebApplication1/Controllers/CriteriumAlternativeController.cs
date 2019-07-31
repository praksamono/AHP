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
        private readonly ICriteriumService criteriumService;
        private readonly IAlternativeService _alternativeService;
        public CriteriumAlternativeController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpPost]
        public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync(CriteriumAlternativeDTO criteriumAlternative, int[] values)
        {   
            //Exceptions
            foreach (var value in values)
            {
                if (Math.Abs(value) > 4)
                {
                    return BadRequest(new { message = "Invalid comparison value." });
                }
            }

            if (criteriumAlternative.goalId == null)
            {
                return BadRequest(new { message = "AlternativeCriterium - Goal ID does not exist." });
            }

            //Calculate priorities using AHP
            float[] priorities = await _mainService.AHPMethod(values);
            //Assign ICriterium
            criteriumAlternative.criterium = await criteriumService.GetCriteriumAsync(criteriumAlternative.criteriumID);
            //Fetch list of alternatives connected to the current goal
            List<IAlternative> alternativesList = await _alternativeService.GetAllAlternativesAsync(criteriumAlternative.goalId);

            int index = 0;
            foreach(IAlternative alternative in alternativesList)
            {
                criteriumAlternative.alternative = alternative; //Assign alternative from list
                criteriumAlternative.LocalPriority = priorities[index++]; //Assign i-th priority from priorities
                ICriteriumAlternative _criteriumAlternative =_mapper.Map<ICriteriumAlternative>(criteriumAlternative); //Map DTO object to I object
                await _criteriumAlternativeService.AddCriteriumAlternativeAsync(_criteriumAlternative); //Add to database
            }
            return Ok();
        }
    }

    public class CriteriumAlternativeDTO
    {   //Sent in the POST request
        public Guid criteriumID;
        public Guid goalId; //Should not be mapped to I object
        //Calculated in controller methods
        public float LocalPriority;
        //Fetched in controller methods
        public Guid CriteriumID;
        public Guid AlternativeID;
        public ICriterium criterium;
        public IAlternative alternative;
    }
}
