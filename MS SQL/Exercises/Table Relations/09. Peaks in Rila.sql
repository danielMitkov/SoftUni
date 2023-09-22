SELECT 
    M.MountainRange,
    P.PeakName, 
    P.Elevation
FROM 
    [Peaks] AS P
JOIN 
    [Mountains] AS M ON P.MountainId = M.Id
WHERE 
    M.MountainRange = 'Rila'
ORDER BY 
    P.Elevation DESC