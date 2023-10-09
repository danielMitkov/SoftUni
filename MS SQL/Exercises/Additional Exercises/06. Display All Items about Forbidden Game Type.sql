SELECT 
    [I].[Name] AS [Item], 
    [I].[Price], 
    [I].[MinLevel], 
    [GT].[Name] AS [Forbidden Game Type]
FROM 
    [Items] AS [I]
LEFT JOIN 
    [GameTypeForbiddenItems] AS [GTF] ON [I].[Id] = [GTF].[ItemId]
LEFT JOIN 
    [GameTypes] AS [GT] ON [GTF].[GameTypeId] = [GT].[Id]
ORDER BY 
    [Forbidden Game Type] DESC, 
    [Item]