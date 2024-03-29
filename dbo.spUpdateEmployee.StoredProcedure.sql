USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployee]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateEmployee]
@PKEmployeeID int ,
@EmployeeFirstName NVARCHAR(50) 
 ,@EmployeeMiddleName NVARCHAR(50) 
 ,@EmployeeLastName NVARCHAR(50) 
 ,@EmployeeDateOfBirth DATE
 ,@EmployeePhoneNumber NCHAR(10)
 ,@EmployeeFinancialNumber NCHAR(10) 
 ,@EmployeeAutomatedNumber INT 
 ,@EmployeeImageURL NVARCHAR(100) 
 ,@EmployeeTaxNumber INT
 
 ,@FKAcademicQualificationID INT 
 ,@FKMaritalStatusID INT 
AS 

update Employee
set EmployeeFirstName  = @EmployeeFirstName  
 ,EmployeeMiddleName= @EmployeeMiddleName  
 ,EmployeeLastName= @EmployeeLastName
 ,EmployeeDateOfBirth = @EmployeeDateOfBirth 
 ,EmployeePhoneNumber = @EmployeePhoneNumber
 ,EmployeeFinancialNumber =@EmployeeFinancialNumber 
 ,EmployeeAutomatedNumber= @EmployeeAutomatedNumber 
 ,EmployeeImageURL= @EmployeeImageURL  
 ,EmployeeTaxNumber= @EmployeeTaxNumber 
 
 ,FKAcademicQualificationID= @FKAcademicQualificationID 
 ,FKMaritalStatusID = @FKMaritalStatusID 


 where PKEmployeeID = @PKEmployeeID


GO
