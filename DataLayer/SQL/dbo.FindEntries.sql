-- ===================================================
-- Author:		René Hennecke
-- Create date: 30.08.2020
-- Description:	Führt eine Suche in EPG, Aufnahmen und
--              Timern durch
-- ===================================================
CREATE PROCEDURE [dbo].[FindEntries]
	@expression nvarchar(50),
	@startTime datetime,
	@seekInTitle bit,
	@seekinShortDescriptions bit,
	@seekInDescriptions bit,
	@seekInTimers bit,
	@seekInRecordings bit,
	@seekInPast bit

AS
BEGIN
	SET NOCOUNT ON;

	SET @expression = LOWER(ISNULL(@expression, N''));
	SET @startTime = ISNULL(@startTime, SYSDATETIME());
	SET @seekInTitle = ISNULL(@seekInTitle, 0);
	SET @seekinShortDescriptions = ISNULL(@seekinShortDescriptions, 0);
	SET @seekinDescriptions = ISNULL(@seekinDescriptions, 0);
	SET @seekInTimers = ISNULL(@seekInTimers, 0);
	SET @seekInRecordings = ISNULL(@seekInRecordings, 0);
	SET @seekInPast = ISNULL(@seekInPast, 0);

	SELECT
		T0.RecId RecId,
		0 SymbolIndex,
		T0.ChannelRecId ChannelRecId,
		T0.StartTime,
		T0.Duration / 60 DurationMinutes,
		T0.Title,
		T0.ShortDescription,
		T0.[Description],
		T0.VPS,
		T1.ChannelName,
		T0.GenreCodes,
		T0.ParentalRating
	FROM
		dbo.EPG T0
    INNER JOIN
		dbo.Channels T1 ON T0.ChannelRecId = T1.RecId
	WHERE
		(
			CASE
			WHEN @seekInTitle = 1 AND LOWER(T0.Title) LIKE '%' + @expression + '%' THEN 1
			ELSE 0 
			END = 1
			OR
			CASE
			WHEN @seekinShortDescriptions = 1 AND LOWER(T0.ShortDescription) LIKE '%' + @expression + '%' THEN 1
			ELSE 0 
			END = 1
			OR
			CASE
			WHEN @seekinDescriptions = 1 AND LOWER(T0.[Description]) LIKE '%' + @expression + '%' THEN 1
			ELSE 0 
			END = 1
		 )
		 AND 
		 (
			CASE 
			WHEN @seekInPast = 0 AND CONVERT(nvarchar(16), T0.StartTime, 120) >= CONVERT(nvarchar(16), @startTime, 120) THEN 1
			WHEN @seekInPast = 1 THEN 1
			END = 1
		 )

	UNION ALL

	SELECT
	    T0.RecId RecId,
		2 SymbolIndex,
		T0.ChannelRecId,
		CAST(null as datetime) StartTime,
		T0.Duration / 60 Duration,
		T0.Title,
		'' ShortDescription,
		'' [Description],
		CAST(null as datetime) VPS,
		T1.ChannelName,
		'' GenreCodes,
		0 ParentalRating
	FROM
		dbo.Timers T0
	LEFT JOIN
		dbo.Channels T1 ON T0.ChannelRecId = T1.RecId
	WHERE
		CASE
		WHEN @seekInTimers = 1 AND LOWER(T0.Title) LIKE '%' + @expression + '%' THEN 1
		ELSE 0
		END = 1
		
	UNION ALL

	SELECT
	    T0.RecId RecId,
		3 SymbolIndex,
		0 ChannelRecId,
		CAST(null as datetime) StartTime,
		T0.Duration Duration,
		T0.Title,
		'' ShortDescription,
		'' [Description],
		CAST(null as datetime) VPS,
		'' ChannelName,
		'' GenreCodes,
		0 ParentalRating
	FROM
		dbo.Recordings T0
	WHERE
		CASE 
		WHEN @seekInRecordings = 1 AND LOWER(T0.Title) LIKE '%' + @expression + '%' THEN 1
		ELSE 0 
		END = 1

	ORDER BY 
		SymbolIndex, Title, StartTime;
END