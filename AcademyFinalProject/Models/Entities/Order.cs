using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderToProduct = new HashSet<OrderToProduct>();
            OrderToWork = new HashSet<OrderToWork>();
        }

        public int Oid { get; set; }
        public int Cid { get; set; }
        public DateTime OrderReceived { get; set; }
        public bool IsComplete { get; set; }

        public Customer C { get; set; }
        public ICollection<OrderToProduct> OrderToProduct { get; set; }
        public ICollection<OrderToWork> OrderToWork { get; set; }
    }
}
