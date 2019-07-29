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

        [HttpGet]
        public async Task<ActionResult<List<CriteriumDTO>>> GetAsync()
        {
            var criteria = await _criteriumService.GetAllCriteriumsAsync();

            if (criteria == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<ICriterium>, List<CriteriumDTO>>(criteria));
        }

        [HttpPost]
        public async Task<ActionResult<List<ICriterium>>> PostAsync(List<CriteriumDTO> Criteria)
        {
            foreach (var criterium in Criteria)
            {
                if (string.IsNullOrEmpty(criterium.CriteriumName))
                {
                    return BadRequest(new { message = "Criterium name can't be empty." });
                }
            }

            var mappedCriteria = _mapper.Map<List<ICriterium>>(Criteria);
            var status = await _criteriumService.AddCriteriumListAsync(mappedCriteria);

            return Ok(status);
        }

        [HttpPut]
        public async Task<ActionResult<List<ICriterium>>> PutAsync(int[] comparisons){
            List<CriteriumDTO> allCriteria = GetAsync();
            float[] priorities = await _mainService.AHPMethod(comparisons);

            int index = 0;
            foreach (var criterium in allCriteria) {
                criterium.LocalPriority = priorities[index++];
            }

            var mappedCriteria = _mapper.Map<List<ICriterium>>(Criteria);
            foreach (var criterion in mappedCriteria) {
                await _criteriumService.UpdateCriteriumAsync(criterion);
            }

            return Ok();
        }
      }

    public class CriteriumDTO
    {
        public string CriteriumName { get; set; }
        public float LocalPriority { get; set; }
        public Guid GoalId { get; set; }
    }
}
