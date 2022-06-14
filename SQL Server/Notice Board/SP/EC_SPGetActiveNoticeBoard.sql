drop procedure if exists EC_SPGetActiveNoticeBoard
go
create procedure EC_SPGetActiveNoticeBoard  
@clgid int,  
@NewsType varchar(10)  = null  
as  
 begin  
		SELECT [id], [UserId], [clgid], [NewsType], [Title], [SubTitle], [TargetLink]  
		,[Startdate], [Enddate], [DispalyOrder], [IsNew], [sts], [edate]  
		FROM [admin_WebAllNews]  
		where clgid = @Clgid and sts = 'A' and   
		(NewsType = @NewsType or @NewsType is null) and  
		(Startdate >= GETDATE() and Enddate <= GETDATE())  
		order by DispalyOrder   
  end