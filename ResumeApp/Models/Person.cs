using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeApp.Models
{
    public class Person
    {
        [Key]
        public int userID { get; set; }
 
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Mid Initial")]
        [StringLength(1, ErrorMessage = "The Middle Initial value cannot exceed 1 characters. ")]
        public string midName { get; set; }

     
        [Display(Name = "Last Name")]
        public string lastName{ get; set; }
        public string city { get; set; }

 
        [StringLength(2, ErrorMessage = "The state value is only two characters. ")]
        public string state { get; set; }
        public PhoneAttribute phone { get; set; }
        public EmailAddressAttribute email { get; set; }

        //navagational Properties
    }
}
