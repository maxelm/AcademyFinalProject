using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class CustomerRequestOfferWrapperVM
    {
        public CustomerInfoVM CustomerInfo { get; set; }
        public ProductSelectionVM ProductSelection { get; set; }
        public ProjectInfoSelectionVM ProjectInfoSelection { get; set; }
    }
}
