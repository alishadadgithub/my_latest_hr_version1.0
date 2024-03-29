USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spAddNewEmployee]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddNewEmployee]
@EmployeeFirstName NVARCHAR(50) 
 ,@EmployeeMiddleName NVARCHAR(50) 
 ,@EmployeeLastName NVARCHAR(50) 
 ,@EmployeeDateOfBirth DATETIME
 ,@EmployeePhoneNumber NCHAR(10)
 ,@EmployeeFinancialNumber NCHAR(10) 
 ,@EmployeeAutomatedNumber INT 
 ,@EmployeeImageURL NVARCHAR(100) 
 ,@EmployeeTaxNumber INT
 
 ,@FKAcademicQualificationID INT 
 ,@FKMaritalStatusID INT 
AS 

INSERT INTO Employee
VALUES (@EmployeeFirstName  
 ,@EmployeeMiddleName  
 ,@EmployeeLastName
 ,@EmployeeDateOfBirth 
 ,@EmployeePhoneNumber
 ,@EmployeeFinancialNumber 
 ,@EmployeeAutomatedNumber 
 ,@EmployeeImageURL  
 ,@EmployeeTaxNumber 

 ,@FKAcademicQualificationID 
 ,@FKMaritalStatusID ) 


GO
