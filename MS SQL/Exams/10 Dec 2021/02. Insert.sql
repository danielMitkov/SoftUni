INSERT INTO Passengers
SELECT 
    CONCAT(FirstName, ' ', LastName) AS FullName,
    CONCAT(FirstName, LastName, '@gmail.com') AS Email
FROM 
    Pilots
WHERE 
    Id BETWEEN 5 AND 15