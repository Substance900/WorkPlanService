using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkPlanService.Models
{
    public class Shift
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Duration { get; set; } = 8;
        [Key]
        public int Id { get; set; }
    }
}
