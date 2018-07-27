using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetPaw.Models
{
    public class Register
    {
        [Display (Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name") ]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be {1} at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Repeat Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "Enter Your Birth Day")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Enter Gender")]
        public int Gender { get; set; }
    }
}