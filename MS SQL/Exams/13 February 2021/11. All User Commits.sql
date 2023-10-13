CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(*)
        FROM
            Commits AS C
        JOIN 
            Users AS U ON U.Id = C.ContributorId
        WHERE 
            U.Username = @username
    )
END