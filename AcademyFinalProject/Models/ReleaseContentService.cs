using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyFinalProject.Models.ViewModels;
using AcademyFinalProject.Models.Entities;

namespace AcademyFinalProject.Models
{
    public class ReleaseContentService : IContentService
    {
        AcademyDbContext context;

        public ReleaseContentService(AcademyDbContext context)
        {
            this.context = context;
        }

        public CustomerInfoVM GetCustomerInfo()
        {
            throw new NotImplementedException();
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
