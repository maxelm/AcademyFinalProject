using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class AmountOfWorkVM
    {
        [Display(Name = "Rivning")]
        public string Demolition { get; set; }
        public int DemolitionHours { get; set; }
        public int HourlyRateDemolition { get; set; }

        [Display(Name = "Avlopp")]
        public string Drain { get; set; }
        public int DrainHours { get; set; }
        public int HourlyRateDrain { get; set; }

        [Display(Name = "Ventilation")]
        public string Ventilation { get; set; }
        public int VentilationHours { get; set; }
        public int HourlyRateVentilation { get; set; }

        [Display(Name = "Kakel")]
        public string Tile { get; set; }
        public int TileHours { get; set; }
        public int HourlyRateTile { get; set; }

        [Display(Name = "El-Arbete")]
        public string Electricity { get; set; }
        public int ElectricityHours { get; set; }
        public int HourlyRateElectricity { get; set; }

        [Display(Name = "Montering")]
        public string Mounting { get; set; }
        public int MountingHours { get; set; }
        public int HourlyRateMounting { get; set; }
    }
}
