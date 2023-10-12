SELECT 
    E.FirstName + ' ' + E.LastName AS FullName,
    COUNT(R.UserId) AS UsersCount
FROM 
    Employees AS E
LEFT JOIN 
    Reports AS R ON R.EmployeeId = E.Id
GROUP BY 
    E.FirstName + ' ' + E.LastName
ORDER BY 
    UsersCount DESC,
    FullName