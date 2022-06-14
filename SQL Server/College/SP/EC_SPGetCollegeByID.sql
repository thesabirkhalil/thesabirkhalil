drop procedure if exists EC_SPGetCollegeByID
go
create procedure EC_SPGetCollegeByID  
@id int  
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
from admin_College where id = @id   
 end