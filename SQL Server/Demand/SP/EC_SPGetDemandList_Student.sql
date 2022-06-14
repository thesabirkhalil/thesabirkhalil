drop procedure if exists EC_SPGetDemandList_Student
go

create procedure EC_SPGetDemandList_Student
@StudID int
as
	begin
						select id,
						CompanyID,
				DemandNo,
				GeneratedMonth,
				GeneratedYear,
				StudID,
				NetAmount,
				TotalDiscount,
				PaidAmount
				from EC_ViewDemandList_Student
				where StudID = @StudID
				order by id desc

	end