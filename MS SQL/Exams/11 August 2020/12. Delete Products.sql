CREATE TRIGGER TR_RemoveRelationsOnDelete
ON Products INSTEAD OF DELETE
AS
BEGIN
    DECLARE @id INT = (SELECT Id FROM deleted)

    DELETE FROM 
        ProductsIngredients
    WHERE 
        ProductId = @id

    DELETE FROM
        Feedbacks
    WHERE 
        ProductId = @id

    DELETE FROM 
        Products
    WHERE 
        Id = @id
END