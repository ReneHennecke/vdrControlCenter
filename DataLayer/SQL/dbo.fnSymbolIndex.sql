-- =============================================
-- Author:		René Hennecke
-- Create date: 02.10.2020
-- Description:	Liefert den SymbolIndex für das Image 
--              in der Liste
-- =============================================
CREATE FUNCTION dbo.fnSymbolIndex(@favouriteRecId int, @timerRecId int, @recordingsRecId int)
RETURNS INT
AS
BEGIN
	DECLARE @result int = 0; 

	IF @favouriteRecId > 0
		SET @result = 1;

	IF @timerRecId > 0
		SET @result = 2;

	IF @recordingsRecId > 0
		SET @result = 3;
	
	RETURN @result;
END;