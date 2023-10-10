SELECT TOP (5)
    O.[Name] AS [Owner],
    COUNT(A.Id) AS CountOfAnimals
FROM 
    Owners AS O
LEFT JOIN 
    Animals AS A ON O.Id = A.OwnerId
GROUP BY 
    O.[Name]
ORDER BY 
    CountOfAnimals DESC,
    [Owner]