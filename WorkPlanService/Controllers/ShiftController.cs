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
    public class ShiftController : ControllerBase
    {
        private readonly IWorkService _workService;

        public ShiftController(IWorkService workService)
        {
            _workService = workService;
        }
        // GET: api/<WorkServiceController>

        [HttpGet("GetAllShift")]
        public ActionResult<IEnumerable<Shift>> Get()
        {
            return Ok(_workService.GetAllShift());
        }

        // GET api/<WorkServiceController>/5
        [HttpGet("GetShift/{id}")]
        public ActionResult<Shift> Get(int id)
        {
            var item = _workService.GetShiftById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<WorkServiceController>
        [HttpPost("PostShift")]
        public ActionResult<Shift> Post([FromBody] Shift shift)
        {
            var item = _workService.AddShift(shift);
            if (item == null)
            {
                return NotFound();
            }
            return CreatedAtAction("Get",item);
        }

        // PUT api/<WorkServiceController>/5
        [HttpPut("UpdateShift/{id}")]
        public ActionResult<Shift> Put([FromBody] Shift shift)
        {
            var item = _workService.UpdateShift(shift);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // DELETE api/<WorkServiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingItem = _workService.GetShiftById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _workService.DeleteShift(id);
            return Ok();
        }
    }
}
