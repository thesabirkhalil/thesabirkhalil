drop view if exists EC_ViewDemandList_Student
go
create view EC_ViewDemandList_Student
as
	
select		DN.id, DN.DemandNo, DD.CompanyID, DN.GeneratedMonth, DN.GeneratedYear, DN.StudID, SUM(DD.Fee) as NetAmount, SUM(DD.DiscountAmt) as TotalDiscount, sum(DD.paidAmt_M) as 'PaidAmount'
from		admin_DemandNote as DN
left join	admin_DemandDetails as DD on DN.id = DD.DmndID 
group by	DN.id, DN.DemandNo, DN.GeneratedMonth, DN.GeneratedYear, DN.StudID, DD.CompanyID