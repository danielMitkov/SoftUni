CREATE PROC usp_GetHoldersWithBalanceHigherThan 
(@balance MONEY) AS
BEGIN
    SELECT 
        [FirstName], 
        [LastName] 
    FROM 
        [AccountHolders] AS [A] 
    JOIN 
        (
        SELECT 
            [AccountHolderId], 
            SUM([Balance]) AS [Sum] 
        FROM 
            [Accounts] 
        GROUP BY 
            [AccountHolderId] 
        ) AS [S] ON 
            [A].[Id] = [AccountHolderId] 
    WHERE 
        [Sum] > @balance 
    ORDER BY 
        [FirstName], 
        [LastName]
END