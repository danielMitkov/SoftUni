CREATE VIEW v_UserWithCountries
AS
SELECT 
    CONCAT_WS(' ', C.FirstName, C.LastName) AS CustomerName,
    Age,
    Gender,
    CO.[Name] AS CountryName
FROM 
    Customers AS C
JOIN 
    Countries AS CO ON C.CountryId = CO.Id