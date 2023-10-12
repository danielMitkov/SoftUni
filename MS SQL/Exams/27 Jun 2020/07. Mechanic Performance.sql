SELECT 
    M.FirstName + ' ' + M.LastName AS Mechanic,
    AVG(DATEDIFF(DAY, J.IssueDate, J.FinishDate)) AS [Average Days]
FROM 
    Mechanics AS M
JOIN 
    Jobs AS J ON J.MechanicId = M.MechanicId
GROUP BY 
    M.FirstName + ' ' + M.LastName,
    M.MechanicId
ORDER BY 
    M.MechanicId