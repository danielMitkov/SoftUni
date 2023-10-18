SELECT 
    T.Id,
    T.Name,
    T.PhoneNumber
FROM 
    Tourists AS T
LEFT JOIN 
    Bookings AS B ON B.TouristId = T.Id
WHERE 
    B.Id IS NULL
ORDER BY 
    T.Name
