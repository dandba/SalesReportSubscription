USE [master]
GO

/****** Object:  Login [HQ_SECURITY\Finance]    Script Date: 1/31/2025 2:56:17 PM ******/
CREATE LOGIN [HQ_SECURITY\Finance] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO


USE [IND_APP]
GO

CREATE USER [HQ_SECURITY\Finance] FOR LOGIN [HQ_SECURITY\Finance]
GO

ALTER ROLE [db_datareader] ADD MEMBER [HQ_SECURITY\Finance]
GO

GRANT EXECUTE ON [dbo].[usp_IND_Ledger_Audit_Fiscal_End_Date] TO [HQ_SECURITY\Finance]
GO

GRANT EXECUTE ON [dbo].[usp_IND_Ledger_Audit_Fiscal_Start_Date] TO [HQ_SECURITY\Finance]
GO

GRANT EXECUTE ON [dbo].[IND_LedgerAuditLoadSp] TO [HQ_SECURITY\Finance]
GO