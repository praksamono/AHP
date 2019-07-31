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
    [Route("api/results")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ICriteriumService _criteriumService;
        private readonly IAlternativeService _alternativeService;
        private readonly IMapper _mapper;

        public ResultController(ICriteriumService criteriumService, IAlternativeService alternativeService, IMapper mapper)
        {
            // _criteriumService = criteriumService;
            _alternativeService = alternativeService;
            _mapper = mapper;
        }

        [HttpGet("{goalId}")]
        public async Task<ActionResult<AlternativeDTO>> GetResultsAsync(Guid goalId)
        {
            // var criteria = await _criteriumService.GetAllCriteriumsAsync(goalId);
            var alternatives = await _alternativeService.GetAllAlternativesAsync(goalId);

            // if (criteria == null)
            // {
            //     return NotFound(new { message = "Criteria not found." });
            // }
            if (alternatives == null)
            {
                return NotFound(new { message = "Alternatives not found." });
            }

            return Ok(_mapper.Map<List<IAlternative>, List<AlternativeDTO>>(alternatives));
        }
    }

}
