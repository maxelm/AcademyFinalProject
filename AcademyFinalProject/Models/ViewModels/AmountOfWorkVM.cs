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
        public int HourlyRateDemolition { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int DrainHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateDrain { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int VentilationHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateVentilation { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int TileHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateTile { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        public int ElectricityHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateElectricity { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim")]
        public int MountingHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateMounting { get; set; }

        public int Summary { get; set; }
    }
}
