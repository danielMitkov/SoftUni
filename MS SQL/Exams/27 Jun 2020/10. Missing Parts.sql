--if you can understand the task description
SELECT 
    P.PartId,
    P.[Description],
    PN.Quantity AS [Required],
    P.StockQty AS [In Stock],
    ISNULL(OP.Quantity, 0) AS Ordered
FROM 
    Jobs AS J
JOIN 
    PartsNeeded AS PN ON J.JobId = PN.JobId
JOIN 
    Parts AS P ON P.PartId = PN.PartId
LEFT JOIN 
    Orders AS O ON O.JobId = J.JobId
LEFT JOIN 
    OrderParts AS OP ON OP.OrderId = O.OrderId
WHERE 
    J.[Status] <> 'Finished'
AND 
    ISNULL(OP.Quantity, 0) + P.StockQty < PN.Quantity