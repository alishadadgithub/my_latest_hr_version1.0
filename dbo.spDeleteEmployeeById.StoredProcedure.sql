USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployeeById]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spDeleteEmployeeById]
@Id int
as
begin
delete from employee where pkemployeeid = @id

end

GO
