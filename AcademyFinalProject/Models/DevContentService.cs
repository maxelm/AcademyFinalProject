using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyFinalProject.Models.ViewModels;

namespace AcademyFinalProject.Models
{

    public class DevContentService : IContentService
    {

        public CustomerInfoVM GetCustomerInfo()
        {
            return new CustomerInfoVM() { FirstName = "Diar", LastName = "Marqus" };
        }

        public ListInquiryVM[] GetOfferInquiries()
        {
            throw new NotImplementedException();
        }

        public SelectedProductsVM GetSelectedProducts()
        {
            throw new NotImplementedException();
        }

        public int[] GetWorkHourlyRates()
        {
            throw new NotImplementedException();
        }

        public void SaveAmountOfWork()
        {
            throw new NotImplementedException();
        }

        public void SaveContact()
        {
            throw new NotImplementedException();
        }

        public void SaveProductsToOrder()
        {
            throw new NotImplementedException();
        }
    }
}
