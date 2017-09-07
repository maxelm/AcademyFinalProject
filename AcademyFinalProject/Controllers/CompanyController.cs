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
        public IActionResult CreateOffer(int cid)
        {
            return View(contentService.CreateOfferWrapperVM());
        }
          
        [HttpPost]
        public IActionResult CreateOffer(CreateOfferWrapperVM createOfferWrapperVM, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(createOfferWrapperVM);
            }

            //om den går igenom så lägger vi till den till databasen och ändrar iscompleted till true.

            return RedirectToAction(nameof(Index));
        }
    }
}
