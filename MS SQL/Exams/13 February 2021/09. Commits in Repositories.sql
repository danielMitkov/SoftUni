SELECT TOP (5)
    R.Id,
    R.[Name],
    COUNT(R.Id) AS Commits
FROM 
    Repositories AS R
JOIN 
    Commits AS C ON C.RepositoryId = R.Id
JOIN 
    RepositoriesContributors AS RC ON RC.RepositoryId = R.Id
GROUP BY 
    R.Id,
    R.[Name]
ORDER BY 
    Commits DESC,
    R.Id,
    R.[Name]