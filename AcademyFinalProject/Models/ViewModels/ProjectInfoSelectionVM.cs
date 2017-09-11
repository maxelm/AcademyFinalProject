using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CustomerRequestOfferWrapperVM.ProjectInfoSelection)) ]
    public class ProjectInfoSelectionVM
    {
        public SelectListItem[] ProjectTypeItems { get; set; }
        [Display(Name = "Uppdragstyp")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedProjectType { get; set; }

        [Display(Name = "Kvm")]
        [Required(ErrorMessage = "Ange antal kvm")]
        public int SquareMeter { get; set; }

        public SelectListItem[] PropertyTypeItems { get; set; }
        [Display(Name = "Fastighet")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedPropertyType { get; set; }

        [Display(Name = "Öns. byggstart")]
        [Required(ErrorMessage = "Ange önskad byggstart")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> RequestedStartDate { get; set; } // TODO: Check how to make calender selection
    }
}
