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
    public class WorkPlanController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorkPlanController(IWorkService workService)
        {
            _workService = workService;
        }
        // GET: api/<WorkServiceController>

        [HttpGet("GetAllWorkDutyPlan")]
        public ActionResult<IEnumerable<WorkDutyPlan>> Get()
        {
            return Ok(_workService.GetAllWorkDutyPlan());
        }

        // GET api/<WorkServiceController>/5
        [HttpGet("GetWorkDutyPlanByDate/{id}")]
        public ActionResult<WorkDutyPlan> GetByDate(DateTime id)
        {
            var item = _workService.GetWorkDutyPlanByDate(id);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }

        // GET api/<WorkServiceController>/5
        [HttpGet("GetWorkDutyPlanByWorker/{id}")]
        public ActionResult<WorkDutyPlan> GetByWorker(int id)
        {
            var item = _workService.GetWorkDutyPlanByWorker(id);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }
        // POST api/<WorkServiceController>
        [HttpPost("PostWorkPlan")]
        public ActionResult<WorkDutyPlan> Post([FromBody] WorkDutyPlan workDuty)
        {
            var item = _workService.AddWorkDutyPlan(workDuty);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }

        // PUT api/<WorkServiceController>/5
        [HttpPut("UpdateWorkPan")]
        public ActionResult<WorkDutyPlan> Put( [FromBody] WorkDutyPlan workDutyPlan)
        {
            var item = _workService.UpdateWorkDutyPlan(workDutyPlan);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }

        // DELETE api/<WorkServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingItem = _workService.GetWorkDutyPlanById(id);

            if (existingItem == null)
            {
                return NoContent();
            }

            _workService.DeleteWorkDutyPlan(id);
            return Ok();
        }
    }
}
