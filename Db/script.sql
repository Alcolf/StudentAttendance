USE [StudentAttendence]
GO
/****** Object:  Table [dbo].[COURSES]    Script Date: 5/16/2023 9:27:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COURSES](
	[COURSE_ID] [varchar](20) NOT NULL,
	[COURSE_NAME_TH] [nvarchar](50) NOT NULL,
	[COURSE_NAME_EN] [varchar](50) NOT NULL,
	[LIMIT_ABSENT] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOTIFICATION]    Script Date: 5/16/2023 9:27:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOTIFICATION](
	[TEACHER_ID] [nvarchar](20) NOT NULL,
	[DATE] [varchar](20) NOT NULL,
	[IS_READ] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STUDENT_RECORD]    Script Date: 5/16/2023 9:27:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUDENT_RECORD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEACHER_ID] [varchar](50) NOT NULL,
	[COURSE_ID] [varchar](50) NOT NULL,
	[STUDENT_ID] [varchar](50) NOT NULL,
	[STUDENT_TITLE] [nvarchar](10) NOT NULL,
	[STUDENT_FIRSTNAME] [nvarchar](50) NOT NULL,
	[STUDENT_LASTNAME] [nvarchar](50) NOT NULL,
	[GRADE] [nvarchar](20) NOT NULL,
	[CLASSROOM] [nvarchar](20) NOT NULL,
	[DATE_CHECK_IN] [varchar](20) NOT NULL,
	[IS_ABSENT] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STUDENTS]    Script Date: 5/16/2023 9:27:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUDENTS](
	[STUDENT_ID] [varchar](20) NOT NULL,
	[TITLE] [nvarchar](10) NOT NULL,
	[FIRST_NAME] [nvarchar](50) NOT NULL,
	[LAST_NAME] [nvarchar](50) NOT NULL,
	[GRADE] [nvarchar](10) NOT NULL,
	[CLASSROOM] [nvarchar](10) NOT NULL,
	[PARENT_CONTACT] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 5/16/2023 9:27:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[USER_ID] [varchar](20) NOT NULL,
	[USERNAME] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](50) NOT NULL,
	[TITLE] [nvarchar](10) NOT NULL,
	[FIRST_NAME] [nvarchar](50) NOT NULL,
	[LAST_NAME] [nvarchar](50) NOT NULL,
	[ROLE] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[COURSES] ([COURSE_ID], [COURSE_NAME_TH], [COURSE_NAME_EN], [LIMIT_ABSENT]) VALUES (N'100001', N'ภาษาไทย', N'Thai Language', 3)
INSERT [dbo].[COURSES] ([COURSE_ID], [COURSE_NAME_TH], [COURSE_NAME_EN], [LIMIT_ABSENT]) VALUES (N'100002', N'คอมพิวเตอร์', N'Computer', 3)
GO
INSERT [dbo].[NOTIFICATION] ([TEACHER_ID], [DATE], [IS_READ]) VALUES (N'00001', N'01-05-2023', 1)
GO
SET IDENTITY_INSERT [dbo].[STUDENT_RECORD] ON 

INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (1, N'00001', N'100001', N'6500001', N'Mr.', N'First', N'FirstL', N'M.1', N'1', N'01-04-2023', 0)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (2, N'00001', N'100001', N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'01-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (3, N'00001', N'100001', N'6500003', N'Mr.', N'Third', N'ThirdL', N'M.1', N'2', N'01-04-2023', 0)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (4, N'00001', N'100001', N'6500004', N'Ms.', N'Fouth', N'FouthL', N'M.1', N'2', N'01-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (5, N'00001', N'100001', N'6500001', N'Mr.', N'First', N'FirstL', N'M.1', N'1', N'02-04-2023', 0)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (6, N'00001', N'100001', N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'02-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (7, N'00001', N'100001', N'6500003', N'Mr.', N'Third', N'ThirdL', N'M.1', N'2', N'02-04-2023', 0)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (8, N'00001', N'100001', N'6500004', N'Ms.', N'Fouth', N'FouthL', N'M.1', N'2', N'02-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (1002, N'00002', N'100002', N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'01-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (1003, N'00002', N'100002', N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'02-04-2023', 1)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (13, N'00001', N'100001', N'6500001', N'Mr.', N'First', N'FirstL', N'M.1', N'1', N'03-04-2023', 0)
INSERT [dbo].[STUDENT_RECORD] ([ID], [TEACHER_ID], [COURSE_ID], [STUDENT_ID], [STUDENT_TITLE], [STUDENT_FIRSTNAME], [STUDENT_LASTNAME], [GRADE], [CLASSROOM], [DATE_CHECK_IN], [IS_ABSENT]) VALUES (14, N'00001', N'100001', N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'03-04-2023', 0)
SET IDENTITY_INSERT [dbo].[STUDENT_RECORD] OFF
GO
INSERT [dbo].[STUDENTS] ([STUDENT_ID], [TITLE], [FIRST_NAME], [LAST_NAME], [GRADE], [CLASSROOM], [PARENT_CONTACT]) VALUES (N'6500001', N'Mr.', N'First', N'FirstL', N'M.1', N'1', N'U4fe2347e748b5b970c5d2e0174c83a0c')
INSERT [dbo].[STUDENTS] ([STUDENT_ID], [TITLE], [FIRST_NAME], [LAST_NAME], [GRADE], [CLASSROOM], [PARENT_CONTACT]) VALUES (N'6500002', N'Ms.', N'Second', N'SecondL', N'M.1', N'1', N'U4fe2347e748b5b970c5d2e0174c83a0c')
INSERT [dbo].[STUDENTS] ([STUDENT_ID], [TITLE], [FIRST_NAME], [LAST_NAME], [GRADE], [CLASSROOM], [PARENT_CONTACT]) VALUES (N'6500003', N'Mr.', N'Third', N'ThirdL', N'M.1', N'2', N'U4fe2347e748b5b970c5d2e0174c83a0c')
INSERT [dbo].[STUDENTS] ([STUDENT_ID], [TITLE], [FIRST_NAME], [LAST_NAME], [GRADE], [CLASSROOM], [PARENT_CONTACT]) VALUES (N'6500004', N'Ms.', N'Fouth', N'FouthL', N'M.1', N'2', N'U4fe2347e748b5b970c5d2e0174c83a0c')
GO
INSERT [dbo].[USERS] ([USER_ID], [USERNAME], [PASSWORD], [TITLE], [FIRST_NAME], [LAST_NAME], [ROLE]) VALUES (N'1', N'Admin', N'Admin', N'Mr.', N'Firstname', N'Lastname', 2)
GO
/****** Object:  StoredProcedure [dbo].[SP.ADD_STUDENT_RECORD]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.ADD_STUDENT_RECORD]
	-- Add the parameters for the stored procedure here
	@TeacherId varchar(50),
	@CourseId varchar(50),
	@DateRecord varchar(50),
	@StudentId varchar(50),
	@StudentTitle varchar(50),
	@StudentFirstname varchar(50),
	@StudentLastname varchar(50),
	@Grade varchar(50),
	@Classroom varchar(50),
	@IsAbsent bit
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO STUDENT_RECORD (TEACHER_ID, COURSE_ID, STUDENT_ID, STUDENT_TITLE, STUDENT_FIRSTNAME, STUDENT_LASTNAME, GRADE, CLASSROOM, DATE_CHECK_IN, IS_ABSENT)
	VALUES (@TeacherId, @CourseId, @StudentId, @StudentTitle, @StudentFirstname, @StudentLastname, @Grade, @Classroom, @DateRecord, @IsAbsent)
	SELECT 1
END TRY
BEGIN CATCH
	SELECT 0
END	 CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP.GET_NOTIFICATION]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.GET_NOTIFICATION]
	-- Add the parameters for the stored procedure here
	@TeacherId nvarchar(20),
	@Date varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT TOP 1 IS_READ FROM NOTIFICATION WHERE TEACHER_ID = @TeacherId AND DATE = @Date)

	BEGIN
		SELECT 1;
	END

	ELSE
	BEGIN
		SELECT 0;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP.GET_STUDENT]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.GET_STUDENT]
	-- Add the parameters for the stored procedure here
	@StudentId varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from STUDENTS WHERE STUDENT_ID = @StudentId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP.LIST_COURSES]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.LIST_COURSES]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM COURSES;
END
GO
/****** Object:  StoredProcedure [dbo].[SP.LIST_STUDENT_BY_GRADE_AND_CLASSROOM]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.LIST_STUDENT_BY_GRADE_AND_CLASSROOM]
	-- Add the parameters for the stored procedure here
	@Grade varchar(10),
	@Classroom varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM STUDENTS AS ST WHERE ST.GRADE = @Grade AND ST.CLASSROOM = @Classroom;
END
GO
/****** Object:  StoredProcedure [dbo].[SP.LIST_STUDENT_RECORD]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.LIST_STUDENT_RECORD]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SR.GRADE, SR.CLASSROOM ,SR.STUDENT_ID, SR.COURSE_ID, COUNT(*) AS COUNT_ABSENT FROM STUDENT_RECORD AS SR WHERE IS_ABSENT = 1 GROUP BY SR.GRADE,SR.CLASSROOM ,SR.STUDENT_ID, SR.COURSE_ID;	
END
GO
/****** Object:  StoredProcedure [dbo].[SP.LIST_STUDENT_RECORD_BY_TEACHERID]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.LIST_STUDENT_RECORD_BY_TEACHERID]
	-- Add the parameters for the stored procedure here
	@TeacherId varchar (20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT SR.GRADE, SR.CLASSROOM ,SR.STUDENT_ID, SR.COURSE_ID, COUNT(*) AS COUNT_ABSENT FROM STUDENT_RECORD AS SR WHERE SR.TEACHER_ID = @TeacherId AND IS_ABSENT = 1 GROUP BY SR.GRADE,SR.CLASSROOM ,SR.STUDENT_ID, SR.COURSE_ID;

	SELECT LIMIT_ABSENT FROM COURSES WHERE COURSE_ID = (SELECT TOP 1 COURSE_ID FROM STUDENT_RECORD WHERE TEACHER_ID = @TeacherId)
END
GO
/****** Object:  StoredProcedure [dbo].[SP.LIST_STUDENT_RECORD_BY_TEACHERID_GRADE_CLASSROOM_DATE]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.LIST_STUDENT_RECORD_BY_TEACHERID_GRADE_CLASSROOM_DATE]
	-- Add the parameters for the stored procedure here
	@TeacherId varchar(20),
	@Grade varchar(20),
	@Classroom varchar(20),
	@Date varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM STUDENT_RECORD AS SR WHERE SR.TEACHER_ID = @TeacherId AND SR.GRADE = @Grade AND SR.CLASSROOM = @Classroom AND SR.DATE_CHECK_IN = @Date;
END
GO
/****** Object:  StoredProcedure [dbo].[SP.UPDATE_NOTIFICATION]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.UPDATE_NOTIFICATION] 
	-- Add the parameters for the stored procedure here
	@TeacherId nvarchar(20),
	@Date varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM NOTIFICATION WHERE TEACHER_ID = @TeacherId AND DATE = @Date;
	INSERT INTO NOTIFICATION (TEACHER_ID, DATE, IS_READ) VALUES(@TeacherId, @Date, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[SP.UPDATE_STUDENT_RECORD]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.UPDATE_STUDENT_RECORD]
	-- Add the parameters for the stored procedure here
	@TeacherId varchar(50),
	@CourseId varchar(50),
	@DateRecord varchar(50),
	@StudentId varchar(50),
	@StudentTitle varchar(50),
	@StudentFirstname varchar(50),
	@StudentLastname varchar(50),
	@Grade varchar(50),
	@Classroom varchar(50),
	@IsAbsent bit
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;
	-- Delete old record
	DELETE FROM STUDENT_RECORD WHERE TEACHER_ID = @TeacherId AND COURSE_ID = @CourseId AND DATE_CHECK_IN = @DateRecord AND GRADE = @Grade AND CLASSROOM = @Classroom And STUDENT_ID = @StudentId;
    -- Insert statements for procedure here
	INSERT INTO STUDENT_RECORD (TEACHER_ID, COURSE_ID, STUDENT_ID, STUDENT_TITLE, STUDENT_FIRSTNAME, STUDENT_LASTNAME, GRADE, CLASSROOM, DATE_CHECK_IN, IS_ABSENT)
	VALUES (@TeacherId, @CourseId, @StudentId, @StudentTitle, @StudentFirstname, @StudentLastname, @Grade, @Classroom, @DateRecord, @IsAbsent)
	SELECT 1
END TRY
BEGIN CATCH
	SELECT 0
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP.USER_SIGN_ON]    Script Date: 5/16/2023 9:27:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP.USER_SIGN_ON]
	-- Add the parameters for the stored procedure here
	@Username varchar(50),
	@Password varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT TOP 1 US.USER_ID FROM USERS AS US WHERE US.USERNAME = @Username AND US.PASSWORD = @Password)
	
	BEGIN
		SELECT TOP 1 * FROM USERS AS US WHERE US.USERNAME = @Username AND US.PASSWORD = @Password;
	END

	ELSE
	BEGIN
		SELECT NULL;
	END

END
GO
