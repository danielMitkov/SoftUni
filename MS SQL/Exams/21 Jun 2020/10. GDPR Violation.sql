SELECT 
    T.Id,
    CONCAT_WS(' ', A.FirstName, A.MiddleName, A.LastName) AS [Full Name],
    [C-A].[Name] AS [From],
    [C-H].[Name] AS [To],
    CASE 
        WHEN T.CancelDate IS NOT NULL THEN 'Canceled'
        ELSE CONCAT(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate), ' days')
    END AS Duration
FROM 
    Trips AS T
JOIN 
    AccountsTrips AS [AT] ON [AT].TripId = T.Id
JOIN 
    Accounts AS A ON [AT].AccountId = A.Id
JOIN 
    Cities AS [C-A] ON [C-A].Id = A.CityId
JOIN 
    Rooms AS R ON T.RoomId = R.Id
JOIN 
    Hotels AS H ON R.HotelId = H.Id
JOIN 
    Cities AS [C-H] ON H.CityId = [C-H].Id
ORDER BY 
    [Full Name],
    T.Id