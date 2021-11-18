using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Company Code")]
        public string  companyCode{ get; set; }
        [Display(Name = "Remember Me")]
        public bool rememberMe { get; set; }
    }
    
}