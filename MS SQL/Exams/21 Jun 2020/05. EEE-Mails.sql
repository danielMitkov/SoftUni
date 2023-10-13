SELECT 
    A.FirstName,
    A.LastName,
    FORMAT(A.BirthDate, 'MM-dd-yyyy') AS BirthDate,
    C.[Name] AS Hometown,
    A.Email
FROM 
    Accounts AS A
JOIN 
    Cities AS C ON C.Id = A.CityId
WHERE 
    Email LIKE 'e%'
ORDER BY 
    Hometown