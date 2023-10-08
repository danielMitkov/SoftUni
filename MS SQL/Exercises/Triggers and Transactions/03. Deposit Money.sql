CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS 
BEGIN
    IF (@MoneyAmount > 0)
    BEGIN
        UPDATE 
            [Accounts]
        SET 
            [Balance] += @MoneyAmount
        WHERE 
            [Id] = @AccountId
    END
END