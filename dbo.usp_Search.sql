USE [ReportPrint]
GO
/*************************************************************

USE [ReportPrint]
GO

DECLARE	@return_value int,
		@cnt int

EXEC	@return_value = [dbo].[usp_Search]
		@filter = N'tpear',
		@field = '[emailto]',
		@cnt = @cnt OUTPUT

SELECT	@cnt as N'@result_count'

SELECT	'Return Value' = @return_value

GO

*************************************************************/
ALTER PROCEDURE dbo.usp_Search 
    @filter varchar(50) = '0',
	@field varchar(50),
    @cnt int OUTPUT 
AS

BEGIN

	DECLARE @Where varchar(1000);
	DECLARE @SQLStr varchar(5000);
	

	IF object_id('tempdb.dbo.##result') IS NOT NULL
	BEGIN
		DROP TABLE ##result;	
	END

	CREATE TABLE ##result (recid int not null)

	--SELECT @filter;

		--Create the conditions for the SQL
	SET @Where = @field + ' LIKE ''%' + @filter + '%''';
	--SET @Where = @Where + ' AND	SalesChannel LIKE ''' + @SalesChannel + ''''
	
	--SELECT @Where;

	--Check the record count
	--SET @SQLStr = 'SELECT '' + @cnt =

	INSERT INTO ##result (recid)
	SELECT 
		recid 
	FROM 
		[ReportPrint].[dbo].[SubscriptionList] 
	WHERE
		[emailto] LIKE '%' + @filter + '%'

	INSERT INTO ##result (recid)
	SELECT 
		recid 
	FROM 
		[ReportPrint].[dbo].[SubscriptionList] 
	WHERE
		[emailcc] LIKE '%' + @filter + '%'

	INSERT INTO ##result (recid)
	SELECT 
		recid 
	FROM 
		[ReportPrint].[dbo].[SubscriptionList] 
	WHERE
		[fileprefix] LIKE '%' + @filter + '%'

	INSERT INTO ##result (recid)
	SELECT 
		recid 
	FROM 
		[ReportPrint].[dbo].[SubscriptionList] 
	WHERE
		[Territory] LIKE '%' + @filter + '%'
	
	/****************************************************
	SET @SQLStr = 'SELECT '' + @param2 + '' = recid FROM [ReportPrint].[dbo].[SubscriptionList] WHERE ' + @Where + ';'
	EXECUTE (@SQLStr)
	--Select Statement

	SET @SQLStr = 'SELECT recid'
	SET @SQLStr = @SQLStr + ',' + @field + ',''' + @filter + ''' AS [Filter] ';
	SET @SQLStr = @SQLStr + 'FROM '
	SET @SQLStr = @SQLStr + '[ReportPrint].[dbo].[SubscriptionList] '
	SET @SQLStr = @SQLStr + 'WHERE ' + @Where + ';'

	EXECUTE (@SQLStr)
	--Save or return the result
	--PRINT @SQLStr
	**************************************************/
	SELECT @cnt = COUNT(recid) FROM ##result;
	SELECT 
		sl.[recid],
		sl.[Territory],
		sl.[reporttype],
		sl.[reportfilename],
		sl.[excelpwd],
		sl.[reportname] 
	FROM 
		[ReportPrint].[dbo].[SubscriptionList] sl
	INNER JOIN
		##result r
		ON r.recid = sl.recid;
	--SELECT * FROM ##result;
	RETURN 0 

END