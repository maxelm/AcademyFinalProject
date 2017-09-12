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

            viewModel.TotalProductCost = CalculateCustomerTotalProductCost(viewModel, cid);

            return viewModel;
        }

        private decimal CalculateCustomerTotalProductCost(SelectedProductsVM productList, int cid) // TODO: Måste provas.
        {
            var squareMeters = context.Customer
            .Where(c => c.CustomerId == cid)
            .Select(c => c.Order.SquareMeter).Single();

            return
                (productList.ShowerPrice) +
                (productList.ToiletPrice) +
                (productList.SinkPrice) +
                (productList.CabinetPrice) +
                (productList.FaucetPrice) +
                (productList.LightningPrice) +
                (productList.TilePrice * squareMeters) +
                (productList.ClinkerPrice * squareMeters);
        }

        private decimal GetProductPrice(PCategory productCategory, Product[] productList)
        {
            decimal price;
            Product product = productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory));

            if (product != null)
            {
                price = product.Price;
            }
            else
            {
                price = 0;
            }

            return price;
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
                    ViableRotcandidates = c.CustomerInfo.ViableROTCandidates,
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
                ShowOrderInfoVM = GetOrderInfoByCID(cid),
                SelectedProductsVM = GetSelectedProductsByCID(cid),
                AmountOfWorkVM = GetAmountOfWorkVM(),
            };
        }

        private ShowOrderInfoVM GetOrderInfoByCID(int cid)
        {
            return context.Customer.Where(c => c.CustomerId == cid).Select(cust => new ShowOrderInfoVM
            {
                ProjectType = cust.Order.ProjectType,
                PropertyType = cust.Order.PropertyType,
                SquareMeter = cust.Order.SquareMeter,
                ViableROTCandidates = cust.Order.ViableRotcandidates,
                RequestedStartDate = cust.Order.RequestedStartDate,
            }).SingleOrDefault();
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
            var cust = context.Customer
                .Include(c => c.Order)
                .Include(c => c.Order.OrderToProduct)
                .Include(c => c.Order.OrderToWork)
                .FirstOrDefault(c => c.CustomerId == id);

            var selectedProducts = context.Customer
                .Where(c => c.CustomerId == id)
                .SelectMany(c => c.Order.OrderToProduct.Select(otp => otp.Product))
                .ToArray();

            var selectedWork = context.Work.Select(w => w).ToArray();

            var x = new FinalOfferVM
            {
                #region Customer Information

                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Email = cust.Email,
                Phone = cust.Phone,
                Street = cust.Street,
                Zip = cust.Zip,
                City = cust.City,

                #endregion

                #region Project Specific Information

                TextBox = cust.Order.CustomerMessage,
                SelectedProjectType = cust.Order.ProjectType,
                SelectedPropertyType = cust.Order.PropertyType,
                SquareMeter = cust.Order.SquareMeter,

                #endregion

                #region Product Information


                Shower = GetProductName(PCategory.Shower, selectedProducts),
                ShowerPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Shower),

                Toilet = GetProductName(PCategory.Toilet, selectedProducts),
                ToiletPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Toilet),

                Sink = GetProductName(PCategory.Sink, selectedProducts),
                SinkPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Sink),

                Cabinet = GetProductName(PCategory.Cabinet, selectedProducts),
                CabinetPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Cabinet),

                Faucet = GetProductName(PCategory.Faucet, selectedProducts),
                FaucetPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Faucet),

                Lightning = GetProductName(PCategory.Lighting, selectedProducts),
                LightningPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Lighting),

                Tile = GetProductName(PCategory.Tile, selectedProducts),
                TilePrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Tile),

                Clinker = GetProductName(PCategory.Clinker, selectedProducts),
                ClinkerPrice = GetFinalProductPrice(cust, selectedProducts, PCategory.Clinker),

                #endregion

                #region Work Information

                DemolitionHours = GetFinalAmountOfHours(WorkType.Demolition, cust, selectedWork),
                HourlyRateDemolition = GetFinalHourlyRate(WorkType.Demolition, cust, selectedWork),

                DrainHours = GetFinalAmountOfHours(WorkType.Drain, cust, selectedWork),
                HourlyRateDrain = GetFinalHourlyRate(WorkType.Drain, cust, selectedWork),

                VentilationHours = GetFinalAmountOfHours(WorkType.Ventilation, cust, selectedWork),
                HourlyRateVentilation = GetFinalHourlyRate(WorkType.Ventilation, cust, selectedWork),

                TileHours = GetFinalAmountOfHours(WorkType.Tile, cust, selectedWork),
                HourlyRateTile = GetFinalHourlyRate(WorkType.Tile, cust, selectedWork),

                ElectricityHours = GetFinalAmountOfHours(WorkType.Electricity, cust, selectedWork),
                HourlyRateElectricity = GetFinalHourlyRate(WorkType.Electricity, cust, selectedWork),

                MountingHours = GetFinalAmountOfHours(WorkType.Mounting, cust, selectedWork),
                HourlyRateMounting = GetFinalHourlyRate(WorkType.Mounting, cust, selectedWork),

                #endregion
            };

            #region Total Calculations

            x.TotalWorkCost = CalculateFinalTotalWorkCost(x);
            x.TotalProductCost = CalculateFinalTotalProductCost(x);
            x.TotalAmountOfHours = CalculateFinalTotalAmountOfHours(x);
            x.ROTDiscount = CalculateFinalRotDiscount(x.TotalWorkCost, 1);

            #endregion

            return x;
        }

        private decimal CalculateFinalRotDiscount(decimal totalWorkCost, int eligableRotPersons) // TODO: add propfor ROTgiltiga
        {
            var rotDiscount = 0.3;
            decimal maxDiscountPerPerson = 50000;

            var discount = totalWorkCost * (decimal)rotDiscount;

            if (discount > (eligableRotPersons * maxDiscountPerPerson))
            {
                discount = (eligableRotPersons * maxDiscountPerPerson);
            }

            return discount;
        }

        private int CalculateFinalTotalAmountOfHours(FinalOfferVM x)
        {
            return
                (x.DemolitionHours) +
                (x.DrainHours) +
                (x.VentilationHours) +
                (x.TileHours) +
                (x.ElectricityHours) +
                (x.MountingHours);
        }

        private decimal CalculateFinalTotalProductCost(FinalOfferVM x)
        {
            return
                (x.ShowerPrice) +
                (x.ToiletPrice) +
                (x.SinkPrice) +
                (x.CabinetPrice) +
                (x.FaucetPrice) +
                (x.LightningPrice) +
                (x.TilePrice * x.SquareMeter) +
                (x.ClinkerPrice * x.SquareMeter);
        }

        private decimal CalculateFinalTotalWorkCost(FinalOfferVM x)
        {
            return
                (x.DemolitionHours * x.HourlyRateDemolition) +
                (x.DrainHours * x.HourlyRateDrain) +
                (x.VentilationHours * x.HourlyRateVentilation) +
                (x.TileHours * x.HourlyRateTile) +
                (x.ElectricityHours * x.HourlyRateElectricity) +
                (x.MountingHours * x.HourlyRateMounting);
        }

        private decimal GetFinalHourlyRate(WorkType workType, Customer c, Work[] workList)
        {
            return c.Order.OrderToWork
                .FirstOrDefault(i => i.WorkId == workList.FirstOrDefault(w => w.WorkType == (int)workType).WorkId).HourlyRate;
        }

        private int GetFinalAmountOfHours(WorkType workType, Customer c, Work[] workList)
        {
            return c.Order.OrderToWork
                .FirstOrDefault(i => i.WorkId == workList.FirstOrDefault(w => w.WorkType == (int)workType).WorkId).AmountOfHours;
        }

        private static decimal GetFinalProductPrice(Customer c, Product[] selectedProducts, PCategory pCategory)
        {
            decimal price;
            var selectedProduct = selectedProducts.FirstOrDefault(p => p.Category == (int)pCategory);

            if (selectedProduct != null)
            {
                int productId = selectedProduct.ProductId;
                var orderToProduct = c.Order.OrderToProduct
                    .Single(item => item.ProductId == productId);

                price = orderToProduct.Price;
            }
            else
            {
                price = 0;
            }

            return price;
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