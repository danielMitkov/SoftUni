SELECT TOP(7)
    I.Number,
    I.Amount,
    C.[Name]
FROM 
    Invoices AS I
JOIN 
    Clients AS C ON I.ClientId = C.Id
WHERE 
    I.IssueDate < '2023-01-01' 
AND 
    I.Currency = 'EUR'
OR
    I.Amount > 500.00
AND 
    C.NumberVAT LIKE 'DE%'
ORDER BY 
    I.Number,
    I.Amount DESC
