using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class ClinicalBiochemistoryReportLIPIDProfileModel
    {
        public int ReportLIPIDPid { get; set; }

        [DisplayName("Pid")]
        public int pid { get; set; }
        [DisplayName("Date")]
        public DateTime date { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        public string Pname { get; set; }
        [DisplayName("Doctor Name")]
        public string DoctorName { get; set; }
        public int Srno { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string RefByDoc { get; set; }
        public string Specilization { get; set; }
        public string Qualification { get; set; }
        [DisplayName("Signature")]
        public string signature { get; set; }
        public string descriptions { get; set; }
        [DisplayName("Branch Location")]
        public string branchLocation { get; set; }
        [DisplayName("Full Address")]
        public string fullAddress { get; set; }
        
        [DisplayName("Serum Cholestrol T")]
        public string serumCholestrol { get; set; }

        [DisplayName("H D L Cholestrol")]
        public string hdlCholestrol { get; set; }

        [DisplayName("L D L Cholestrol")]
        public string LDLCholestrol { get; set; }

        [DisplayName("V L D L")]
        public string VLDLCholestrol { get; set; }

        [DisplayName("Serum Triglyceride")]
        public string serumTriglyceride { get; set; }

        [DisplayName("T/HDL")]
        public string THDL { get; set; }

        [DisplayName("LDL/HDL")]
        public string LDLHDL { get; set; }

        [DisplayName("Total Lipid")]
        public string titalLipid { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

    }
}