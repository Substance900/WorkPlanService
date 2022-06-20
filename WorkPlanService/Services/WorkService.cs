using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Models;

namespace WorkPlanService.Services
{
    public class WorkService : IWorkService
    {
        private readonly List<Shift> _shifts;
        private readonly List<WorkDutyPlan> _workDutyPlans;
        private readonly List<Worker> _workers;

        public WorkService()
        {
            _shifts = new List<Shift> { new Shift { Id=1,StartTime="0",EndTime="8"},new Shift { Id = 2, StartTime = "8", EndTime = "16" }, new Shift { Id = 3, StartTime = "16", EndTime = "24" } };

            _workers = new List<Worker> { new Worker {Id=1,Name="John" }, new Worker { Id = 2, Name = "Frank" }, new Worker { Id = 3, Name = "Judith" }, new Worker { Id = 4, Name = "Lizzy" } };
            _workDutyPlans = new List<WorkDutyPlan> { new WorkDutyPlan { Id=1,ShiftId=1,WorkerId=1,Date=DateTime.Today}, new WorkDutyPlan { Id = 2, ShiftId = 2, WorkerId = 3, Date = DateTime.Today }, new WorkDutyPlan { Id = 3, ShiftId = 3, WorkerId =21, Date = DateTime.Today } };
        }
        public Shift AddShift(Shift shift)
        {
            // var check = _shifts.FirstOrDefault(c=>c.Id==shift.Id||c.StartTime==shift.StartTime);
            var check = _shifts.Contains(shift);

            if (!check)
            {
                _shifts.Add(shift);
                return shift;
            }
            return null;

        }

        public WorkDutyPlan AddWorkDutyPlan(WorkDutyPlan workdutyplan)
        {
            // var check = _shifts.FirstOrDefault(c=>c.Id==shift.Id||c.StartTime==shift.StartTime);
            var check = _workDutyPlans.Contains(workdutyplan);
            var checkExisted = _workDutyPlans.FindAll(x => x.ShiftId == workdutyplan.ShiftId || x.WorkerId == workdutyplan.WorkerId);

            if (checkExisted?.Count()>0)
            {
                _workDutyPlans.Add(workdutyplan);
                return workdutyplan;
            }
            return null;
        }

        public Worker AddWorker(Worker worker)
        {
            // var check = _shifts.FirstOrDefault(c=>c.Id==shift.Id||c.StartTime==shift.StartTime);
            var check = _workers.Contains(worker);

            if (!check)
            {
                _workers.Add(worker);
                return worker;
            }
            return null;
        }

        public void DeleteShift(int id)
        {
            var shift = _shifts.Find(c=>c.Id==id);
            _shifts.Remove(shift);
        }

        public void DeleteWorkDutyPlan(int id)
        {
            var workDutyPlan = _workDutyPlans.Find(c => c.Id == id);
            _workDutyPlans.Remove(workDutyPlan);
        }

        public void DeleteWorker(int id)
        {
            var worker = _workers.Find(c => c.Id == id);
            _workers.Remove(worker);
        }

        public IEnumerable<Shift> GetAllShift()
        {
            return _shifts;
        }

        public IEnumerable<WorkDutyPlan> GetAllWorkDutyPlan()
        {
            return _workDutyPlans;
        }

        public IEnumerable<Worker> GetAllWorker()
        {
            return _workers;
        }

        public Shift GetShiftById(int id)
        {
            return _shifts.Find(c=>c.Id==id);
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByDate(DateTime date)
        {
            return _workDutyPlans.FindAll(c=>c.Date==date);
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByWorker(int workerId)
        {
            return _workDutyPlans.FindAll(c => c.WorkerId == workerId);
        }

        public Worker GetWorkerById(int id)
        {
           return _workers.Find(c => c.Id == id);
        }

        public Shift UpdateShift(Shift shift)
        {
          var check=  _shifts.Find(c => c.Id == shift.Id);
            if (check is object)
            {
                check.StartTime = shift.StartTime;
                check.EndTime = shift.EndTime;
                return check;
            }
            
            return null;
        }

        public WorkDutyPlan UpdateWorkDutyPlan(WorkDutyPlan workDutyPlan)
        {// the only reason for update is if workerid does not exist and shift id exist 
            var check = _workDutyPlans.Find(c => c.Id == workDutyPlan.Id);
            if (check is object)
            {
                var checkWorker = _workDutyPlans.Find(c => c.Date == workDutyPlan.Date && c.WorkerId == workDutyPlan.WorkerId);

                if (checkWorker is not object)
                {
                  //  var checkShift = _workDutyPlans.Find(c => c.Date == workDutyPlan.Date && c.WorkerId == workDutyPlan.WorkerId);
                    //if (checkWorker.ShiftId!=workDutyPlan.ShiftId)
                    //{
                        check.ShiftId = workDutyPlan.ShiftId;
                        check.WorkerId = workDutyPlan.WorkerId;
                   // }
                }
                
                return check;
            }

            return null;
        }

        public Worker UpdateWorker(Worker worker)
        {
           var existedWorker= _workers.Find(c => c.Id == worker.Id);
            if (existedWorker is object)
            {
                existedWorker.Name = worker.Name;
                return existedWorker;
            }
            return null;
        }
    }
}
