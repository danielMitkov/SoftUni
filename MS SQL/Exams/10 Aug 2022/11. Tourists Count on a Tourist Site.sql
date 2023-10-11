CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
    RETURN
    (
        SELECT 
            COUNT(ST.TouristId)
        FROM 
            Sites AS S
        JOIN 
            SitesTourists AS ST ON S.Id = ST.SiteId
        WHERE 
            S.[Name] = @Site
    )
END