DECLARE @gameAccountId INT = 
(
    SELECT 
        [UG].[Id] 
    FROM 
        [UsersGames] AS [UG]
    JOIN 
        [Users] AS [U] ON [UG].[UserId] = [U].[Id]
    JOIN 
        [Games] AS [G] ON [UG].[GameId] = [G].[Id]
    WHERE 
        [U].[Username] = 'Stamat' AND [G].[Name] = 'Safflower'
)

DECLARE @accountCash MONEY = 
(
    SELECT 
        [Cash] 
    FROM 
        [UsersGames]
    WHERE 
        [Id] = @gameAccountId
)
DECLARE @totalCost MONEY = 
(
    SELECT 
        SUM([Price]) 
    FROM 
        [Items] 
    WHERE 
        [MinLevel] BETWEEN 11 AND 12
)
IF (@accountCash >= @totalCost)
BEGIN 
    BEGIN TRANSACTION
    UPDATE 
        [UsersGames]
    SET 
        [Cash] -= @totalCost
    WHERE 
        [Id] = @gameAccountId

    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
        SELECT 
            [Id], 
            @gameAccountId
        FROM 
            [Items] 
        WHERE 
            [MinLevel] BETWEEN 11 AND 12
    )
    COMMIT
END

SET @accountCash = 
(
    SELECT 
        [Cash] 
    FROM 
        [UsersGames]
    WHERE 
        [Id] = @gameAccountId
)
SET @totalCost = 
(
    SELECT 
        SUM([Price]) 
    FROM 
        [Items] 
    WHERE 
        [MinLevel] BETWEEN 19 AND 21
)
IF (@accountCash >= @totalCost)
BEGIN 
    BEGIN TRANSACTION
    UPDATE 
        [UsersGames]
    SET 
        [Cash] -= @totalCost
    WHERE 
        [Id] = @gameAccountId

    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
        SELECT 
            [Id], 
            @gameAccountId
        FROM 
            [Items] 
        WHERE 
            [MinLevel] BETWEEN 19 AND 21
    )
    COMMIT
END

SELECT 
    [I].[Name] 
FROM 
    [UserGameItems] AS [UGI]
JOIN 
    [Items] AS [I] ON [UGI].[ItemId] = [I].[Id]
WHERE 
    [UserGameId] = @gameAccountId