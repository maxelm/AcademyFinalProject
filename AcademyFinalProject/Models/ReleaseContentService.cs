using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyFinalProject.Models.ViewModels;
using AcademyFinalProject.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcademyFinalProject.Models
{

    enum PCategory
    {
        Shower = 1,
        Toilet = 2,
        Sink = 3,
        Cabinet = 4,
        Faucet = 5,
        Lighting = 6,
        Tile = 7,
        Clinker = 8,
    }

    enum WorkType
    {
        Demolition = 1,
        Drain = 2,
        Ventilation = 3,
        Tile = 4,
        Electricity = 5,
        Mounting = 6,
    }

    public class ReleaseContentService : IContentService
    {
        AcademyDbContext context;

        public ReleaseContentService(AcademyDbContext context)
        {
            this.context = context;
        }

        public ShowCustomerInfoVM GetCustomerInfoByCID(int cid)
        {
            return context.Customer.Where(c => c.CustomerId == cid).Select(cust => new ShowCustomerInfoVM
            {
                CID = cid,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Street = cust.Street,
                Zip = cust.Zip,
                City = cust.City,
                Email = cust.Email,
                Phone = cust.Phone,
                TextBox = cust.Order.CustomerMessage
            }).SingleOrDefault();

        }

        public CustomerRequestOfferWrapperVM GetFirstView() // REDO FÖR TESTING
        {
            return new CustomerRequestOfferWrapperVM()
            {
                CustomerInfo = new CreateCustomerInfoVM(),
                ProjectInfoSelection = GetProjectInfoLists(),
                ProductSelection = GetProductLists(),
            };
        }

        private ProjectInfoSelectionVM GetProjectInfoLists() // REDO FÖR TESTING lägg Getproject/property metoderna i denna?
        {
            return new ProjectInfoSelectionVM
            {
                ProjectTypeItems = GetProjectTypeItems(),
                PropertyTypeItems = GetPropertyTypeItems(),
            };
        }

        private SelectListItem[] GetProjectTypeItems() // REDO FÖR TESTING (se över användningen av Enum)
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = nameof(ProjectType.Badrumsrenovering), Value = nameof(ProjectType.Badrumsrenovering) },
                new SelectListItem { Text = nameof(ProjectType.Kakling), Value = nameof(ProjectType.Kakling) },
            };
        }

        private SelectListItem[] GetPropertyTypeItems() // REDO FÖR TESTING (se över användningen av Enum)
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = nameof(PropertyType.Radhus), Value = nameof(PropertyType.Radhus) },
                new SelectListItem { Text = nameof(PropertyType.Villa), Value = nameof(PropertyType.Villa) },
                new SelectListItem { Text = nameof(PropertyType.BRF), Value = nameof(PropertyType.BRF) },
                new SelectListItem { Text = nameof(PropertyType.Lägenhet), Value = nameof(PropertyType.Radhus) },
            };
        }

        public ListInquiryVM[] GetOfferInquiries()
        {
            return context.Customer.Select(c => new ListInquiryVM
            {
                CID = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                ProjectType = c.Order.ProjectType,
                SquareMeter = c.Order.SquareMeter,
                RequestedStartDate = c.Order.RequestedStartDate,
                OrderReceived = c.Order.OrderReceived,
                IsComplete = c.Order.IsComplete,
            }).ToArray();
        }

        public ProductSelectionVM GetProductLists() // REDO FÖR TESTING
        {
            return new ProductSelectionVM()
            {
                ShowerItems = SetSelectItem(PCategory.Shower),
                ToiletItems = SetSelectItem(PCategory.Toilet),
                SinkItems = SetSelectItem(PCategory.Sink),
                CabinetItems = SetSelectItem(PCategory.Cabinet),
                FaucetItems = SetSelectItem(PCategory.Faucet),
                LightingItems = SetSelectItem(PCategory.Lighting),
                TileItems = SetSelectItem(PCategory.Tile),
                ClinkerItems = SetSelectItem(PCategory.Clinker),
            };
        }

        private SelectListItem[] SetSelectItem(PCategory productCategory) // REDO FÖR TESTING TODO: Add currrency.
        {
            var x = context.Product.Where(p => p.Category == Convert.ToInt32(productCategory)).Select(p => new SelectListItem { Text = $"{p.Name}\t({p.Price.ToString()} SEK)", Value = $"{p.ProductId.ToString()}_{p.Price}" }).ToArray();
            var y = new SelectListItem[x.Length + 1];
            y[x.Length] = new SelectListItem { Text = "-- Välj produkt --", Value = "0", Selected = true };
            Array.Copy(x, y, x.Length);

            return y;
        }

        public SelectedProductsVM GetSelectedProductsByCID(int cid) // REDO FÖR TESTING
        {
            var selectedProducts = context.Customer
                .Where(c => c.CustomerId == cid)
                .SelectMany(c => c.Order.OrderToProduct.Select(otp => otp.Product))
                .ToArray();

            var viewModel = new SelectedProductsVM
            {

                Shower = GetProductName(PCategory.Shower, selectedProducts),
                ShowerPrice = GetProductPrice(PCategory.Shower, selectedProducts),
                Toilet = GetProductName(PCategory.Toilet, selectedProducts),
                ToiletPrice = GetProductPrice(PCategory.Toilet, selectedProducts),
                Sink = GetProductName(PCategory.Sink, selectedProducts),
                SinkPrice = GetProductPrice(PCategory.Sink, selectedProducts),
                Cabinet = GetProductName(PCategory.Cabinet, selectedProducts),
                CabinetPrice = GetProductPrice(PCategory.Cabinet, selectedProducts),
                Faucet = GetProductName(PCategory.Faucet, selectedProducts),
                FaucetPrice = GetProductPrice(PCategory.Faucet, selectedProducts),
                Lightning = GetProductName(PCategory.Lighting, selectedProducts),
                LightningPrice = GetProductPrice(PCategory.Lighting, selectedProducts),
                Tile = GetProductName(PCategory.Tile, selectedProducts),
                TilePrice = GetProductPrice(PCategory.Tile, selectedProducts),
                Clinker = GetProductName(PCategory.Clinker, selectedProducts),
                ClinkerPrice = GetProductPrice(PCategory.Clinker, selectedProducts),
            };

            return viewModel;
        }

        private decimal GetProductPrice(PCategory productCategory, Product[] productList)
        {
            Product product = productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory));

            if (product != null)
            {
                return product.Price;
            }
            else
            {
                return 0;
            }
        }

        private string GetProductName(PCategory productCategory, Product[] productList)
        {
            Product product = productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory));

            if (product != null)
            {
                return product.Name;
            }
            else
            {
                return null;
            }
        }

        public void SaveAmountOfWork(AmountOfWorkVM work, int cid) // REDO FÖR TESTING (kanske bör göra extra metod)
        {
            var orderId = context.Customer.Where(c => c.CustomerId == cid).Select(c => c.Order.OrderId).SingleOrDefault();

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Demolition, HourlyRate = work.HourlyRateDemolition, AmountOfHours = work.DemolitionHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Drain, HourlyRate = work.HourlyRateDrain, AmountOfHours = work.DrainHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Ventilation, HourlyRate = work.HourlyRateVentilation, AmountOfHours = work.VentilationHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Tile, HourlyRate = work.HourlyRateTile, AmountOfHours = work.TileHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Electricity, HourlyRate = work.HourlyRateElectricity, AmountOfHours = work.ElectricityHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Mounting, HourlyRate = work.HourlyRateMounting, AmountOfHours = work.MountingHours });

            context.Order.SingleOrDefault(o => o.OrderId == orderId).IsComplete = true;

            context.SaveChanges();
        }

        public void SaveContact(CustomerRequestOfferWrapperVM c)
        {
            Customer temp = new Customer
            {
                FirstName = c.CustomerInfo.FirstName,
                LastName = c.CustomerInfo.LastName,
                Street = c.CustomerInfo.Street,
                Zip = c.CustomerInfo.Zip,
                City = c.CustomerInfo.City,
                Email = c.CustomerInfo.Email,
                Phone = c.CustomerInfo.Phone,

                Order = new Order
                {
                    OrderReceived = DateTime.Now,
                    IsComplete = false,
                    ProjectType = c.ProjectInfoSelection.SelectedProjectType,
                    PropertyType = c.ProjectInfoSelection.SelectedPropertyType,
                    SquareMeter = c.ProjectInfoSelection.SquareMeter,
                    RequestedStartDate = c.ProjectInfoSelection.RequestedStartDate,
                    CustomerMessage = c.CustomerInfo.TextBox,
                }
            };

            AddSelectedProductToOrder(c.ProductSelection.SelectedShower, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedToilet, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedSink, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedCabinet, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedFaucet, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedLighting, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedTile, temp);
            AddSelectedProductToOrder(c.ProductSelection.SelectedClinker, temp);

            context.Customer.Add(temp);
            context.SaveChanges(); //todo: async?
        }

        private void AddSelectedProductToOrder(string product, Customer temp)
        {
            if (!(product == "0"))
            {
                var productValue = product.Split("_");
                var productId = Convert.ToInt32(productValue[0]);
                var price = Convert.ToDecimal(productValue[1]);

                temp.Order.OrderToProduct.Add(new OrderToProduct { ProductId = productId, Price = price });
            }
        }

        public CreateOfferWrapperVM GetOfferRequestByCID(int cid) // REDO FÖR TESTING
        {
            return new CreateOfferWrapperVM
            {
                ShowCustomerInfoVM = GetCustomerInfoByCID(cid),
                SelectedProductsVM = GetSelectedProductsByCID(cid),
                AmountOfWorkVM = GetAmountOfWorkVM(),
            };
        }

        private AmountOfWorkVM GetAmountOfWorkVM() // REDO FÖR TESTING
        {
            var workList = context.Work.Select(w => w).ToArray();

            return new AmountOfWorkVM
            {
                HourlyRateDemolition = GetHrlyRate(WorkType.Demolition, workList),
                HourlyRateDrain = GetHrlyRate(WorkType.Drain, workList),
                HourlyRateVentilation = GetHrlyRate(WorkType.Ventilation, workList),
                HourlyRateTile = GetHrlyRate(WorkType.Tile, workList),
                HourlyRateElectricity = GetHrlyRate(WorkType.Electricity, workList),
                HourlyRateMounting = GetHrlyRate(WorkType.Mounting, workList),
            };
        }

        private decimal GetHrlyRate(WorkType workType, Work[] wList) // REDO FÖR TESTING
        {
            return wList.FirstOrDefault(w => w.WorkType == Convert.ToInt32(workType)).StandardHourlyRate;
        }

        public FinalOfferVM GetFinalOffer(int id)
        {
            throw new NotImplementedException();
        }
    }
}

#region Alternativ till SelectMany med joins
////TODO Fixa syntax
//var test1 = context.Customer
//    .Include(c => c.Order)
//    .Include(c => c.Order.OrderToProduct)
//    .Include(c => c.Order.OrderToProduct.)
//    .FirstOrDefault(c => c.CustomerId == cid)
//    .Order
//    .OrderToProduct;
#endregion