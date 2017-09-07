using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models.Entities;
using AcademyFinalProject.Models;

namespace AcademyFinalProject.Controllers
{
    public class HomeController : Controller
    {

        IContentService contentService;

        public HomeController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        public IActionResult Index()
        {
            return View(contentService.GetFirstView());
        }

        public IActionResult CustomerRequestOffer()
        {
            return View();
        }

        public IActionResult Inquiries()
        {
            return View(contentService.GetOfferInquiries());
        }
    }
}
