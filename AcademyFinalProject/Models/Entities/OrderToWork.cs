using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class OrderToWork
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int Wid { get; set; }
        public int AmountOfHours { get; set; }
        public decimal HourlyRate { get; set; }

        public Order O { get; set; }
        public Work W { get; set; }
    }
}
