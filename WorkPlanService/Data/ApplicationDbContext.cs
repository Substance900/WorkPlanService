using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkPlanService.Models;

namespace WorkPlanService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<WorkDutyPlan> WorkDutyPlans { get; set; }
    }
}
