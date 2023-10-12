DECLARE @mechanicId INT = (SELECT MechanicId FROM Mechanics WHERE FirstName + ' ' + LastName = 'Ryan Harnos')

UPDATE 
    Jobs
SET 
    MechanicId = @mechanicId,
    Status = 'In Progress'
WHERE 
    Status = 'Pending'