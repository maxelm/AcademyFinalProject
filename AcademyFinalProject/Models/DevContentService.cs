using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyFinalProject.Models.ViewModels;
using AcademyFinalProject.Models.Entities;

namespace AcademyFinalProject.Models
{
    public class DevContentService : IContentService
    {
        AcademyDbContext context;

        public CustomerInfoVM GetCustomerInfo()
        {
            return new CustomerInfoVM() { FirstName = "Diar", LastName = "Marqus" };
        }

        public CustomerRequestOfferWrapperVM GetFirstView()
        {
            var x = new CustomerRequestOfferWrapperVM
            {
                CustomerInfo = new CustomerInfoVM { FirstName = "Max" },
                ProjectInfoSelection = new ProjectInfoSelectionVM { SquareMeter = 10 }

            };

            return x;
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
