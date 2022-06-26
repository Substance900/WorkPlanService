using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Data;
using WorkPlanService.Models;

namespace WorkPlanService.Services
{
    public class WorkServiceWithDbContext : IWorkService
    {
        private readonly ApplicationDbContext _context;

        public WorkServiceWithDbContext(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Shift AddShift(Shift shift)
        {
            var check = _context.Shifts.First(c=>c.Id==shift.Id);


            if (check is not object)
            {
                _context.Shifts.Add(shift);
                _context.SaveChangesAsync();
                return shift;
            }
            return null;
        }

        public WorkDutyPlan AddWorkDutyPlan(WorkDutyPlan workdutyplan)
        {
            var checkExisted = _context.WorkDutyPlans.Select(x => x.ShiftId == workdutyplan.ShiftId || x.WorkerId == workdutyplan.WorkerId);

            if (checkExisted?.Count() == 0)
            {
                _context.WorkDutyPlans.Add(workdutyplan);
                _context.SaveChangesAsync();
                return workdutyplan;
            }
            return null;
        }

        public Worker AddWorker(Worker worker)
        {
            var check = _context.Workers.First(c => c.Id == worker.Id);


            if (check is not object)
            {
                _context.Workers.Add(worker);
                _context.SaveChangesAsync();
                return worker;
            }
            return null;
        }

        public void DeleteShift(int id)
        {
            try
            {
                var checkExisted = _context.Shifts.First(c => c.Id == id);

                if (checkExisted is object)
                {
                    _context.Shifts.Remove(checkExisted);
                    _context.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteWorkDutyPlan(int id)
        {
            try
            {
                var checkExisted = _context.WorkDutyPlans.First(c => c.Id == id);

                if (checkExisted is object)
                {
                    _context.WorkDutyPlans.Remove(checkExisted);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteWorker(int id)
        {
            try
            {
                var checkExisted = _context.Workers.First(c => c.Id == id);

                if (checkExisted is object)
                {
                    _context.Workers.Remove(checkExisted);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Shift> GetAllShift()
        {
            return _context.Shifts.ToList();
        }

        public IEnumerable<WorkDutyPlan> GetAllWorkDutyPlan()
        {
            return _context.WorkDutyPlans.ToList();
        }

        public IEnumerable<Worker> GetAllWorker()
        {
            return _context.Workers.ToList();
        }

        public Shift GetShiftById(int id)
        {
            return _context.Shifts.First(c=>c.Id==id);
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByDate(DateTime date)
        {
            return _context.WorkDutyPlans.Where(c => c.Date == date);
        }

        public WorkDutyPlan GetWorkDutyPlanById(int id)
        {
            return _context.WorkDutyPlans.First(c => c.Id == id);
        }

        public IEnumerable<WorkDutyPlan> GetWorkDutyPlanByWorker(int workerId)
        {
            return _context.WorkDutyPlans.Where(c => c.WorkerId == workerId);
        }

        public Worker GetWorkerById(int id)
        {
            return _context.Workers.First(c => c.Id == id);
        }

        public Shift UpdateShift(Shift shift)
        {
            var check = _context.Shifts.First(c => c.Id == shift.Id);
            if (check is object)
            {
                check.StartTime = shift.StartTime;
                check.EndTime = shift.EndTime;
                _context.SaveChanges();
                return check;
            }

            return null;
        }

        public WorkDutyPlan UpdateWorkDutyPlan(WorkDutyPlan workDutyPlan)
        {
            // the only reason for update is if workerid does not exist and shift id exist 
            workDutyPlan.Date = DateTime.Today;
            var check = _context.WorkDutyPlans.First(c => c.Id == workDutyPlan.Id);
            if (check is not object)
            {
                var checkWorker = _context.WorkDutyPlans.Where(c => c.Date == workDutyPlan.Date && c.WorkerId == workDutyPlan.WorkerId);

                if (checkWorker is not object)
                {
                    //  var checkShift = _workDutyPlans.Find(c => c.Date == workDutyPlan.Date && c.WorkerId == workDutyPlan.WorkerId);
                    //if (checkWorker.ShiftId!=workDutyPlan.ShiftId)
                    //{
                    check.ShiftId = workDutyPlan.ShiftId;
                    check.WorkerId = workDutyPlan.WorkerId;
                    _context.SaveChanges();
                    // }
                }
            }
                return check;
            
        }
        public Worker UpdateWorker(Worker worker)
        {
            var existedWorker = _context.Workers.First(c => c.Id == worker.Id);
            if (existedWorker is object)
            {
                existedWorker.Name = worker.Name;
                _context.SaveChanges();
                return existedWorker;
            }
            return null;
        }
    }
}
