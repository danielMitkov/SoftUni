CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS 
BEGIN 
    BEGIN TRANSACTION

    INSERT INTO [EmployeesProjects] VALUES 
    (@emloyeeId, @projectID)

    DECLARE @projectCount INT = 
    (
        SELECT 
            COUNT(*) 
        FROM 
            [EmployeesProjects]
        WHERE 
            [EmployeeID] = @emloyeeId
    )
    IF (@projectCount > 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
    END
    COMMIT
END