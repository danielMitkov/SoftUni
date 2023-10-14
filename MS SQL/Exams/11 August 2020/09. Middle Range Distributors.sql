SELECT 
    D.[Name] AS DistributorName,
    I.[Name] AS IngredientName,
    P.[Name] AS ProductName,
    AVG(F.Rate) AS AverageRate
FROM 
    Distributors AS D
JOIN 
    Ingredients AS I ON D.Id = I.DistributorId
JOIN 
    ProductsIngredients AS PRI ON PRI.IngredientId = I.Id
JOIN 
    Products AS P ON PRI.ProductId = P.Id
JOIN 
    Feedbacks AS F ON P.Id = F.ProductId
GROUP BY 
    D.[Name],
    I.[Name],
    P.[Name]
HAVING 
    AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY 
    DistributorName,
    IngredientName,
    ProductName