CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(FD.Id)
        FROM 
            Passengers AS P
        JOIN 
            FlightDestinations AS FD ON P.Id = FD.PassengerId
        WHERE 
            P.Email = @email
    )
END