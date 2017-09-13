using Microsoft.AspNetCore.Mvc;
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
        [Display(Name = "Dusch")]
        public string Shower { get; set; }
        public decimal ShowerPrice { get; set; }

        [Display(Name = "Toalett")]
        public string Toilet { get; set; }
        public decimal ToiletPrice { get; set; }


        [Display(Name = "Handfat")]
        public string Sink { get; set; }
        public decimal SinkPrice { get; set; }


        [Display(Name = "Skåp")]
        public string Cabinet { get; set; }
        public decimal CabinetPrice { get; set; }


        [Display(Name = "Blandare")]
        public string Faucet { get; set; }
        public decimal FaucetPrice { get; set; }


        [Display(Name = "Belysning")]
        public string Lightning { get; set; }
        public decimal LightningPrice { get; set; }


        [Display(Name = "Kakel")]
        public string Tile { get; set; }
        public decimal TilePrice { get; set; }


        [Display(Name = "Klinker")]
        public string Clinker { get; set; }
        public decimal ClinkerPrice { get; set; }

        [Display(Name = "Total kostnad")]
        public decimal TotalProductCost { get; set; }
    }
}
