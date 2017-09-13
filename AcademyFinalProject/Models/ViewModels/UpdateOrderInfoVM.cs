using Microsoft.AspNetCore.Mvc;
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
        public string ProjectType { get; set; }

        [Display(Name = "Kvm")]
        public int SquareMeter { get; set; }

        [Display(Name = "Fastighet")]
        public string PropertyType { get; set; }

        [Display(Name = "Öns. byggstart")]
        [DataType(DataType.Date)]
        public DateTime RequestedStartDate { get; set; }

        [Display(Name = "ROT berättigade")]
        public int ViableROTCandidates { get; set; }
    }
}
