SELECT 
    [P].[PeakName], 
    [M].[MountainRange] AS [Mountain], 
    [P].[Elevation]
FROM 
    [Mountains] AS [M]
JOIN 
    [Peaks] AS [P] ON [M].[Id] = [P].[MountainId]
ORDER BY 
    [P].[Elevation] DESC,
    [P].[PeakName]