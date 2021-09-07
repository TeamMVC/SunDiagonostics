using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SunDiagonostics.Models
{
    public class RegistrationModel
    {
        //  public int rid { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Email")]
        public string emalid { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Confirm Password")]
        public string confirmPassword { get; set; }
        [DisplayName("Center")]
        public int CenterId { get; set; }
        public bool status { get; set; }
       
    }
}