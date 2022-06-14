drop procedure if exists EC_SPGetCollegeByURLCode
go
create procedure EC_SPGetCollegeByURLCode  
@URLCode varchar(100)  
as  
 begin  
  select id,  
   UnivID,  
   URLCode,  
   CollegeName,  
   Code,  
   EmailID,  
   ContactPerson,  
   ContactNo,  
   Address,  
   City,  
   Dist,  
   State,  
   Pincode,  
   LogoURL,  
   ReportHeaderLogo,  
   DomainName,  
   CollegeImage,  
   sts,  
   Edate,  
   PrivacyPolicyPage,  
   RefundSecurityPage,  
   TermsConditionPage,  
   AboutUsPage,  
   AppThemeClr   
from admin_College where URLCode = @URLCode   
 end