using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPlanService.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
