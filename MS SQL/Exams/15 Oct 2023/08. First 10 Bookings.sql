SELECT TOP (10)
    H.Name,
    D.Name,
    C.Name
FROM 
    Bookings AS B
JOIN 
    Hotels AS H ON H.Id = B.HotelId
JOIN 
    Destinations AS D ON D.Id = H.DestinationId
JOIN 
    Countries AS C ON C.Id = D.CountryId
WHERE 
    B.ArrivalDate < '2023-12-31'
AND 
    B.HotelId % 2 <> 0
ORDER BY 
    C.Name,
    B.ArrivalDate
