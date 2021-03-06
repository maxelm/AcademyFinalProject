﻿using System;
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

        public CustomerRequestOfferWrapperVM GetFirstView()
        {
            return new CustomerRequestOfferWrapperVM()
            {
                CustomerInfo = new CreateCustomerInfoVM(),
                ProjectInfoSelection = GetProjectInfoLists(),
                ProductSelection = GetProductLists(),
            };
        }

        private ProjectInfoSelectionVM GetProjectInfoLists() // TODO:lägg Getproject/property metoderna i denna?
        {
            return new ProjectInfoSelectionVM
            {
                ProjectTypeItems = GetProjectTypeItems(),
                PropertyTypeItems = GetPropertyTypeItems(),
                ROTCandidateItems = GetROTCandidateItems(),
                ViableROTCandidates = 0,
            };
        }

        private SelectListItem[] GetROTCandidateItems()
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = "0", Value = "0" },
                new SelectListItem { Text = "1", Value = "1" },
                new SelectListItem { Text = "2", Value = "2" },
            };
        }

        private SelectListItem[] GetProjectTypeItems() // REDO FÖR TESTING (se över användningen av Enum)
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = "-- Välj uppdragstyp --", Value = "" },
                new SelectListItem { Text = nameof(ProjectType.Badrumsrenovering), Value = nameof(ProjectType.Badrumsrenovering) },
                new SelectListItem { Text = nameof(ProjectType.Kakling), Value = nameof(ProjectType.Kakling) },
            };
        }

        private SelectListItem[] GetProjectTypeItemsUpdate() // REDO FÖR TESTING (se över användningen av Enum)
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = nameof(ProjectType.Badrumsrenovering), Value = nameof(ProjectType.Badrumsrenovering) },
                new SelectListItem { Text = nameof(ProjectType.Kakling), Value = nameof(ProjectType.Kakling) },
            };
        }

        private SelectListItem[] GetPropertyTypeItems()
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = "-- Välj fastighet --", Value = "" },
                new SelectListItem { Text = nameof(PropertyType.Radhus), Value = nameof(PropertyType.Radhus) },
                new SelectListItem { Text = nameof(PropertyType.Villa), Value = nameof(PropertyType.Villa) },
                new SelectListItem { Text = nameof(PropertyType.BRF), Value = nameof(PropertyType.BRF) },
                new SelectListItem { Text = nameof(PropertyType.Lägenhet), Value = nameof(PropertyType.Radhus) },
            };
        }

        private SelectListItem[] GetPropertyTypeItemsUpdate()
        {
            return new SelectListItem[]
            {
                new SelectListItem { Text = nameof(PropertyType.Radhus), Value = nameof(PropertyType.Radhus) },
                new SelectListItem { Text = nameof(PropertyType.Villa), Value = nameof(PropertyType.Villa) },
                new SelectListItem { Text = nameof(PropertyType.BRF), Value = nameof(PropertyType.BRF) },
                new SelectListItem { Text = nameof(PropertyType.Lägenhet), Value = nameof(PropertyType.Radhus) },
            };
        }

        public ListInquiryVM[] GetOfferInquiries() // todo : check if acutally ordered.
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
            }).OrderByDescending(c => c.OrderReceived).ToArray();
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
            var x = context.Product.Where(p => p.Category == Convert.ToInt32(productCategory)).Select(p => new SelectListItem { Text = $"{p.Name}\t({p.Price.ToString("C")})", Value = $"{p.ProductId.ToString()}_{p.Price}" }).ToArray();
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

        private decimal CalculateCustomerTotalProductCost(UpdateSelectedProductsVM productList, int cid) // TODO: Måste provas.
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

        private string GetProductNameUpdate(PCategory productCategory, Product[] productList)
        {
            Product product = productList.FirstOrDefault(p => p.Category == Convert.ToInt32(productCategory));

            if (product != null)
            {
                return $"{product.ProductId.ToString()}_{product.Price}";
            }
            else
            {
                return null;
            }
        }

        public void SaveAmountOfWork(AmountOfWorkVM work, int id) // REDO FÖR TESTING (kanske bör göra extra metod)
        {
            var order = context.Customer.Where(c => c.CustomerId == id).Select(c => c.Order).SingleOrDefault();
            var orderId = order.OrderId;

            var orderToWork = context.OrderToWork.Where(o => o.OrderId == orderId).ToArray();
            context.OrderToWork.RemoveRange(orderToWork);

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Demolition, HourlyRate = work.HourlyRateDemolition, AmountOfHours = work.DemolitionHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Drain, HourlyRate = work.HourlyRateDrain, AmountOfHours = work.DrainHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Ventilation, HourlyRate = work.HourlyRateVentilation, AmountOfHours = work.VentilationHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Tile, HourlyRate = work.HourlyRateTile, AmountOfHours = work.TileHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Electricity, HourlyRate = work.HourlyRateElectricity, AmountOfHours = work.ElectricityHours });

            context.OrderToWork.Add(new OrderToWork { OrderId = orderId, WorkId = (int)WorkType.Mounting, HourlyRate = work.HourlyRateMounting, AmountOfHours = work.MountingHours });

            order.TravelCost = work.TravelCost;
            order.WorkDiscount = work.WorkDiscount;
            order.IsComplete = true;

            context.SaveChanges();
        }

        public void SaveCustomer(CustomerRequestOfferWrapperVM c)
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
                    CustomerMessage = c.ProjectInfoSelection.TextBox,
                    ViableRotcandidates = c.ProjectInfoSelection.ViableROTCandidates,
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

        public CreateOfferWrapperVM GetOfferRequestByCID(int id) // REDO FÖR TESTING
        {
            return new CreateOfferWrapperVM
            {
                ShowCustomerInfoVM = GetCustomerInfoByCID(id),
                ShowOrderInfoVM = GetOrderInfoByCID(id),
                SelectedProductsVM = GetSelectedProductsByCID(id),
                AmountOfWorkVM = GetAmountOfWorkVM(id),
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
                OrderReceived = cust.Order.OrderReceived,
                RequestedStartDate = cust.Order.RequestedStartDate,
            }).SingleOrDefault();
        }

        private AmountOfWorkVM GetAmountOfWorkVM(int id)
        {
            var orderToWork = context.Customer.Where(c => c.CustomerId == id).SelectMany(c => c.Order.OrderToWork.Where(i => i.OrderId == c.Order.OrderId)).ToArray();

            var workList = context.Work.Select(w => w).ToArray();

            if (orderToWork.Count() > 0)
            {
                if (orderToWork.Count() > 6)
                {
                    throw new Exception("ska bara kunna ha 6 ordertoproducts..");
                }
                var order = context.Customer.Where(c => c.CustomerId == id).Select(c => c.Order).Single();

                var x = context.Customer.Where(c => c.CustomerId == id).Select(c => new AmountOfWorkVM
                {
                    DemolitionHours = GetAmountOfHours(WorkType.Demolition, orderToWork, workList),
                    HourlyRateDemolition = GetHourlyRate(WorkType.Demolition, orderToWork, workList),

                    DrainHours = GetAmountOfHours(WorkType.Drain, orderToWork, workList),
                    HourlyRateDrain = GetHourlyRate(WorkType.Drain, orderToWork, workList),

                    VentilationHours = GetAmountOfHours(WorkType.Ventilation, orderToWork, workList),
                    HourlyRateVentilation = GetHourlyRate(WorkType.Ventilation, orderToWork, workList),

                    TileHours = GetAmountOfHours(WorkType.Tile, orderToWork, workList),
                    HourlyRateTile = GetHourlyRate(WorkType.Tile, orderToWork, workList),

                    ElectricityHours = GetAmountOfHours(WorkType.Electricity, orderToWork, workList),
                    HourlyRateElectricity = GetHourlyRate(WorkType.Electricity, orderToWork, workList),

                    MountingHours = GetAmountOfHours(WorkType.Mounting, orderToWork, workList),
                    HourlyRateMounting = GetHourlyRate(WorkType.Mounting, orderToWork, workList),

                    TravelCost = order.TravelCost,
                    WorkDiscount = order.WorkDiscount,

                }).Single();

                x.TotalAmountOfHours = CalculateFinalTotalAmountOfHours(x);
                x.TotalWorkCost = CalculateFinalTotalWorkCost(x);

                return x;
            }
            else
            {
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
        }

        private decimal GetHrlyRate(WorkType workType, Work[] wList)
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
                ViableROTCandidates = cust.Order.ViableRotcandidates,
                RequestedStartDate = cust.Order.RequestedStartDate,
                TravelCost = cust.Order.TravelCost,
                WorkDiscount = cust.Order.WorkDiscount,

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
                HourlyRateDemolition = GetHourlyRate(WorkType.Demolition, cust, selectedWork),

                DrainHours = GetFinalAmountOfHours(WorkType.Drain, cust, selectedWork),
                HourlyRateDrain = GetHourlyRate(WorkType.Drain, cust, selectedWork),

                VentilationHours = GetFinalAmountOfHours(WorkType.Ventilation, cust, selectedWork),
                HourlyRateVentilation = GetHourlyRate(WorkType.Ventilation, cust, selectedWork),

                TileHours = GetFinalAmountOfHours(WorkType.Tile, cust, selectedWork),
                HourlyRateTile = GetHourlyRate(WorkType.Tile, cust, selectedWork),

                ElectricityHours = GetFinalAmountOfHours(WorkType.Electricity, cust, selectedWork),
                HourlyRateElectricity = GetHourlyRate(WorkType.Electricity, cust, selectedWork),

                MountingHours = GetFinalAmountOfHours(WorkType.Mounting, cust, selectedWork),
                HourlyRateMounting = GetHourlyRate(WorkType.Mounting, cust, selectedWork),

                #endregion
            };

            #region Total Calculations

            x.TotalWorkCost = CalculateFinalTotalWorkCost(x);
            x.TotalProductCost = CalculateFinalTotalProductCost(x);
            x.TotalAmountOfHours = CalculateFinalTotalAmountOfHours(x);
            x.ROTDiscount = CalculateFinalRotDiscount(x.TotalWorkCost, x.ViableROTCandidates);
            x.TotalPrice = x.TotalWorkCost + x.TotalProductCost + x.TravelCost;
            x.TotalPriceAfterDiscount = x.TotalPrice - x.ROTDiscount - x.WorkDiscount;

            x.DemlitionTotal = x.DemolitionHours * x.HourlyRateDemolition;
            x.VentilationTotal = x.VentilationHours * x.HourlyRateVentilation;
            x.ElectricityTotal = x.ElectricityHours * x.HourlyRateElectricity;
            x.TileTotal = x.TileHours * x.HourlyRateTile;
            x.DrainTotal = x.DrainHours * x.HourlyRateDrain;
            x.MountingTotal = x.MountingHours * x.HourlyRateMounting;

            x.TileTotalCost = x.SquareMeter * x.TilePrice;
            x.ClinkerTotalCost = x.SquareMeter * x.ClinkerPrice;

            #endregion

            return x;
        }

        private decimal CalculateFinalRotDiscount(decimal totalWorkCost, int eligableRotPersons)
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

        private int CalculateFinalTotalAmountOfHours(AmountOfWorkVM x)
        {
            return
                (x.DemolitionHours) +
                (x.DrainHours) +
                (x.VentilationHours) +
                (x.TileHours) +
                (x.ElectricityHours) +
                (x.MountingHours);
        }

        private int CalculateFinalTotalAmountOfHours(UpdateAmountOfWorkVM x)
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

        private decimal CalculateFinalTotalWorkCost(AmountOfWorkVM x)
        {
            return
                (x.DemolitionHours * x.HourlyRateDemolition) +
                (x.DrainHours * x.HourlyRateDrain) +
                (x.VentilationHours * x.HourlyRateVentilation) +
                (x.TileHours * x.HourlyRateTile) +
                (x.ElectricityHours * x.HourlyRateElectricity) +
                (x.MountingHours * x.HourlyRateMounting);
        }

        private decimal CalculateFinalTotalWorkCost(UpdateAmountOfWorkVM x)
        {
            return
                (x.DemolitionHours * x.HourlyRateDemolition) +
                (x.DrainHours * x.HourlyRateDrain) +
                (x.VentilationHours * x.HourlyRateVentilation) +
                (x.TileHours * x.HourlyRateTile) +
                (x.ElectricityHours * x.HourlyRateElectricity) +
                (x.MountingHours * x.HourlyRateMounting);
        }

        private decimal GetHourlyRate(WorkType workType, Customer c, Work[] workList)
        {
            return c.Order.OrderToWork
                .FirstOrDefault(i => i.WorkId == workList.FirstOrDefault(w => w.WorkType == (int)workType).WorkId).HourlyRate;
        }

        private decimal GetHourlyRate(WorkType workType, OrderToWork[] orderToWork, Work[] workList)
        {
            return orderToWork
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

        public void DeleteCustomer(int customerID, string saveCommand = "SaveChanges")
        {
            var customer = context.Customer.First(c => c.CustomerId == customerID);
            var order = context.Customer.Where(c => c.CustomerId == customerID).Select(c => c.Order).Single();
            var OID = order.OrderId;

            var orderToProductItems = context.OrderToProduct.Where(i => i.OrderId == OID).Select(i => i).ToArray();
            context.OrderToProduct.RemoveRange(orderToProductItems);

            var orderToWorkItems = context.OrderToWork.Where(i => i.OrderId == OID).Select(i => i).ToArray();
            context.OrderToWork.RemoveRange(orderToWorkItems);

            context.Order.Remove(order);
            context.Customer.Remove(customer);

            if (saveCommand == "SaveChanges")
            {
                context.SaveChanges();
            }
        }

        public UpdateOfferWrapperVM UpdateOffer(int id)
        {
            return new UpdateOfferWrapperVM
            {
                UpdateCustomerInfoVM = GetCustomerInfoUpdate(id),
                UpdateOrderInfoVM = GetOrderInfoUpdate(id),
                UpdateSelectedProductsVM = GetSelectedProductsUpdate(id),
                UpdateAmountOfWorkVM = GetAmountOfWorkUpdate(id),
            };
        }

        private UpdateSelectedProductsVM GetSelectedProductsUpdate(int id)
        {
            var selectedProducts = context.Customer
                .Where(c => c.CustomerId == id)
                .SelectMany(c => c.Order.OrderToProduct.Select(otp => otp.Product))
                .ToArray();

            var m = new UpdateSelectedProductsVM
            {
                Shower = GetProductNameUpdate(PCategory.Shower, selectedProducts),
                Toilet = GetProductNameUpdate(PCategory.Toilet, selectedProducts),
                Sink = GetProductNameUpdate(PCategory.Sink, selectedProducts),
                Cabinet = GetProductNameUpdate(PCategory.Cabinet, selectedProducts),
                Faucet = GetProductNameUpdate(PCategory.Faucet, selectedProducts),
                Lighting = GetProductNameUpdate(PCategory.Lighting, selectedProducts),
                Tile = GetProductNameUpdate(PCategory.Tile, selectedProducts),
                Clinker = GetProductNameUpdate(PCategory.Clinker, selectedProducts),
            };

            m.ShowerItems = SetSelectItemUpdate(PCategory.Shower);
            m.ToiletItems = SetSelectItemUpdate(PCategory.Toilet);
            m.SinkItems = SetSelectItemUpdate(PCategory.Sink);
            m.CabinetItems = SetSelectItemUpdate(PCategory.Cabinet);
            m.FaucetItems = SetSelectItemUpdate(PCategory.Faucet);
            m.LightingItems = SetSelectItemUpdate(PCategory.Lighting);
            m.TileItems = SetSelectItemUpdate(PCategory.Tile);
            m.ClinkerItems = SetSelectItemUpdate(PCategory.Clinker);

            return m;
        }

        private SelectListItem[] SetSelectItemUpdate(PCategory productCategory)
        {
            var x = context.Product.Where(p => p.Category == (int)productCategory).Select(p => p);

            var selectListItems = new List<SelectListItem>();

            selectListItems.Add(new SelectListItem { Text = $"-- Inget val --", Value = $"0" });

            foreach (var product in x)
            {
                selectListItems.Add(new SelectListItem { Text = $"{product.Name}\t({product.Price.ToString("C")})", Value = $"{product.ProductId.ToString()}_{product.Price}" });
            }

            return selectListItems.ToArray();
        }

        #region RIP BeautifulCode
        //private SelectListItem[] SetSelectItemUpdate(PCategory productCategory, string chosenProduct)
        //{
        //    var x = context.Product.Where(p => p.Category == (int)productCategory).Select(p => p);

        //    var selectListItems = new List<SelectListItem>();

        //    selectListItems.Add(new SelectListItem { Text = $"-- Inget val --", Value = $"0", Selected = (chosenProduct == null) });

        //    foreach (var product in x)
        //    {

        //        selectListItems.Add(new SelectListItem { Text = $"{product.Name}\t({product.Price.ToString()} SEK)", Value = $"{product.ProductId.ToString()}_{product.Price}", Selected = (product.Name == chosenProduct) });
        //    }

        //    return selectListItems.ToArray();
        //}
        #endregion

        private UpdateAmountOfWorkVM GetAmountOfWorkUpdate(int id)
        {
            var orderToWork = context.Customer.Where(c => c.CustomerId == id).SelectMany(c => c.Order.OrderToWork.Where(i => i.OrderId == c.Order.OrderId)).ToArray();

            var workList = context.Work.Select(w => w).ToArray();

            if (orderToWork.Count() > 0)
            {
                if (orderToWork.Count() > 6)
                {
                    throw new Exception("ska bara kunna ha 6 ordertoproducts..");
                }
                var order = context.Customer.Where(c => c.CustomerId == id).Select(c => c.Order).Single();

                var x = context.Customer.Where(c => c.CustomerId == id).Select(c => new UpdateAmountOfWorkVM
                {
                    DemolitionHours = GetAmountOfHours(WorkType.Demolition, orderToWork, workList),
                    HourlyRateDemolition = GetHourlyRate(WorkType.Demolition, orderToWork, workList),

                    DrainHours = GetAmountOfHours(WorkType.Drain, orderToWork, workList),
                    HourlyRateDrain = GetHourlyRate(WorkType.Drain, orderToWork, workList),

                    VentilationHours = GetAmountOfHours(WorkType.Ventilation, orderToWork, workList),
                    HourlyRateVentilation = GetHourlyRate(WorkType.Ventilation, orderToWork, workList),

                    TileHours = GetAmountOfHours(WorkType.Tile, orderToWork, workList),
                    HourlyRateTile = GetHourlyRate(WorkType.Tile, orderToWork, workList),

                    ElectricityHours = GetAmountOfHours(WorkType.Electricity, orderToWork, workList),
                    HourlyRateElectricity = GetHourlyRate(WorkType.Electricity, orderToWork, workList),

                    MountingHours = GetAmountOfHours(WorkType.Mounting, orderToWork, workList),
                    HourlyRateMounting = GetHourlyRate(WorkType.Mounting, orderToWork, workList),

                    TravelCost = order.TravelCost,
                    WorkDiscount = order.WorkDiscount,

                }).Single();

                x.TotalAmountOfHours = CalculateFinalTotalAmountOfHours(x);
                x.TotalWorkCost = CalculateFinalTotalWorkCost(x);

                return x;
            }
            else
            {
                return new UpdateAmountOfWorkVM
                {
                    HourlyRateDemolition = GetHrlyRate(WorkType.Demolition, workList),
                    HourlyRateDrain = GetHrlyRate(WorkType.Drain, workList), //TODO : HÄR SMÄLLER DET
                    HourlyRateVentilation = GetHrlyRate(WorkType.Ventilation, workList),
                    HourlyRateTile = GetHrlyRate(WorkType.Tile, workList),
                    HourlyRateElectricity = GetHrlyRate(WorkType.Electricity, workList),
                    HourlyRateMounting = GetHrlyRate(WorkType.Mounting, workList),
                };
            }

        }

        private int GetAmountOfHours(WorkType workType, OrderToWork[] y, Work[] workList)
        {
            int amountOfHours = 0;

            var x = y.First(i => i.WorkId == workList.FirstOrDefault(w => w.WorkType == (int)workType).WorkId);

            if (x != null)
            {
                amountOfHours = x.AmountOfHours;
            }

            return amountOfHours;
        }

        private UpdateOrderInfoVM GetOrderInfoUpdate(int id)
        {
            return context.Customer.Where(c => c.CustomerId == id).Select(cust => new UpdateOrderInfoVM
            {
                ProjectType = cust.Order.ProjectType,
                PropertyType = cust.Order.PropertyType,
                SquareMeter = cust.Order.SquareMeter,
                ViableROTCandidates = cust.Order.ViableRotcandidates,
                ROTCandidateItems = GetROTCandidateItems(),
                OrderReceived = cust.Order.OrderReceived,
                RequestedStartDate = cust.Order.RequestedStartDate,
                TravelCost = cust.Order.TravelCost,
                WorkDiscount = cust.Order.WorkDiscount,
                ProjectTypeItems = GetProjectTypeItemsUpdate(),
                PropertyTypeItems = GetPropertyTypeItemsUpdate(),
                TextBox = cust.Order.CustomerMessage,

            }).SingleOrDefault();
        }

        private UpdateCustomerInfoVM GetCustomerInfoUpdate(int id)
        {
            return context.Customer.Where(c => c.CustomerId == id).Select(c => new UpdateCustomerInfoVM
            {
                CID = id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Street = c.Street,
                Zip = c.Zip,
                City = c.City,
                Email = c.Email,
                Phone = c.Phone,
            }).SingleOrDefault();
        }

        public void SaveOfferUpdate(UpdateOfferWrapperVM m, int id)
        {
            bool isComplete = context.Order.Where(o => o.CustomerId == id).Select(o => o.IsComplete).Single();

            DeleteCustomer(id, "SaveLater");

            Customer cust = new Customer
            {
                FirstName = m.UpdateCustomerInfoVM.FirstName,
                LastName = m.UpdateCustomerInfoVM.LastName,
                Street = m.UpdateCustomerInfoVM.Street,
                Zip = m.UpdateCustomerInfoVM.Zip,
                City = m.UpdateCustomerInfoVM.City,
                Email = m.UpdateCustomerInfoVM.Email,
                Phone = m.UpdateCustomerInfoVM.Phone,

                Order = new Order
                {
                    IsComplete = isComplete,
                    OrderReceived = m.UpdateOrderInfoVM.OrderReceived,
                    ProjectType = m.UpdateOrderInfoVM.ProjectType,
                    PropertyType = m.UpdateOrderInfoVM.PropertyType,
                    SquareMeter = m.UpdateOrderInfoVM.SquareMeter,
                    RequestedStartDate = m.UpdateOrderInfoVM.RequestedStartDate,
                    CustomerMessage = m.UpdateOrderInfoVM.TextBox,
                    ViableRotcandidates = m.UpdateOrderInfoVM.ViableROTCandidates,
                    TravelCost = m.UpdateOrderInfoVM.TravelCost,
                    WorkDiscount = m.UpdateOrderInfoVM.WorkDiscount,
                }
            };

            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Shower, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Toilet, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Sink, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Cabinet, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Faucet, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Lighting, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Tile, cust);
            AddSelectedProductToOrder(m.UpdateSelectedProductsVM.Clinker, cust);

            AddWorkToOrder(m.UpdateAmountOfWorkVM, cust.Order.OrderToWork);

            context.Customer.Add(cust);

            context.SaveChanges();
        }

        private void AddWorkToOrder(UpdateAmountOfWorkVM m, ICollection<OrderToWork> orderToWork)
        {
            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Demolition,
                AmountOfHours = m.DemolitionHours,
                HourlyRate = m.HourlyRateDemolition
            });

            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Drain,
                AmountOfHours = m.DrainHours,
                HourlyRate = m.HourlyRateDrain
            });

            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Electricity,
                AmountOfHours = m.ElectricityHours,
                HourlyRate = m.HourlyRateElectricity
            });

            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Mounting,
                AmountOfHours = m.MountingHours,
                HourlyRate = m.HourlyRateMounting
            });

            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Tile,
                AmountOfHours = m.TileHours,
                HourlyRate = m.HourlyRateTile
            });

            orderToWork.Add(new OrderToWork
            {
                WorkId = (int)WorkType.Ventilation,
                AmountOfHours = m.VentilationHours,
                HourlyRate = m.HourlyRateVentilation
            });

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