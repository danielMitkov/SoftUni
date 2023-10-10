CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS 
BEGIN
    RETURN
    (
        SELECT 
            COUNT(V.Id)
        FROM 
            VolunteersDepartments AS VD
        LEFT JOIN 
            Volunteers AS V ON V.DepartmentId = VD.Id
        WHERE 
            VD.DepartmentName = @VolunteersDepartment
    )
END