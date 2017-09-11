using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class Work
    {
        public Work()
        {
            OrderToWork = new HashSet<OrderToWork>();
        }

        public int WorkId { get; set; }
        public int WorkType { get; set; }
        public string Description { get; set; }
        public decimal StandardHourlyRate { get; set; }

        public ICollection<OrderToWork> OrderToWork { get; set; }
    }
}
