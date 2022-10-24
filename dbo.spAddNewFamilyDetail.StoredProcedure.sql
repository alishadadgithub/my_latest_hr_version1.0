USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spAddNewFamilyDetail]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spAddNewFamilyDetail]
@FamilyDetailsFullName NVARCHAR(50) 
 ,@FamilyDetailsDOB DATETIME
 ,@FamilyDetailsGender NCHAR(10) 
 ,@FKRelativeTypeID INT 
 ,@FKEmployeeID INT 
AS 

INSERT INTO FamilyDetails
VALUES (@FamilyDetailsFullName 
 ,@FamilyDetailsDOB 
 ,@FamilyDetailsGender
 ,@FKRelativeTypeID 
 ,@FKEmployeeID   ) 


GO
