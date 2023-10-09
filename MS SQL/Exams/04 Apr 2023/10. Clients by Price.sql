SELECT 
    C.[Name] AS Client,
    FLOOR(AVG(P.Price)) AS [Average Price]
FROM 
    Clients AS C
JOIN 
    ProductsClients AS PC ON C.Id = PC.ClientId
JOIN 
    Products AS P ON PC.ProductId = P.Id
JOIN 
    Vendors AS V ON V.Id = P.VendorId
WHERE 
    V.NumberVAT LIKE '%FR%'
GROUP BY 
    C.[Name]
ORDER BY 
    AVG(P.Price),
    C.[Name] DESC
