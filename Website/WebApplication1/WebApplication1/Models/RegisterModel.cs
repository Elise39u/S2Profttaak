using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "Confirm your password")]
        public string ConfirmatiePassword { get; set; }
    }
}