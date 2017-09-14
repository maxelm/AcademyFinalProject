using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models.Entities;
using AcademyFinalProject.Models;
using AcademyFinalProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace AcademyFinalProject.Controllers
{
    public class HomeController : Controller
    {

        IContentService contentService;

        public HomeController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet]
        public IActionResult Confirm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomerRequestOffer()
        { 
            return View(contentService.GetFirstView());
        }

        [HttpPost]
        public IActionResult CustomerRequestOffer(CustomerRequestOfferWrapperVM customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }

            contentService.SaveContact(customer);

            return RedirectToAction(nameof(Confirm));
        }
    }
}

#region utkommenterad god
//var model = new CustomerRequestOfferWrapperVM();

//model.ProjectInfoSelection.ProjectTypeItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Badrumsrenovering", Value ="1"},
//    new SelectListItem {Text = "Kakelsättning", Value ="2"},
//    new SelectListItem {Text = "Stambyte", Value ="3"}
//};

//model.ProjectInfoSelection.PropertyTypeItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Radhus", Value ="1"},
//    new SelectListItem {Text = "Bostadsrätt", Value ="2"},
//    new SelectListItem {Text = "Villa", Value ="3"}
//};

//model.ProductSelection.ShowerItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Dusch 1", Value ="1"},
//    new SelectListItem {Text = "Dusch 2", Value ="2"},
//    new SelectListItem {Text = "Dusch 3", Value ="3"}
//};

//model.ProductSelection.ToiletItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Toalett 1", Value ="1"},
//    new SelectListItem {Text = "Toalett 2", Value ="2"},
//    new SelectListItem {Text = "Toalett 3", Value ="3"}
//};

//model.ProductSelection.SinkItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Handfat 1", Value ="1"},
//    new SelectListItem {Text = "Handfat 2", Value ="2"},
//    new SelectListItem {Text = "Handfat 3", Value ="3"}
//};

//model.ProductSelection.CabinetItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Skåp 1", Value ="1"},
//    new SelectListItem {Text = "Skåp 2", Value ="2"},
//    new SelectListItem {Text = "Skåp 3", Value ="3"}
//};

//model.ProductSelection.FaucetItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Blandare 1", Value ="1"},
//    new SelectListItem {Text = "Blandare 2", Value ="2"},
//    new SelectListItem {Text = "Blandare 3", Value ="3"}
//};

//model.ProductSelection.LightingItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Belysning 1", Value ="1"},
//    new SelectListItem {Text = "Belysning 2", Value ="2"},
//    new SelectListItem {Text = "Belysning 3", Value ="3"}
//};

//model.ProductSelection.TileItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Kakel 1", Value ="1"},
//    new SelectListItem {Text = "Kakel 2", Value ="2"},
//    new SelectListItem {Text = "Kakel 3", Value ="3"}
//};

//model.ProductSelection.ClinkerItems = new SelectListItem[]
//{
//    new SelectListItem {Text = "Klinker 1", Value ="1"},
//    new SelectListItem {Text = "Klinker 2", Value ="2"},
//    new SelectListItem {Text = "Klinker 3", Value ="3"}
//};
#endregion
