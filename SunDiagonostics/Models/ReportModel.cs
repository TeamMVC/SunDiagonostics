using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunDiagonostics.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public int ReportTypeId { get; set; }
        public string ReportId { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}