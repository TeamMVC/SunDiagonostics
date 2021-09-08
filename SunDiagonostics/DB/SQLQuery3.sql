USE [SUNDIGNOSTIC]
GO

/****** Object:  Table [dbo].[tbl_Printer]    Script Date: 08-09-2021 22:31:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_Printer](
	[Printer_id] [int] IDENTITY(1,1) NOT NULL,
	[Printer_Name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Printer] PRIMARY KEY CLUSTERED 
(
	[Printer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


