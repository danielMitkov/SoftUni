CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
    DECLARE @tripHotelId INT = 
    (
        SELECT 
            R.HotelId
        FROM 
            Trips AS T
        JOIN 
            Rooms AS R ON T.RoomId = R.Id
        WHERE 
            T.Id = @TripId
    )
    DECLARE @targetRoomHotelId INT = 
    (
        SELECT 
            HotelId
        FROM 
            Rooms
        WHERE 
            Id = @TargetRoomId
    )
    IF (@tripHotelId != @targetRoomHotelId)
    BEGIN 
        RAISERROR('Target room is in another hotel!', 16, 1)
        RETURN
    END

    DECLARE @targerRoomBedsCount INT = 
    (
        SELECT 
            Beds
        FROM 
            Rooms
        WHERE 
            Id = @TargetRoomId
    )
    DECLARE @tripAccountsCount INT = 
    (
        SELECT 
            COUNT(*)
        FROM 
            AccountsTrips
        WHERE 
            TripId = @TripId
    )
    IF (@targerRoomBedsCount < @tripAccountsCount)
    BEGIN
        RAISERROR('Not enough beds in target room!', 16, 1)
        RETURN
    END

    UPDATE 
        Trips
    SET 
        RoomId = @TargetRoomId
    WHERE 
        Id = @TripId
END