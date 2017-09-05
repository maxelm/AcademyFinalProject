using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    public class CustomerInfoVM
    {
        [Required]
        [Display (Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Gatuadress")]
        public string Street { get; set; }
        
        [Required]
        [Display(Name = "Postkod")]
        public string Zip { get; set; }
        
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
        
        public string TextBox { get; set; }
    }
}
