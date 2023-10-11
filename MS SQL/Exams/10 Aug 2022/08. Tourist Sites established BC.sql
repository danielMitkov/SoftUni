SELECT 
    S.[Name] AS [Site],
    L.[Name] AS [Location],
    L.Municipality,
    L.Province,
    S.Establishment
FROM 
    Sites AS S
JOIN 
    Locations AS L ON S.LocationId = L.Id
WHERE 
    S.Establishment LIKE '%BC%'
AND 
    L.[Name] NOT LIKE '[B,M,D]%'
ORDER BY 
    S.[Name]