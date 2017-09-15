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

        [Route("bekraftelse")]
        [HttpGet]
        public IActionResult Confirm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(CustomerRequestOffer));
        }

        [Route("offertforfragan")]
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

            contentService.SaveCustomer(customer);

            return RedirectToAction(nameof(Confirm));
        }
    }
}
