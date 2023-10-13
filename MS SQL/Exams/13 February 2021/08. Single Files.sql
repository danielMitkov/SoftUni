SELECT 
    Id,
    [Name],
    CONCAT(Size, 'KB') AS Size
FROM 
    Files
WHERE 
    Id NOT IN
(
    SELECT 
        ISNULL(ParentId, 0)
    FROM 
        Files
)
ORDER BY 
    Id,
    [Name],
    Size DESC