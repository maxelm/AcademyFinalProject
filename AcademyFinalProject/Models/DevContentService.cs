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
        //AcademyDbContext context;

        public CreateCustomerInfoVM GetCustomerInfoById()
        {
            return new CreateCustomerInfoVM() { FirstName = "Diar", LastName = "Marqus" };
        }

        public CreateCustomerInfoVM GetCustomerInfoById(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerRequestOfferWrapperVM GetFirstView()
        {
            var x = new CustomerRequestOfferWrapperVM
            {
                CustomerInfo = new CreateCustomerInfoVM { FirstName = "Max" },
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

        public CreateOfferWrapperVM GetOfferRequestByCID(int id)
        {
            CreateOfferWrapperVM createOfferWrapper = new CreateOfferWrapperVM();
            createOfferWrapper.ShowCustomerInfoVM = new ShowCustomerInfoVM();
            createOfferWrapper.AmountOfWorkVM = new AmountOfWorkVM();
            createOfferWrapper.SelectedProductsVM = new SelectedProductsVM();

            createOfferWrapper.ShowCustomerInfoVM.CID = 1;
            createOfferWrapper.ShowCustomerInfoVM.LastName = "Marq";
            createOfferWrapper.ShowCustomerInfoVM.Phone = "0703042332";
            createOfferWrapper.ShowCustomerInfoVM.FirstName = "Diar";
            createOfferWrapper.ShowCustomerInfoVM.Street = "SolnaGatan 43";
            createOfferWrapper.ShowCustomerInfoVM.TextBox = "Övrig text is the shiz";
            createOfferWrapper.ShowCustomerInfoVM.Zip = "73143";
            createOfferWrapper.ShowCustomerInfoVM.Email = "Diar@gmai.com";
            createOfferWrapper.ShowCustomerInfoVM.City = "Stockholm";
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

        public ProductSelectionVM GetProductLists()
        {
            throw new NotImplementedException();
        }

        public SelectedProductsVM GetSelectedProductsByCid()
        {
            throw new NotImplementedException();
        }

        public SelectedProductsVM GetSelectedProductsByCID(int cid)
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
            throw new NotImplementedException();
        }

        ShowCustomerInfoVM IContentService.GetCustomerInfoByCID(int id)
        {
            throw new NotImplementedException();
        }

        public FinalOfferVM GetFinalOffer(int id)
        {
            return new FinalOfferVM
            {
                FirstName = "Diar",
                LastName = "Marqus",
                Email = "Diar@gmail.com",
                City = "Stockholm",
                Phone = "070312132",
                Zip = "73132",
                Street = "Gatan 23",
                Cabinet = "ItalianoSkåp",
                CabinetPrice = 500,
                Clinker = "Klinker",
                ClinkerPrice = 500,
                Faucet = "Blandaren",
                FaucetPrice = 500,
                Lightning = "Belysning",
                LightningPrice = 500,
                Sink = "Handfatet",
                SinkPrice = 500,
                Tile = "Italienskt kakel",
                TilePrice = 500,
                Shower = "DubbelDusch",
                ShowerPrice = 500,
                Toilet = "Toalettenski",
                ToiletPrice = 500,
                DemolitionHours = 7,
                HourlyRateDemolition = 100,
                DrainHours = 6,
                HourlyRateDrain = 120,
                ElectricityHours = 3,
                HourlyRateElectricity = 115,
                MountingHours = 5,
                HourlyRateMounting = 110,
                TileHours = 8,
                HourlyRateTile = 180,
                VentilationHours = 3,
                HourlyRateVentilation = 112,
                ROTDiscount = 0,
                TotalAmountOfHours = 0,
                TotalProductCost = 0,
                TextBox = "Övrigt",
                TotalWorkCost = 0,
                SelectedProjectType = "Badrumsrenovering",
                SelectedPropertyType = "Radhus",
                SquareMeter = 50
            };
        }


    }
}
