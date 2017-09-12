using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyFinalProject.Models.ViewModels
{
    [Bind(Prefix = nameof(CreateOfferWrapperVM.ShowCustomerInfoVM))]
    public class ShowCustomerInfoVM
    {
        public int CID { get; set; }

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

        [Display(Name = "Övrigt")]
        public string TextBox { get; set; }
    }
}
