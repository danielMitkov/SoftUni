CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
SELECT 
    Id,
    [Name],
    CONCAT(Size, 'KB') AS Size
FROM 
    Files AS F
WHERE 
    [Name] LIKE '%.' + @fileExtension
ORDER BY 
    Id,
    [Name],
    F.Size DESC