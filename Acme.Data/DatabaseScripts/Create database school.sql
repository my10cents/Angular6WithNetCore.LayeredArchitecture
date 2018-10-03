CREATE DATABASE School
GO

USE School
GO

CREATE TABLE [Course](
	[Id] [int] NOT NULL,
	[Title] [varchar](100) NULL,
	[Credits] [int] NULL,
	CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED([Id])
)
GO


CREATE TABLE [Student](
	[Id] [int] NOT NULL,
	[LastName] [varchar](50) NULL,
	[FirstMidName] [varchar](50) NULL,
	[EnrollmentDate] [datetime] NULL,
	CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED([Id])
)
GO

CREATE TABLE [Enrollment](
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

insert into Course values (1,'Chemistry',3);
insert into Course values (2,'Microeconomics',3);
insert into Course values (3,'Macroeconomics',3);
insert into Course values (4,'Calculus',4);
insert into Course values (5,'Trigonometry',4);
insert into Course values (6,'Composition',3);
insert into Course values (7,'Literature',4);
GO

insert into Student values (1,'Alexander','Carson','2010-09-01 00:00:00');
insert into Student values (2,'Alonso','Meredith','2012-09-01 00:00:00');
insert into Student values (3,'Anand','Arturo','2013-09-01 00:00:00');
insert into Student values (4,'Barzdukas','Gytis','2012-09-01 00:00:00');
insert into Student values (5,'Li','Yan','2012-09-01 00:00:00');
insert into Student values (6,'Justice','Peggy','2011-09-01 00:00:00');
insert into Student values (7,'Norman','Laura','2013-09-01 00:00:00');
insert into Student values (8,'Olivetto','Nino','2005-08-11 00:00:00');
GO

insert into Enrollment values (1,1,1,'A');
insert into Enrollment values (2,2,1,'C');
insert into Enrollment values (3,3,1,'B');
insert into Enrollment values (4,4,2,'B');
insert into Enrollment values (5,5,2,'B');
insert into Enrollment values (6,6,2,'B');
insert into Enrollment values (7,1,3,'C');
insert into Enrollment values (8,2,3,'B');
insert into Enrollment values (9,1,4,'B');
insert into Enrollment values (10,6,5,'B');
insert into Enrollment values (11,7,6,'B');
go




