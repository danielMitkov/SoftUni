SELECT TOP (20)
    FD.Id AS DestinationId,
    FD.[Start],
    P.FullName,
    A.AirportName,
    FD.TicketPrice
FROM 
    FlightDestinations AS FD
JOIN 
    Passengers AS P ON FD.PassengerId = P.Id
JOIN 
    Airports AS A ON FD.AirportId = A.Id
WHERE 
    DAY(FD.[Start]) % 2 = 0
ORDER BY 
    FD.TicketPrice DESC,
    A.AirportName