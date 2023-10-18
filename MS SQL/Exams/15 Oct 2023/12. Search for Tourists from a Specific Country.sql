CREATE PROC usp_SearchByCountry(@country NVARCHAR(50))
AS
SELECT 
    TT.Name,
    TT.PhoneNumber,
    TT.Email,
    COUNT(BB.Id) AS CountOfBookings
FROM 
    Tourists AS TT
JOIN 
    Bookings AS BB ON BB.TouristId = TT.Id
JOIN 
    Countries AS CC ON CC.Id = TT.CountryId
WHERE 
    CC.Name = @country
GROUP BY 
    TT.Name,
    TT.PhoneNumber,
    TT.Email
ORDER BY 
    CountOfBookings DESC
