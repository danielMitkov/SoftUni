SELECT 
    H.Id,
    H.Name
FROM 
    Hotels AS H
JOIN 
    HotelsRooms AS HR ON HR.HotelId = H.Id
JOIN 
    Rooms AS R ON R.Id = HR.RoomId
JOIN 
    Bookings AS B ON H.Id = B.HotelId
WHERE 
    R.Type = 'VIP Apartment'
GROUP BY 
    H.Id,
    H.Name
ORDER BY 
    COUNT(B.Id) DESC
