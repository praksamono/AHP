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
    [Route("api/alternatives")]
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

        [HttpGet("{goalId}")]
        public async Task<ActionResult<List<AlternativeDTO>>> GetAlternativesAsync(Guid goalId)
        {
            if (goalId == null)
            {
                return BadRequest(new { message = "Goal id is not set." });
            }

            var alternatives = await _service.GetAllAlternativesAsync(goalId);

            if (alternatives == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<IAlternative>, List<AlternativeDTO>>(alternatives));
        }


        [HttpPost("{goalId}")]
        public async Task<ActionResult<List<IAlternative>>> CreateAlternativesAsync([FromBody]List<AlternativeDTO> alternatives, Guid goalId)
        {
            if (goalId == null)
            {
                return BadRequest(new { message = "Goal id is not set." });
            }

            string alternativesCheck = await AreValidAlternatives(alternatives);
            if (!string.IsNullOrEmpty(alternativesCheck))
            {
                return BadRequest(new { message = alternativesCheck });
            }

            foreach (var alternative in alternatives)
            {
                string errorMessage = await IsValidAlternativeName(alternative.AlternativeName);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return BadRequest(new { message = errorMessage });
                }
            }

            var mappedAlts = _mapper.Map<List<AlternativeDTO>, List<IAlternative>>(alternatives);
            var status = await _service.AddAlternativeListAsync(mappedAlts, goalId);

            return Ok();
        }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteAlternativeAsync(Guid id)
        // {
        //     if (id == null)
        //     {
        //         return BadRequest(new { message = "Id can't be empty." });
        //     }
        //
        //     var alternative = await _service.DeleteAlternativeAsync(id);
        //
        //     return Ok();
        // }

        // [HttpPut]
        // public async Task<ActionResult> UpdateAlternativeAsync(AlternativeDTO alternative)
        // {
        //     if (string.IsNullOrEmpty(alternative.AlternativeName))
        //     {
        //         return BadRequest(new { message = "Alternative name can't be empty." });
        //     }
        //
        //     var mappedAlternative = _mapper.Map<AlternativeDTO, IAlternative>(alternative);
        //     var newAlternative = await _service.UpdateAlternativeAsync(mappedAlternative);
        //
        //     return Ok();
        // }

        private async Task<string> AreValidAlternatives(List<AlternativeDTO> Alternatives)
        {
            if (Alternatives.Count == 0)
            {
                return "No alternatives sent.";
            }
            if (Alternatives.Count < 2)
            {
                return "Not enough alternatives sent (1 sent, at least 2 needed.)";
            }
            return "";
        }

        private async Task<string> IsValidAlternativeName(string alternativeName)
        {
            if (string.IsNullOrEmpty(alternativeName))
            {
                return "Alternative name is not set.";
            }
            if (!Regex.IsMatch(alternativeName, @"^[a-zA-Z0-9 ]+$"))
            {
                return "Alternative name contains invalid characters: " + alternativeName;
            }
            return "";
        }
    }

	public class AlternativeDTO
	{
		public string AlternativeName { get; set; }
        public float GlobalPriority { get; set; }
		public Guid Id { get; set; }
	}

}
