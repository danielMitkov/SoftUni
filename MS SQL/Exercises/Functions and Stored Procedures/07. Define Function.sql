CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT AS
BEGIN
    DECLARE @index INT = 1

    WHILE (@index <= LEN(@word))
    BEGIN
        DECLARE @currentChar CHAR = SUBSTRING(@word, @index, 1)

        IF (CHARINDEX(@currentChar, @setOfLetters) = 0)
        BEGIN
            RETURN 0
        END
        SET @index += 1
    END
    RETURN 1
END