UPDATE 
    [Countries]
SET 
    [CountryName] = 'Burma'
WHERE 
    [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]([Name], [CountryCode])
SELECT 
    'Hanga Abbey', 
    [CountryCode]
FROM 
    [Countries]
WHERE 
    [CountryName] = 'Tanzania'

INSERT INTO [Monasteries]([Name], [CountryCode])
SELECT 
    'Myin-Tin-Daik', 
    [CountryCode]
FROM 
    [Countries]
WHERE 
    [CountryName] = 'Myanmar'

SELECT 
    [CON].[ContinentName], 
    [COU].[CountryName], 
    COUNT([M].[Id]) AS [MonasteriesCount] 
FROM 
    [Monasteries] AS [M] 
RIGHT JOIN 
    [Countries] AS [COU] ON [M].[CountryCode] = [COU].[CountryCode] 
RIGHT JOIN 
    [Continents] AS [CON] ON [COU].[ContinentCode] = [CON].[ContinentCode] 
WHERE 
    [COU].[IsDeleted] = 0 
GROUP BY 
    [CON].[ContinentName], 
    [COU].[CountryName] 
ORDER BY 
    [MonasteriesCount] DESC, 
    [COU].[CountryName]