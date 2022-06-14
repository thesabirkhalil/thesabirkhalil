
drop view if exists EC_ViewDemandDetail_Student
go
create view EC_ViewDemandDetail_Student
as
	
select		DN.id as 'DemandID', dn.StudID, PRG.ProgramName, Sem.SemName, AY.Name as 'AcadmicYear', DD.GeneratedMonth, DN.GeneratedYear, 
			isnull(PG.GroupName,DD.Description) as 'Description',  sum(dd.fee) as 'Fee',
			sum(isnull(DP.PaidAmt,0)) as 'PaidAmt'
from		admin_DemandDetails as DD
left join	admin_DemandNote as DN on DD.DmndID = DN.id
left join	admin_PlanHead as PH on PH.id = DD.PlanHeadID
left join	admin_PlanGroup as PG on PH.PlanGroupID = PG.id
left join	admin_Program as PRG on DD.ProgID = PRG.id
left join	admin_AcadmicYear as AY on DD.AcdID = AY.id
left join	admin_Semester as Sem on DD.SemID = sem.id
left join	admin_DemandPayment as DP on DD.id = DP.DmndDtlID
group by	DN.id, PRG.ProgramName, Sem.SemName, AY.Name, DD.GeneratedMonth, DN.GeneratedYear, isnull(PG.GroupName,DD.Description),dn.StudID