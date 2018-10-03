USE [School]
GO

CREATE TABLE [dbo].[Course](
	[Id] [int] NOT NULL,
	[Title] [varchar](100) NULL,
	[Credits] [int] NULL,
	CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED([Id])
)
GO


CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstMidName] [varchar](50) NULL,
	[EnrollmentDate] [datetime] NULL,
	CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED([Id])
)
GO

CREATE TABLE [dbo].[Enrollment](
	[Id] [int] NOT NULL,
	[CourseID] [int] NULL,
	[StudentID] [int] NULL,
	[Grade] [varchar](1) NULL,
	CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED([Id])
)
GO

ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY([CourseID]) REFERENCES [dbo].[Course] ([Id])
GO

ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course]
GO

ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student] FOREIGN KEY([StudentID])REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student]
GO




