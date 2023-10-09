SELECT 
    P.Id,
    P.[Name],
    P.Price,
    C.[Name]
FROM 
    Products AS P
JOIN 
    Categories AS C ON P.CategoryId = C.Id
WHERE 
    C.[Name] IN ('ADR', 'Others')
ORDER BY 
    P.Price DESC
