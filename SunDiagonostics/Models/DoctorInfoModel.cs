using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class DoctorInfoModel
    {
        public int docid { get; set; }
        public string Doc_Name { get; set; }
        public string Logo { get; set; }
        public string consultuntPathologistdname { get; set; }
        public string consultuntPathologistdegree { get; set; }
        public string consultuntRediologistdname { get; set; }
        public string consultuntRediologistdegree { get; set; }
        public int descriptions { get; set; }
        public string fullAddress { get; set; }
        public string branchLocation { get; set; }
        public string signature { get; set; }
    }
}