USE [AgriBook]
GO
/****** Object:  StoredProcedure [dbo].[spGetById]    Script Date: 10/24/2022 7:42:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetById]
@Id int
as
begin
select * from employee where
[PKEmployeeID]=@Id
end

GO
