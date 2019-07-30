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
        public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync(CriteriumAlternativeDTO criteriumAlternative)
        {
            foreach (var value in criteriumAlternative.values)
            {
                if (Math.Abs(value) > 4)
                {
                    return BadRequest(new { message = "Invalid comparison value." });
                }
            }

            float[] priorities = await _mainService.AHPMethod(criteriumAlternative.values);

            //int index = 0;
            for (int i = 0; i < priorities.Length; i++)
            {
                
            }

            foreach()
            /*foreach (var criterium in mappedCriteria)
            {
              criterium.LocalPriority = priorities[index++];
            }

            var reMappedCriteria = _mapper.Map<List<ICriterium>>(mappedCriteria);

            foreach (var criterion in reMappedCriteria)
            {
              await _criteriumService.UpdateCriteriumAsync(criterion, id);
            }*/

            return Ok();
        }
    }

    public class CriteriumAlternativeDTO
    {
        public int[] values;
        public Guid criteriumID;
    }
}
