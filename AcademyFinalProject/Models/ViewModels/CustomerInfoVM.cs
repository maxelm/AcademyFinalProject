using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CustomerRequestOfferWrapperVM.CustomerInfo))]
    public class CustomerInfoVM
    {
        [Required(ErrorMessage = "Ange ditt förnamn")]
        [Display (Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ange ditt efternamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ange din E-mail")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Ange ditt telefonnummer")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Ange din gatuadress")]
        [Display(Name = "Gatuadress")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Ange din postkod")]
        [Display(Name = "Postkod")]
        public string Zip { get; set; }
        
        [Required(ErrorMessage = "Ange din stad")]
        [Display(Name = "Stad")]
        public string City { get; set; }
        
        [Display(Name = "Övriga Kommentarer")]
        public string TextBox { get; set; }
    }
}
