USE [Photohosting]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 28.05.2021 11:12:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[UID] [int] IDENTITY(0,1) NOT NULL,
	[Login] [nvarchar](10) NULL,
	[Password] [nvarchar](10) NULL,
	[Email] [nvarchar](20) NULL,
	[Phone_Number] [int] NULL,
	[BdayDate] [date] NULL,
	[Name] [nchar](15) NULL,
	[LastName] [nchar](15) NULL,
	[Pic] [varbinary](max) NULL,
	[ImagePath] [varchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO


