drop procedure if exists EC_SPUserAuthecticatonBYUserType
go
create procedure EC_SPUserAuthecticatonBYUserType
@Username varchar(50),
@Usertype varchar(50),
@Password varchar(50)
as
	begin
		select		*
		from		EC_UserAuthentication 
		where		Username = @Username and UserType= @Usertype and Password  = @Password
		
	end

