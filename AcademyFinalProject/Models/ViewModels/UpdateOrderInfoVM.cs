using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(UpdateOfferWrapperVM.UpdateOrderInfoVM))]
    public class UpdateOrderInfoVM
    {
        [Display(Name = "Uppdragstyp")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string ProjectType { get; set; }
        public SelectListItem[] ProjectTypeItems { get; set; }

        [Display(Name = "Kvm")]
        [Required(ErrorMessage = "Ange antal kvm")]
        [Range(1, int.MaxValue, ErrorMessage = "Felaktig inmatning")]
        public int SquareMeter { get; set; }

        [Display(Name = "Fastighet")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string PropertyType { get; set; }
        public SelectListItem[] PropertyTypeItems { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ange önskad byggstart")]
        [Display(Name = "Offertförfrågan togs emot")]
        public DateTime OrderReceived { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Öns. byggstart")]
        [Required(ErrorMessage = "Ange önskad byggstart")]
        public DateTime RequestedStartDate { get; set; }

        [Display(Name = "ROT berättigade")]
        [Range(0, 2, ErrorMessage = "Felaktig antal personer")]
        public int ViableROTCandidates { get; set; }
        public SelectListItem[] ROTCandidateItems { get; set; }

        [Display(Name = "Resekostnad")]
        [Required(ErrorMessage = "Skriv in rabbatt")]
        [Range(0, int.MaxValue, ErrorMessage = "Rabatten får inte vara ett negativ nummer")]
        public decimal TravelCost { get; set; }

        [Display(Name = "Rabatt")]
        [Required(ErrorMessage = "Skriv in rabbatt")]
        [Range(0, int.MaxValue, ErrorMessage = "Rabatten får inte vara ett negativ nummer")]
        public decimal WorkDiscount { get; set; }

        [Display(Name = "Övrigt")]
        public string TextBox { get; set; }
    }
}
