SELECT 
    C.Id,
    C.FirstName + ' ' + C.LastName AS ClientName,
    C.Email
FROM 
    Clients AS C
LEFT JOIN 
    ClientsCigars AS CC ON CC.ClientId = C.Id
WHERE 
    CC.ClientId IS NULL
ORDER BY 
    ClientName