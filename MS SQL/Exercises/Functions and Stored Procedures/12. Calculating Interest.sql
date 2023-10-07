CREATE PROC usp_CalculateFutureValueForAccount 
(@id INT, @interest FLOAT) AS 
BEGIN 
    SELECT 
        [A].[Id] AS [Account Id], 
        [AH].[FirstName] AS [First Name], 
        [AH].[LastName] AS [Last Name], 
        [A].[Balance] AS [Current Balance], 
        [dbo].[ufn_CalculateFutureValue]([A].[Balance], @interest, 5) AS [Balance in 5 years] 
    FROM 
        [Accounts] AS [A] 
    JOIN 
        [AccountHolders] AS [AH] ON [A].[AccountHolderId] = [AH].[Id] 
    WHERE 
        [A].[Id] = @id
END