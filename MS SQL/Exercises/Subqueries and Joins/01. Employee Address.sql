SELECT TOP (5) 
    [E].[EmployeeID],
    [E].JobTitle,
    [E].AddressID,
    [A].AddressText
FROM 
    [Employees] AS [E]
JOIN 
    [Addresses] AS [A] ON [E].AddressID = [A].AddressID
ORDER BY 
    [E].AddressID 