//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetPaw.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime Date { get; set; }
        public string resetPassword { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string profilePicture { get; set; }
    }
}