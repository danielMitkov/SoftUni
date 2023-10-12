SELECT 
    U.Username,
    C.[Name] AS CategoryName
FROM 
    Users AS U 
JOIN 
    Reports AS R ON R.UserId = U.Id
JOIN 
    Categories AS C ON R.CategoryId = C.Id
WHERE 
    DAY(U.Birthdate) = DAY(R.OpenDate)
AND 
    MONTH(U.Birthdate) = MONTH(R.OpenDate)
ORDER BY 
    U.Username,
    CategoryName