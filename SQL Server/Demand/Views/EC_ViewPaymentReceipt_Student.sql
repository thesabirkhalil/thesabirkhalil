drop view if exists EC_ViewPaymentReceipt_Student
go
create view EC_ViewPaymentReceipt_Student
as
	
select		PM.PaymentNo, PM.acknowledgementCode, PM.sts, sum(PM.PaidAmount	) as 'PaidAmount',
			PM.Edate, PM.id, STUD.id AS 'StudentID'
from		admin_PaymentMaster as PM
left join	admin_DemandNote as DN on PM.DemandID = DN.id
left join	admin_Student as STUD on DN.StudID = STUD.id
group by	PM.PaymentNo, PM.acknowledgementCode, PM.sts, PM.Edate, PM.id, STUD.id
