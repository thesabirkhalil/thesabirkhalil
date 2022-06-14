
if exists  (select 1 from admin_Setting where CLGID = 21 and isCompanyFeeFilter != 1)
	begin
		update admin_Setting set isCompanyFeeFilter = 1 where CLGID = 21 
	end