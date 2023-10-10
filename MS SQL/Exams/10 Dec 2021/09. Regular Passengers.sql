SELECT 
    P.FullName,
    COUNT(FD.Id) AS CountOfAircraft,
    SUM(FD.TicketPrice) AS TotalPayed
FROM 
    Passengers AS P
JOIN 
    FlightDestinations AS FD ON P.Id = FD.PassengerId
WHERE 
    SUBSTRING(P.FullName, 2, 1) = 'a'
GROUP BY 
    P.FullName
HAVING 
    COUNT(FD.Id) > 1
ORDER BY 
    P.FullName