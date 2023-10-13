SELECT 
    U.Username,
    AVG(F.Size) AS Size
FROM 
    Users AS U
JOIN 
    Commits AS C ON C.ContributorId = U.Id
JOIN 
    Files AS F ON F.CommitId = C.Id
GROUP BY 
    U.Username
ORDER BY 
    AVG(F.Size) DESC,
    U.Username