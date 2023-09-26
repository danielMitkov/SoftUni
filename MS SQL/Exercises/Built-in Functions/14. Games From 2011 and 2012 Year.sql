SELECT TOP (50) 
    [Name], 
    FORMAT([Start],'yyyy-MM-dd','bg-BG') AS [Start] 
FROM 
    [Games] 
WHERE 
    YEAR([Start]) BETWEEN 2011 AND 2012 
ORDER BY 
    [Start], 
    [Name] 