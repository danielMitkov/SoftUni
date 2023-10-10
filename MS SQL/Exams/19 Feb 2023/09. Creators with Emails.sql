SELECT 
    CONCAT(C.FirstName, ' ', C.LastName) AS FullName,
    C.Email,
    MAX(B.Rating) AS Rating
FROM 
    Creators AS C
JOIN 
    CreatorsBoardgames AS CB ON C.Id = CB.CreatorId
JOIN 
    Boardgames AS B ON CB.BoardgameId = B.Id
WHERE 
    RIGHT(C.Email, 4) = '.com'
GROUP BY
    CONCAT(C.FirstName, ' ', C.LastName),
    C.Email
ORDER BY 
    FullName