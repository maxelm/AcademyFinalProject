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

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderReceived { get; set; }
        public bool IsComplete { get; set; }
        public string ProjectType { get; set; }
        public int SquareMeter { get; set; }
        public string PropertyType { get; set; }
        public DateTime RequestedStartDate { get; set; }
        public string CustomerMessage { get; set; }
        public int ViableRotcandidates { get; set; }
        public decimal WorkDiscount { get; set; }
        public decimal TravelCost { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderToProduct> OrderToProduct { get; set; }
        public ICollection<OrderToWork> OrderToWork { get; set; }
    }
}
