SELECT 
    SUB.JobDuringJourney,
    SUB.FullName,
    SUB.JobRank
FROM 
(
    SELECT 
        TC.JobDuringJourney,
        C.BirthDate,
        CONCAT_WS(' ', C.FirstName, C.LastName) AS FullName,
        DENSE_RANK() OVER (PARTITION BY TC.JobDuringJourney ORDER BY C.BirthDate) AS JobRank
    FROM 
        TravelCards AS TC
    JOIN 
        Colonists AS C ON C.Id = TC.ColonistId
) AS SUB
WHERE 
    SUB.JobRank = 2