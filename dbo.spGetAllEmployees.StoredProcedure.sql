USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetAllEmployees]
as
begin

select * from Employee

end
GO
