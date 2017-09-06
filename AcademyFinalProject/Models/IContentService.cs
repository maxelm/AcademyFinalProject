using AcademyFinalProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models
{
    public interface IContentService
    {
        void SaveContact();
        void SaveProductsToOrder();
        ListInquiryVM[] GetOfferInquiries();
        CustomerInfoVM GetCustomerInfo();
        SelectedProductsVM GetSelectedProducts();
        void SaveAmountOfWork();
        int[] GetWorkHourlyRates();
        CustomerRequestOfferWrapperVM GetFirstView();
    }
}
