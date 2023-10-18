SELECT 
    FORMAT(B.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
    B.AdultsCount,
    B.ChildrenCount
FROM 
    Bookings AS B
JOIN 
    Rooms AS R ON R.Id = B.RoomId
ORDER BY 
    R.Price DESC,
    B.ArrivalDate
