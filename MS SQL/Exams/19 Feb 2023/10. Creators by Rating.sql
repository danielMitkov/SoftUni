SELECT 
    C.LastName,
    CEILING(AVG(B.Rating)) AS AverageRating,
    'Stonemaier Games' AS PublisherName
FROM 
    Creators AS C
JOIN 
    CreatorsBoardgames AS CB ON C.Id = CB.CreatorId
JOIN 
    Boardgames AS B ON CB.BoardgameId = B.Id
JOIN 
    Publishers AS P ON B.PublisherId = P.Id
WHERE 
    P.[Name] = 'Stonemaier Games'
GROUP BY 
    C.LastName
ORDER BY 
    AVG(B.Rating) DESC -- without ceiling