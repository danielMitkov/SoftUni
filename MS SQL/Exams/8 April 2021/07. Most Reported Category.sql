SELECT TOP (5)
    C.[Name],
    COUNT(R.Id) AS ReportsNumber
FROM 
    Categories AS C
LEFT JOIN 
    Reports AS R ON R.CategoryId = C.Id
GROUP BY 
    C.[Name]
ORDER BY 
    ReportsNumber DESC,
    C.[Name]