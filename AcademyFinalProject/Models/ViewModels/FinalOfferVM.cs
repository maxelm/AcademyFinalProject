using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class FinalOfferVM
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; } 

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Gatuadress")]
        public string Street { get; set; }

        [Display(Name = "Postkod")]
        public string Zip { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }

        [Display(Name = "Övriga Kommentarer")]
        public string TextBox { get; set; } // TODO: Behöver vi denna?

        [Display(Name = "Uppdragstyp")]
        public string SelectedProjectType { get; set; }

        [Display(Name = "Kvm")]
        public int SquareMeter { get; set; }

        [Display(Name = "Fastighet")]
        public string SelectedPropertyType { get; set; }

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

        [Display(Name = "Rivning")]
        public int DemolitionHours { get; set; }
        public decimal HourlyRateDemolition { get; set; }

        [Display(Name = "Avlopp")]
        public int DrainHours { get; set; }
        public decimal HourlyRateDrain { get; set; }

        [Display(Name = "Ventilation")]
        public int VentilationHours { get; set; }
        public decimal HourlyRateVentilation { get; set; }

        [Display(Name = "Kakel")]
        public int TileHours { get; set; }
        public decimal HourlyRateTile { get; set; }

        [Display(Name = "El")]
        public int ElectricityHours { get; set; }
        public decimal HourlyRateElectricity { get; set; }

        [Display(Name = "Montering")]
        public int MountingHours { get; set; }
        public decimal HourlyRateMounting { get; set; }

        [Display(Name = "Total summa")]
        public decimal TotalProductCost { get; set; }
        [Display(Name = "Total Hours")]
        public int TotalAmountOfHours { get; set; }
        [Display(Name = "Total Cost")]
        public decimal TotalWorkCost { get; set; }

        public decimal ROTDiscount { get; set; }

    }
}
