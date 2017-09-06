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

            //var temp = context.Customer.FirstOrDefault(c => c.Cid == 1);
            //var x = temp.Order.OrderToProduct;
            //var y = x.Where(i => i.Oid == i.)
            

            var ord = context.Order.FirstOrDefault(o => o.Oid == 1);

            var xx = ord.OrderToProduct.Where(i => i.Oid == ord.Oid).Select(p => p.P);

            foreach (var product in xx)
            {
                
            }

            throw new Exception();

        }

        public CustomerRequestOfferWrapperVM GetFirstView()
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

        public void SaveContact(CustomerInfoVM c)
        {
            context.Customer.Add(new Customer
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Street = c.Street,
                Zip = c.Zip,
                City = c.City,
                Email = c.Email,
                Phone = c.Phone,
                
                

            });
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
