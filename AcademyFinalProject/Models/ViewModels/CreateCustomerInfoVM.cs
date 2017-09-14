using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CustomerRequestOfferWrapperVM.CustomerInfo))]
    public class CreateCustomerInfoVM
    {
        [Display (Name = "Förnamn")]
        [Required(ErrorMessage = "Ange ditt förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Ange ditt efternamn")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Ange din E-mail")]
        [EmailAddress(ErrorMessage ="Felaktig E-mail")]
        public string Email { get; set; }
        
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Ange ditt telefonnummer")]
        [Range (0,9999999999999999, ErrorMessage ="Tel får endast innehålla siffror")]
        public string Phone { get; set; }
        
        [Display(Name = "Gatuadress")]
        [Required(ErrorMessage = "Ange din gatuadress")]
        public string Street { get; set; }
        
        [Display(Name = "Postnr")]
        [Required(ErrorMessage = "Ange din postkod")]
        [MaxLength(5, ErrorMessage = "Postnr får endast innehålla 5 siffror")]
        [Range(0,int.MaxValue, ErrorMessage = "Postnr får endast innehålla 5 siffror")]
        public string Zip { get; set; }
        
        [Display(Name = "Stad")]
        [Required(ErrorMessage = "Ange din stad")]
        public string City { get; set; }
    }
}
