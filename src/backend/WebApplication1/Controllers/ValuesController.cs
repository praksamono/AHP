using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Common;
using Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IGoalRepository repository;
        private readonly IMapper _mapper;


        public ValuesController(IGoalRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            var test = await this.repository.AddGoalAsync(new Goal());
            return Ok(test);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

  

    }
}
