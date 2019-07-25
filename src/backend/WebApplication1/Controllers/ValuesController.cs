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



        public ValuesController(IMapper mapper, IGoalRepository repository)
        {
            this._mapper = mapper;
            this.repository = repository;   
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {


            //var test = await this.repository.AddGoalAsync(new Goal("Stan"));

            //var tempGuid = Guid.Parse("79407330-7cb3-41a7-ac44-08d71028aa6c");
            //var test = await this.repository.DeleteGoalAsync(tempGuid);

            //var test = await this.repository.AddCriteriumAsync(new Criterium("Stan",5));
            var test = await this.repository.AddGoalAsync(new Goal("Stan"));

            return Ok(test);
            //return Ok();
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
