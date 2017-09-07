using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class ListInquiryVM
    {
        public int CID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectType { get; set; }
        public int SquareMeter { get; set; }
        public DateTime RequestedStartDate { get; set; }
        public DateTime OrderReceived { get; set; }
        public bool IsComplete { get; set; }
        public int CID { get; set; }
    }
}
