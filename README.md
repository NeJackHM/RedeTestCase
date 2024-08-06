-- Execute queries and change database connections values

create database RedeTestCase
use RedeTestCase

CREATE TABLE JobCategory (
  Id INT PRIMARY KEY IDENTITY(1,1),
  Description NVARCHAR(255),
  Active BIT,
  CreatedAt DATETIME
);

INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Administración',1, GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Marketing',1,GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Producción',1,GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Recursos Humanos',1,GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Sistemas',1,GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Ingeniería',1,GETDATE());
INSERT INTO [dbo].[JobCategory] ([Description],[Active],[CreatedAt])VALUES('Ventas',1,GETDATE());

CREATE TABLE Person (
  Id INT PRIMARY KEY IDENTITY(1,1),
  JobCategoryId INT NOT NULL,
  Name NVARCHAR(255) NOT NULL,
  Email NVARCHAR(255) NOT NULL UNIQUE,
  Gender NVARCHAR(1) NOT NULL,
  BirthDate DATETIME,
  CreatedAt DATETIME,
  TelefoneNumber NVARCHAR(15),
  Country NVARCHAR(15),
  IsFreelance BIT,
  IsMarried BIT,
  Active BIT,
  FOREIGN KEY (JobCategoryId) REFERENCES JobCategory(Id),
);

select * from JobCategory
select * from Person