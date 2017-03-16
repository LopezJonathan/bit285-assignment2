using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.ViewModels
{
    public class PasswordGeneratorViewModel
    {
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public int BirthYear { get; set; }

        [Required]
        [Display(Name = "Favorite Color")]
        public String FavoriteColor { get; set; }

        public String PasswordSuggestion { get; set; }
    }
}