USE [ReportPrint]
GO

/****** Object:  StoredProcedure [dbo].[uspNewMonthlySalespersonSubscription]    Script Date: 1/31/2025 12:21:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*
todo report file name tied to email name
parmstring does not take variables *
Test insert vars using a select to display them

********************************************************************
USE [ReportPrint]
GO

DECLARE	@return_value int

EXEC	[dbo].[uspNewMonthlySalespersonSubscription]
		@sales_code = N'LaPaRM',
		@SalesChannel = N'Regional_SC',
		@Region = N'*',
		@pwd = N'peak',
		@freq = N'M',
		@email = N'pamela@lapaent.com;nick@lapaent.com;jbahou@indium.com',
		@cc = N'tschachtler@indium.com;lclark@indium.com',
		@recId = @return_value OUTPUT;

		SELECT	'Subscription' = @return_value

GO

********************************************************************
*/
CREATE PROCEDURE [dbo].[uspNewMonthlySalespersonSubscription]
    @sales_code nvarchar(8),						--[Territory], |Salesman|
	@SalesChannel nvarchar(15) = N'Regional_SC',
	@Region nvarchar(10) = N'*',					--|SalesManager|
    @pwd nvarchar(7),
	@freq nchar(1),									--(D - Daily, W - Weekly, M - Monthly)
	@email nvarchar(100),
	@cc nvarchar(100),
	@fileprefix nvarchar(25),
	@recId int OUTPUT
AS
BEGIN

SET NOCOUNT ON;

DECLARE @timeframe nvarchar(3);

SELECT @timeframe = 
	CASE 
		WHEN @freq = 'W' THEN 'CW'
		ELSE @freq
	END;

DECLARE @report_name NVARCHAR(40) = 'SNAP-SHOT Monthly Salesperson Report';
DECLARE @report_file_name NVARCHAR(50) = CONCAT(@fileprefix,'_MonthlySalespersonReport.xlsx');
DECLARE @report_id uniqueidentifier;		--8ABF770A-618B-41A6-8C0F-64970CD9FF2D
DECLARE @subscription_id uniqueidentifier;	--18ABDD99-9B3D-467C-9BD4-59183207087E
DECLARE @paramstring nvarchar(150);


SELECT @report_id = [reportid],@subscription_id = [subscriptionid] FROM [dbo].[ReportList] WHERE [reportname] = @report_name;



SET @paramstring = CONCAT('|Salesmgr|,',@Region,',|SalesChannel|,',@SalesChannel,',|SalesPerson|,',@sales_code)
--Sample

--'|Salesmgr|,*,|SalesChannel|,Regional_SC,|SalesPerson|,Restroni'
--'|Salesmgr|,*,|SalesChannel|,Regional_SC,|SalesPerson|,LaPaRM'

 
INSERT INTO [dbo].[SubscriptionList]
           ([reportname]
           ,[reportfilename]
           ,[reporttype]
           ,[subscriptionid]
           ,[paramstring]
           ,[reportid]
           ,[emailto]
           ,[emailcc]
           ,[excelpwd]
           ,[fileprefix]
           ,[int_ext]
		   ,[Territory])
     VALUES
           (@report_name									--[reportname]
           ,@report_file_name								--[reportfilename]
           ,@freq	
           ,@subscription_id								--[subscriptionid]
           ,@paramstring									--[paramstring]
           ,@report_id										--[reportid]
		   ,@email											--[emailto]
           ,@cc												--[emailcc]
           ,@pwd											--[excelpwd]
           ,@fileprefix										--[emailname]
           ,'ext'
		   ,@sales_code)

	SET @recId = @@IDENTITY; 

	INSERT INTO [dbo].[AutomatedDispatch]
           ([Id]
           ,[ReportName]
           ,[FilePath]
           ,[ModifiedDate]
           ,[bEnabled])
     VALUES
           (@recId
           ,@report_file_name
           ,'\\DB-SRV\Reports2'
           ,GETDATE()
           ,1)

RETURN;
END
GO


