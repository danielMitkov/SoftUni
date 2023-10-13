SELECT TOP (10)
    C.Id,
    C.[Name] AS City,
    C.CountryCode AS Country,
    COUNT(*) AS Accounts
FROM 
    Cities AS C
JOIN 
    Accounts AS A ON A.CityId = C.Id
GROUP BY 
    C.Id,
    C.[Name],
    C.CountryCode
ORDER BY 
    Accounts DESC