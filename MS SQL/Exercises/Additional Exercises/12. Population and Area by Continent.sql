SELECT 
    [CON].[ContinentName], 
    SUM(CAST([COU].[AreaInSqKm] AS BIGINT)) AS [CountriesArea], 
    SUM(CAST([COU].[Population] AS BIGINT)) AS [CountriesPopulation]
FROM 
    [Continents] AS [CON]
LEFT JOIN 
    [Countries] AS [COU] ON [CON].[ContinentCode] = [COU].[ContinentCode]
GROUP BY 
    [CON].[ContinentName]
ORDER BY 
    [CountriesPopulation] DESC