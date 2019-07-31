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
        private readonly ICriteriumAlternativeService _criteriumAlternativeService;
        public CriteriumAlternativeController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpPost]
        public async Task<ActionResult<CriteriumAlternativeDTO>> SendValuesAsync(int[] values, Guid criteriumID)
        {
            foreach (var value in values)
            {
                if (Math.Abs(value) > 4)
                {
                    return BadRequest(new { message = "Invalid comparison value." });
                }
            }

            float[] priorities = await _mainService.AHPMethod(values);
            List<ICriterium> criteriaList;
            List<IAlternative> alternativesList;

            //int index = 0;
            for (int i = 0; i < priorities.Length; i++)
            {
                //await _criteriumAlternativeService.AddCriteriumAlternativeAsync();
            }

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
