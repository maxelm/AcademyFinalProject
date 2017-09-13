﻿using Microsoft.AspNetCore.Mvc;
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
        [Required(ErrorMessage = "Ange ditt förnamn")]
        [Display (Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ange ditt efternamn")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ange din E-mail")]
        [EmailAddress(ErrorMessage ="Felaktig E-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Ange ditt telefonnummer")]
        [Display(Name = "Telefon")]
        [Range (0,9999999999999999, ErrorMessage ="Tel får endast innehålla siffror")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Ange din gatuadress")]
        [Display(Name = "Gatuadress")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Ange din postkod")]
        [Display(Name = "Postnr")]
        [MaxLength(5, ErrorMessage = "Postnr får endast innehålla 5 siffror")]
        [Range(0,int.MaxValue, ErrorMessage = "Postnr får endast innehålla 5 siffror")]
        public string Zip { get; set; }
        
        [Required(ErrorMessage = "Ange din stad")]
        [Display(Name = "Stad")]
        public string City { get; set; }
        
        [Display(Name = "Övrigt")]
        public string TextBox { get; set; }

        [Display(Name = "ROT berättigade")]
        [Range(0, 5, ErrorMessage ="Felaktig antal personer")]
        public int ViableROTCandidates { get; set; }
    }
}
