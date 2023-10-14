SELECT 
    C.Id,
    CONCAT_WS(' ', C.FirstName, C.LastName) AS full_name
FROM 
    Colonists AS C
JOIN 
    TravelCards AS TC ON C.Id = TC.ColonistId
WHERE 
    TC.JobDuringJourney = 'Pilot'
ORDER BY 
    C.Id