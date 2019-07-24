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
        public CriteriumController(IMapper mapper, ICriteriumService criteriumService)
        {
            _mapper = mapper;
            _criteriumService = criteriumService;
        }

        [HttpGet]
        public async Task<ActionResult<CriteriumDTO>> GetAsync()
        {
            // var criterium = await _criteriumService.GetCriteriumAsync();

            if (criterium == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<ICriterium>, List<CriteriumDTO>>(criterium));
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

            var mappedCriterium = _mapper.Map<ICriterium>(Criteria);
            //var status = await _criteriumService.AddCriteriumAsync(mappedCriterium);
            return Ok(/*status*/);
        }
      }

    public class CriteriumDTO
    {
        public string CriteriumName { get; set; }
        public float GlobalCriteriumPriority { get; set; }
    }
}
