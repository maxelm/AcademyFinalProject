using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(UpdateOfferWrapperVM.UpdateAmountOfWorkVM))]
    public class UpdateAmountOfWorkVM
    {
        [Display(Name = "Rivning")]
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int DemolitionHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateDemolition { get; set; }

        [Display(Name = "Avlopp")]
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int DrainHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateDrain { get; set; }

        [Display(Name = "Ventilation")]
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int VentilationHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateVentilation { get; set; }

        [Display(Name = "Kakel")]
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int TileHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateTile { get; set; }

        [Display(Name = "El")]
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int ElectricityHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateElectricity { get; set; }

        [Display(Name = "Montering")]
        [Required(ErrorMessage = "Skriv in antal tim")]
        [Range(0, int.MaxValue, ErrorMessage = "Antal timmar får inte vara ett negativt nummer")]
        public int MountingHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Tim debitering får inte vara ett negativt nummer")]
        public decimal HourlyRateMounting { get; set; }

        [Display(Name = "Total tim:")]
        public int TotalAmountOfHours { get; set; }

        [Display(Name = "Total kostnad")]
        public decimal TotalWorkCost { get; set; }

        [Display(Name = "Resekostnad")]
        [Required(ErrorMessage = "Skriv in resekostnad")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Resekostnaden får inte vara ett negativ nummer")]
        public decimal TravelCost { get; set; }

        [Display(Name = "Rabatt")]
        [Required(ErrorMessage = "Skriv in rabatt")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Rabatten får inte vara ett negativ nummer")]
        public decimal WorkDiscount { get; set; }
    }
}
