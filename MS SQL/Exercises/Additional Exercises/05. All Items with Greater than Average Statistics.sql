SELECT 
    [I].[Name], 
    [I].[Price], 
    [I].[MinLevel],
    [S-I].[Strength], 
    [S-I].[Defence], 
    [S-I].[Speed], 
    [S-I].[Luck], 
    [S-I].[Mind]
FROM 
    [Items] AS [I]
JOIN 
    [Statistics] AS [S-I] ON [I].[StatisticId] = [S-I].[Id]
CROSS JOIN 
(
    SELECT 
        AVG([Speed]) AS [AVG Speed], 
        AVG([Luck]) AS [AVG Luck], 
        AVG([Mind]) AS [AVG Mind]
    FROM 
        [Statistics]
) AS [AVG]
WHERE 
    [S-I].[Speed] > [AVG].[AVG Speed] 
AND 
    [S-I].[Luck] > [AVG].[AVG Luck] 
AND 
    [S-I].[Mind] > [AVG].[AVG Mind]
ORDER BY 
    [I].[Name]
--we are adding the average values to each row without any conditions
--or you can use variables outside the query