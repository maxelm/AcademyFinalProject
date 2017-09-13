using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class UpdateOfferWrapperVM
    {
        public UpdateCustomerInfoVM UpdateCustomerInfoVM { get; set; }
        public UpdateOrderInfoVM UpdateOrderInfoVM { get; set; }
        public UpdateSelectedProductsVM UpdateSelectedProductsVM { get; set; }
        public UpdateAmountOfWorkVM UpdateAmountOfWorkVM { get; set; }
    }
}
