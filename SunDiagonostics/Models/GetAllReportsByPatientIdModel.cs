using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class GetAllReportsByPatientIdModel
    {       
        public int Pid { get; set; }
        public string Name { get; set; }
        public int ReportTypeId { get; set; }
        public int ReportId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public string Printer_Name { get; set; }

    }
}