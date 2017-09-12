using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class CreateOfferWrapperVM
    {
        public ShowCustomerInfoVM ShowCustomerInfoVM { get; set; }
        public ShowOrderInfoVM ShowOrderInfoVM { get; set; }
        public SelectedProductsVM SelectedProductsVM { get; set; } 
        public AmountOfWorkVM AmountOfWorkVM { get; set; } 
    }
}
