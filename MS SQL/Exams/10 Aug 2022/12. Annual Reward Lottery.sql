CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
    DECLARE @siteCount INT =
    (
        SELECT 
            COUNT(ST.SiteId)
        FROM 
            Tourists AS T
        JOIN 
            SitesTourists AS ST ON T.Id = ST.TouristId
        WHERE 
            T.[Name] = @TouristName
    )
    DECLARE @badge VARCHAR(20)

    IF(@siteCount >= 100) SET @badge = 'Gold badge'

    ELSE IF (@siteCount >= 50) SET @badge = 'Silver badge'

    ELSE IF (@siteCount >= 25) SET @badge = 'Bronze badge'
    --
    UPDATE 
        Tourists
    SET 
        Reward = @badge
    WHERE 
        [Name] = @TouristName
    --
    SELECT 
        [Name],
        Reward
    FROM 
        Tourists
    WHERE 
        [Name] = @TouristName
END