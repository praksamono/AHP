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
    [Route("api/alternatives/[action]")]
    [ApiController]
    public class AlternativeController : ControllerBase
    {
        private readonly IAlternativeService _service;
        private readonly IMapper _mapper;

        public AlternativeController(IAlternativeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlternativeDTO>>> GetAlternativesAsync()
        {
            var alternatives = await _service.GetAllAlternativesAsync();

            if (alternatives == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<IAlternative>, List<AlternativeDTO>>(alternatives));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlternativeDTO>> GetAlternativeByIdAsync(Guid id)
        {
            if(id == null)
            {
                return BadRequest(new { message = "Alternative id is not set." });
            }

            var alternative = await _service.GetAlternativeAsync(id);

            if (alternative == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IAlternative, AlternativeDTO>(alternative));
        }

        [HttpPost]
        public async Task<ActionResult<IAlternative>> AddAlternativeAsync(AlternativeDTO alternative)
        {
            if (string.IsNullOrEmpty(alternative.AlternativeName))
            {
                return BadRequest(new { message = "Add alterantive async." });
            }

            var mappedAlternative = _mapper.Map<AlternativeDTO, IAlternative>(alternative);
            var status = await _service.AddAlternativeAsync(mappedAlternative);

            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<List<IAlternative>>> CreateAlternativesAsync(List<AlternativeDTO> alternatives)
        {
            foreach (var alternative in alternatives)
            {
                if (string.IsNullOrEmpty(alternative.AlternativeName))
                {
                    return BadRequest(new { message = "Create alternative async." });
                    // throw new HttpResponseException("Alternative name is not set.", HttpStatusCode.BadRequest);
                }
            }

            var mappedAlts = _mapper.Map<List<AlternativeDTO>, List<IAlternative>>(alternatives);
            var status = await _service.AddAlternativeListAsync(mappedAlts);

            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlternativeAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "Alternative id is not set." });
            }

            var alternative = await _service.DeleteAlternativeAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAlternativeAsync(AlternativeDTO alternative)
        {
            if (string.IsNullOrEmpty(alternative.AlternativeName))
            {
                return BadRequest(new { message = "Alternative name can't be empty." });
            }

            var mappedAlternative = _mapper.Map<AlternativeDTO, IAlternative>(alternative);
            var newAlternative = await _service.UpdateAlternativeAsync(mappedAlternative);

            return Ok();
        }
    }

	public class AlternativeDTO
	{
		public string AlternativeName { get; set; }
		public Guid GoalId { get; set; }
	}

}
