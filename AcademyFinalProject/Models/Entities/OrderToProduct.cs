using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class OrderToProduct
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int Pid { get; set; }
        public decimal Price { get; set; }

        public Order O { get; set; }
        public Product P { get; set; }
    }
}
