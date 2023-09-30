SELECT
    [E].[EmployeeID],
    [E].[FirstName],
    [E].[ManagerID],
    [EM].[FirstName] AS [ManagerName]
FROM 
    [Employees] AS [E]
JOIN 
    [Employees] AS [EM] ON [E].[ManagerID] = [EM].[EmployeeID]
WHERE 
    [E].[ManagerID] IN (3, 7)
ORDER BY 
    [E].[EmployeeID]