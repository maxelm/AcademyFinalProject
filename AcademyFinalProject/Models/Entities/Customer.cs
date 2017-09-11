using System;
using System.Collections.Generic;

namespace AcademyFinalProject.Models.Entities
{
    public partial class Customer
    {
        public int Cid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProjectType { get; set; }
        public int SquareMeter { get; set; }
        public string PropertyType { get; set; }
        public DateTime RequestedStartDate { get; set; }
        public string CustomerMessage { get; set; }

        public Order Order { get; set; }
    }
}
