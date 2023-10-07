CREATE FUNCTION ufn_CalculateFutureValue 

(@sum MONEY, @interest FLOAT, @years INT) 

RETURNS MONEY 
AS 
BEGIN 
    RETURN @sum * POWER(1 + @interest, @years)
END