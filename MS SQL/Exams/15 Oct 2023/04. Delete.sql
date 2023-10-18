DECLARE @TouristIds TABLE (Id INT)
INSERT INTO @TouristIds
SELECT 
    Id
FROM 
    Tourists
WHERE 
    [Name] LIKE '%Smith'

DELETE FROM 
    Bookings
WHERE 
    TouristId IN (SELECT * FROM @TouristIds)

DELETE FROM 
    Tourists
WHERE 
    Id IN (SELECT * FROM @TouristIds)
