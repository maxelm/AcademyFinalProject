using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderToProduct = new HashSet<OrderToProduct>();
        }

        public int ProductId { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderToProduct> OrderToProduct { get; set; }
    }
}
