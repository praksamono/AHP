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

		[HttpGet]
		public async Task<ActionResult<List<AlternativeDTO>>> GetAlternativesAsync()
		{
			// var alternatives = await _service.GetAlternativesAsync();

			if (alternatives == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<List<AlternativeDTO>>(alternatives));
		}

		[HttpPost]
		public async Task<ActionResult<List<IAlternative>>> CreateAlternativesAsync(List<AlternativeDTO> alternatives)
		{
			foreach (var alternative in alternatives)
			{
				if (string.IsNullOrEmpty(alternative.AlternativeName))
				{
					return BadRequest(new {message = "Alternative name is not set."});
					// throw new HttpResponseException("Alternative name is not set.", HttpStatusCode.BadRequest);
				}
			}

			var mappedAlts = _mapper.Map<List<IAlternative>>(alternatives);
			// await _service.CreateAlternativesAsync(mappedAlts);

			return CreatedAtAction(nameof(GetAlternativesAsync), new { }, mappedAlts);
		}

	}

	public class AlternativeDTO
	{
		public string AlternativeName { get; set; }
		public Guid GoalId { get; set; }
	}

}
