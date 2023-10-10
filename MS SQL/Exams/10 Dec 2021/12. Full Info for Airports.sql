CREATE PROC usp_SearchByAirportName (@airportName VARCHAR(70))
AS
SELECT 
    AP.AirportName,
    P.FullName,
    CASE 
        WHEN FD.TicketPrice <= 400 THEN 'Low'
        WHEN FD.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
        WHEN FD.TicketPrice > 1501 THEN 'High'
    END AS LevelOfTickerPrice,
    AC.Manufacturer,
    AC.Condition,
    ATY.TypeName
FROM
    Airports AS AP
JOIN 
    FlightDestinations AS FD ON AP.Id = FD.AirportId
JOIN 
    Passengers AS P ON FD.PassengerId = P.Id
JOIN 
    Aircraft AS AC ON FD.AircraftId = AC.Id
JOIN 
    AircraftTypes AS ATY ON AC.TypeId = ATY.Id
WHERE 
    AP.AirportName = @airportName
ORDER BY 
    AC.Manufacturer,
    P.FullName