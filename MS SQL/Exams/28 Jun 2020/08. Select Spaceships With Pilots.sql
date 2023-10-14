SELECT
    S.[Name],
    S.Manufacturer
FROM 
    Spaceships AS S
JOIN 
    Journeys AS J ON J.SpaceshipId = S.Id
JOIN 
    TravelCards AS TC ON TC.JourneyId = J.Id
JOIN 
    Colonists AS C ON C.Id = TC.ColonistId
WHERE 
    TC.JobDuringJourney = 'Pilot'
AND 
    DATEDIFF(YEAR, C.BirthDate, '01/01/2019') < 30
ORDER BY 
    S.[Name]