SELECT 
    SUBSTRING(T.[Name], CHARINDEX(' ', T.[Name]) + 1, LEN(T.[Name])) AS LastName,
    Nationality,
    Age,
    PhoneNumber
FROM 
    Tourists AS T
JOIN 
(
    SELECT 
        T.Id
    FROM 
        Tourists AS T
    JOIN 
        SitesTourists AS ST ON T.Id = ST.TouristId
    JOIN 
        Sites AS S ON ST.SiteId = S.Id
    JOIN 
        Categories AS C ON C.Id = S.CategoryId
    WHERE 
        C.[Name] = 'History and archaeology'
    GROUP BY 
        T.Id
) AS SUB ON SUB.Id = T.Id
ORDER BY 
    LastName