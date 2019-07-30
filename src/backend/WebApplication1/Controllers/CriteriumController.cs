using System;
using System.Collections.Generic;
using System.Linq;
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
            // Console.WriteLine(goalId);
            foreach (var criterium in Criteria)
            {
                if (string.IsNullOrEmpty(criterium.CriteriumName))
                {
                    return BadRequest(new { message = "Criterium name can't be empty." });
                }
            }

            var mappedCriteria = _mapper.Map<List<ICriterium>>(Criteria);
            var status = await _criteriumService.AddCriteriumListAsync(mappedCriteria, goalId);

            return Ok(_mapper.Map<List<ICriterium>, List<CriteriumDTO>>(mappedCriteria));
        }

        [HttpPut]
        public async Task<ActionResult<List<ICriterium>>> PutAsync(int[] comparisons,Guid id){
            var allCriteria = await _criteriumService.GetAllCriteriumsAsync(id);
            var mappedCriteria = _mapper.Map<List<CriteriumDTO>>(allCriteria);

            float[] priorities = await _mainService.AHPMethod(comparisons);

            int index = 0;
            foreach (var criterium in mappedCriteria) {
                criterium.LocalPriority = priorities[index++];
            }

            var reMappedCriteria = _mapper.Map<List<ICriterium>>(mappedCriteria);
            foreach (var criterion in reMappedCriteria) {
                await _criteriumService.UpdateCriteriumAsync(criterion,id);
            }

            return Ok("sve oke");
        }
      }

    public class CriteriumDTO
    {
        public string CriteriumName { get; set; }
        public float LocalPriority { get; set; }
        public Guid GoalId { get; set; }
    }
}
