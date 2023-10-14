CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(TC.ColonistId)
        FROM 
            Planets AS P
        LEFT JOIN 
            Spaceports AS S ON P.Id = S.PlanetId
        LEFT JOIN 
            Journeys AS J ON J.DestinationSpaceportId = S.Id
        LEFT JOIN 
            TravelCards AS TC ON TC.JourneyId = J.Id
        WHERE 
            P.[Name] = @PlanetName
    )
END