SELECT * FROM MYTest
go


CREATE PROCEDURE dbo.ConvertDateSingleCond
AS
SET NOCOUNT ON;

SELECT DateCol,CONVERT(varchar(255),DateCol,120)
FROM [dbo].TestTableSSDT
WHERE CONVERT(varchar(255),DateCol,120)='2009-04-13 12:59:05';
