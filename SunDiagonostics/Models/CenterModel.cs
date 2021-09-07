using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class CenterModel
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public string Address { get; set; }
        public string location { get; set; }
        public string Description { get; set; }
    }
}