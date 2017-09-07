using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class CreateOfferWrapperVM
    {
        public CustomerInfoVM CustomerInfoVM { get; set; } 
        public SelectedProductsVM SelectedProductsVM { get; set; } 
        public AmountOfWorkVM AmountOfWorkVM { get; set; } 
    }
}
