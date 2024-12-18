USE [FiscalPro]
if not exists (select column_name from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TblProveedor' and COLUMN_NAME = 'TipoBienes')
begin
	alter Table TblProveedor add TipoBienes varchar(100);
end