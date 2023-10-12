SELECT 
    J.JobId,
    ISNULL(SUM(OP.Quantity * P.Price), 0) AS Total
FROM 
    Jobs AS J
LEFT JOIN 
    Orders AS O ON O.JobId = J.JobId
LEFT JOIN 
    OrderParts AS OP ON OP.OrderId = O.OrderId
LEFT JOIN 
    Parts AS P ON P.PartId = OP.PartId
WHERE 
    J.Status = 'Finished'
GROUP BY 
    J.JobId
ORDER BY 
    Total DESC,
    J.JobId