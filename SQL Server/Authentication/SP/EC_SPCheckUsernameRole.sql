drop procedure if exists EC_SPCheckUsernameType
go
create procedure EC_SPCheckUsernameType
@Username varchar(20),
@Usertype varchar(100)
as
	begin
		select		count(id) 
		from		EC_UserAuthentication 
		where		Username = @Username and UserType= @Usertype
		
	end

