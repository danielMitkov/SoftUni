SELECT
    ProductId,
    Rate,
    [Description],
    CustomerId,
    Age,
    Gender
FROM
    Feedbacks AS F
JOIN 
    Customers AS C ON F.CustomerId = C.Id
WHERE 
    Rate < 5.0
ORDER BY 
    ProductId DESC,
    Rate