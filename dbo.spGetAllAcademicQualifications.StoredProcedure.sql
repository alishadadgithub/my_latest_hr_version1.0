USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllAcademicQualifications]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetAllAcademicQualifications]
as
begin

select * from AcademicQualification

end
GO
