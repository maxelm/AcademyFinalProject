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
        public int DemolitionHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateDemolition { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int DrainHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateDrain { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int VentilationHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateVentilation { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int TileHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateTile { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int ElectricityHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateElectricity { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim")]
        public int MountingHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public decimal HourlyRateMounting { get; set; }

        public int TotalAmountOfHours { get; set; }
        public decimal TotalWorkCost { get; set; }
    }
}
