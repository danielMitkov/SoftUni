CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            SUM(B.ChildrenCount + B.AdultsCount)
        FROM 
            Bookings AS B
        JOIN 
            Rooms AS R ON R.Id = B.RoomId
        JOIN 
            Tourists AS T ON T.Id = B.TouristId
        WHERE 
            R.Type = @name
    )
END
