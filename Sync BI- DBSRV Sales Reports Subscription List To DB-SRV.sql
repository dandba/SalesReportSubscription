/******************************************************************
This report subscription originates on DB-SRV. While in the process
of moving to the new server BI-DBSRV, this script syncs changes made 
to the old server over to the new server.
***************************************************************/


SET IDENTITY_INSERT [ReportPrint].[dbo].[SubscriptionList] ON;
GO

MERGE INTO [ReportPrint].[dbo].[SubscriptionList] AS TARGET
USING [DB-SRV.ICA.COM].[ReportPrint].[dbo].[SubscriptionList] AS SOURCE
ON TARGET.[recid] = Source.[recid]
 
 
WHEN NOT MATCHED BY TARGET 
	THEN INSERT
           ([recid]
			,[reportname]
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
			(Source.[recid]
			,Source.[reportname]
			,Source.[reportfilename]
			,Source.[reporttype]
			,'C7A029FD-0DDD-4D6F-A752-79BB0CBE86A3'
			,Source.[paramstring]
			,'C7A029FD-0DDD-4D6F-A752-79BB0CBE86A3'
			,Source.[emailto]
			,Source.[emailcc]
			,Source.[excelpwd]
			,Source.[fileprefix]
			,Source.[int_ext]
			,Source.[Territory])

WHEN MATCHED 
    THEN UPDATE SET Target.[reportname] = Source.[reportname]
		,Target.[reportfilename] = Source.[reportfilename]
		,Target.[reporttype] = Source.[reporttype]
		,Target.[paramstring] = Source.[paramstring]
		,Target.[emailto] = Source.[emailto]
		,Target.[emailcc] = Source.[emailcc]
		,Target.[excelpwd] = Source.[excelpwd]
		,Target.[fileprefix] = Source.[fileprefix]
		,Target.[int_ext] = Source.[int_ext]
		,Target.[Territory] = Source.[Territory]

WHEN NOT MATCHED BY SOURCE THEN DELETE 

--Optional 
OUTPUT $action, inserted.*, deleted.*;

GO 
/******************************************************************
***************************************************************/

SET IDENTITY_INSERT [ReportPrint].[dbo].[SubscriptionList] OFF;
GO

UPDATE [ReportPrint].[dbo].[SubscriptionList]
SET [subscriptionid] = rl.[subscriptionid] 
,[reportid] = rl.[reportid]
FROM
	[ReportPrint].[dbo].[SubscriptionList] sl
INNER JOIN
	[ReportPrint].[dbo].[ReportList] rl
	ON sl.reportname = rl.reportname
WHERE
	sl.[reportid] IN ('C7A029FD-0DDD-4D6F-A752-79BB0CBE86A3','CCE67CC5-C570-43E2-9900-D87D59632CEF')
	

  
