CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT 
AS 
BEGIN
    DECLARE @productId INT = 
    (
        SELECT
            P.Id 
        FROM 
            Products AS P
        WHERE 
            P.[Name] = @name
    )
    RETURN 
    (
        SELECT  
            COUNT(ClientId)
        FROM 
            ProductsClients AS PC
        WHERE 
            PC.ProductId = @productId
    )
END
