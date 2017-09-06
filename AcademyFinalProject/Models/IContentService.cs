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
        CustomerInfoVM GetCustomerInfoById(int id);
        SelectedProductsVM GetSelectedProductsByCid(int cid);
        void SaveAmountOfWork();
        CustomerRequestOfferWrapperVM GetFirstView();
        ProductSelectionVM GetProductLists();
        CreateOfferWrapperVM GetOfferRequestById(int id);
    }
}
