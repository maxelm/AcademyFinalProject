using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class OrderToProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
