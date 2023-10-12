CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
BEGIN
    DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
    
    DECLARE @ReportCategoryDepartmentId INT = 
    (
        SELECT 
            C.DepartmentId
        FROM 
            Reports AS R
        JOIN 
            Categories AS C ON C.Id = R.CategoryId
        WHERE 
            R.Id = @ReportId
    )
    IF(@EmployeeDepartmentId = @ReportCategoryDepartmentId)
    BEGIN
        UPDATE 
            Reports
        SET 
            EmployeeId = @EmployeeId
        WHERE 
            Id = @ReportId
    END
    ELSE 
        RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
END