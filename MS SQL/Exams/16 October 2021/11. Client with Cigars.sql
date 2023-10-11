CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(CC.CigarId)
        FROM 
            Clients AS C
        JOIN 
            ClientsCigars AS CC ON CC.ClientId = C.Id
        WHERE 
            C.FirstName = @name
    )
END