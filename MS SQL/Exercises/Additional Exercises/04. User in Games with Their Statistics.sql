SELECT 
    [U].[Username], 
    [G].[Name] AS [Game],
    MAX([C].[Name]) as [Character],
    SUM([S-I].[Strength]) + MAX([S-C].[Strength]) + MAX([S-GT].[Strength]) AS [Strength], 
    SUM([S-I].[Defence]) + MAX([S-C].[Defence]) + MAX([S-GT].[Defence]) AS [Defence], 
    SUM([S-I].[Speed]) + MAX([S-C].[Speed]) + MAX([S-GT].[Speed]) AS [Speed], 
    SUM([S-I].[Mind]) + MAX([S-C].[Mind]) + MAX([S-GT].[Mind]) AS [Mind], 
    SUM([S-I].[Luck]) + MAX([S-C].[Luck]) + MAX([S-GT].[Luck]) AS [Luck]
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
JOIN 
    [Statistics] AS [S-I] ON [I].[StatisticId] = [S-I].[Id]
JOIN 
    [Characters] AS [C] ON [UG].[CharacterId] = [C].[Id]
JOIN 
    [Statistics] AS [S-C] ON [C].[StatisticId] = [S-C].[Id]
JOIN 
    [GameTypes] AS [GT] ON [G].[GameTypeId] = [GT].[Id]
JOIN 
    [Statistics] AS [S-GT] ON [GT].[BonusStatsId] = [S-GT].[Id]
GROUP BY 
    [U].[Username],
    [G].[Name]
ORDER BY 
    [Strength] DESC, 
    [Defence] DESC, 
    [Speed] DESC, 
    [Mind] DESC, 
    [Luck] DESC
--for each result stat column take one value for that column from the 3 statictics tables and sum the 3 values