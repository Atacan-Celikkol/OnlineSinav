using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSinav.UI.WebMVC.Models
{
    public class RegisterViewModel
    {
        //public User User { get; set; }

        //public UserDetail UserDetail { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }

    }
}