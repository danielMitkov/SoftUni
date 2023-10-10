CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
    SELECT 
        A.[Name],
        ISNULL(O.[Name], 'For adoption') AS [OwnersName]
    FROM 
        Animals AS A
    LEFT JOIN 
        Owners AS O ON A.OwnerId = O.Id
    WHERE 
        A.[Name] = @AnimalName
END