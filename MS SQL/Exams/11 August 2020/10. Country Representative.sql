SELECT 
    SUB.CountryName,
    SUB.DistributorName
FROM 
    Countries AS C
JOIN 
(
    SELECT 
        C.[Name] AS CountryName,
        D.[Name] AS DistributorName,
        COUNT(I.Id) AS IngredientCount,
        DENSE_RANK() OVER (PARTITION BY C.[Name] ORDER BY COUNT(I.Id) DESC) AS Ranking
    FROM 
        Countries AS C
    JOIN 
        Distributors AS D ON D.CountryId = C.Id
    LEFT JOIN 
        Ingredients AS I ON I.DistributorId = D.Id --Distributor might not have any in ingredients
    GROUP BY
        C.[Name],
        D.[Name]
) AS SUB ON C.[Name] = SUB.CountryName
WHERE 
    SUB.Ranking = 1
ORDER BY 
    SUB.CountryName,
    SUB.DistributorName

--first for each country for each distributor get the count of ingredients they have, 
--then group(PARTITION) by country and assign ranks to the counts