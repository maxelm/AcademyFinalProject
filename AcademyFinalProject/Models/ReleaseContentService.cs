using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyFinalProject.Models.ViewModels;
using AcademyFinalProject.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyFinalProject.Models
{

    enum PCategory //TODO: gör om databas till värden och tilldela.
    {
        Shower = 0,
        Toilet = 1,
        Sink = 2,
        Cabinet = 3,
        Faucet = 4,
        Lighting = 5,
        Tile = 6,
        Clinker = 7,
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

        public CustomerInfoVM GetCustomerInfoById(int id) // REDO FÖR TESTING
        {
            Customer cust = context.Customer.FirstOrDefault(c => c.Cid == id);
            return new CustomerInfoVM
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Street = cust.Street,
                Zip = cust.Zip,
                City = cust.City,
                Email = cust.Email,
                Phone = cust.Phone,
                TextBox = cust.CustomerMessage,
            };
        }

        public CustomerRequestOfferWrapperVM GetFirstView() // REDO FÖR TESTING
        {
            return new CustomerRequestOfferWrapperVM()
            {
                CustomerInfo = new CustomerInfoVM(),
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
                CID = c.Cid,
                FirstName = c.FirstName,
                LastName = c.LastName,
                ProjectType = c.ProjectType,
                SquareMeter = c.SquareMeter,
                RequestedStartDate = c.RequestedStartDate,
                OrderReceived = c.Order.OrderReceived,
                IsComplete = c.Order.IsComplete,
            }).ToArray();
        }

        public ProductSelectionVM GetProductLists() // REDO FÖR TESTING
        {
            return new ProductSelectionVM()
            {
                ShowerItems = SetSelectItem("Dusch"),
                ToiletItems = SetSelectItem("Toalett"),
                SinkItems = SetSelectItem("Handfat"),
                CabinetItems = SetSelectItem("Skåp"),
                FaucetItems = SetSelectItem("Blandare"),
                LightingItems = SetSelectItem("Belysning"),
                TileItems = SetSelectItem("Kakel"),
                ClinkerItems = SetSelectItem("Klinker"),
            };
        }

        private SelectListItem[] SetSelectItem(string productCategory) // REDO FÖR TESTING
        {
            return context.Product.Where(p => p.Category == productCategory).Select(p => new SelectListItem { Text = p.Name, Value = $"{p.Pid.ToString()}_{p.Price}" }).ToArray();
        }

        public SelectedProductsVM GetSelectedProductsByCid(int cid) // REDO FÖR TESTING
        {
            IEnumerable<Product> pList = context.Customer.FirstOrDefault(c => c.Cid == cid).Order.OrderToProduct.Select(i => i.P);

            return new SelectedProductsVM
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

        private decimal GetProductPrice(PCategory productCategory, IEnumerable<Product> productList)// REDO FÖR TESTING
        {
            return productList.FirstOrDefault(p => p.Category == nameof(productCategory)).Price;
        }

        private string GetProductName(PCategory productCategory, IEnumerable<Product> productList)// REDO FÖR TESTING
        {
            return productList.FirstOrDefault(p => p.Category == nameof(productCategory)).Name;
        }

        public void SaveAmountOfWork(AmountOfWorkVM work, int cid) // REDO FÖR TESTING (kanske bör göra extra metod)
        {
            var orderId = context.Customer.FirstOrDefault(c => c.Cid == cid).Order.Oid;
            var orderToWork = context.Customer.FirstOrDefault(c => c.Cid == cid).Order.OrderToWork;

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Demolition),
                AmountOfHours = work.DemolitionHours,
                HourlyRate = work.HourlyRateDemolition
            });

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Drain),
                AmountOfHours = work.DrainHours,
                HourlyRate = work.HourlyRateDrain,
            });

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Ventilation),
                AmountOfHours = work.VentilationHours,
                HourlyRate = work.HourlyRateVentilation,
            });

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Tile),
                AmountOfHours = work.TileHours,
                HourlyRate = work.HourlyRateTile,
            });

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Electricity),
                AmountOfHours = work.ElectricityHours,
                HourlyRate = work.HourlyRateElectricity,
            });

            orderToWork.Add(new OrderToWork
            {
                Oid = orderId,
                Wid = Convert.ToInt32(WorkType.Mounting),
                AmountOfHours = work.MountingHours,
                HourlyRate = work.HourlyRateMounting,
            });
        }

        public void SaveContact(CustomerRequestOfferWrapperVM c) // WIP 
        {
            // Skapa Kunden
            Customer temp = new Customer
            {
                FirstName = c.CustomerInfo.FirstName,
                LastName = c.CustomerInfo.LastName,
                Street = c.CustomerInfo.Street,
                Zip = c.CustomerInfo.Zip,
                City = c.CustomerInfo.City,
                Email = c.CustomerInfo.Email,
                Phone = c.CustomerInfo.Phone,
                ProjectType = c.ProjectInfoSelection.SelectedProjectType,
                PropertyType = c.ProjectInfoSelection.SelectedPropertyType,
                SquareMeter = c.ProjectInfoSelection.SquareMeter,
                RequestedStartDate = c.ProjectInfoSelection.RequestedStartDate,
                CustomerMessage = c.CustomerInfo.TextBox,

                //Skapa Ordern i Kunden
                Order = new Order
                {
                    OrderReceived = DateTime.Now,
                    IsComplete = false,
                }
            };

            //temp.Order.Cid = temp.Cid; // Ge Order CID värdet av kundens CID (nödvändigt?)


            //context.Order.Add(temp.Order); // Lägg till Ordern till Tabellen (nödvändigt?)

            // Lägg till produkterna kopplade till ordern
            temp.Order.OrderToProduct.Add(new OrderToProduct
            {
                //Oid = temp.Order.Oid,
                Pid = Convert.ToInt32(c.ProductSelection.SelectedToilet),
                Price = context.Product.FirstOrDefault(p => p.Pid == Convert.ToInt32(c.ProductSelection.SelectedToilet)).Price
            });



            context.Customer.Add(temp); // Lägg till kunden till tabellen
            context.SaveChangesAsync(); // TODO: Consider async and implications.


            /*frågor:
             * 1. När sparas ID och kan jag komma åt det innan jag sparat?
             * 2. Kommer Order som är 1:1 automatiskt lägga till CID?
             * 3. Samma fråga gällande Order2Product
             * 4. Order / Order2Product förmodar jag läggs inte till i tabellen automatiskt??
             * 5. SelectedListItems - Vad för object kan det vara? komplexa? msåte ha ProductID.
             */
        }

        public CreateOfferWrapperVM GetOfferRequestById(int id) // REDO FÖR TESTING
        {
            return new CreateOfferWrapperVM
            {
                CustomerInfoVM = GetCustomerInfoById(id),
                SelectedProductsVM = GetSelectedProductsByCid(id),
                AmountOfWorkVM = GetAmountOfWorkVM(),
            };
        }

        private AmountOfWorkVM GetAmountOfWorkVM() // REDO FÖR TESTING
        {
            IQueryable<Work> wList = context.Work.Select(w => w);

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

        private decimal GetHrlyRate(WorkType workType, IQueryable<Work> wList) // REDO FÖR TESTING
        {
            return wList.FirstOrDefault(w => w.Type == nameof(workType)).StandardHourlyRate;
        }


    }
}