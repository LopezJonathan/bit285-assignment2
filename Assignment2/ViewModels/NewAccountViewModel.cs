using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Assignment2.Models;

namespace Assignment2.ViewModels
{
    public class NewAccountViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public String Email { get; set; }

        public int ProgramID { get; set; }

        [Required]
        [Display(Name = "Program Options")]

        public virtual ICollection<Program> ProgramOptions { get; set; }

        [Required]
        [Display(Name = "email me program updates")]
        public bool EmailUpdates { get; set; }

    }
}