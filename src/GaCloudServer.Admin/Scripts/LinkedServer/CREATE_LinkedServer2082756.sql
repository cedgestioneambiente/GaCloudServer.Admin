USE [master]
GO

/****** Object:  LinkedServer [20.82.75.6]    Script Date: 27/09/2022 09:18:56 ******/
EXEC master.dbo.sp_addlinkedserver @server = N'20.82.75.6', @srvproduct=N'SQL Server'
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname=N'20.82.75.6',@useself=N'False',@locallogin=NULL,@rmtuser=N'csgroup',@rmtpassword='QDS6bNPq*gH5^mZW'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'collation compatible', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'data access', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'dist', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'pub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'rpc', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'rpc out', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'sub', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'connect timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'collation name', @optvalue=null
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'lazy schema validation', @optvalue=N'false'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'query timeout', @optvalue=N'0'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'use remote collation', @optvalue=N'true'
GO

EXEC master.dbo.sp_serveroption @server=N'20.82.75.6', @optname=N'remote proc transaction promotion', @optvalue=N'true'
GO