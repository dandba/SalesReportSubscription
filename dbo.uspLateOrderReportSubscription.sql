USE [ReportPrint]
GO

/****** Object:  StoredProcedure [dbo].[uspLateOrderReportSubscription]    Script Date: 1/31/2025 12:23:04 PM ******/
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

EXEC	[dbo].[uspLateOrderReportSubscription]
		@sales_code = N'LaPaRM',
		@site = N'*',
		@product_code = N'*',
		@SalesChannel = N'Regional_SC',
		@Region = N'*',
		@pwd = N'peak',
		@freq = N'D',
		@email = N'dwheeler@indium.com',
		@cc = N'ksethi@indium.com',
		@recId = @return_value OUTPUT;

		SELECT	'Return Value' = @return_value
GO

********************************************************************
*/

CREATE PROCEDURE [dbo].[uspLateOrderReportSubscription]
    @sales_code nvarchar(8),						--[Territory], |Salesman|
	@site nvarchar(12) = '*',
	@product_code nvarchar(8) = '*',
	@SalesChannel nvarchar(15) = 'Regional_SC',
	@Region nvarchar(10) = '*',						--|SalesManager|
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

DECLARE @report_name NVARCHAR(40) = 'SNAP-SHOT Late Orders';
DECLARE @report_file_name NVARCHAR(50) = CONCAT(@fileprefix,'_LateOrders.xlsx');
DECLARE @report_id uniqueidentifier;
DECLARE @subscription_id uniqueidentifier;
DECLARE @paramstring nvarchar(150);


SELECT @report_id = [reportid],@subscription_id = [subscriptionid] FROM [dbo].[ReportList] WHERE [reportname] = @report_name;
--SELECT @report_name,@report_id,@subscription_id	--Check vars



SET @paramstring = CONCAT('|SalesManager|,',@Region,',|SalesChannel|,',@SalesChannel,',|Site|,',@site,',|Salesman|,',@sales_code,',|ProductCode|,',@product_code,',|TimeframeText|,',@timeframe)
--Sample
--'|SalesManager|,*,|SalesChannel|,Regional_SC,|Site|,*,|Salesman|,LaPaRM,|ProductCode|,*,|TimeframeText|,CW'
--SELECT MAX([RecId]) FROM [BI].[dbo].[tblSubscriptions];  
 
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
END
GO


