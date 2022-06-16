using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPlanService.Models
{
    public class Shift
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; } = 8;
    }
}
