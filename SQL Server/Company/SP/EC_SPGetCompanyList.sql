drop procedure if exists EC_SPGetCompanyList
go
create procedure EC_SPGetCompanyList
@CollegeID int
as
	begin
		select id,UsrID, ClgID, CompanyName, CompanyCode, CompanyPrefix, ComapnyFeeType, ContactPersone, ContactNo, EmailID, Address, City, Dist,
		State, Pincode, sts, IsComapnyFeeTypeShow, Edate 
		from admin_Company
		where	CLgID = @CollegeID
		order by CompanyName
	end