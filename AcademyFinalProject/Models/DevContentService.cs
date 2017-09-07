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

        public CustomerInfoVM GetCustomerInfoById()
        {
            return new CustomerInfoVM() { FirstName = "Diar", LastName = "Marqus" };
        }

        public CustomerInfoVM GetCustomerInfoById(int id)
        {
            throw new NotImplementedException();
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
            List<ListInquiryVM> inquiries = new List<ListInquiryVM>();
            #region tempDatan till listan
            inquiries.Add(new ListInquiryVM { FirstName = "Diar", LastName = "Marquez", IsComplete = true, OrderReceived = DateTime.Now, ProjectType = "Radhus", RequestedStartDate = DateTime.Now, SquareMeter = 100, CID = 1 });
            inquiries.Add(new ListInquiryVM { FirstName = "Daniel", LastName = "Mandersson", IsComplete = true, OrderReceived = DateTime.Now, ProjectType = "Radhus", RequestedStartDate = DateTime.Now, SquareMeter = 84, CID = 2 });
            inquiries.Add(new ListInquiryVM { FirstName = "Dusan", LastName = "Mavic", IsComplete = true, OrderReceived = DateTime.Now, ProjectType = "Villa", RequestedStartDate = DateTime.Now, SquareMeter = 130, CID = 3 });
            inquiries.Add(new ListInquiryVM { FirstName = "Dogge", LastName = "Melanda", IsComplete = true, OrderReceived = DateTime.Now, ProjectType = "Lägehet", RequestedStartDate = DateTime.Now, SquareMeter = 55, CID = 4 });
            inquiries.Add(new ListInquiryVM { FirstName = "Dille", LastName = "Miftari", IsComplete = false, OrderReceived = DateTime.Now, ProjectType = "BRF", RequestedStartDate = DateTime.Now, SquareMeter = 60, CID = 5 });
            inquiries.Add(new ListInquiryVM { FirstName = "Dragan", LastName = "Mrsic", IsComplete = false, OrderReceived = DateTime.Now, ProjectType = "Lägenhet", RequestedStartDate = DateTime.Now, SquareMeter = 33, CID = 6 });
            inquiries.Add(new ListInquiryVM { FirstName = "Dalibor", LastName = "Maric", IsComplete = false, OrderReceived = DateTime.Now, ProjectType = "Lägenhet", RequestedStartDate = DateTime.Now, SquareMeter = 29, CID = 7 });
            #endregion

            return inquiries.ToArray();
        }

        public CreateOfferWrapperVM GetOfferRequestById(int id)
        {
            throw new NotImplementedException();
        }

        public ProductSelectionVM GetProductLists()
        {
            throw new NotImplementedException();
        }

        public SelectedProductsVM GetSelectedProductsByCid()
        {
            throw new NotImplementedException();
        }

        public SelectedProductsVM GetSelectedProductsByCid(int cid)
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

        public void SaveAmountOfWork(AmountOfWorkVM work, int cid)
        {
            throw new NotImplementedException();
        }

        public void SaveContact()
        {
            throw new NotImplementedException();
        }

        public void SaveContact(CustomerRequestOfferWrapperVM c)
        {
            throw new NotImplementedException();
        }

        public void SaveProductsToOrder()
        {
            throw new NotImplementedException();
        }

        public CreateOfferWrapperVM CreateOfferWrapperVM()
        {
            CreateOfferWrapperVM createOfferWrapper = new CreateOfferWrapperVM();
            createOfferWrapper.CustomerInfoVM = new CustomerInfoVM();
            createOfferWrapper.AmountOfWorkVM = new AmountOfWorkVM();
            createOfferWrapper.SelectedProductsVM = new SelectedProductsVM();

            createOfferWrapper.CustomerInfoVM.CID = 1;
            createOfferWrapper.CustomerInfoVM.FirstName = "Diar";
            createOfferWrapper.CustomerInfoVM.LastName = "Marq";
            createOfferWrapper.CustomerInfoVM.PhoneNumber = "0703042332";
            createOfferWrapper.CustomerInfoVM.Street = "SolnaGatan 43";
            createOfferWrapper.CustomerInfoVM.TextBox = "Övrig text is the shiz";
            createOfferWrapper.CustomerInfoVM.Zip = "73143";
            createOfferWrapper.CustomerInfoVM.Email = "Diar@gmai.com";
            createOfferWrapper.CustomerInfoVM.City = "Stockholm";
            createOfferWrapper.SelectedProductsVM.Cabinet = "Skåp";
            createOfferWrapper.SelectedProductsVM.Clinker = "Klinker";
            createOfferWrapper.SelectedProductsVM.Faucet = "Blandare";
            createOfferWrapper.SelectedProductsVM.Lightning = "Belysning";
            createOfferWrapper.SelectedProductsVM.Shower = "Duschenzi";
            createOfferWrapper.SelectedProductsVM.Sink = "Handfatski";
            createOfferWrapper.SelectedProductsVM.Tile = "Kakel";
            createOfferWrapper.SelectedProductsVM.Toilet = "Toalett";

            return createOfferWrapper;
        }

    }
}
