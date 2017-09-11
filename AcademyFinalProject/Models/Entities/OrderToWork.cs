using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class OrderToWork
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WorkId { get; set; }
        public int AmountOfHours { get; set; }
        public decimal HourlyRate { get; set; }

        public Order Order { get; set; }
        public Work Work { get; set; }
    }
}
