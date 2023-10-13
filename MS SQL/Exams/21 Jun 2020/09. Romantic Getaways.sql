SELECT 
    A.Id,
    A.Email,
    [C-A].[Name] AS City,
    COUNT(T.Id) AS Trips
FROM 
    Accounts AS A
JOIN 
    Cities AS [C-A] ON A.CityId = [C-A].Id
JOIN 
    AccountsTrips AS [AT] ON [AT].AccountId = A.Id
JOIN 
    Trips AS T ON [AT].TripId = T.Id
JOIN 
    Rooms AS R ON R.Id = T.RoomId
JOIN 
    Hotels AS H ON R.HotelId = H.Id
JOIN 
    Cities AS [C-H] ON H.CityId = [C-H].Id
WHERE 
    [C-A].[Name] = [C-H].[Name]
GROUP BY 
    A.Id,
    A.Email,
    [C-A].[Name]
HAVING
    COUNT(T.Id) >= 1
ORDER BY 
    Trips DESC,
    A.Id