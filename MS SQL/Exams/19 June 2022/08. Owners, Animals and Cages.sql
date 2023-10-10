SELECT
    CONCAT(O.[Name], '-', A.[Name]) AS OwnersAnimals,
    O.PhoneNumber,
    C.CageId
FROM 
    Owners AS O
JOIN 
    Animals AS A ON O.Id = A.OwnerId
JOIN 
    AnimalTypes AS T ON A.AnimalTypeId = T.Id
JOIN 
    AnimalsCages AS C ON A.Id = C.AnimalId
WHERE 
    T.AnimalType = 'Mammals'
ORDER BY 
    O.[Name],
    A.[Name] DESC