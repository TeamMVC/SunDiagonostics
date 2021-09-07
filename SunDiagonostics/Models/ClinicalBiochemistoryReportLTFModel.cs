using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class ClinicalBiochemistoryReportLTFModel
    {
       public int ReportLTFid { get; set; }

        [DisplayName("Pid")]
        public int pid { get; set; }
        [DisplayName("Date")]
        public DateTime date { get; set; }
        [DisplayName("Report Name")]
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
    
        [DisplayName("Serum Bilirubin T")]
        public string serumBilirubin { get; set; }

        [DisplayName("Serum Bilirubin D")]
        public string serumBilirubinD { get; set; }

        [DisplayName("Serum Bilirubin ID")]
        public string serumBilirubinID { get; set; }

        [DisplayName("Asparate Amino SGOT")]
        public string serumAsparateAminoTransferase { get; set; }

        [DisplayName("Serum Alanine Amino Transferase SGPT")]
        public string serumAlanineAminoTransferase { get; set; }

        [DisplayName("Serum Total Protein")]
        public string serumTotalProtein { get; set; }

        [DisplayName("Serum Albumin")]
        public string serumAlbumin { get; set; }

        [DisplayName("Serum Glubulin")]
        public string serumGlubulin { get; set; }

        [DisplayName("A/g Ration")]
        public string AGRation { get; set; }

        [DisplayName("Serum Alkaline Phosphatse")]
        public string serumAlkalinePhosphatse { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

    }
}