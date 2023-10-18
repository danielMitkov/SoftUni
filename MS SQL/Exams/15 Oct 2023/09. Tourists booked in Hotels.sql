SELECT 
    H.Name AS HotelName,
    R.Price AS RoomPrice
FROM 
    Tourists AS T
JOIN 
    Bookings AS B ON B.TouristId = T.Id
JOIN 
    Hotels AS H ON B.HotelId = H.Id
JOIN 
    Rooms AS R ON B.RoomId = R.Id
WHERE 
    T.Name NOT LIKE '%EZ'
ORDER BY 
    R.Price DESC
