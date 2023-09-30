SELECT TOP (50)
    [E].[EmployeeID],
    [E].[FirstName] + ' ' + [E].[LastName] AS [EmployeeName],
    [EM].[FirstName] + ' ' + [EM].[LastName] AS [ManagerName],
    [D].[Name]
FROM 
    [Employees] AS [E]
JOIN 
    [Employees] AS [EM] ON [E].[ManagerID] = [EM].[EmployeeID]
JOIN
    [Departments] AS [D] ON [E].[DepartmentID] = [D].DepartmentID
ORDER BY 
    [E].[EmployeeID]