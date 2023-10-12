CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(12, 2)
AS
BEGIN
    RETURN
    (
        SELECT 
            ISNULL(SUM(OP.Quantity * P.Price), 0)
        FROM 
            Jobs AS J
        JOIN 
            Orders AS O ON O.JobId = J.JobId
        JOIN 
            OrderParts AS OP ON OP.OrderId = O.OrderId
        JOIN 
            Parts AS P ON P.PartId = OP.PartId
        WHERE 
            J.JobId = @JobId
    )
END