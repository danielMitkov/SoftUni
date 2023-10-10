SELECT 
    AP.AirportName,
    FD.[Start] AS DayTime,
    FD.TicketPrice,
    P.FullName,
    AC.Manufacturer,
    AC.Model
FROM 
    FlightDestinations AS FD
JOIN 
    Airports AS AP ON FD.AirportId = AP.Id
JOIN 
    Passengers AS P ON FD.PassengerId = P.Id
JOIN 
    Aircraft AS AC ON FD.AircraftId = AC.Id
WHERE 
    FD.TicketPrice > 2500
AND
    DATEPART(HOUR, FD.[Start]) BETWEEN 6 AND 20
ORDER BY 
    AC.Model