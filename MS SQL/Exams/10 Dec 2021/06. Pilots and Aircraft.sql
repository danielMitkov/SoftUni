SELECT 
    P.FirstName,
    P.LastName,
    A.Manufacturer,
    A.Model,
    A.FlightHours
FROM 
    Pilots AS P
JOIN 
    PilotsAircraft AS PA ON P.Id = PA.PilotId
JOIN 
    Aircraft AS A ON PA.AircraftId = A.Id
WHERE 
    A.FlightHours <= 304
ORDER BY 
    A.FlightHours DESC,
    P.FirstName