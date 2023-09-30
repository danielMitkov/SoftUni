SELECT TOP (5)
    Ranking.CountryName AS Country,
    CASE 
        WHEN Ranking.PeakName IS NULL THEN '(no highest peak)' ELSE Ranking.PeakName
        END AS [Highest Peak Name], 
    CASE 
        WHEN Ranking.Elevation IS NULL THEN 0 ELSE Ranking.Elevation
        END AS [Highest Peak Elevation],
    CASE 
        WHEN Ranking.MountainRange IS NULL THEN '(no mountain)' ELSE Ranking.MountainRange
        END AS [Mountain]
FROM (
    SELECT 
        C.CountryName, 
        P.PeakName, 
        P.Elevation,
        M.MountainRange,
        DENSE_RANK() OVER (PARTITION BY C.CountryCode ORDER BY P.Elevation DESC) 
            AS RankNum
    FROM 
        Countries AS C
    LEFT JOIN
        MountainsCountries AS MC ON C.CountryCode = MC.CountryCode
    LEFT JOIN 
        Mountains AS M ON MC.MountainId = M.Id
    LEFT JOIN 
        Peaks AS P ON M.Id = P.MountainId
    ) AS Ranking
WHERE 
    RankNum = 1
ORDER BY 
    Country,
    [Highest Peak Name]