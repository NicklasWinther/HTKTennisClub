USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='HTKTennisClub')
DROP DATABASE HTKTennisClub
GO
CREATE DATABASE HTKTennisClub
GO

USE HTKTennisClub

CREATE TABLE Members(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Firstname NVARCHAR(20) NOT NULL,
	Lastname NVARCHAR(20) NOT NULL,
	Address NVARCHAR(MAX) NOT NULL,
	PhoneNumber NVARCHAR(8) NOT NULL,
	Email NVARCHAR(MAX) NOT NULL,
	BirthDate DateTime2 NOT NULL,
	Active BIT NOT NULL
)
INSERT INTO Members VALUES('Louise', 'Nygaard', 'Strandvej 54', '26984598', 'LouiseMNygaard@jourrapide.com', '1960-11-05', 1)
INSERT INTO Members VALUES('Jacob', 'Kjeldsen', 'Ørbækvej 76', '56485269', 'JacobPKjeldsen@rhyta.com', '1959-02-19', 1)
INSERT INTO Members VALUES('Albert', 'Iversen', 'Skolevej 7', '21548963', 'AlbertLIversen@jourrapide.com', '2001-12-25', 0)
INSERT INTO Members VALUES('Maja', 'Jespersen', 'Grønvangen 59', '65982569', 'MajaPJespersen@armyspy.com', '1998-06-11', 1)
