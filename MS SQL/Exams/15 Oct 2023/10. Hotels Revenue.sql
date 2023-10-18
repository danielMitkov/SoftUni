SELECT 
    NIGHT.HotelName,
    SUM(NIGHT.RealPrice) AS HotelRevenue
FROM 
(
    SELECT 
        DATEDIFF(DAY, B.ArrivalDate, B.DepartureDate) * R.Price AS RealPrice,
        B.Id AS BookingId,
        H.Name as HotelName
    FROM 
        Bookings AS B
    JOIN 
        Hotels AS H ON H.Id = B.HotelId
    JOIN 
        Rooms AS R ON R.Id = B.RoomId
) AS NIGHT
GROUP BY 
    NIGHT.HotelName
ORDER BY 
    HotelRevenue DESC
