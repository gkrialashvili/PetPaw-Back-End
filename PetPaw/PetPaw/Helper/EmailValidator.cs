using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;
using System.Diagnostics.CodeAnalysis;
using PetPaw.Models;


//[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
//[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
//public class RequiredAttribute : ValidationAttribute
//{

//    public RequiredAttribute()
//        : base(() => DataAnnotationsResources.RequiredAttribute_ValidationError)
//    {
//    }

namespace PetPaw.Helper
{
    public class EmailValidatorAttribute : ValidationAttribute
    {
        PetPawEntities db = new PetPawEntities();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (db.users.Any(x => x.Email == value.ToString()))
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return null;
        }
    }
}