SELECT 
    [P].[PeakName], 
    [M].[MountainRange] AS [Mountain], 
    [CTRY].[CountryName], 
    [CNENT].[ContinentName]
FROM 
    [Mountains] AS [M]
JOIN 
    [Peaks] AS [P] ON [M].[Id] = [P].[MountainId]
JOIN 
    [MountainsCountries] AS [MC] ON [MC].[MountainId] = [M].[Id]
JOIN 
    [Countries] AS [CTRY] ON [MC].[CountryCode] = [CTRY].[CountryCode]
JOIN 
    [Continents] AS [CNENT] ON [CTRY].[ContinentCode] = [CNENT].[ContinentCode]
ORDER BY 
    [P].[PeakName],
    [CTRY].[CountryName]