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
  
        public ShowCustomerInfoVM GetCustomerInfoByCID(int cid) // REDO FÖR TESTING
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
                new SelectListItem { Text = nameof(ProjectType.BadrumsRenovering), Value = nameof(ProjectType.BadrumsRenovering) },
                new SelectListItem { Text = nameof(ProjectType.EndastKakling), Value = nameof(ProjectType.EndastKakling) },
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

        public ListInquiryVM[] GetOfferInquiries() // REDO FÖR TESTING
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
            y[x.Length] = new SelectListItem { Text = "--Välj produkt--", Value = "0" };
            Array.Copy(x, y, x.Length);

            return y;
        }

        public SelectedProductsVM GetSelectedProductsByCID(int cid) // REDO FÖR TESTING
        {
            var x = context.Customer.FirstOrDefault(c => c.CustomerId == cid).Order;

            //TODO Fixa syntax
            var test1 = context.Customer
                .Include(c => c.Order)
                .Include(c => c.Order.OrderToProduct)
                //.Include(c => c.Order.OrderToProduct.)
                .FirstOrDefault(c => c.CustomerId == cid)
                .Order
                .OrderToProduct;

            var test2 = context.Customer
                .Where(c => c.CustomerId == cid)
                .SelectMany(c => c.Order.OrderToProduct.Select(otp => otp.Product))
                .ToArray();

            //test1.Order = context.Order.FirstOrDefault(o => o.Cid == cid);

            var validation = context.Customer.FirstOrDefault(c => c.CustomerId == cid).Order.OrderToWork;

            return null;
            if (validation != null)
            {

                if ((validation.Count() > 0))
                {
                    IEnumerable<Product> pList = context.Customer.FirstOrDefault(c => c.CustomerId == cid).Order.OrderToProduct.Select(i => i.Product);

                    return new SelectedProductsVM // NULL CHECKA
                    {
                        Shower = GetProductName(PCategory.Shower, pList),
                        ShowerPrice = GetProductPrice(PCategory.Shower, pList),
                        Toilet = GetProductName(PCategory.Toilet, pList),
                        ToiletPrice = GetProductPrice(PCategory.Toilet, pList),
                        Sink = GetProductName(PCategory.Sink, pList),
                        SinkPrice = GetProductPrice(PCategory.Sink, pList),
                        Cabinet = GetProductName(PCategory.Cabinet, pList),
                        CabinetPrice = GetProductPrice(PCategory.Cabinet, pList),
                        Faucet = GetProductName(PCategory.Faucet, pList),
                        FaucetPrice = GetProductPrice(PCategory.Faucet, pList),
                        Lightning = GetProductName(PCategory.Lighting, pList),
                        LightningPrice = GetProductPrice(PCategory.Lighting, pList),
                        Tile = GetProductName(PCategory.Tile, pList),
                        TilePrice = GetProductPrice(PCategory.Tile, pList),
                        Clinker = GetProductName(PCategory.Clinker, pList),
                        ClinkerPrice = GetProductPrice(PCategory.Clinker, pList),
                    };
                }
            }

            else return new SelectedProductsVM();
        }

        private decimal GetProductPrice(PCategory productCategory, IEnumerable<Product> productList)// REDO FÖR TESTING
        {
            return productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory)).Price;
        }

        private string GetProductName(PCategory productCategory, IEnumerable<Product> productList)// REDO FÖR TESTING
        {
            return productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory)).Name;
        }

        public void SaveAmountOfWork(AmountOfWorkVM work, int cid) // REDO FÖR TESTING (kanske bör göra extra metod)
        {
            var orderId = context.Customer.FirstOrDefault(c => c.CustomerId == cid).Order.OrderId;
            var orderToWork = context.Customer.FirstOrDefault(c => c.CustomerId == cid).Order.OrderToWork;

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Demolition),
                AmountOfHours = work.DemolitionHours,
                HourlyRate = work.HourlyRateDemolition
            });

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Drain),
                AmountOfHours = work.DrainHours,
                HourlyRate = work.HourlyRateDrain,
            });

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Ventilation),
                AmountOfHours = work.VentilationHours,
                HourlyRate = work.HourlyRateVentilation,
            });

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Tile),
                AmountOfHours = work.TileHours,
                HourlyRate = work.HourlyRateTile,
            });

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Electricity),
                AmountOfHours = work.ElectricityHours,
                HourlyRate = work.HourlyRateElectricity,
            });

            orderToWork.Add(new OrderToWork
            {
                OrderId = orderId,
                WorkId = Convert.ToInt32(WorkType.Mounting),
                AmountOfHours = work.MountingHours,
                HourlyRate = work.HourlyRateMounting,
            });
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
            var wList = context.Work.Select(w => w).ToArray();

            return new AmountOfWorkVM
            {
                HourlyRateDemolition = GetHrlyRate(WorkType.Demolition, wList),
                HourlyRateDrain = GetHrlyRate(WorkType.Drain, wList),
                HourlyRateVentilation = GetHrlyRate(WorkType.Ventilation, wList),
                HourlyRateTile = GetHrlyRate(WorkType.Tile, wList),
                HourlyRateElectricity = GetHrlyRate(WorkType.Electricity, wList),
                HourlyRateMounting = GetHrlyRate(WorkType.Mounting, wList),
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