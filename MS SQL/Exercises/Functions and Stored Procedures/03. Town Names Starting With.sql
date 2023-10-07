CREATE PROC usp_GetTownsStartingWith
(@startStr VARCHAR(50)) AS 
SELECT 
    [Name]
FROM 
    [Towns]
WHERE 
    [Name] LIKE @startStr + '%'