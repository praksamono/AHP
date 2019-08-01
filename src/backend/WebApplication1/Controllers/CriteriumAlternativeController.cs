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

        [HttpPost("{criteriumId}")]
        public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync([FromBody]int[] values, Guid criteriumId)
        {
            CriteriumAlternativeDTO criteriumAlternative = new CriteriumAlternativeDTO();
            //Exceptions
            foreach (var value in values)
            {
                if (Math.Abs(value) > 4)
                {
                    return BadRequest(new { message = "Invalid comparison value." });
                }
            }

            criteriumAlternative = await AssignCriteriumAlternativesPropertiesAsync(criteriumAlternative, criteriumId);
            await SendCriteriumAlternativesAsync(criteriumAlternative, values);
            
            return Ok();
        }

        private async Task<CriteriumAlternativeDTO> AssignCriteriumAlternativesPropertiesAsync(CriteriumAlternativeDTO criteriumAlternative, Guid criteriumId)
        {   
            //Assign ICriterium
            criteriumAlternative.criterium = await _criteriumService.GetCriteriumAsync(criteriumId);
            criteriumAlternative.CriteriumId = criteriumId;
            return criteriumAlternative;
        }

        private async Task<bool> SendCriteriumAlternativesAsync(CriteriumAlternativeDTO criteriumAlternative, int[] values)
        {
            //Calculate priorities using AHP
            float[] priorities = await _mainService.AHPMethod(values);
            //Fetch list of alternatives connected to the current goal
            List<IAlternative> alternativesList = await _alternativeService.GetAllAlternativesAsync(criteriumAlternative.criterium.GoalId);

            int index = 0;
            foreach (IAlternative alternative in alternativesList)
            {
                criteriumAlternative.alternative = alternative; //Assign alternative from list
                criteriumAlternative.AlternativeId = alternative.Id;
                criteriumAlternative.LocalPriority = priorities[index++]; //Assign i-th priority from priorities
                ICriteriumAlternative _criteriumAlternative = _mapper.Map<CriteriumAlternativeDTO, ICriteriumAlternative>(criteriumAlternative); //Map DTO object to I object
                await _criteriumAlternativeService.AddCriteriumAlternativeAsync(_criteriumAlternative); //Add to database
            }
            return true;
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
