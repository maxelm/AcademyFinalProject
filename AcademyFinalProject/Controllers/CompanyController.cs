using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models;
using AcademyFinalProject.Models.ViewModels;

namespace AcademyFinalProject.Controllers
{
    public class CompanyController : Controller
    {
        IContentService contentService;

        public CompanyController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("offertlista")]
        [HttpGet]
        public IActionResult Inquiries()
        {
            return View(contentService.GetOfferInquiries());
        }

        [Route("skapaoffert")]
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

            return RedirectToAction(nameof(Inquiries));
        }

        [Route("slutoffert")]
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

        [Route("uppdatera-offert")]
        [HttpGet]
        public IActionResult UpdateOffer(int id)
        {
            return View(contentService.UpdateOffer(id));
        }

        [HttpPost]
        public IActionResult UpdateOffer(UpdateOfferWrapperVM model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            contentService.SaveOfferUpdate(model, id);

            return RedirectToAction(nameof(Inquiries));
        }
    }
}
