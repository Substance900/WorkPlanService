using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPlanService.Models
{
    public class WorkDutyPlan
    {
        public DateTime Date { get; set; }

        public int ShiftId { get; set; }

        public int WorkerId { get; set; }
        [Key]
        public int Id { get; set; }
    }

}
