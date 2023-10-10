SELECT 
    A.[Name],
    [AT].AnimalType,
    FORMAT(A.BirthDate,'dd.MM.yyyy') AS BirthDate
FROM 
    Animals AS A
JOIN 
    AnimalTypes AS [AT] ON A.AnimalTypeId = [AT].Id
ORDER BY 
    A.[Name]