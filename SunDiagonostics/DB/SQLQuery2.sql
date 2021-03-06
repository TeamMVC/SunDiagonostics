USE [SUNDIGNOSTIC]
GO
/****** Object:  StoredProcedure [dbo].[usp_getAllReportsByPatientId]    Script Date: 08-09-2021 22:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_getAllReportsByPatientId]
(
@Pid int
)
AS 
BEGIN
SELECT
cb.Pid,
cb.ReportTypeId,
rpt.ReportType as Name,
cb.ReportId,
cb.CreatedOn,
cb.UpdatedOn,
cb.CreatedBy,
cb.UpdatedBy,(select Printer_Name from tbl_Printer) as Printer_Name
FROM tbl_ClinicalBiochemistoryReportLIPIDProfile cb
inner join tbl_ReportType rpt
on cb.ReportTypeId=rpt.id
WHERE Pid=@Pid
UNION  
SELECT 
cb.Pid,
cb.ReportTypeId,
rpt.ReportType as Name,
cb.ReportId,
cb.CreatedOn,
cb.UpdatedOn,
cb.CreatedBy,
cb.UpdatedBy,(select Printer_Name from tbl_Printer) as Printer_Name
FROM tbl_ClinicalBiochemistoryReportLTF cb
inner join tbl_ReportType rpt
on cb.ReportTypeId=rpt.id
WHERE Pid=@Pid
 UNION 
SELECT
 cb.Pid,
cb.ReportTypeId,
rpt.ReportType as Name,
cb.ReportId,
cb.CreatedOn,
cb.UpdatedOn,
cb.CreatedBy,
cb.UpdatedBy,(select Printer_Name from tbl_Printer) as Printer_Name
 FROM tbl_ComputerBloodPictureReport cb
inner join tbl_ReportType rpt
on cb.ReportTypeId=rpt.id
  WHERE Pid=@Pid
  

  select Printer_id,Printer_Name from tbl_Printer
END

