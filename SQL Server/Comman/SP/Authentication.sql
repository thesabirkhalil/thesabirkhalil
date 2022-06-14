select	MobileNo, count(MobileNo) 
from	EC_UserAuthentication
group by MobileNo having count(MobileNo) > 2

select * from EC_UserAuthentication where MobileNo = '9123152011'