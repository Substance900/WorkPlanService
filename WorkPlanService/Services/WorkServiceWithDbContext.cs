using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Models;

namespace WorkPlanService.Services
{
    public class WorkServiceWithDbContext : IWorkService
    {

        public Shift AddShift(Shift shift)
        {
            throw new NotImplementedException();
        }

        public WorkDutyPlan AddWorkDutyPlan(WorkDutyPlan shift)
        {
            throw new NotImplementedException();
        }

        public Worker AddWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public void DeleteShift(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkDutyPlan(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorker(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shift> GetAllShift()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkDutyPlan> GetAllWorkDutyPlan()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worker> GetAllWorker()
        {
            throw new NotImplementedException();
        }

        public Shift GetShiftById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByWorker(int workerId)
        {
            throw new NotImplementedException();
        }

        public Worker GetWorkerById(int id)
        {
            throw new NotImplementedException();
        }

        public Shift UpdateShift(Shift shift)
        {
            throw new NotImplementedException();
        }

        public WorkDutyPlan UpdateWorkDutyPlan(WorkDutyPlan shift)
        {
            throw new NotImplementedException();
        }

        public Worker UpdateWorker(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
