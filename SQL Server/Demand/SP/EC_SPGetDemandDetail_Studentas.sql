drop procedure if exists EC_SPGetDemandDetail_Studentas
go
create procedure EC_SPGetDemandDetail_Studentas
@DemandiID int,
@StudentID int
as
	begin
		select		*
		from		EC_ViewDemandDetail_Student 
		where		DemandID = @DemandiID and StudID= @StudentID

	end