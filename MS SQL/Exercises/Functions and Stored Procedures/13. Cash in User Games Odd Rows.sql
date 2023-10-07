CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE 
AS 
    RETURN SELECT 
        SUM([Cash]) AS [SumCash]
    FROM 
        (
        SELECT 
            [Cash], 
            ROW_NUMBER() OVER (ORDER BY [Cash] DESC) AS [Row Number]
        FROM 
            [UsersGames] AS [UG]
        JOIN 
            [Games] AS [G] ON [UG].[GameId] = [G].[Id]
        WHERE 
            [G].[Name] = @gameName
        ) AS [Rows]
    WHERE 
        [Row Number] % 2 <> 0