using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SunDiagonostics.Models
{
    public class ComputerBloodPictureReportModel
    {
        public int cbpid { get; set; }
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
        public string description { get; set; }
        [DisplayName("Branch Location")]
        public string branchLocation { get; set; }
        [DisplayName("Full Address")]
        public string fullAddress { get; set; }
 
        [DisplayName("Haemoglobin")]
        public string haemoglobin { get; set; }
        [DisplayName("Erythrocyte Count")]
        public string erythrocyteCount { get; set; }
        [DisplayName("Total WBC Count")]
        public string totalWBCCount { get; set; }
        [DisplayName("Neutrophils")]
        public string neutrophils { get; set; }
        [DisplayName("Lymphocytes")]
        public string lymphocytes { get; set; }
        [DisplayName("Eosinophils")]
        public string eosinophils { get; set; }
        [DisplayName("Eonocytes")]
        public string monocytes { get; set; }
        [DisplayName("Bcs")]
        public string bcs { get; set; }
        [DisplayName("RBCs")]
        public string rbcs { get; set; }
        [DisplayName("Platelet Count")]
        public string plateletCount { get; set; }
        [DisplayName("Methodology")]
        public string methodology { get; set; }
        [DisplayName("Basophils")]
        public string basophils { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

    }
}