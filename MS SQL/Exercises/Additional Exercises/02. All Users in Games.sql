SELECT 
    [G].[Name] AS [Game], 
    [GT].[Name] AS [Game Type], 
    [U].[Username], 
    [UG].[Level], 
    [UG].[Cash], 
    [C].[Name] AS [Character]
FROM 
    [Games] AS [G]
JOIN 
    [GameTypes] AS [GT] ON [G].[GameTypeId] = [GT].[Id]
JOIN 
    [UsersGames] AS [UG] ON [G].[Id] = [UG].[GameId]
JOIN 
    [Users] AS [U] ON [UG].[UserId] = [U].[Id]
JOIN 
    [Characters] AS [C] ON [UG].[CharacterId] = [C].[Id]
ORDER BY 
    [UG].[Level] DESC,
    [U].[Username], 
    [G].[Name]