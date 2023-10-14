SELECT 
    CONCAT_WS(' ', C.FirstName, C.LastName) AS CustomerName,
    PhoneNumber,
    Gender
FROM 
    Customers AS C
LEFT JOIN 
    Feedbacks AS F ON F.CustomerId = C.Id
WHERE 
    F.Id IS NULL
ORDER BY 
    C.Id