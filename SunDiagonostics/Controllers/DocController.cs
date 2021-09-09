using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SunDiagonostics.Models;
using System.Web.Security;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.HtmlConverter;
using ceTe.DynamicPDF.Printing;
using System.Web.Hosting;

namespace SunDiagonostics.Controllers
{

    public class DocController : Controller
    {
        //string hostname = "akbardiagnostic.dswebcare.com";
        // GET: Doc
        public ActionResult Index()
        {
            var Reports = RetuningData.ReturnigList<ReportModel>("sp_getReports", null);

            ViewBag.ReportType = new SelectList(Reports,"Id", "ReportType");
            return View();
        }
        public ActionResult DoctorInfo()
        {
            return View();
        }
        public ActionResult Registration()
        {
            var dlist = RetuningData.ReturnigList<CenterModel>("usp_getCenter", null);
            ViewBag.Center = new SelectList(dlist, "CenterId", "CenterName");
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel reg)
        {
            var param = new DynamicParameters();
            param.Add("@Name", reg.name);
            param.Add("@Email", reg.emalid);
            param.Add("@Passward", reg.password);
            param.Add("@Status", reg.status);
            param.Add("@CenterId", 1);
           
            int i = RetuningData.AddOrSave<int>("usp_getUserLogin", param);
            if (i > 0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            var param = new DynamicParameters();
            param.Add("@Email", login.email);
            param.Add("@Passward", login.Passward);

            LoginModel _login = RetuningData.ReturnigList<LoginModel>("sp_getLogin", param).SingleOrDefault();
            if (_login != null)
            {
                //FormsAuthentication.SetAuthCookie(param.UserName, false);
                Session["UserId"] = _login.id;
                return RedirectToAction("Dashboard");

            }
            else
            {
                return View();
            }
        }

        public ActionResult PatientInfo()
        {
            PatientInfoModel Doc = new PatientInfoModel();

            var dlist = RetuningData.ReturnigList<PatientInfoModel>("uspGetDoctotList", null);
            Doc.DoctorList = new SelectList(dlist, "docid", "DoctorName");
            return View(Doc);
        }

        [HttpPost]
        public ActionResult PatientInfo(PatientInfoModel pm)
        {
            var param = new DynamicParameters();
            
            param.Add("@Pname", pm.pname);
            param.Add("@Age", pm.age);
            param.Add("@Gender", pm.gender);
            param.Add("@docid", pm.docid);
            param.Add("@mobileNo", pm.mobileNo);
            param.Add("@CreatedBy", 1);
            param.Add("@UpdatedBy", 1);
           

            string mobileno = RetuningData.ReturnSingleValue<string>("AddNewPatientInfoDetails", param);
            if (mobileno != null && mobileno != "")
            {
                return RedirectToAction("Dashboard", "Doc");
                
            }
            else
            {
                return View();
            }

        }
        public ActionResult PatientReport()
        {
            var param = new DynamicParameters();
            param.Add("@Name_Mobile", Session["mobileno"]);

            var rltf = RetuningData.ReturnigList<ClinicalBiochemistoryReportLTFModel>("uspGetDashborad", param);
            return View(rltf);
        }
        public ActionResult PatientList()
        {
            List<SunDiagonostics.Models.PatientInfoModel> pat = RetuningData.ReturnigList<PatientInfoModel>("GetPatientInfoDetails", null).ToList();
            return View(pat);
        }

        public ActionResult ComputerBloodPictureReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ComputerBloodPictureReport(ComputerBloodPictureReportModel cbrm)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", cbrm.pid);
            param.Add("@Haemoglobin", cbrm.haemoglobin);
            param.Add("@ErythrocyteCount", cbrm.erythrocyteCount);
            param.Add("@TotalWBCCount", cbrm.totalWBCCount);
            param.Add("@Neutrophils", cbrm.neutrophils);
            param.Add("@Lymphocytes", cbrm.lymphocytes);
            param.Add("@Eosinophils", cbrm.eosinophils);
            param.Add("@Monocytes", cbrm.monocytes);
            param.Add("@Basophils", cbrm.basophils);
            param.Add("@Rbcs", cbrm.rbcs);
            param.Add("@PlateletCount", cbrm.plateletCount);
            param.Add("@CreatedBy", cbrm.CreatedBy);
            param.Add("@UpdatedBy", cbrm.UpdatedBy);

            int i = RetuningData.AddOrSave<int>("AddNewComputerBloodPictureReportDetails", param);
            if (i > 0)
            {
                return RedirectToAction("GetAllReportsByPatientId", new { Pid = cbrm.pid });

            }
            else
            {
                return View();
            }
        }
        public ActionResult ComputerBloodPictureReportList()
        {
            var br = RetuningData.ReturnigList<ComputerBloodPictureReportModel>("GetComputerBloodPictureReportDetails", null);
            return View(br);
        }
       
        public ActionResult Print_CBPReport(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId);
            SunDiagonostics.Models.ComputerBloodPictureReportModel pat = RetuningData.ReturnigList<ComputerBloodPictureReportModel>("GetComputerBloodPictureReportDetails", param).SingleOrDefault();
            return View("Print_CBPReport", pat);
        }
        public ActionResult ClinicalBiochemistoryReportLIPIDProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClinicalBiochemistoryReportLIPIDProfile(ClinicalBiochemistoryReportLIPIDProfileModel lipid)
        {
            var param = new DynamicParameters();
           
            param.Add("@Pid", lipid.pid);
            param.Add("@serumCholestrol", lipid.serumCholestrol);
            param.Add("@hdlCholestrol", lipid.hdlCholestrol);
            param.Add("@LDLCholestrol", lipid.LDLCholestrol);
            param.Add("@VLDLCholestrol", lipid.VLDLCholestrol);
            param.Add("@serumTriglyceride", lipid.serumTriglyceride);
            param.Add("@THDL", lipid.THDL);
            param.Add("@LDLHDL", lipid.LDLHDL);
            param.Add("@titalLipid", lipid.titalLipid);
            param.Add("@CreatedBy", lipid.titalLipid);
            param.Add("@UpdatedBy", lipid.titalLipid);
             
            int i = RetuningData.AddOrSave<int>("AddNewClinicalBiochemistoryReportLIPIDProfileDetails", param);
            if (i > 0)
            {
                return RedirectToAction("GetAllReportsByPatientId", new {Pid= lipid.pid });
            }
            else
            {
                return View();
            }
        }
        public ActionResult ClinicalBiochemistoryReportLIPIDProfileList()
        {
            var rlipid = RetuningData.ReturnigList<ClinicalBiochemistoryReportLTFModel>("GetClinicalBiochemistoryReportLIPIDProfileDetails", null);
            return View(rlipid);
        }
        public ActionResult Print_LIPIDProfileReport(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId); 


            SunDiagonostics.Models.ClinicalBiochemistoryReportLIPIDProfileModel pat = RetuningData.ReturnigList<ClinicalBiochemistoryReportLIPIDProfileModel>("GetClinicalBiochemistoryReportLIPIDProfileDetails", param).SingleOrDefault();
            if (rpt.Pid != null)
            {
                pat.Srno = (int)rpt.Pid;
            }
            return View(pat);
        }
        public ActionResult ClinicalBiochemistoryReportLTF()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClinicalBiochemistoryReportLTF(ClinicalBiochemistoryReportLTFModel ltf)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", ltf.pid);
            param.Add("@serumBilirubin", ltf.serumBilirubin);
            param.Add("@serumBilirubinD", ltf.serumBilirubinD);
            param.Add("@serumBilirubinID", ltf.serumBilirubinID);
            param.Add("@serumAsparateAminoTransferase", ltf.serumAsparateAminoTransferase);
            param.Add("@serumAlanineAminoTransferase", ltf.serumAlanineAminoTransferase);
            param.Add("@serumTotalProtein", ltf.serumTotalProtein);
            param.Add("@serumAlbumin", ltf.serumAlbumin);
            param.Add("@serumGlubulin", ltf.serumGlubulin);
            param.Add("@AGRation", ltf.AGRation);
            param.Add("@serumAlkalinePhosphatse", ltf.serumAlkalinePhosphatse);
            param.Add("@CreatedBy",1);
            param.Add("@UpdatedBy",1);
            int i = RetuningData.AddOrSave<int>("AddNewClinicalBiochemistoryReportLTFDetails", param);
            if (i > 0)
            {
                return RedirectToAction("GetAllReportsByPatientId", new { Pid = ltf .pid });
            }
            else
            {
                return View();
            }
        }
        public ActionResult ClinicalBiochemistoryReportLTFList()
        {
            var rltf = RetuningData.ReturnigList<ClinicalBiochemistoryReportLTFModel>("GetClinicalBiochemistoryReportLTFDetail", null);
            return View(rltf);
        }
        public ActionResult Print_LTFReport(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId);
            SunDiagonostics.Models.ClinicalBiochemistoryReportLTFModel pat = RetuningData.ReturnigList<ClinicalBiochemistoryReportLTFModel>("GetClinicalBiochemistoryReportLTFDetail", param).SingleOrDefault();
            if (rpt.Pid != null)
            {
                pat.Srno = (int)rpt.Pid;
            }
            return View(pat);
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dashboard(PatientInfoModel dm)
        {
            var param = new DynamicParameters();
            // param.Add("@Pid", Session["Pid"]);
            //param.Add("@Date", cbrm.date);
            param.Add("@Name_Mobile", dm.Name_Mobile);
            //int i = RetuningData.AddOrSave<int>("Dashborad", param);
            var i = RetuningData.ReturnigList<PatientInfoModel>("uspGetDashborad", param);
            if (i != null)
            {
                 
                //param.Add("@Name_Mobile", i.Pname);
                //FormsAuthentication.SetAuthCookie(param.UserName, false);
                return View(i);
            }
            else
            {
                return View();
            }

        }
           
        [HttpPost]
        public ActionResult Index(PatientInfoModel dm)
        {
            var param = new DynamicParameters();
            // param.Add("@Pid", Session["Pid"]);
            //param.Add("@Date", cbrm.date);
            param.Add("@Pid", dm.pid);
            param.Add("@Pname", dm.pname);
            param.Add("@RefByDoc", dm.RefByDoc);

            //int i = RetuningData.AddOrSave<int>("Dashborad", param);
            PatientInfoModel i = RetuningData.ReturnigList<PatientInfoModel>("AddReportType_Details", param).SingleOrDefault();
            if (i != null)
            {
                //FormsAuthentication.SetAuthCookie(param.UserName, false);
                return RedirectToAction("PatientReport");
            }
            else
            {
                return View();
            }

        }
        public ActionResult GetAllReportsByPatientId()
        {
            GetAllReportsByPatientIdModel obj = new GetAllReportsByPatientIdModel();
            var Reports = RetuningData.ReturnigList<ReportModel>("sp_getReports", null);
            ViewBag.ReportType = new SelectList(Reports, "Id", "ReportType");
            int Pid = Convert.ToInt32(Request.QueryString["Pid"]);
            var param = new DynamicParameters();
            param.Add("@Pid", Pid);
            var rltf = RetuningData.ReturnigList<GetAllReportsByPatientIdModel>("usp_getAllReportsByPatientId", param);
            return View(rltf);
        }
        public ActionResult ShowReport(ReportByPidModel rpt)
        {
            ReportByPidModel obj = new ReportByPidModel();

            obj.Pid = rpt.Pid;
            obj.ReportTypeId = Convert.ToInt32(Request.QueryString["ReportTypeId"]);
            obj.ReportId = Convert.ToInt32(Request.QueryString["ReportId"]);
            obj.Printer_Name = RetuningData.ReturnSingleValue<string>("usp_getPrinter", null);
            if (obj.ReportTypeId == 1)
            {
                return RedirectToAction("Print_LIPIDProfileReport", obj);
            }
            else if (obj.ReportTypeId == 2)
            {
                return RedirectToAction("Print_LTFReport", obj);
            }
            else if (obj.ReportTypeId ==3)
            {
                return RedirectToAction("Print_CBPReport", obj);
            }
            return View();
        }

       public ActionResult Print_LPIDReport(ReportByPidModel rept)
        {
            try
            {
                ConversionOptions options = new ConversionOptions(ceTe.DynamicPDF.HtmlConverter.PageSize.A4, ceTe.DynamicPDF.HtmlConverter.PageOrientation.Portrait, 0.2f);
                string path = HostingEnvironment.MapPath("~/Upload");
                Converter.Convert(new Uri("https://localhost:44319/Doc/Print_LIPIDProfileReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), path + @"\WithConversionOptions.pdf", options);
               // Converter.Convert(new Uri(@"akbardiagnostic.dswebcare.com/Doc/Print_LIPIDProfileReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), @"D:\WithConversionOptions.pdf", options);

                //Converter.Convert(new Uri("https://en.wikipedia.org"), "E:\\SimpleConversion.pdf");
                ceTe.DynamicPDF.Printing.PrintJob printJob = new PrintJob(rept.Printer_Name.ToString(), path + @"\WithConversionOptions.pdf");
                printJob.Print();
                return Content("PDF Generated");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       public ActionResult Print_LTF(ReportByPidModel rept)
        {
            
            try
            {
                ConversionOptions options = new ConversionOptions(ceTe.DynamicPDF.HtmlConverter.PageSize.A4, ceTe.DynamicPDF.HtmlConverter.PageOrientation.Portrait, 0.2f);
                string path = HostingEnvironment.MapPath("~/Upload");
                Converter.Convert(new Uri("https://localhost:44319/Doc/Print_LTFReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), path + @"\WithConversionOptions.pdf", options);

                // Converter.Convert(new Uri(@"akbardiagnostic.dswebcare.com/Doc/Print_LTFReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), @"E:\WithConversionOptions.pdf", options);

                //Converter.Convert(new Uri("https://en.wikipedia.org"), "E:\\SimpleConversion.pdf");
                ceTe.DynamicPDF.Printing.PrintJob printJob = new PrintJob(rept.Printer_Name.ToString(), path + @"\WithConversionOptions.pdf");
                printJob.Print();
                return Content("PDF Generated");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       public ActionResult Print_CBPReport1(ReportByPidModel rept)
        {
            try
            {
                ConversionOptions options = new ConversionOptions(ceTe.DynamicPDF.HtmlConverter.PageSize.A4, ceTe.DynamicPDF.HtmlConverter.PageOrientation.Portrait, 0.2f);
                string path = HostingEnvironment.MapPath("~/Upload");
                Converter.Convert(new Uri("https://localhost:44319/Doc/Print_LTFReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), path + @"\WithConversionOptions.pdf", options);
                // Converter.Convert(new Uri(@"akbardiagnostic.dswebcare.com/Doc/Print_CBPReport?Pid=" + rept.Pid + "&ReportTypeId=" + rept.ReportTypeId + "&ReportId=" + rept.ReportId + ""), @"D:\WithConversionOptions.pdf", options);
                //Converter.Convert(new Uri("https://en.wikipedia.org"), "E:\\SimpleConversion.pdf");
                ceTe.DynamicPDF.Printing.PrintJob printJob = new PrintJob(rept.Printer_Name.ToString(), path + @"\WithConversionOptions.pdf");
                printJob.Print();
                return Content("PDF Generated");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult UpdateCBPReportByPatientId(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId);
            SunDiagonostics.Models.ComputerBloodPictureReportModel pat = RetuningData.ReturnigList<ComputerBloodPictureReportModel>("GetComputerBloodPictureReportDetails", param).SingleOrDefault();
            return View(pat);
        }

        [HttpGet]

        public ActionResult UpdateLIPIDProfileReportByPatientId(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId);
            SunDiagonostics.Models.ClinicalBiochemistoryReportLIPIDProfileModel pat = RetuningData.ReturnigList<ClinicalBiochemistoryReportLIPIDProfileModel>("GetClinicalBiochemistoryReportLIPIDProfileDetails", param).SingleOrDefault();
            return View(pat);
        }

        [HttpPost]

        public ActionResult UpdateLIPIDProfileReportByPatientId(ClinicalBiochemistoryReportLIPIDProfileModel lipid)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", lipid.pid);
            param.Add("@serumCholestrol", lipid.serumCholestrol);
            param.Add("@hdlCholestrol", lipid.hdlCholestrol);
            param.Add("@LDLCholestrol", lipid.LDLCholestrol);
            param.Add("@VLDLCholestrol", lipid.VLDLCholestrol);
            param.Add("@serumTriglyceride", lipid.serumTriglyceride);
            param.Add("@THDL", lipid.THDL);
            param.Add("@LDLHDL", lipid.LDLHDL);
            param.Add("@titalLipid", lipid.titalLipid);
            param.Add("@CreatedBy", lipid.titalLipid);
            param.Add("@UpdatedBy", lipid.titalLipid);

            int i = RetuningData.AddOrSave<int>("AddNewClinicalBiochemistoryReportLIPIDProfileDetails", param);
            if (i > 0)
            {
                return RedirectToAction("GetAllReportsByPatientId", new { Pid = lipid.pid });
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]

        public ActionResult UpdateLTFReportByPatientId(ReportByPidModel rpt)
        {
            var param = new DynamicParameters();
            param.Add("@Pid", rpt.Pid);
            param.Add("@ReportId", rpt.ReportId);
            SunDiagonostics.Models.ClinicalBiochemistoryReportLTFModel pat = RetuningData.ReturnigList<ClinicalBiochemistoryReportLTFModel>("GetClinicalBiochemistoryReportLTFDetail", param).SingleOrDefault();
            if (rpt.Pid != null)
            {
                pat.Srno = (int)rpt.Pid;
            }
            return View(pat);
        }

    }
}