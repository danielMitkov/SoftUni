SELECT 
    MIN([AVG]) 
FROM (
    SELECT 
        AVG([E].Salary) AS [AVG]
    FROM 
        [Employees] AS [E]
    GROUP BY 
        [E].[DepartmentID]) AS [G]