drop procedure if exists EC_SPGetSettings
go
create procedure EC_SPGetSettings
@CollegeID int
as
	begin
		select id
,CLGID
,SMSGateway
,OTPGateway
,SMSDeliveryGateway
,SMSGatewaysecond
,OTPGatewaysecond
,WAGAteway
,WAGatewayMedia
,DemandPrefix
,Mob_Replace_Test
,MSG_Replace_txt
,MSG_Replace_JobID
,SMSLanguage
,VoucherPrefix
,acknowledgementFormat
,ReceiptFormat
,EnqReceiptFormate
,Stud_Walt_acknowFormat
,stud_Walt_ReceiptFormat
,isAutoDemand
,TCnoFormate
,isLateFine
,LateFineDay
,LateFineMode
,LateFineHead
,Labrary_MaxBookHoldDay
,PO_Limit
,IsOnlinePayment
,IsliveClassAuto
,IsSemChangeRequest
,isDECEDeatils
,isManualAttendanceDate
,isApiAttendanceAllowed
,isOnlineExamRequest
,isMaterialApproval
,IsGoogleEducation
,AttendancePercantage
,BillingMode
,isBulkPayment
,isPlanHeadGroup
,EmpAttendanceShowMonths
,isCompanyFeeFilter from admin_Setting where CLGID = @CollegeID
	end