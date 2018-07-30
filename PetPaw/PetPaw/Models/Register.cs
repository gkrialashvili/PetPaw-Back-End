using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PetPaw.Helper;

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

        [EmailValidator (ErrorMessage = "Email Already Exists")]
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
        + "@"
        + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Please enter valid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be minimum {2} characters long.", MinimumLength = 6)]
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

        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
    }
}