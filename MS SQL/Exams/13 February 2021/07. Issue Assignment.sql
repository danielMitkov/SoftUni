SELECT 
    I.Id,
    U.Username + ' : ' + I.Title AS IssueAssignee
FROM
    Issues AS I
JOIN 
    Users AS U ON U.Id = I.AssigneeId
ORDER BY 
    I.Id DESC,
    U.Username