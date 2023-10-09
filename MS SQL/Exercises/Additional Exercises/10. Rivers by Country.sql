SELECT 
    [CTRY].[CountryName], 
    [CNENT].[ContinentName],
    ISNULL([RESULT].[RiversCount], 0) AS [RiversCount],
    ISNULL([RESULT].[TotalLength], 0) AS [TotalLength]
FROM 
    [Countries] AS [CTRY]
LEFT JOIN 
    [Continents] AS [CNENT] ON [CTRY].[ContinentCode] = [CNENT].[ContinentCode]
LEFT JOIN 
(
    SELECT 
        [CR].[CountryCode],
        COUNT([CR].[RiverId]) AS [RiversCount],
        SUM([R].[Length]) AS [TotalLength]
    FROM 
        [CountriesRivers] AS [CR]
    LEFT JOIN 
        [Rivers] AS [R] ON [CR].[RiverId] = [R].[Id]
    LEFT JOIN 
        [Countries] AS [CTRY] ON [CR].[CountryCode] = [CTRY].[CountryCode]
    GROUP BY 
        [CR].[CountryCode]
) AS [RESULT] ON [RESULT].[CountryCode] = [CTRY].[CountryCode]
ORDER BY 
    [RiversCount] DESC, 
    [TotalLength] DESC, 
    [CountryName]