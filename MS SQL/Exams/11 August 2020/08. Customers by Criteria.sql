SELECT 
    C.FirstName,
    C.Age,
    C.PhoneNumber
FROM 
    Customers AS C
JOIN 
    Countries AS CO ON C.CountryId = CO.Id
WHERE
    (C.Age >= 21 AND C.FirstName LIKE '%an%')
OR
    (C.PhoneNumber LIKE '%38' AND CO.[Name] <> 'Greece')
ORDER BY 
    C.FirstName,
    C.Age DESC