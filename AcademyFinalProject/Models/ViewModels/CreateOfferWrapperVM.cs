using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class CreateOfferWrapperVM
    {
        public CustomerInfoVM CustomerInfoVM { get; set; } = new CustomerInfoVM();
        public SelectedProductsVM SelectedProductsVM { get; set; } = new SelectedProductsVM();
        public AmountOfWorkVM AmountOfWorkVM { get; set; } = new AmountOfWorkVM();
    }
}
