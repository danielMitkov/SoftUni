DECLARE @userId INT = (SELECT [Id] FROM [Users] WHERE [Username] = 'Alex')

DECLARE @gameId INT = (SELECT [Id] FROM [Games] WHERE [Name] = 'Edinburgh')

DECLARE @userGameId INT = (SELECT [Id] FROM [UsersGames] WHERE [UserId] = @userId AND GameId = @gameId)

DECLARE @itemsIds TABLE (Id INT)
INSERT INTO @itemsIds (Id)
(
    SELECT [Id] FROM [Items] WHERE [Name] IN ('Blackguard', 
                                              'Bottomless Potion of Amplification', 
                                              'Eye of Etlich (Diablo III)', 
                                              'Gem of Efficacious Toxin', 
                                              'Golden Gorget of Leoric', 
                                              'Hellfire Amulet')
)
DECLARE @totalCost MONEY = 
(
    SELECT 
        SUM([Price]) 
    FROM 
        [Items] 
    WHERE 
        [Id] IN (SELECT * FROM @itemsIds)
)

UPDATE UsersGames
SET Cash -= @totalCost
WHERE Id = @userGameId

INSERT INTO UserGameItems (ItemId, UserGameId) 
(
    SELECT 
        [Id], 
        @userGameId 
    FROM 
        @itemsIds
)
SELECT
	[U].[Username],
	[G].[Name],
	[UG].[Cash],
	[I].[Name] AS [Item Name]
FROM 
    [Users] AS [U]
JOIN 
    [UsersGames] AS [UG] ON [U].[Id] = [UG].[UserId]
JOIN 
    [Games] AS [G] ON [UG].[GameId] = [G].[Id]
JOIN 
    [UserGameItems] AS [UGI] ON [UG].[Id] = [UGI].[UserGameId]
JOIN 
    [Items] AS [I] ON [UGI].[ItemId] = [I].[Id]
WHERE 
    [G].[Id] = @gameId
ORDER BY 
    [I].[Name]