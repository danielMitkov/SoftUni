SELECT 
    [U].[Username], 
    [G].[Name] AS [Game],
    COUNT(ItemId) AS [Items Count], 
    SUM([I].[Price]) AS [Items Price]
FROM 
    [UsersGames] AS [UG]
JOIN 
    [Games] AS [G] ON [UG].[GameId] = [G].[Id]
JOIN 
    [Users] AS [U] ON [UG].[UserId] = [U].[Id]
JOIN 
    [UserGameItems] AS [UGI] ON [UGI].[UserGameId] = [UG].[Id]
JOIN 
    [Items] AS [I] ON [UGI].[ItemId] = [I].[Id]
GROUP BY 
    [U].[Username], 
    [G].[Name] 
HAVING 
    COUNT(*) >= 10 
ORDER BY 
    [Items Count] DESC, 
    [Items Price] DESC, 
    [U].[Username]