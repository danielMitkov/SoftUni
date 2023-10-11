SELECT 
    L.Province,
    L.Municipality,
    L.[Name] AS [Location],
    SUB.CountOfSites
FROM 
    Locations AS L
JOIN 
(
    SELECT
        L.Id,
        COUNT(S.Id) AS CountOfSites
    FROM 
        Locations AS L
    JOIN 
        Sites AS S ON L.Id = S.LocationId
    WHERE 
        L.Province = 'Sofia'
    GROUP BY 
        L.Id
) AS SUB ON SUB.Id = L.Id
ORDER BY 
    CountOfSites DESC,
    L.[Name]