USE master; 
GO 
 
--Delete the SMS (Student Management System) database if it exists. 
IF EXISTS(SELECT * from sys.databases WHERE name='SMS') 
BEGIN 
    DROP DATABASE SMS; 
END 

CREATE DATABASE SMS;
GO


USE SMS;
GO

CREATE TABLE dbo.Course(
	CourseCode varchar(10)  PRIMARY KEY NOT NULL,
	CourseTitle varchar(50) NOT NULL,
	TotalCourseHours int NOT NULL,
	School varchar(50) NOT NULL,
	Department varchar(50) NOT NULL);
GO

insert into Course values('COMP212','Programming III', 56,'SETAS','ICET');
insert into Course values('COMP110','Programming I', 56,'SETAS','ICET');
insert into Course values('COMP214','Advanced Database Concepts', 56,'SETAS','ICET');
insert into Course values('COMP228','Java Programming', 56,'SETAS','ICET');
insert into Course values('COMP306','Web Services Programming', 56,'SETAS','ICET');
insert into Course values('COMP311','Software Testing and Quality Assurance', 56,'SETAS','ICET');
insert into Course values('COMP254','Data Structures and Algorithms', 56,'SETAS','ICET');


CREATE TABLE dbo.Student(
	StudentID varchar(10) PRIMARY KEY NOT NULL,
	FirstName varchar(50) NULL,
	LastName varchar(50) NULL,
	Program varchar(8) NULL);
Go
	
insert into Student values('300111222','Cindy','Jones','3409');
insert into Student values('300222333','John','Smith','3419');
insert into Student values('300333444','Howard','Browns','3439');
insert into Student values('300444555','Trevor','Lee','3439');
insert into Student values('300555666','Yin','Li','3409');
insert into Student values('300982100','Jovane','Marques','3409');


CREATE TABLE dbo.Login(
	LoginName varchar(10)  PRIMARY KEY NOT NULL,
	Password varchar(12) NOT NULL,
	CONSTRAINT FK_Login_Student FOREIGN KEY (LoginName) REFERENCES dbo.Student(StudentID));
GO

insert into Login values('300111222','password');
insert into Login values('300222333','test');
insert into Login values('300333444','password');
insert into Login values('300444555','password');
insert into Login values('300555666','123456');
insert into Login values('300982100','jjj');


CREATE TABLE dbo.Enrollment(
	StudentID varchar(10) NOT NULL,
	CourseCode varchar(10) NOT NULL,
    CONSTRAINT PK_Enrollment PRIMARY KEY (StudentID,CourseCode),
	CONSTRAINT FK_Enrollment_Course FOREIGN KEY (CourseCode) REFERENCES dbo.Course(CourseCode),
	CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentID) REFERENCES dbo.Student(StudentID));
GO

insert into enrollment values('300111222','COMP212');
insert into enrollment values('300111222','COMP311');
insert into enrollment values('300111222','COMP306');

-- COMMENTED BECAUSE WAS COMPLAINING AND THE SCRIPT DO NOT FINISH THE EXECUTION
--insert into enrollment values('300222333','COMP228');
--insert into enrollment values('300222333','COMP309');
--insert into enrollment values('300222333','COMP306');

insert into enrollment values('300333444','COMP110');
insert into enrollment values('300333444','COMP214');
insert into enrollment values('300333444','COMP309');

insert into enrollment values('300444555','COMP110');
insert into enrollment values('300444555','COMP228');
insert into enrollment values('300444555','COMP311');

insert into enrollment values('300982100','COMP228');
insert into enrollment values('300982100','COMP309');
insert into enrollment values('300982100','COMP212');
