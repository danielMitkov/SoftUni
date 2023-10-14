SELECT 
    COUNT(C.Id) AS [Count]
FROM 
    Journeys AS J
JOIN 
    TravelCards AS TC ON J.Id = TC.JourneyId
JOIN 
    Colonists AS C ON TC.ColonistId = C.Id
WHERE 
    J.Purpose = 'Technical'