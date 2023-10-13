CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @chosenRoomInfo TABLE (Id INT, [Type] NVARCHAR(20), Beds INT, TotalPrice DECIMAL (12, 2))

    INSERT INTO @chosenRoomInfo (Id, [Type], Beds, TotalPrice)
    SELECT TOP (1)
        R.Id,
        R.[Type],
        R.Beds,
        (H.BaseRate + R.Price) * @People AS TotalPrice
    FROM 
        Hotels AS H
    JOIN 
        Rooms AS R ON R.HotelId = H.Id
    JOIN 
        Trips AS T ON R.Id = T.RoomId
    WHERE 
        H.Id = @HotelId
    AND 
        R.Beds >= @People
    AND 
        R.Id NOT IN
    (-- write this condition exactly like the task description
        SELECT 
            RoomId 
        FROM 
            Trips
        WHERE 
            @Date BETWEEN ArrivalDate AND ReturnDate 
        AND 
            CancelDate IS NULL
    )
    ORDER BY 
        TotalPrice DESC

    IF EXISTS (SELECT 1 FROM @chosenRoomInfo)
    BEGIN
        DECLARE @Id INT = (SELECT Id FROM @chosenRoomInfo)
        DECLARE @Type NVARCHAR(20) = (SELECT [Type] FROM @chosenRoomInfo)
        DECLARE @Beds INT = (SELECT Beds FROM @chosenRoomInfo)
        DECLARE @TotalPrice DECIMAL (12, 2) = (SELECT TotalPrice FROM @chosenRoomInfo)
        
        RETURN CONCAT('Room ', @Id, ': ', @Type, ' (', @Beds, ' beds) - $', @TotalPrice)
    END
    RETURN 'No rooms available'
END