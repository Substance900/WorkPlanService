using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Models;
using WorkPlanService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkPlanService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkService _workService;


        public WorkerController(IWorkService workService)
        {
            _workService = workService;
        }
        // GET: api/<WorkServiceController>
       
        [HttpGet("GetAllWorker")]
        public ActionResult<IEnumerable<Worker>> Get()
        {
            return Ok(_workService.GetAllWorker());
        }

        // GET api/<WorkServiceController>/5
        [HttpGet("GetWorker/{id}")]
        public ActionResult<Worker> Get(int id)
        {
            var item = _workService.GetWorkerById(id);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }

        // POST api/<WorkServiceController>
        [HttpPost("PostWorker")]
        public ActionResult<Worker> Post([FromBody] Worker worker)
        {
            var item = _workService.AddWorker(worker);
            if (item == null)
            {
                return NoContent();
            }
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // PUT api/<WorkServiceController>/5
        [HttpPut("UpdateWorker")]
        public ActionResult<Worker> Put([FromBody] Worker worker)
        {
            var item = _workService.UpdateWorker(worker);
            if (item == null)
            {
                return NoContent();
            }
            return  Ok( item);
        }

        // DELETE api/<WorkServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingItem = _workService.GetWorkerById(id);

            if (existingItem == null)
            {
                return NoContent();
            }

            _workService.DeleteWorker(id);
            return Ok();
        }
    }
}
