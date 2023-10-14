SELECT 
    P.[Name] AS PlanetName,
    COUNT(J.Id) AS JourneysCount
FROM 
    Planets AS P
JOIN 
    Spaceports AS S ON P.Id = S.PlanetId
JOIN 
    Journeys AS J ON J.DestinationSpaceportId = S.Id
GROUP BY 
    P.[Name]
ORDER BY 
    JourneysCount DESC,
    PlanetName