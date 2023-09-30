SELECT TOP (5) 
    [C].[CountryName], 
    MAX([P].[Elevation]) AS [HighestPeakElevation], 
    MAX([R].[Length]) AS [LongestRiverLength] 
FROM 
    [Countries] AS [C] 
LEFT JOIN 
    [CountriesRivers] AS [CR] ON [C].[CountryCode] = [CR].[CountryCode] 
LEFT JOIN 
    [Rivers] AS [R] ON [CR].[RiverId] = [R].[Id] 
LEFT JOIN 
    [MountainsCountries] AS [MC] ON [C].[CountryCode] = [MC].[CountryCode] 
LEFT JOIN 
    [Mountains] AS [M] ON [MC].[MountainId] = [M].[Id] 
LEFT JOIN 
    [Peaks] AS [P] ON [M].[Id] = [P].[MountainId] 
GROUP BY 
    [C].[CountryName] 
ORDER BY 
    [HighestPeakElevation] DESC, 
    [LongestRiverLength] DESC, 
    [C].[CountryName]