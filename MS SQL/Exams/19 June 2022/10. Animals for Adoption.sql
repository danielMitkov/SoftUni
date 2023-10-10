SELECT
    A.[Name],
    YEAR(A.BirthDate) AS BirthYear,
    T.AnimalType
FROM 
    Animals AS A
JOIN 
    AnimalTypes AS T ON A.AnimalTypeId = T.Id
WHERE 
    A.OwnerId IS NULL
AND
    DATEDIFF(YEAR, A.BirthDate,'01/01/2022') < 5
AND 
    T.Id <> 3
ORDER BY 
    A.[Name]