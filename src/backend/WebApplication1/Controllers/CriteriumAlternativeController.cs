using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AHP.Service.Common;
using Model.Common;

namespace WebAPI
{
  [Route("api/criteriumalternatives")]
  [ApiController]
  public class CriteriumAlternativeController : ControllerBase
  {
    private readonly IMainService _mainService;
    public CriteriumAlternativeController(IMainService mainService)
    {
      _mainService = mainService;
    }

    [HttpPost]
    public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync(CriteriumAlternativeDTO criterium)
    {
      foreach (var value in criterium.values)
      {
        if (Math.Abs(value) > 4)
        {
          return BadRequest(new { message = "Invalid comparison value." });
        }
      }

      var status = await _mainService.AHPMethod(criterium.values, criterium.criteriumName);
      return Ok(/*status*/);
    }
  }

  public class CriteriumAlternativeDTO
  {
      public int[] values;
      public string criteriumName;
  }
}
