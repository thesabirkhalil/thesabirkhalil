  drop procedure if exists EC_SPGetWebBanner
  go
create procedure EC_SPGetWebBanner  
@Clgid int  
as  
 begin  
SELECT [id]  
      ,[UserID]  
      ,[clgid]  
      ,[Title]  
      ,[BannerImg]  
      ,[TargetLink]  
      ,[Startdate]  
      ,[EndDate]  
      ,[DisplayOrder]  
      ,[sts]  
      ,[Edate]  
  FROM [admin_academist].[admin_academist].[admin_WebHomeBanner]  
  where sts = 'A' and  (Startdate <= Getdate() and EndDate >= Getdate()) and clgid = @Clgid   
  order by DisplayOrder asc  
  end