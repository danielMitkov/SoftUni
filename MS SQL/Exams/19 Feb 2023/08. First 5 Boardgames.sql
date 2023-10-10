SELECT TOP (5)
    B.[Name],
    B.Rating,
    C.[Name] AS CategoryName
FROM 
    Boardgames AS B
JOIN 
    PlayersRanges AS PR ON B.PlayersRangeId = PR.Id
JOIN 
    Categories AS C ON B.CategoryId = C.Id
WHERE 
    (B.Rating > 7.00 AND B.[Name] LIKE '%a%')
OR
    (B.Rating > 7.50 AND PR.PlayersMin = 2 AND PR.PlayersMax = 5)
ORDER BY 
    B.[Name],
    B.Rating DESC