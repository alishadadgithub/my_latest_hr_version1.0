USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllFamilyDetails]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetAllFamilyDetails]
as
begin

select * from FamilyDetails

end
GO
