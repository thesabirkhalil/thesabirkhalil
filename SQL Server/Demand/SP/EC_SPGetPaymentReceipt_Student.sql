drop procedure if exists EC_SPGetPaymentReceipt_Student
go

create procedure EC_SPGetPaymentReceipt_Student
@StudentID int
as
	begin
		select * from EC_ViewPaymentReceipt_Student where StudentID = @StudentID
	end