using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class SelectedProductsVM
    {
        [Display(Name = "Dusch")]
        public string Shower { get; set; }

        [Display(Name = "Toalett")]
        public string Toilet { get; set; }

        [Display(Name = "Handfat")]
        public string Sink { get; set; }

        [Display(Name = "Skåp")]
        public string Cabinet { get; set; }

        [Display(Name = "Blandare")]
        public string Faucet { get; set; }

        [Display(Name = "Belysning")]
        public string Lightning { get; set; }

        [Display(Name = "Kakel")]
        public string Tile { get; set; }

        [Display(Name = "Klinker")]
        public string Clinker { get; set; }
    }
}
