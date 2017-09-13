using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(UpdateOfferWrapperVM.UpdateSelectedProductsVM))]
    public class UpdateSelectedProductsVM
    {
        public SelectListItem[] ShowerItems { get; set; }
        [Display(Name = "Dusch")]
        public string Shower { get; set; }
        public decimal ShowerPrice { get; set; }

        public SelectListItem[] ToiletItems { get; set; }
        [Display(Name = "Toalett")]
        public string Toilet { get; set; }
        public decimal ToiletPrice { get; set; }

        public SelectListItem[] SinkItems { get; set; }
        [Display(Name = "Handfat")]
        public string Sink { get; set; }
        public decimal SinkPrice { get; set; }

        public SelectListItem[] CabinetItems { get; set; }
        [Display(Name = "Skåp")]
        public string Cabinet { get; set; }
        public decimal CabinetPrice { get; set; }

        public SelectListItem[] FaucetItems { get; set; }
        [Display(Name = "Blandare")]
        public string Faucet { get; set; }
        public decimal FaucetPrice { get; set; }

        public SelectListItem[] LightingItems { get; set; }
        [Display(Name = "Belysning")]
        public string Lighting { get; set; }
        public decimal LightningPrice { get; set; }

        public SelectListItem[] TileItems { get; set; }
        [Display(Name = "Kakel")]
        public string Tile { get; set; }
        public decimal TilePrice { get; set; }

        public SelectListItem[] ClinkerItems { get; set; }
        [Display(Name = "Klinker")]
        public string Clinker { get; set; }
        public decimal ClinkerPrice { get; set; }

        [Display(Name = "Total kostnad")]
        public decimal TotalProductCost { get; set; }
    }
}
