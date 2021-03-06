﻿using AcademyFinalProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models
{
    public interface IContentService
    {
        void SaveCustomer(CustomerRequestOfferWrapperVM c);
        ListInquiryVM[] GetOfferInquiries();
        ShowCustomerInfoVM GetCustomerInfoByCID(int id);
        SelectedProductsVM GetSelectedProductsByCID(int cid);
        void SaveAmountOfWork(AmountOfWorkVM work, int cid);
        CustomerRequestOfferWrapperVM GetFirstView();
        ProductSelectionVM GetProductLists();
        CreateOfferWrapperVM GetOfferRequestByCID(int id);
        FinalOfferVM GetFinalOffer(int id);
        void DeleteCustomer(int id, string saveCommand = "SaveChanges");
        UpdateOfferWrapperVM UpdateOffer(int id);
        void SaveOfferUpdate(UpdateOfferWrapperVM model, int id);
    }
}
