using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SunDiagonostics.Models
{
    public class LoginModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Password")]
        public string Passward { get; set; }
        public string Name_Mobile { get; set; }
    }
}