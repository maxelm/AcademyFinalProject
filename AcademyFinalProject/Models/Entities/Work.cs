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

        public int WID { get; set; }
        public string Type { get; set; }
        public decimal StandardHourlyRate { get; set; }

        public ICollection<OrderToWork> OrderToWork { get; set; }
    }
}
