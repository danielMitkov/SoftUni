SELECT 
    A.Id AS AccountId,
    CONCAT(A.FirstName, ' ', A.LastName) AS FullName,
    MAX(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS LongestTrip,
    MIN(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS ShortestTrip
FROM 
    Accounts AS A
JOIN 
    AccountsTrips AS ACT ON ACT.AccountId = A.Id
JOIN 
    Trips AS T ON ACT.TripId = T.Id
WHERE 
    A.MiddleName IS NULL
AND 
    T.CancelDate IS NULL
GROUP BY 
    A.Id,
    CONCAT(A.FirstName, ' ', A.LastName)
ORDER BY 
    LongestTrip DESC,
    ShortestTrip