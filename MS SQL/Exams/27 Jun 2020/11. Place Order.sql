CREATE PROC usp_PlaceOrder
(@JobId INT, @PartSerialNumber VARCHAR(50), @Quantity INT)
AS 
BEGIN
    IF (@Quantity <= 0) THROW 50012, 'Part quantity must be more than zero!', 1

    IF ((SELECT [Status] FROM Jobs WHERE JobId = @JobId) = 'Finished') THROW 50011, 'This job is not active!', 1
    
    IF (@JobId NOT IN (SELECT JobId FROM Jobs)) THROW 50013, 'Job not found!', 1 

    IF (@PartSerialNumber NOT IN (SELECT SerialNumber FROM Parts)) THROW 50014, 'Part not found!', 1 
    
    IF ((SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL) IS NULL)
    INSERT INTO Orders VALUES (@JobId, NULL, 0)

    DECLARE @OrderId INT = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)

    DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @PartSerialNumber)

    DECLARE @PartQuantity INT = (SELECT Quantity FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId)
    
    IF (@PartQuantity IS NULL) --if there is our order row in OrderParts
        INSERT INTO OrderParts VALUES (@OrderId, @PartId, @Quantity)
    ELSE
        UPDATE OrderParts SET Quantity += @Quantity WHERE OrderId = @OrderId AND PartId = @PartId
END