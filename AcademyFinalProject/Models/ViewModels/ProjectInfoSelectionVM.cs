﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public enum ProjectType
    {
        Badrumsrenovering = 0,
        Kakling = 1,
    }

    public enum PropertyType
    {
        Radhus = 0,
        Villa = 1,
        BRF = 2,
        Lägenhet = 3,
    }


    [Bind(Prefix = nameof(CustomerRequestOfferWrapperVM.ProjectInfoSelection))]
    public class ProjectInfoSelectionVM
    {
        public SelectListItem[] ProjectTypeItems { get; set; }
        [Display(Name = "Uppdragstyp")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedProjectType { get; set; }

        [Display(Name = "Kvm")]
        [Required(ErrorMessage = "Ange antal kvm")]
        [Range (1,int.MaxValue, ErrorMessage = "Felaktig inmatning")]
        public int SquareMeter { get; set; }

        public SelectListItem[] PropertyTypeItems { get; set; }
        [Display(Name = "Fastighet")]
        [Required(ErrorMessage = "Välj ett alternativ")]
        public string SelectedPropertyType { get; set; }

        [Display(Name = "Öns. byggstart")]
        [Required(ErrorMessage = "Ange önskad byggstart")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequestedStartDate { get; set; }
    }
}
