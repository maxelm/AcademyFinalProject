using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderReceived { get; set; }

        public bool IsComplete { get; set; }
    }
}
