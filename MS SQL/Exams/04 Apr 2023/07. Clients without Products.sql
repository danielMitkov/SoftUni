SELECT 
    C.Id,
    C.[Name] AS [Client], 
    CONCAT(A.StreetName, ' ', A.StreetNumber, ', ', A.City, ', ', A.PostCode, ', ', CO.[Name]) 
FROM 
    Clients AS C
LEFT JOIN 
    ProductsClients AS PC ON C.Id = PC.ClientId
JOIN 
    Addresses AS A ON C.AddressId = A.Id
JOIN 
    Countries AS CO ON A.CountryId = CO.Id
WHERE 
    PC.ClientId IS NULL
