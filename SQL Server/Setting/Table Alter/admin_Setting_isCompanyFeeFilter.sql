
alter table admin_Setting
Add isCompanyFeeFilter bit not null
CONSTRAINT admin_Setting_isCompanyFeeFilter DEFAULT 0
WITH VALUES

