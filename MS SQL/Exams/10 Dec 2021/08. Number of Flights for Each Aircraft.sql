SELECT 
    A.Id AS AircraftId,
    A.Manufacturer,
    A.FlightHours,
    COUNT(FD.Id) AS FlightDestinationsCount,
    ROUND(AVG(FD.TicketPrice), 2) AS AvgPrice
FROM 
    Aircraft AS A
JOIN 
    FlightDestinations AS FD ON A.Id = FD.AircraftId
GROUP BY 
    A.Id,
    A.Manufacturer,
    A.FlightHours
HAVING 
    COUNT(FD.Id) >= 2
ORDER BY 
    FlightDestinationsCount DESC,
    AircraftId