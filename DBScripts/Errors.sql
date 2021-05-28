USE [Photohosting]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 28.05.2021 11:13:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Solved] [bit] NULL,
	[UId] [int] NULL,
	[UName] [varchar](max) NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Errors] ADD  DEFAULT ((0)) FOR [Solved]
GO

ALTER TABLE [dbo].[Errors]  WITH CHECK ADD  CONSTRAINT [FK_Errors_Accounts] FOREIGN KEY([UId])
REFERENCES [dbo].[Accounts] ([UID])
GO

ALTER TABLE [dbo].[Errors] CHECK CONSTRAINT [FK_Errors_Accounts]
GO


