drop view if exists EC_UserAuthentication
go
create view EC_UserAuthentication
as
	
	SELECT		FAC.[id], [UnivID], [ClgID], [Name], [MobileNo], [EmailID], [Username], [Password], [RoleID], [sts], 'User' AS 'UserType', fac.ProfilePic
	FROM        admin_academist.admin_Faculty AS FAC 
	UNION ALL
	SELECT      FAC.[id], NULL, [ClgID], [StaffName], [StaffContact], [StaffEmail], [EmpCode], [Password], [RoleID], [sts], 'Teacher' AS 'UserType', fac.ProfilePic
	FROM        admin_academist.admin_StaffReg AS FAC 
	UNION ALL
	SELECT      [id], null, [ClgID], Name, Mobile, EmailID, CollegeNo, Mobile, null, [sts], 'Student' AS 'UserType', ProImg
	FROM        admin_academist.admin_Student  
