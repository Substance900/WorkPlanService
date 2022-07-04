//using Moq;
//using System;
//using System.Collections.Generic;
//using WorkPlanService.Controllers;
//using WorkPlanService.Data;
//using WorkPlanService.Models;
//using WorkPlanService.Services;
//using Xunit;

//namespace WorkPlanDbContextTest
//{
//    public class WorkPlanDbContextControllerTest
//    {
//        public Mock<WorkServiceWithDbContext> mock = new Mock<WorkServiceWithDbContext>();
//        private readonly IWorkService _service;
//        private readonly ShiftController _shiftController;
//        private readonly WorkPlanController _workPlanController;
//        public WorkPlanDbContextControllerTest()
//        {
//            // var context = CreateDbContext();

//            // _service = new WorkServiceWithDbContext(mock.Object);
//            _service = new WorkService();
//            _shiftController = new ShiftController(_service);
//            _workPlanController = new WorkPlanController(_service);
//        }
//      //  [Fact]
//        public void GetShiftbyId()
//        {
//            mock.Setup(p => p.GetShiftById(1));
//            ShiftController emp = new ShiftController(mock.Object);
//            Shift result = _shiftController.Get(1).Value;
//            Assert.Equal(1, result.Id);
//        }
//      //  [Fact]
//        public void GetShiftDetails()
//        {
//            var employeeDTO = new Shift()
//            {
//                Id = 1,
//                StartTime = "0",
//                EndTime = "8"
//            };
//            mock.Setup(p => p.GetShiftById(1)).Returns(employeeDTO);
//            ShiftController emp = new ShiftController(mock.Object);
//            var result = emp.Get(1);
//            Assert.True(employeeDTO.Equals(result));
//        }

//        private Mock<ApplicationDbContext> CreateDbContext()
//        {
//            var context = new Mock<ApplicationDbContext>();
//            context.Setup(c => c.AddRange(new List<Shift>
//            { new Shift { Id = 1, StartTime = "0", EndTime = "8" },
//                new Shift { Id = 2, StartTime = "8", EndTime = "16" },
//                new Shift { Id = 3, StartTime = "16", EndTime = "24" }
//            }
//));



//            return context;



//        }
//    }
//}
