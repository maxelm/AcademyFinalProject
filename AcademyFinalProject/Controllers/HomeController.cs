using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcademyFinalProject.Models.Entities;

namespace AcademyFinalProject.Controllers
{
    public class HomeController : Controller
    {

        AcademyDbContext context;

        public HomeController(AcademyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerRequestOffer()
        {
            return View();
        }
    }
}
