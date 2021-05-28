USE [Photohosting]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 28.05.2021 11:13:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[UId] [int] NULL,
	[Message] [nvarchar](max) NOT NULL,
	[PId] [int] NOT NULL,
	[UName] [nvarchar](max) NULL,
	[UPic] [varbinary](max) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Accounts] FOREIGN KEY([UId])
REFERENCES [dbo].[Accounts] ([UID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Accounts]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Picture] FOREIGN KEY([PId])
REFERENCES [dbo].[Picture] ([PID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Picture]
GO


