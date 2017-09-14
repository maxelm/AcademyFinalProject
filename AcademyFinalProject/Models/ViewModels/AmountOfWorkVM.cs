using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CreateOfferWrapperVM.AmountOfWorkVM))]
    public class AmountOfWorkVM
    {
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Rivning")]
        public int DemolitionHours { get; set; }

        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateDemolition { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Avlopp")]
        public int DrainHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateDrain { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Ventilation")]
        public int VentilationHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateVentilation { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Kakel")]
        public int TileHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateTile { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "El")]
        public int ElectricityHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateElectricity { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim")]
        [Display(Name = "Montering")]
        public int MountingHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal HourlyRateMounting { get; set; }

        [Display(Name = "Total tim:")]
        public int TotalAmountOfHours { get; set; }

        [Display(Name = "Total kostnad")]
        public decimal TotalWorkCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Display(Name = "Resekostnad")]
        public decimal TravelCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Display(Name = "Rabatt")]
        public decimal WorkDiscount { get; set; }
    }
}
