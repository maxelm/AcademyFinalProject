using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyFinalProject.Models.ViewModels
{
    public class ShowOrderInfoVM
    {
        [Display(Name = "Uppdragstyp")]
        public string ProjectType { get; set; }

        [Display(Name = "Kvm")]
        public int SquareMeter { get; set; }

        [Display(Name = "Fastighet")]
        public string PropertyType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Offerförfrågan togs emot")]
        public DateTime OrderReceived { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Öns. byggstart")]
        public DateTime RequestedStartDate { get; set; }

        [Display(Name = "ROT berättigade")]
        public int ViableROTCandidates { get; set; }
    }
}