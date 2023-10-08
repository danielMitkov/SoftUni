CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount MONEY)
AS 
BEGIN
    IF (@MoneyAmount > 0)
    BEGIN
        UPDATE 
            [Accounts]
        SET 
            [Balance] -= @MoneyAmount
        WHERE 
            [Id] = @AccountId
    END
END