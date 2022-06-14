drop procedure if exists EC_SPGetSMSOutboxByStudent 
go
create procedure EC_SPGetSMSOutboxByStudent
@StudentID int
as
	begin
		Declare @Todaye datetime = getdate();

		select * from admin_smsoutbox where StudId = @StudentID and scheduleDateTime <= @Todaye
	end