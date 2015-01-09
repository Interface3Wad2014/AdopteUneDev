USE [AdopteUneDev]
GO

/****** Object:  Table [dbo].[Review]    Script Date: 01/09/2015 11:31:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[idReview] [int] IDENTITY(1,1) NOT NULL,
	[ReviewName] [nvarchar](50) NOT NULL,
	[ReviewText] [nvarchar](max) NOT NULL,
	[ReviewMail] [nvarchar](256) NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
	[idDev] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[idReview] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Developer]
GO

ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ReviewDate]  DEFAULT (getdate()) FOR [ReviewDate]
GO


