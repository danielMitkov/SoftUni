CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
    IF (@JourneyId NOT IN (SELECT Id FROM Journeys))
    BEGIN
        RAISERROR('The journey does not exist!', 16, 1)
        RETURN
    END

    IF (@NewPurpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId))
    BEGIN
        RAISERROR('You cannot change the purpose!', 16, 1)
        RETURN
    END

    UPDATE 
        Journeys
    SET 
        Purpose = @NewPurpose
    WHERE 
        Id = @JourneyId
END