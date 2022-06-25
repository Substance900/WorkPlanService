using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WorkPlanService.Controllers;
using WorkPlanService.Models;
using WorkPlanService.Services;
using Xunit;

namespace WorkPlanService.Test
{
    public class WorkPlanControllerTest
    {
        private readonly IWorkService _service;
        private readonly ShiftController _shiftController;
        private readonly WorkPlanController _workPlanController;

        public WorkPlanControllerTest()
        {
            _service =new WorkService();
            _shiftController =new  ShiftController(_service);
            _workPlanController = new WorkPlanController(_service);

        }
        [Fact]
        public void GetAllShiftTest()
        {
            var result = _shiftController.Get();

            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as ObjectResult;

            Assert.IsType<List<Shift>>(list.Value);

            var listShifts = list.Value as List<Shift>;

            Assert.Equal(3, listShifts.Count);


        }
        [Fact]
        public void NoTwoShift()
        {
            var testWorkPlan = new WorkDutyPlan { Date = DateTime.Today, ShiftId = 1, WorkerId = 1 };

            var result = _workPlanController.Post(testWorkPlan);

            Assert.IsType<NoContentResult>(result.Result);

            //var list = result.Result as ObjectResult;

            //Assert.IsType<NoContentResult>(list.Value);

            //var listShifts = list.Value as NoContentResult;

            //Assert..Equal(, listShifts);


        }
    }
}
