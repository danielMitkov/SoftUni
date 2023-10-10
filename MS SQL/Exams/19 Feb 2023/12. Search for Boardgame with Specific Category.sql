CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
SELECT 
    B.[Name], 
    B.YearPublished, 
    B.Rating, 
    C.[Name] AS CategoryName, 
    P.[Name] AS PublisherName, 
    CONCAT(PR.PlayersMin, ' people') AS MinPlayers, 
    CONCAT(PR.PlayersMax, ' people') AS MaxPlayers
FROM 
    Boardgames AS B
JOIN
    Categories AS C ON B.CategoryId = C.Id
JOIN 
    PlayersRanges AS PR ON B.PlayersRangeId = PR.Id
JOIN 
    Publishers AS P ON B.PublisherId = P.Id
WHERE 
    C.[Name] = @category
ORDER BY 
    PublisherName,
    B.YearPublished DESC