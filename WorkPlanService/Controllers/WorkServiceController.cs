using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkPlanService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkServiceController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkServiceController(IWorkService workService)
        {
            _workService = workService;
        }
        // GET: api/<WorkServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorkServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WorkServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
