using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models;
using AcademyFinalProject.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademyFinalProject.Controllers
{
    public class CompanyController : Controller
    {
        IContentService contentService;

        public CompanyController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Inquiries()
        {
            return View(contentService.GetOfferInquiries());
        }

        [HttpGet]
        public IActionResult CreateOffer(int id)
        {
            return View(contentService.GetOfferRequestByCID(id));
        }
          
        [HttpPost]
        public IActionResult CreateOffer(CreateOfferWrapperVM model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            contentService.SaveAmountOfWork(model.AmountOfWorkVM, id);

            return RedirectToAction(nameof(FinalOffer), new { id = id });
        }

        [HttpGet]
        public IActionResult FinalOffer(int id)
        {
           return View(contentService.GetFinalOffer(id));
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            contentService.DeleteCustomer(id);

            return RedirectToAction(nameof(Inquiries));
        }

        [HttpGet]
        public IActionResult UpdateOffer(int id)
        {
            return View(contentService.UpdateOffer(id));
        }
    }
}
