using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class AmountOfWorkVM
    {
        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Rivning")]
        public int DemolitionHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateDemolition { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Avlopp")]
        public int DrainHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateDrain { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Ventilation")]
        public int VentilationHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateVentilation { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "Kakel")]
        public int TileHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateTile { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim.")]
        [Display(Name = "El")]
        public int ElectricityHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateElectricity { get; set; }

        [Required(ErrorMessage = "Skriv in antal tim")]
        [Display(Name = "Montering")]
        public int MountingHours { get; set; }
        [Required(ErrorMessage = "Skriv in tim deb.")]
        public int HourlyRateMounting { get; set; }

        [Display(Name = "Total summa")]
        public int Summary { get; set; }
    }
}
