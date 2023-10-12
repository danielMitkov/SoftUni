SELECT 
    ISNULL(E.FirstName + ' ' + E.LastName, 'None') AS Employee,
    ISNULL(D.[Name], 'None') AS Department,
    C.[Name] AS Category,
    R.[Description],
    FORMAT(R.OpenDate, 'dd.MM.yyyy') AS OpenDate,
    S.[Label] AS [Status],
    U.[Name] AS [User]
FROM 
    Reports AS R
LEFT JOIN 
    Users AS U ON R.UserId = U.Id
LEFT JOIN 
    [Status] AS S ON S.Id = R.StatusId
LEFT JOIN 
    Employees AS E ON E.Id = R.EmployeeId
LEFT JOIN 
    Categories AS C ON R.CategoryId = C.Id
LEFT JOIN 
    Departments AS D ON D.Id = E.DepartmentId
ORDER BY 
    E.FirstName DESC,
    E.LastName DESC,
    D.[Name],
    C.[Name],
    R.[Description],
    R.OpenDate,
    S.[Label],
    U.[Name]