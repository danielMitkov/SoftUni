CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(CB.BoardgameId)
        FROM 
            Creators AS C
        JOIN 
            CreatorsBoardgames AS CB ON CB.CreatorId = C.Id
        WHERE 
            C.FirstName = @name
    )
END