using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CustomerRequestOfferWrapperVM.ProductSelection))]
    public class ProductSelectionVM
    {
        [Display(Name = "Dusch")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedShower { get; set; }
        public SelectListItem[] ShowerItems { get; set; }

        [Display(Name = "Toalett")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedToilet { get; set; }
        public SelectListItem[] ToiletItems { get; set; }

        [Display(Name = "Handfat")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedSink { get; set; }
        public SelectListItem[] SinkItems { get; set; }

        [Display(Name = "Skåp")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedCabinet { get; set; }
        public SelectListItem[] CabinetItems { get; set; }

        [Display(Name = "Blandare")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedFaucet { get; set; }
        public SelectListItem[] FaucetItems { get; set; }

        [Display(Name = "Belysning")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedLighting { get; set; }
        public SelectListItem[] LightingItems { get; set; }

        [Display(Name = "Kakel")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedTile { get; set; }
        public SelectListItem[] TileItems { get; set; }

        [Display(Name = "Klinker")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedClinker { get; set; }
        public SelectListItem[] ClinkerItems { get; set; }

        [Display(Name = "Summa")]
        public decimal TotalProductCost { get; set; }
    }
}
