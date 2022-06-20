using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Models;

namespace WorkPlanService.Services
{
  public  interface IWorkService
    {
        IEnumerable<Worker> GetAllWorker();
        Worker GetWorkerById(int id);
        Worker AddWorker(Worker worker);
        Worker UpdateWorker(Worker worker);
        void DeleteWorker(int id);

        IEnumerable<Shift> GetAllShift();
        Shift GetShiftById(int id);
        Shift AddShift(Shift shift);
        Shift UpdateShift(Shift shift);
        void DeleteShift(int id);


        IEnumerable<WorkDutyPlan> GetAllWorkDutyPlan();
        IEnumerable<WorkDutyPlan> GetWorkDutyPlanByDate(DateTime date);
        IEnumerable<WorkDutyPlan> GetWorkDutyPlanByWorker(int workerId);
        WorkDutyPlan AddWorkDutyPlan(WorkDutyPlan workDutyPlan);
        WorkDutyPlan UpdateWorkDutyPlan(WorkDutyPlan workDutyPlan);
        void DeleteWorkDutyPlan(int id);

    }
}
